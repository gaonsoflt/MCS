using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCS
{
    public class ProcessViewModel : INotifyPropertyChanged
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

        private string meterialName;
        private string MeterialName
        {
            get { return this.meterialName; }
            set
            {
                this.meterialName = value;
            }
        }
        private string meterialID;
        private string MeterialID
        {
            get { return this.meterialID; }
            set
            {
                this.meterialID = value;
            }
        }

        private string materialInfo;
        public string MaterialInfo
        {
            get { return this.materialInfo; }
            set
            {
                this.materialInfo = value;
                OnPropertyUpdate("MaterialInfo");
            }
        }

        private long materialQuantity;
        public long MaterialQuantity
        {
            get { return this.materialQuantity; }
            set
            {
                this.materialQuantity = value;
                OnPropertyUpdate("MaterialQuantity");
            }
        }

        private string productName;
        private string ProductName
        {
            get { return this.productName; }
            set
            {
                this.productName = value;
            }
        }
        private string productID;
        private string ProductID
        {
            get { return this.productID; }
            set
            {
                this.productID = value;
            }
        }

        private string productInfo;
        public string ProductInfo
        {
            get { return this.productInfo; }
            set
            {
                this.productInfo = value;
                OnPropertyUpdate("ProductInfo");
            }
        }

        private long productQuantity;
        public long ProductQuantity
        {
            get { return this.productQuantity; }
            set
            {
                this.productQuantity = value;
                OnPropertyUpdate("ProductQuantity");
            }
        }

        private long quantity;
        public long Quantity
        {
            get { return this.quantity; }
            set
            {
                this.quantity = value;
                OnPropertyUpdate("Quantity");
            }
        }

        private long faulty;
        public long Faulty
        {
            get { return this.faulty; }
            set
            {
                this.faulty = value;
                OnPropertyUpdate("Faulty");
            }
        }

        private DateTime workStartDT;
        public DateTime WorkStartDT
        {
            get { return this.workStartDT; }
            set
            {
                this.workStartDT = value;
                if (workStartDT == default(DateTime))
                {
                    workStartDTstr = "";
                }
                else
                {
                    workStartDTstr = workStartDT.ToString("yyyy년 MM월 dd일 tt HH시 mm분");
                }
                OnPropertyUpdate("WorkStartDTstr");
            }
        }

        private string workStartDTstr;
        public string WorkStartDTstr
        {
            get { return this.workStartDTstr; }
        }

        private DateTime workEndDT;
        public DateTime WorkEndDT
        {
            get { return this.workEndDT; }
            set
            {
                this.workEndDT = value;
                if (workEndDT == default(DateTime))
                {
                    workEndDTstr = "";
                }
                else
                {
                    workEndDTstr = workEndDT.ToString("yyyy년 MM월 dd일 tt HH시 mm분");
                }
                OnPropertyUpdate("WorkEndDTstr");
            }
        }

        private string workEndDTstr;
        public string WorkEndDTstr
        {
            get { return this.workEndDTstr; }
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
