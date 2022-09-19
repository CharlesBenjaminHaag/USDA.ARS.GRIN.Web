using System;
using System.Collections.ObjectModel;
using USDA.ARS.GRIN.Common.Library.Security;
using USDA.ARS.GRIN.Web.AppLayer;
using USDA.ARS.GRIN.Web.DataLayer;

namespace USDA.ARS.GRIN.Web.ViewModelLayer
{
    public class SysUserViewModelBase: AuthenticatedViewModelBase 
    {
        public SysUserViewModelBase() {}

        private string _DisplayUserName;
        private string _PasswordResetToken;
        private SysUser _Entity = new SysUser();
        private SysUserSearch _SearchEntity = new SysUserSearch();
        private Collection<SysUser> _DataCollection = new Collection<SysUser>();
        private Collection<SysGroupUserMap> _DataCollectionGroups = new Collection<SysGroupUserMap>();
       

        public string IsReadOnly
        {
            get
            {
                if ((AuthenticatedUser.IsInRole("GGTOOLS_COOPERATOR")) ||
                    (AuthenticatedUser.IsInRole("MANAGE_COOPERATOR")) ||
                    (AuthenticatedUser.IsInRole("GGTOOLS_ADMIN")) ||
                    (AuthenticatedUser.SysUserID == Entity.ID)
                    )
                {
                    return "N";
                }
                else
                {
                    return "Y";
                }
            }
        }

        public string DisplayUserName
        {
            get { return _DisplayUserName; }
            set { _DisplayUserName = value; }
        }

        public string PasswordResetToken 
        {
            get { return _PasswordResetToken; }
            set { _PasswordResetToken = value; }
        }

        public SysUser Entity
        {
            get { return _Entity; }
            set { _Entity = value; }
        }

        public SysUserSearch SearchEntity
        {
            get { return _SearchEntity; }
            set { _SearchEntity = value; }
        }

        public Collection<SysUser> DataCollection
        {
            get { return _DataCollection; }
            set { _DataCollection = value; }
        }
        public Collection<SysGroupUserMap> DataCollectionGroups
        {
            get { return _DataCollectionGroups; }
            set { _DataCollectionGroups = value; }
        }

        protected bool validateHashedPassword(string password, string storedSaltHash)
        {
            string crypt;
            string salt;
            string storedHash;

            // parse the stored password field for hash type, salt, and hashed password
            string[] hashes = storedSaltHash.Split(':');
            string[] passField = hashes[0].Split('$');
            if (passField.Length == 1)
            {
                // original format of SHA1 hash with no salt
                crypt = "SHA1";
                salt = "";
                storedHash = passField[0];
            }
            else if (passField.Length == 2)
            {
                // two fields means salt and hash
                crypt = "SHA256";
                salt = passField[0];
                storedHash = passField[1];
            }
            else if (passField.Length == 3)
            {
                // with three fields the first is the hash type
                crypt = passField[0];
                salt = passField[1];
                storedHash = passField[2];
            }
            else
            {
                // can't figure out what is stored in the hash field
                return false;
            }

            string hashedPassword;
            if (crypt == "SHA1")
            {
                hashedPassword = Crypto.HashText(salt + password);
            }
            else if (crypt == "SHA256")
            {
                hashedPassword = Crypto.HashTextSHA256(salt + password);
            }
            else
            {
                // don't understand the hash type
                return false;
            }

            // Finally we test whether it is a match
            if (hashedPassword == storedHash) return true;

            return false;
        }
    }
}
