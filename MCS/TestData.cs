using MCS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MCS
{
    public class TestData
    {
        //public static DataTable GetOrderData()
        //{
        //    DataTable table = new DataTable();
        //    table.Columns.Add("OrderID", typeof(string));
        //    table.Columns.Add("Status", typeof(string));
        //    table.Columns.Add("Equipment", typeof(string));
        //    table.Columns.Add("SequenceName", typeof(string));
        //    table.Columns.Add("Material", typeof(string));
        //    table.Columns.Add("MaterialQuantity", typeof(long));
        //    table.Columns.Add("Product", typeof(string));
        //    table.Columns.Add("Standard", typeof(string));
        //    table.Columns.Add("ProductQuantity", typeof(long));

        //    table.Rows.Add("지시서-20170001", "대기", "200톤-7호", "SEMI-PRO", "[DFM7210001-2/3]\nDIFFUSER(2 / 2TRA’F)", 5000, "[MAZ64844002-1/2]\nBRACKET - 01 1 / 2공정", "GI 1.2*155*C", 5000);
        //    table.Rows.Add("지시서-20170033", "완료", "200톤-8호", "세척/포장", "[08484-494]\nCONTACIT PALTE(15413 - 0)", 10000, "[DFM7210001]\nDIFFUSUER", "CH18380", 10000);
        //    table.Rows.Add("지시서-20170046", "진행중", "방청기", "BE", "[MCK569943-2/3]\nCOVER(2 / 3 BE공정)", 2000, "[MBN362395-08]\nC / PANNEL", "0.8*625*C", 4000);
        //    table.Rows.Add("지시서-20170044", "대기", "방청기", "BE", "[MCK569943-2/3]\nCOVER(2 / 3 BE공정)", 2000, "[MBN362395-08]\nC / PANNEL", "0.8*625*C", 4000);
        //    table.Rows.Add("지시서-20170045", "대기", "방청기", "BE", "[MCK569943-2/3]\nCOVER(2 / 3 BE공정)", 2000, "[MBN362395-08]\nC / PANNEL", "0.8*625*C", 4000);
        //    table.Rows.Add("지시서-20170047", "대기", "방청기", "BE", "[MCK569943-2/3]\nCOVER(2 / 3 BE공정)", 2000, "[MBN362395-08]\nC / PANNEL", "0.8*625*C", 4000);

        //    return table;
        //}

        public static Order GetOrderInfo()
        {
            Order order = new Order();
            order.OrderId = "작업지시서-201704020394";
            order.OrderQty = 1000;
            return order;
        }

        public static List<Order> GetOrderList()
        {
            List<Order> list = new List<Order>();
            list.Add(new Order(1, "지시서-20170001"));
            list.Add(new Order(1, "지시서-20170002"));
            list.Add(new Order(1, "지시서-20170003"));
            return list;
        }

        public static List<WorkCenter> GetWorkCenterList()
        {
            List<WorkCenter> list = new List<WorkCenter>();
            list.Add(new WorkCenter(0, 1, "작업장1"));
            list.Add(new WorkCenter(0, 2, "작업장2"));
            list.Add(new WorkCenter(0, 3, "작업장3"));
            return list;
        }
    }
}
