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
    public class WorkStartModel
    {
        public delegate void SetRestResponseHandler(object obj);
        public event SetRestResponseHandler OnResult;

        private HttpRestProxy rest;

        public WorkStartModel()
        {
            rest = new HttpRestProxy();
        }

        public async void SaveWorkStart(WorkHistory history)
        {
            try
            {
                var result = await Task.Run(()
                    => rest.PostAsync("api/workorders/history", HttpRestProxy.ConvertStringContent(history)));

                if(result.Headers.Location != null)
                {
                    OnResult(result.Headers.Location.AbsolutePath);
                } else
                {
                    OnResult(null);
                }
            }
            catch
            {
                OnResult(null);
            }
        }
    }
}
