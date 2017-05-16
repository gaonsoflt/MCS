using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace MCS.Model
{
    [DataContract]
    public class UserModel
    {
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

    }
}
