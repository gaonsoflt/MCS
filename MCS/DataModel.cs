using MCS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCS
{
    public class DataModel
    {
        private static DataModel model;
        public static DataModel GetModel()
        {
            if(model == null)
            {
                model = new DataModel();
            }
            return model;
        }

        private DataModel()
        {

        }

        private string workCenter;
        public string WorkCenter
        {
            get { return this.workCenter; }
            set
            {
                this.workCenter = value;
            }
        }

        private string equipment;
        public string Equipment
        {
            get { return this.equipment; }
            set
            {
                this.equipment = value;
            }
        }

        private UserModel user;
        public UserModel User
        {
            get { return this.user; }
            set
            {
                this.user = value;
            }
        }

        private string workerID;
        public string WorkerID
        {
            get { return this.workerID; }
            set
            {
                this.workerID = value;
            }
        }

        private string workerPW;
        public string WorkerPW
        {
            get { return this.workerPW; }
            set
            {
                this.workerPW = value;
            }
        }

        private string worker;
        public string Worker
        {
            get { return this.worker; }
            set
            {
                this.worker = value;
            }
        }

        private string orderID;
        public string OrderID
        {
            get { return this.orderID; }
            set
            {
                this.orderID = value;
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
            }
        }

        private long materialQuantity;
        public long MaterialQuantity
        {
            get { return this.materialQuantity; }
            set
            {
                this.materialQuantity = value;
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
            }
        }

        private long productQuantity;
        public long ProductQuantity
        {
            get { return this.productQuantity; }
            set
            {
                this.productQuantity = value;
            }
        }

        private long planQuantity;
        public long PlanQuantity
        {
            get { return this.planQuantity; }
            set
            {
                this.planQuantity = value;
            }
        }

        private long quantity;
        public long Quantity
        {
            get { return this.quantity; }
            set
            {
                this.quantity = value;
            }
        }

        private long faulty;
        public long Faulty
        {
            get { return this.faulty; }
            set
            {
                this.faulty = value;
            }
        }

        private DateTime workStartDT;
        public DateTime WorkStartDT
        {
            get { return this.workStartDT; }
            set
            {
                this.workStartDT = value;
            }
        }

        private DateTime workEndDT;
        public DateTime WorkEndDT
        {
            get { return this.workEndDT; }
            set
            {
                this.workEndDT = value;
            }
        }
    }
}
