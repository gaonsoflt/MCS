using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace MCS.Model
{
    [DataContract]
    public class CodeMinor
    {
        protected CodeMinor()
        {
        }

        [DataMember(Name = "compSeq")]
        public long CompSeq { get; set; }

        [DataMember(Name = "minorSeq")]
        public long MinorSeq { get; set; }

        [DataMember(Name = "majorSeq")]
        public long MajorSeq { get; set; }

        [DataMember(Name = "minorName")]
        public String MinorName { get; set; }

        [DataMember(Name = "useYn")]
        public long UseYn{ get; set; }

        [DataMember(Name = "delimiter")]
        public String Delimiter { get; set; }
    }
}
