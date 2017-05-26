using MCS.Model;
using MCS.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MCS
{
    public class OrderListModel
    {
        public delegate void SetRestResponseHandler(object obj);
        public event SetRestResponseHandler OnResult;

        private HttpRestProxy rest;

        public OrderListModel()
        {
            rest = new HttpRestProxy();
        }

        public async void GetOrderList(long from, long to)
        {
            try
            {
                var order = await Task.Run(()
                    => rest.GetAsync<List<Order>>(String.Format("api/workorders/date?from={0}&to={1}", from.ToString(), to.ToString())));

                OnResult(order);
            }
            catch
            {
                OnResult(null);
            }
        }

        private TimeSpan CalcurateDiffDate(DateTime from, DateTime to)
        {
            return to - from;
        }

        public bool CheckSearchPeriodSize(DateTime from, DateTime to)
        {
            TimeSpan df = CalcurateDiffDate(from, to);
            if (df.Days < 0 || df.Days > 7)
            {
                return false;
            }
            return true;
        }
    }
}
