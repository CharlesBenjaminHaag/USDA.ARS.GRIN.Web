using System;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using USDA.ARS.GRIN.Common.Library.Email;
using USDA.ARS.GRIN.Common.Library.Exceptions;
using USDA.ARS.GRIN.Common.Library.Security;
using USDA.ARS.GRIN.Web.DataLayer;

namespace USDA.ARS.GRIN.Web.ViewModelLayer
{

    public class SysUserViewModel : SysUserViewModelBase
    {
        public SysUser Get(string userName)
        {
            //TODO
            return Entity;
        }

        public SysUser Get(int entityId)
        {
            using (SysUserManager mgr = new SysUserManager())
            {
                Entity = mgr.Get(entityId);
            }
            return Entity;
        }

        public void GetGroups(int sysUserId)
        {
            using (SysUserManager mgr = new SysUserManager())
            {
                try
                {
                    DataCollectionGroups = new Collection<SysGroupUserMap>(mgr.SelectGroups(sysUserId));
                    RowsAffected = mgr.RowsAffected;
                }
                catch (Exception ex)
                {
                    PublishException(ex);
                    throw ex;
                }
            }
        }

        public int Search()
        {
            using (SysUserManager mgr = new SysUserManager())
            {
                try
                {
                    DataCollection = new Collection<SysUser>(mgr.Search(SearchEntity));
                    RowsAffected = mgr.RowsAffected;
                    if (RowsAffected == 1)
                    {
                        Entity = DataCollection[0];
                    }
                }
                catch (Exception ex)
                {
                    PublishException(ex);
                    throw ex;
                }
                return mgr.RowsAffected;
            }
        }

        public int Insert()
        {
            using (SysUserManager mgr = new SysUserManager())
            {
                try
                {
                    Entity.Password = GetSecurePassword(Entity.Password);
                    Entity.ID = mgr.Insert(Entity);
                }
                catch (Exception ex)
                {
                    PublishException(ex);
                    throw ex;
                }
                return Entity.ID;
            }
        }

        public void Update()
        {
            try
            {
                using (SysUserManager mgr = new SysUserManager())
                {
                    Entity.SysUserPlainTextPassword = Entity.Password;
                    Entity.Password = GetSecurePassword(Entity.Password);
                    mgr.UpdatePassword(Entity);
                }
            }
            catch (Exception ex)
            {
                PublishException(ex);
                throw ex;
            }
        }

        public bool Authenticate()
        {
            string storedPassword = String.Empty;
            string hashedPassword = String.Empty;
            bool passwordIsValid = false;

            SearchEntity.UserName = Entity.UserName;
            SearchEntity.Password = Entity.Password;

            if (String.IsNullOrEmpty(SearchEntity.UserName))
            {
                Entity.IsAuthenticated = false;
                UserMessage = "Please enter your GRIN-Global user name.";
                return false;
            }

            if (SearchEntity.UserName.Length > 50)
            {
                Entity.IsAuthenticated = false;
                UserMessage = "The user name that you have entered does not exist.";
                return false;
            }

            Search();

            if (RowsAffected == 0)
            {
                Entity.IsAuthenticated = false;
                UserMessage = "The user name that you have entered does not exist.";
                return false;
            }
            else
            {
                Entity = DataCollection[0];

                // Check password using standard GG framework Crypto.cs logic.
                storedPassword = Entity.SysUserPassword;
                hashedPassword = Crypto.HashText(SearchEntity.Password);
                passwordIsValid = (validateHashedPassword(SearchEntity.Password, storedPassword) ||
                    validateHashedPassword(hashedPassword, storedPassword));

                if (passwordIsValid)
                {
                    Entity.IsAuthenticated = true;
                }
                else
                {
                    Entity.IsAuthenticated = false;
                    UserMessage = "Your password is incorrect.";
                    return false;
                }

                // Check groups.
                GetGroups(Entity.ID);
                Entity.Groups = DataCollectionGroups.ToList();
                //if (DataCollectionGroups.Count == 0)
                //{
                //    Entity.IsAuthenticated = false;
                //    UserMessage = "You must be a member of at least one group.";
                //}

                //if (DataCollectionGroups.ToList().Where(x => x.GroupTag == "GGTOOLS_COOPERATOR").Count() > 0)
                //{
                //    Entity.IsSuperCooperator = "Y";
                //}
                //else
                //{
                //    Entity.IsSuperCooperator = "N";
                //}

                //if (DataCollectionGroups.ToList().Where(x => x.GroupTag == "GGTOOLS_ADMIN").Count() > 0)
                //{
                //    Entity.IsSysAdmin = "Y";
                //}
                //else
                //{
                //    Entity.IsSysAdmin = "N";
                //}

                //if (DataCollectionGroups.ToList().Where(x => x.GroupTag == "MANAGE_COOPERATOR").Count() > 0)
                //{
                //    Entity.IsSuperCooperator = "Y";
                //}
                //else
                //{
                //    Entity.IsSuperCooperator = "N";
                //}

                //if (DataCollectionGroups.ToList().Where(x => x.GroupTag == "MANAGE_SITE_" + Entity.SiteShortName).Count() > 0)
                //{
                //    Entity.IsSiteAdmin = "Y";
                //}
                //else
                //{
                //    Entity.IsSiteAdmin = "N";
                //}
                return true;
            }
        }

        /// <summary>
        /// Generates and saves token and sends user email
        /// </summary>
        /// <returns></returns>

        //public void GeneratePasswordResetToken(string userName)
        //{
        //    string passwordResetUrl = String.Empty;
        //    SMTPManager sMTPManager = new SMTPManager();
        //    SMTPMailMessage sMTPMailMessage = new SMTPMailMessage();

        //    try
        //    {
        //        SearchEntity.UserName = userName;
        //        Search();
        //        if (RowsAffected > 0)
        //        {
        //            PasswordResetToken = Crypto.GeneratePasswordResetToken("");
        //            var url = new UrlHelper(System.Web.HttpContext.Current.Request.RequestContext);
        //            var fullUrl = url.Action("ResetPassword", "Login", new { token = PasswordResetToken }, protocol: System.Web.HttpContext.Current.Request.Url.Scheme);

        //            AddPasswordResetToken(Entity.SysUserID, PasswordResetToken);

        //            // Generate and send reset-password email
        //            sMTPMailMessage.To = Entity.EmailAddress;
        //            sMTPMailMessage.Subject = "Your GRIN-Global Password-Reset Link";
        //            sMTPMailMessage.Body = "<p>You are receiving this email because you recently requested a reset of your GRIN-Global Curator Tool (CT) password.</p>";
        //            sMTPMailMessage.Body += "<p>Your email reset link is:<br/> ";
        //            sMTPMailMessage.Body += "<a href='" + fullUrl + "'>" + fullUrl + "</a></p>";
        //            sMTPMailMessage.Body += "<p><strong>This link will expire after 24 hours.</strong> Please reset your password as soon as possible.</p>";
        //            sMTPMailMessage.IsHtml = true;
        //            sMTPManager.SendMessage(sMTPMailMessage);
        //        }
        //        else
        //        {
        //            UserMessage = "The user name that you have entered does not exist.";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        PublishException(ex);
        //        throw ex;
        //    }
        //}

        //public int AddPasswordResetToken(int sysUserId, string token)
        //{
        //    using (SysUserManager mgr = new SysUserManager())
        //    {
        //        return mgr.InsertSysUserPasswordResetToken(sysUserId, token);
        //    }
        //}

        //public SysUser ValidatePasswordResetToken(string token)
        //{
        //    using (SysUserManager mgr = new SysUserManager())
        //    {
        //        return mgr.ValidateSysUserPasswordResetToken(token);
        //    }
        //}

        //public void UpdatePassword()
        //{
        //    SysUser sysUser = new SysUser();

        //    try
        //    {
        //        using (SysUserManager mgr = new SysUserManager())
        //        {
        //            // Get sys user ID based on token; store in separate Sys User instance.
        //            if (!String.IsNullOrEmpty(PasswordResetToken))
        //            {
        //                sysUser = ValidatePasswordResetToken(PasswordResetToken);
        //            }

        //            Entity.ID = sysUser.ID;
        //            Entity.SysUserID = sysUser.SysUserID;
        //            // Store the user-entered password as plain text.
        //            Entity.SysUserPlainTextPassword = Entity.Password;
        //            // Generate the encoded password.
        //            Entity.Password = GetSecurePassword(Entity.Password);
        //            mgr.UpdatePassword(Entity);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        PublishException(ex);
        //        throw ex;
        //    }
        //}

        public string GetSecurePassword(string password)
        { 
            password = Crypto.HashText(password);
            password = SaltAndHash(password);
            return password;
        }

        public override bool Validate()
        {
            if (String.IsNullOrEmpty(Entity.UserName) && String.IsNullOrEmpty(Entity.SysUserName))
            {
                UserMessage = "Please enter your user name.";
                ValidationMessages.Add(new Common.Library.ValidationMessage { Message = UserMessage });
                return false;
            }
                
            if (Entity.Password != Entity.PasswordConfirm)
            {
                UserMessage = "The passwords that you have entered do not match.";
                ValidationMessages.Add(new Common.Library.ValidationMessage { Message = UserMessage });
                return false;
            }

            if (Entity.Password.Length < 12)
            {
                UserMessage = "Your password must be at least 12 characters.";
                ValidationMessages.Add(new Common.Library.ValidationMessage { Message = UserMessage });
                return false;
            }

            if (Entity.Password.Length >255)
            {
                UserMessage = "Your password must be no longer than 255 characters.";
                ValidationMessages.Add(new Common.Library.ValidationMessage { Message = UserMessage });
                return false;
            }

            string passReqPatt1 =  @"\p{Nd}";
            int passReqCnt1 = 1;
            if (passReqCnt1 > 0 && Regex.Matches(Entity.Password, passReqPatt1).Count < passReqCnt1)
            {
                UserMessage = "Your password must contain at least one digit.";
                ValidationMessages.Add(new Common.Library.ValidationMessage { Message = UserMessage });
                return false;
            }

            string passReqPatt2 = @"\p{Ll}";
            int passReqCnt2 = 1;
            if (passReqCnt2 > 0 && Regex.Matches(Entity.Password, passReqPatt2).Count < passReqCnt1)
            {
                UserMessage = "Your password must contain at least one lowercase letter.";
                ValidationMessages.Add(new Common.Library.ValidationMessage { Message = UserMessage });
                return false;
            }

            string passReqPatt3 = @"\p{Lu}";
            int passReqCnt3 = 1;
            if (passReqCnt3 > 0 && Regex.Matches(Entity.Password, passReqPatt3).Count < passReqCnt1)
            {
                UserMessage = "Your password must contain at least one uppercase letter.";
                ValidationMessages.Add(new Common.Library.ValidationMessage { Message = UserMessage });
                return false;
            }

            string passReqPatt4 = @"[\p{S}\p{P}\p{Z}\p{C}]";
            int passReqCnt4 = 1;
            if (passReqCnt4 > 0 && Regex.Matches(Entity.Password, passReqPatt4).Count < passReqCnt1)
            {
                UserMessage = "Your password must contain at least one special character.";
                ValidationMessages.Add(new Common.Library.ValidationMessage { Message = UserMessage });
                return false;
            }
            return true;
        }

        private static string SaltAndHash(string password)
        {
            int saltSize = 6;
            string salt = Crypto.SaltText(saltSize);
            string hash = Crypto.HashTextSHA256(salt + password);
            return salt + "$" + hash;
        }

        public void SendNotification(string notificationType)
        {
            SMTPManager sMTPManager = new SMTPManager();
            SMTPMailMessage infoRequestEmailMessage = new SMTPMailMessage();
            infoRequestEmailMessage.From = "gringlobal-support@usda.gov";
            infoRequestEmailMessage.To = Entity.EmailAddress;

            if (notificationType == "N")
            {
                infoRequestEmailMessage.CC = "marty.reisinger@usda.gov";
            }

            switch(notificationType)
            { 
                case "N":
                    infoRequestEmailMessage.Subject = "Your GRIN-Global CT Account Has Been Created";
                    break;
                case "P":
                    infoRequestEmailMessage.Subject = "Your GRIN-Global CT Account Password Has Been Reset";
                    break;
            }

            infoRequestEmailMessage.Body += "<table>";
            infoRequestEmailMessage.Body += "<tr>";
            infoRequestEmailMessage.Body += "<td><strong>Environment</strong></td><td>PRODUCTION</td>";
            infoRequestEmailMessage.Body += "</tr>";
            infoRequestEmailMessage.Body += "<tr>";
            infoRequestEmailMessage.Body += "<td><strong>Username</strong></td><td>" + Entity.SysUserName + "</td>";
            infoRequestEmailMessage.Body += "</tr>";
            infoRequestEmailMessage.Body += "<tr>";
            infoRequestEmailMessage.Body += "<td><strong>New Password</strong></td><td>" + Entity.SysUserPlainTextPassword + "</td>";
            infoRequestEmailMessage.Body += "</tr>";
            infoRequestEmailMessage.Body += "<tr>";
            infoRequestEmailMessage.Body += "<td><strong>Expires</strong></td><td>" + Entity.SysUserPasswordExpirationDate.ToShortDateString() + "</td>";
            infoRequestEmailMessage.Body += "</tr>";
            infoRequestEmailMessage.Body += "</table>";

            if (notificationType == "N")
            {
                infoRequestEmailMessage.Body += "<p>";
                infoRequestEmailMessage.Body += "For guidance in the installation of the Curator Tool, please refer to: <br/>";
                infoRequestEmailMessage.Body += "<a href='https://www.grin-global.org/download_ct.html'>GRIN-Global Curator Installation</a>";
                infoRequestEmailMessage.Body += "</p>";
            }

            infoRequestEmailMessage.IsHtml = true;
            sMTPManager.SendMessage(infoRequestEmailMessage);
        }
        public bool IsAlphaNumeric(string input)
        {
            // Remove "." and "@" characters before comparison -- both are common in user 
            // names.
            input = input.Replace('.', 'X').Replace('@', 'X');

            string pattern = @"^[a-zA-Z0-9]*$";
            if (Regex.IsMatch(input, pattern))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}

