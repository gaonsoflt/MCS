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
    public class EquipmentModel
    {
        public delegate void SetRestResponseHandler(object obj);
        public event SetRestResponseHandler OnResult;

        private HttpRestProxy rest;

        public EquipmentModel()
        {
            rest = new HttpRestProxy();
        }

        public async void GetEquipmentList()
        {
            var equipments = await Task.Run(()
                    => rest.GetAsync<List<Equipment>>("api/equipments"));
            if (equipments != null)
            {
                OnResult(equipments);
            }
            else
            {
                OnResult(null);
            }
        }
    }
}
