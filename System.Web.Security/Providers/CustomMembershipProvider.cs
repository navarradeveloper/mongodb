using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using Blog.Entities.Entities;
using MongoDB.Bson;

namespace Blog.Web.Security
{
    public class CustomMembershipProvider : WebMatrix.WebData.ExtendedMembershipProvider
    {
        private IUserBBDD _userService;

        public CustomMembershipProvider() {
            _userService = new UserBBDD(new Blog.DA.DAContext(ConfigurationManager.ConnectionStrings["MongoDB"].ConnectionString)); ;
        }

        /// <summary>
        /// Create a User in MogoDB 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="email"></param>
        /// <param name="passwordQuestion"></param>
        /// <param name="passwordAnswer"></param>
        /// <param name="isApproved"></param>
        /// <param name="providerUserKey"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer,
            bool isApproved, object providerUserKey, out MembershipCreateStatus status) {
            ValidatePasswordEventArgs args = new ValidatePasswordEventArgs(username, password, true);
            OnValidatingPassword(args);

            if (args.Cancel) {
                status = MembershipCreateStatus.InvalidPassword;
                return null;
            }

            if (RequiresUniqueEmail && GetUserNameByEmail(email) != string.Empty) {
                status = MembershipCreateStatus.DuplicateEmail;
                return null;
            }

            MembershipUser user = GetUser(username, true);

            if (user == null) {
                User userObj = new User();
                userObj.UserId = ObjectId.GenerateNewId();
                userObj.Name = username;
                userObj.NameNormalize = username.ToUrl();
                userObj.Password = GetMD5Hash(password);
                userObj.Email = email.ToLower();

                _userService.RegisterUser(userObj);

                status = MembershipCreateStatus.Success;

                return GetUser(username, true);
            } else {
                status = MembershipCreateStatus.DuplicateUserName;
            }

            return null;
        }

        /// <summary>
        /// Gets a MemberShip user is exists en DDBB
        /// </summary>
        /// <param name="username"></param>
        /// <param name="userIsOnline"></param>
        /// <returns></returns>
        public override MembershipUser GetUser(string username, bool userIsOnline) {
            User user = _userService.GetUser(username);
            if (user != null) {
                MembershipUser memUser = new MembershipUser("CustomMembershipProvider",
                                               username, user.UserId, user.Email,
                                               string.Empty, string.Empty,
                                               true, false, DateTime.MinValue,
                                               DateTime.MinValue,
                                               DateTime.MinValue,
                                               DateTime.Now, DateTime.Now);
                return memUser;
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="providerUserKey"></param>
        /// <param name="userIsOnline"></param>
        /// <returns></returns>
        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline) {
            User user = _userService.GetUser(new ObjectId(providerUserKey.ToString()));
            if (user != null) {
                MembershipUser memUser = new MembershipUser("CustomMembershipProvider",
                                               user.Name, user.UserId, user.Email,
                                               string.Empty, string.Empty,
                                               true, false, DateTime.MinValue,
                                               DateTime.MinValue,
                                               DateTime.MinValue,
                                               DateTime.Now, DateTime.Now);
                return memUser;
            }
            return null;
        }

        public override bool ValidateUser(string username, string password) {
            string md5Pswd = GetMD5Hash(password);
            User user = _userService.GetUserByNameAndPassword(username, md5Pswd);
            if (user != null) return true;
            return false;
        }

        public static string GetMD5Hash(string value) {
            MD5 md5Hasher = MD5.Create();
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(value));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++) {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }


        public override bool RequiresUniqueEmail {
            get { return true; }
        }
        public override string GetUserNameByEmail(string email) {
            User user = _userService.GetUserByEmail(email);
            if (user != null) {
                return user.Email;
            }
            return String.Empty;
        }






































        public override int GetUserIdFromPasswordResetToken(string token) {
            throw new NotImplementedException();
        }



        public override bool ConfirmAccount(string accountConfirmationToken) {
            throw new NotImplementedException();
        }

        public override bool ConfirmAccount(string userName, string accountConfirmationToken) {
            throw new NotImplementedException();
        }

        public override string CreateAccount(string userName, string password, bool requireConfirmationToken) {
            throw new NotImplementedException();
        }

        public override string CreateUserAndAccount(string userName, string password, bool requireConfirmation, IDictionary<string, object> values) {
            throw new NotImplementedException();
        }

        public override bool DeleteAccount(string userName) {
            throw new NotImplementedException();
        }

        public override string GeneratePasswordResetToken(string userName, int tokenExpirationInMinutesFromNow) {
            throw new NotImplementedException();
        }

        public override ICollection<WebMatrix.WebData.OAuthAccountData> GetAccountsForUser(string userName) {
            throw new NotImplementedException();
        }

        public override DateTime GetCreateDate(string userName) {
            throw new NotImplementedException();
        }

        public override DateTime GetLastPasswordFailureDate(string userName) {
            throw new NotImplementedException();
        }

        public override DateTime GetPasswordChangedDate(string userName) {
            throw new NotImplementedException();
        }

        public override int GetPasswordFailuresSinceLastSuccess(string userName) {
            throw new NotImplementedException();
        }



        public override bool IsConfirmed(string userName) {
            throw new NotImplementedException();
        }

        public override bool ResetPasswordWithToken(string token, string newPassword) {
            throw new NotImplementedException();
        }

        public override string ApplicationName {
            get {
                throw new NotImplementedException();
            }
            set {
                throw new NotImplementedException();
            }
        }

        public override bool ChangePassword(string username, string oldPassword, string newPassword) {
            throw new NotImplementedException();
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer) {
            throw new NotImplementedException();
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData) {
            throw new NotImplementedException();
        }

        public override bool EnablePasswordReset {
            get { throw new NotImplementedException(); }
        }

        public override bool EnablePasswordRetrieval {
            get { throw new NotImplementedException(); }
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords) {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords) {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords) {
            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline() {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer) {
            throw new NotImplementedException();
        }

        public override int MaxInvalidPasswordAttempts {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredNonAlphanumericCharacters {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredPasswordLength {
            get { throw new NotImplementedException(); }
        }

        public override int PasswordAttemptWindow {
            get { throw new NotImplementedException(); }
        }

        public override MembershipPasswordFormat PasswordFormat {
            get { throw new NotImplementedException(); }
        }

        public override string PasswordStrengthRegularExpression {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresQuestionAndAnswer {
            get { return false; }
        }



        public override string ResetPassword(string username, string answer) {
            throw new NotImplementedException();
        }

        public override bool UnlockUser(string userName) {
            throw new NotImplementedException();
        }

        public override void UpdateUser(MembershipUser user) {
            throw new NotImplementedException();
        }


    }
}
