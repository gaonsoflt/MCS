using MCS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MCS
{
    /// <summary>
    /// WorkStartDialog.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class WorkStartDialog : Window
    {
        private WorkOrder NextOrder;
        WorkStartModel model;

        public WorkStartDialog()
        {
            InitializeComponent();
            this.DataContext = new WorkStartViewModel();
        }

        public WorkStartDialog(String CurOrderId, String nextOrderId)
        {
            InitializeComponent();
            this.DataContext = new WorkStartViewModel();
            model = new WorkStartModel();
            model.OnResult += new WorkStartModel.SetRestResponseHandler(OnResult);
            SetMessage(CurOrderId, nextOrderId);
        }

        public WorkStartDialog(WorkOrder nextOrder)
        {
            InitializeComponent();
            this.DataContext = new WorkStartViewModel();
            model = new WorkStartModel();
            model.OnResult += new WorkStartModel.SetRestResponseHandler(OnResult);
            this.NextOrder = nextOrder;
            SetMessage(DataModel.GetModel().OrderID, NextOrder.OrderId);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var viewModel = this.DataContext as WorkStartViewModel;
            viewModel.SelectedStartDt = DateTime.Now;
        }

        private void OnResult(object obj)
        {
            if(obj != null)
            {
                if (obj.GetType() == typeof(String))
                {
                    // 귀찮아서 그냥 코딩~
                    // API Call 새로운 작업으로 변경
                    DataModel.GetModel().Order = this.NextOrder;
                    this.DialogResult = true;
                    this.Close();
                }
            }
        }

        public String Message
        {
            get
            {
                var viewModel = this.DataContext as WorkStartViewModel;
                return viewModel.Message;
            }
            set
            {
                var viewModel = this.DataContext as WorkStartViewModel;
                viewModel.Message = value;
            }
        }

        private void SetMessage(String now, String next)
        {
            String msg = "";
            if (!string.IsNullOrEmpty(now))
            {
                msg += "진행중이던 작업[" + now + "]을 취소하고";
            }
            msg += " 새로운 작업을 시작하시겠습니까?";

            Message = msg;
        }

        private void ClickButton(object sender, RoutedEventArgs e)
        {
            var viewModel = this.DataContext as WorkStartViewModel;
            Button btn = sender as Button;
            if (btn == btnStart)
            {
                WorkHistory history = new WorkHistory(
                    NextOrder.CompSeq, 
                    NextOrder.OrderId, 
                    DataModel.GetModel().Equipment.ToolId, 
                    DataModel.GetModel().User.UserId,
                    viewModel.SelectedStartDt);
                model.SaveWorkStart(history);
            }
            else
            {
                this.Close();
            }
        }

    }
}
