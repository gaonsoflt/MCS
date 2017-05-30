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
    public class OrderModel
    {
        public delegate void SetRestResponseHandler(object obj);
        public event SetRestResponseHandler OnResult;

        private HttpRestProxy rest;

        public OrderModel()
        {
            rest = new HttpRestProxy();
        }

        public async void GetOrder(String id)
        {
            try
            {
                var order = await Task.Run(()
                    => rest.GetAsync<Order>(String.Format("api/workorders/{0}", id)));

                OnResult(order);
            }
            catch
            {
                OnResult(null);
            }
        }

        public async void GetLatestWorkHistoryByToolId(String id)
        {
            try
            {
                var his = await Task.Run(()
                    => rest.GetAsync<WorkHistory>(String.Format("api/workorders/history/equipments/{0}", id)));

                OnResult(his);
            }
            catch
            {
                OnResult(null);
            }
        }
    }
}
