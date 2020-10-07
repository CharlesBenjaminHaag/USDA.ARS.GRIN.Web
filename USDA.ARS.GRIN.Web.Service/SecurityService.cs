using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using USDA.ARS.GRIN.Web.Models;
using USDA.ARS.GRIN.Web.Repository;
using GrinGlobal.Core;

namespace USDA.ARS.GRIN.Web.Service
{
    public class SecurityService
    {
        public ResultContainer Login(string userName, string password, out GRINUser user)
        {
            string hashedPassword = String.Empty;
            ResultContainer resultContainer = new ResultContainer();
            bool passwordIsValid = false;
            UserRepository _repository = new UserRepository();

            user = new GRINUser();

            try
            {

                user = _repository.Find(userName);
                if (user.ID == 0)
                {
                    resultContainer.ResultCode = LoginResult.USER_NOT_FOUND.ToString();
                    return resultContainer;
                }

                hashedPassword = Crypto.HashText(password);
                passwordIsValid = (validateHashedPassword(password, user.Password) || validateHashedPassword(hashedPassword, user.Password));

                if (passwordIsValid)
                    resultContainer.ResultCode = LoginResult.SUCCESS.ToString();
                else
                {
                    resultContainer.ResultCode = LoginResult.INVALID_PASSWORD.ToString();
                    return resultContainer;
                }
            }
            catch (Exception aex)
            {
                resultContainer.ResultCode = aex.Message;
                resultContainer.ResultDescription = aex.StackTrace;
            }
            return resultContainer;
        }

        private bool validateHashedPassword(string password, string storedSaltHash)
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

    public enum LoginResult
    {
        SUCCESS,
        USER_NOT_FOUND,
        INVALID_PASSWORD
    }
}

