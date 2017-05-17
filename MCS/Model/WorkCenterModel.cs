using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace MCS.Model
{
    [DataContract]
    public class WorkCenterModel
    {
        public WorkCenterModel()
        {
        }

        [DataMember(Name = "compSeq")]
        public long CompSeq { get; set; }

        [DataMember(Name = "wcSeq")]
        public long WcSeq { get; set; }

        [DataMember(Name = "wcName")]
        public string WcName { get; set; }

        [DataMember(Name = "workDeptSeq")]
        public long WorkDeptSeq { get; set; }

        [DataMember(Name = "wcType")]
        public long WcType { get; set; }

        [DataMember(Name = "capaType")]
        public long CapaType { get; set; }

        [DataMember(Name = "capaRate")]
        public double? CapaRate { get; set; }
    }
}
