using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace MCS.Model
{
    [DataContract]
    public class User
    {
        public User()
        {
        }

        public User(string userId, string loginPwd)
        {
            this.UserId = userId;
            this.LoginPwd = loginPwd;
        }

        public User(string userId, string loginPwd, string userNm)
        {
            this.UserId = userId;
            this.LoginPwd = loginPwd;
            this.UserNm = userNm;
        }

        public User(string userId, string loginPwd, string userNm, string token)
        {
            this.UserId = userId;
            this.LoginPwd = loginPwd;
            this.UserNm = userNm;
            this.Token = token;
        }

        [DataMember(Name = "compSeq")]
        public long CompSeq { get; set; }

        [DataMember(Name = "userSeq")]
        public long UserSeq { get; set; }

        [DataMember(Name = "userId")]
        public string UserId { get; set; }

        [DataMember(Name = "loginPwd")]
        public string LoginPwd { get; set; }

        [DataMember(Name = "userNm")]
        public string UserNm { get; set; }

        [DataMember(Name = "userType")]
        public long UserType { get; set; }

        [DataMember(Name = "empSeq")]
        public long? EmpSeq { get; set; }

        [DataMember(Name = "token")]
        public string Token { get; set; }
    }
}
