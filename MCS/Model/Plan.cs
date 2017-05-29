using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace MCS.Model
{
    [DataContract]
    public class Plan
    {
        public Plan()
        {
        }

        public Plan(long compSeq, String prodPlanNo)
        {
            this.CompSeq = compSeq;
            this.ProdPlanNo = prodPlanNo;
        }

        [DataMember(Name = "compSeq")]
        public long CompSeq { get; set; }

        [DataMember(Name = "prodPlanNo")]
        public String ProdPlanNo { get; set; }

        [DataMember(Name = "prodPlanSeq")]
        public long ProdPlanSeq { get; set; }

        [DataMember(Name = "prodPlanDate")]
        public String ProdPlanDate { get; set; }

        [DataMember(Name = "prodPlanQty")]
        public long ProdPlanQty { get; set; }

        [DataMember(Name = "endDate")]
        public String EndDate { get; set; }

        [DataMember(Name = "planGBN")]
        public String PlanGBN { get; set; }

        [DataMember(Name = "orderSerl")]
        public long OrderSerl { get; set; }

        [DataMember(Name = "assetType")]
        public CodeMinor AssetType { get; set; }

        [DataMember(Name = "unit")]
        public CodeMinor Unit { get; set; }

        [DataMember(Name = "status")]
        public CodeMinor Status { get; set; }
    }
}
