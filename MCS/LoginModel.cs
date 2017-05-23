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
    public class LoginModel
    {
        public delegate void SetLoginHandler(bool isSuccess);
        public event SetLoginHandler OnLogin;

        public delegate void SetRestResponseHandler(object obj);
        public event SetRestResponseHandler OnResult;

        private HttpRestProxy rest;

        private const String KEY = "user.12345678901";
        private const String IV = "0000000000000000";

        public LoginModel ()
        {
            rest = new HttpRestProxy();
        }

        public async void CheckLogin(string id, string pw)
        {
            try
            {
                String _id = BBCrypto.AESEncrypt256(KEY, IV, id);
                String _pw = BBCrypto.AESEncrypt256(KEY, IV, pw);
                //Console.WriteLine("[" + _id + "]/[" + _pw + "]");

                StringContent content = new StringContent(JsonConvert.SerializeObject(new User(_id, _pw)), Encoding.UTF8, "application/json");

                var user = await Task.Run(()
                    => rest.PostAsync<User>("api/users/login", HttpRestProxy.ConvertStringContent(new User(_id, _pw))));

                //var user = await Task.Run(()
                //    => rest.GetAsync<UserModel>(string.Format("users/login?u={0}&p={1}", _id, _pw)));
                    //=> rest.GetAsync<UserModel>(string.Format("users/login?u={0}&p={1}", "0181195ed160e2df2bf5e935c87609fe", "d871ce025cd27c5ac8176ae3d58dd617")));
                if (user != null)
                {
                    DataModel.GetModel().User = user;
                    OnLogin(true);
                }
                else
                {
                    DataModel.GetModel().User = new User();
                    OnLogin(false);
                }
            }
            catch
            {
                DataModel.GetModel().User = new User();
                OnLogin(false);
            }
        }

        public async void GetWorkCenterList()
        {
            var workCenters = await Task.Run(()
                    => rest.GetAsync<List<WorkCenter>>("api/workcenters"));
            if (workCenters != null)
            {
                OnResult(workCenters);
            }
            else
            {
                OnResult(null);
            }
        }
    }
}
