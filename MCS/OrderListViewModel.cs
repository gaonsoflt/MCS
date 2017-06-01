using MCS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCS
{
    public class OrderListViewModel: INotifyPropertyChanged
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

        private DateTime selectedFromDate;
        public DateTime SelectedFromDate
        {
            get { return this.selectedFromDate; }
            set
            {
                this.selectedFromDate = value;
                OnPropertyUpdate("SelectedFromDate");
            }
        }

        private DateTime selectedToDate;
        public DateTime SelectedToDate
        {
            get { return this.selectedToDate; }
            set
            {
                this.selectedToDate = value;
                OnPropertyUpdate("SelectedToDate");
            }
        }

        //private DataTable orderList;
        //public DataTable OrderList
        //{
        //    get { return this.orderList; }
        //    set
        //    {
        //        this.orderList = value;
        //        OnPropertyUpdate("OrderList");
        //    }
        //}

        private List<WorkOrder> orderList;
        public List<WorkOrder> OrderList
        {
            get { return this.orderList; }
            set
            {
                this.orderList = value;
                OnPropertyUpdate("OrderList");
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
