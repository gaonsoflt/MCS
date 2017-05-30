using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using MCS.Utils;

namespace MCS.Model
{
    [DataContract]
    public class WorkHistory
    {
        public WorkHistory()
        {
        }

        public WorkHistory(long compSeq, String workOrderNo, String toolId, String workerId, DateTime startDt)
        {
            this.CompSeq = compSeq;
            this.WorkOrderNo = workOrderNo;
            this.ToolId = toolId;
            this.WorkerId = workerId;
            this.StartDt = (BBConvert.CSharpMillisToJavaLong(startDt) * 1000);
        }

        [DataMember(Name = "compSeq")]
        public long CompSeq { get; set; }

        [DataMember(Name = "workHisSeq")]
        public long WorkHisSeq { get; set; }

        [DataMember(Name = "workOrderNo")]
        public String WorkOrderNo { get; set; }

        [DataMember(Name = "toolId")]
        public String ToolId { get; set; }

        [DataMember(Name = "workerId")]
        public String WorkerId { get; set; }

        [DataMember(Name = "startDt")]
        public long StartDt { get; set; }
    }
}
