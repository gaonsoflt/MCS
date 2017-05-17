using MCS.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCS
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public LoginViewModel()
        {
            LoadLoginInfo();
        }

        public void LoadLoginInfo()
        {
            SelectedWorkCenter = Properties.Settings.Default.WorkCenter;
            LoginID = Properties.Settings.Default.WorkerID;
            LoginPW = Properties.Settings.Default.WorkerPW;
            IsSaveLoginInfo = Properties.Settings.Default.IsSaveLoginInfo;
        }

        public void SaveLoginInfo()
        {
            Properties.Settings.Default.WorkCenter = SelectedWorkCenter;
            Properties.Settings.Default.WorkerID = LoginID;
            Properties.Settings.Default.WorkerPW = LoginPW;
            Properties.Settings.Default.IsSaveLoginInfo = IsSaveLoginInfo;
            Properties.Settings.Default.Save();
        }

        public void ClearLoginInfo()
        {
            Properties.Settings.Default.WorkCenter = "";
            Properties.Settings.Default.WorkerID = "";
            Properties.Settings.Default.WorkerPW = "";
            Properties.Settings.Default.IsSaveLoginInfo = false;
            Properties.Settings.Default.Save();
        }

        private string loginID;
        public string LoginID
        {
            get { return this.loginID; }
            set
            {
                this.loginID = value;
                OnPropertyUpdate("LoginID");
            }
        }

        private string loginPW;
        public string LoginPW
        {
            get { return this.loginPW; }
            set
            {
                this.loginPW = value;
                OnPropertyUpdate("LoginPW");
            }
        }

        private List<WorkCenterModel> workCenterList;
        public List<WorkCenterModel> WorkCenterList
        {
            get { return (this.workCenterList != null) ? this.workCenterList : new List<WorkCenterModel>(); }
            set
            {
                this.workCenterList = value;
                OnPropertyUpdate("WorkCenterList");
            }
        }

        private string selectedWorkCenter;
        public string SelectedWorkCenter
        {
            get { return this.selectedWorkCenter; }
            set
            {
                this.selectedWorkCenter = value;
                OnPropertyUpdate("SelectedWorkCenter");
            }
        }

        private bool isSaveLoginInfo;
        public bool IsSaveLoginInfo
        {
            get { return this.isSaveLoginInfo; }
            set
            {
                this.isSaveLoginInfo = value;
                OnPropertyUpdate("IsSaveLoginInfo");
            }
        }

        private void OnPropertyUpdate(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
