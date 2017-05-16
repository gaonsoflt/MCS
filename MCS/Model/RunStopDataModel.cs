using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCS.Model
{
    public class RunStopDataModel
    {
        public RunStopDataModel()
        {

        }

        public RunStopDataModel(string operationDate, string startTime, string stopTime, long operationTime, string operationType, string reason)
        {
            this.OperationDate = operationDate;
            this.StartTime = startTime;
            this.StopTime = stopTime;
            this.OperationTime = operationTime;
            this.OperationType = operationType;
            this.Reason = reason;
        }

        public string OperationDate { get; set; }
        public string StartTime { get; set; }
        public string StopTime { get; set; }
        public long OperationTime { get; set; }
        public string OperationType { get; set; }
        public string Reason { get; set; }

        //public RunStopDataModel(DateTime operationDate, DateTime startTime, DateTime stopTime, TimeSpan operationTime, string operationType, string reason)
        //{
        //    this.OperationDate = operationDate;
        //    this.StartTime = startTime;
        //    this.StopTime = stopTime;
        //    this.OperationTime = operationTime;
        //    this.OperationType = operationType;
        //    this.Reason = reason;
        //}

        //public DateTime OperationDate { get; set; }
        //public DateTime StartTime { get; set; }
        //public DateTime StopTime { get; set; }
        //public TimeSpan OperationTime { get; set; }
        //public string OperationType { get; set; }
        //public string Reason { get; set; }
    }
}
