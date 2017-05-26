using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace MCS.Model
{
    [DataContract]
    public class Item
    {
        public Item()
        {
        }

        public Item(long compSeq, long itemSeq)
        {
            this.CompSeq = compSeq;
            this.ItemSeq = itemSeq;
        }

        [DataMember(Name = "compSeq")]
        public long CompSeq { get; set; }

        [DataMember(Name = "ItemSeq")]
        public long ItemSeq{ get; set; }

        [DataMember(Name = "itemName")]
        public String ItemName { get; set; }

        [DataMember(Name = "itemNo")]
        public String ItemNo { get; set; }

        [DataMember(Name = "spec")]
        public String Spec { get; set; }
    }
}
