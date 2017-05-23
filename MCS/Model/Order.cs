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

        public Order(long compSeq, long orderSeq, String orderId)
        {
            this.CompSeq = compSeq;
            this.OrderSeq = orderSeq;
            this.OrderId = orderId;
        }

        [DataMember(Name = "compSeq")]
        public long CompSeq { get; set; }

        [DataMember(Name = "orderSeq")]
        public long OrderSeq { get; set; }

        [DataMember(Name = "orderId")]
        public string OrderId { get; set; }
    }
}
