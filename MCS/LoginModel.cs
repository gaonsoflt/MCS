using MCS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCS
{
    public class LoginModel
    {
        public delegate void SetLoginHandler(bool isSuccess);
        public event SetLoginHandler OnLogin;

        private HttpRestProxy rest;

        public LoginModel ()
        {
            rest = new HttpRestProxy();
        }

        public async void CheckLogin(string id, string pw)
        {
            try
            {
                var user = await Task.Run(()
                    => rest.GetAsync<UserModel>(string.Format("users/login?u={0}&p={1}", "0181195ed160e2df2bf5e935c87609fe", "d871ce025cd27c5ac8176ae3d58dd617")));
                //=> rest.GetAsync<UserModel>(string.Format("users/login?u={0}&p={1}", id, pw)));
                if (user != null)
                {
                    DataModel.GetModel().User = user;
                    DataModel.GetModel().Worker = user.UserNm;
                    DataModel.GetModel().WorkerID = user.UserId;
                    OnLogin(true);
                }
                else
                {
                    DataModel.GetModel().User = null;
                    OnLogin(false);
                }
            }
            catch
            {
                DataModel.GetModel().User = null;
                OnLogin(false);
            }
        }
    }
}
