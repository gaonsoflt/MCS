using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCS
{
    public class WorkStartViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


        //private DateTime workEndDT;
        //public DateTime WorkEndDT
        //{
        //    get { return this.workEndDT; }
        //    set
        //    {
        //        this.workEndDT = value;
        //        if (workEndDT == default(DateTime))
        //        {
        //            workEndDTstr = "";
        //        }
        //        else
        //        {
        //            workEndDTstr = workEndDT.ToString("yyyy년 MM월 dd일 tt HH시 mm분");
        //        }
        //        OnPropertyUpdate("WorkEndDTstr");
        //    }
        //}

        private String message;
        public String Message
        {
            get { return this.message; }
            set
            {
                this.message = value;
                OnPropertyUpdate("Message");
            }
        }

        private DateTime selectedStartDt;
        public DateTime SelectedStartDt
        {
            get { return this.selectedStartDt; }
            set
            {
                this.selectedStartDt = value;
                OnPropertyUpdate("SelectedStartDt");
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
