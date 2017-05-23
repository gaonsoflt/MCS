using MCS.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCS
{
    public class RunStopViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string workCenter;
        public string WorkCenter
        {
            get { return this.workCenter; }
            set
            {
                this.workCenter = value;
                OnPropertyUpdate("WorkCenter");
            }
        }

        private string equipment;
        public string Equipment
        {
            get { return this.equipment; }
            set
            {
                this.equipment = value;
                OnPropertyUpdate("Equipment");
            }
        }

        private string worker;
        public string Worker
        {
            get { return this.worker; }
            set
            {
                this.worker = value;
                OnPropertyUpdate("Worker");
            }
        }

        private string orderID;
        public string OrderID
        {
            get { return this.orderID; }
            set
            {
                this.orderID = value;
                OnPropertyUpdate("OrderID");
            }
        }

        private string reason;
        public string Reason
        {
            get { return this.reason; }
            set
            {
                this.reason = value;
                OnPropertyUpdate("Reason");
            }
        }

        private ObservableCollection<RunStopData> operationList;
        public ObservableCollection<RunStopData> OperationList
        {
            get { return this.operationList; }
            set
            {
                this.operationList = value;
                OnPropertyUpdate("OperationList");
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
