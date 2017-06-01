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
    public class ProdSummary
    {
        public ProdSummary()
        {
        }

        public ProdSummary(long compSeq, String toolId, long normalQty, long defectQty)
        {
            this.CompSeq = compSeq;
            this.ToolId = toolId;
            this.NormalQty = normalQty;
            this.DefectQty = defectQty;
        }

        [DataMember(Name = "compSeq")]
        public long CompSeq { get; set; }

        [DataMember(Name = "toolId")]
        public String ToolId { get; set; }

        [DataMember(Name = "normalQty")]
        public long NormalQty { get; set; }

        [DataMember(Name = "defectQty")]
        public long DefectQty { get; set; }
    }
}
