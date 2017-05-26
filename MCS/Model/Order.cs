using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace MCS.Model
{
    [DataContract]
    public class Order
    {
        public Order()
        {
        }

        public Order(long compSeq, String orderId)
        {
            this.CompSeq = compSeq;
            this.OrderId = orderId;
        }


        [DataMember(Name = "compSeq")]
        public long CompSeq { get; set; }

        [DataMember(Name = "workOrderNo")]
        public String OrderId { get; set; }

        [DataMember(Name = "workOrderSerl")]
        public long WorkOrderSerl { get; set; }

        [DataMember(Name = "workOrderDate")]
        public String WorkOrderDate { get; set; }

        [DataMember(Name = "prodPlanNo")]
        public String ProdPlanNo { get; set; }

        [DataMember(Name = "goodItemSeq")]
        public long GoodItemSeq { get; set; }

        [DataMember(Name = "item")]
        public Item Item { get; set; }

        [DataMember(Name = "procSeq")]
        public long ProcSeq { get; set; }

        [DataMember(Name = "orderQty")]
        public long OrderQty { get; set; }

        [DataMember(Name = "workDate")]
        public String WorkDate { get; set; }

        [DataMember(Name = "empSeq")]
        public long EmpSeq { get; set; }
    }
}
