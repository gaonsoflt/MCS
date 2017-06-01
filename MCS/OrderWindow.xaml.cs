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
    /// OrderWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class OrderWindow : Window
    {
        OrderModel model;
        WorkOrder order;

        public OrderWindow()
        {
            InitializeComponent();
            this.DataContext = new OrderViewModel();
            model = new OrderModel();
            model.OnResult += new OrderModel.SetRestResponseHandler(OnResult);
        }

        public OrderWindow(string orderId)
        {
            InitializeComponent();
            this.order = new WorkOrder();
            this.order.OrderId = orderId;
            this.DataContext = new OrderViewModel();
            model = new OrderModel();
            model.OnResult += new OrderModel.SetRestResponseHandler(OnResult);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateWorkCenterForm();
            GetOrderInfo();
        }

        private void UpdateWorkCenterForm()
        {
            var viewModel = this.DataContext as OrderViewModel;
            DataModel model = DataModel.GetModel();
            viewModel.WorkCenter = model.WorkCenterName;
            viewModel.Equipment = model.EquipmentName;
            viewModel.Worker = model.Worker;

        }

        private void UpdateForm(WorkOrder order)
        {
            var viewModel = this.DataContext as OrderViewModel;
            viewModel.OrderID = order.OrderId;
            viewModel.PlanQuantity = order.Plan.ProdPlanQty;
            viewModel.MaterialInfo = order.Item.ItemName;
        }

        private void GetOrderInfo()
        {
            // GetOrderInfo Call 하여 작업지시 정보를 폼에 출력
            model.GetOrder(order.OrderId);
        }

        private void OnResult(object obj)
        {
            if (obj != null)
            {
                if (obj.GetType() == typeof(WorkOrder))
                {
                    WorkOrder order = obj as WorkOrder;
                    this.order = order;
                    UpdateForm(order);
                }
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ClickButton(object sender, RoutedEventArgs e)
        {
            var viewModel = this.DataContext as OrderViewModel;
            Button btn = sender as Button;
            if (btn == btnStartWork)
            {
                //string _orderID = DataModel.GetModel().OrderID;
                //string msg = "";
                //if (!string.IsNullOrEmpty(_orderID))
                //{
                //    msg += "진행중이던 작업[" + _orderID + "]을 취소하고";
                //}
                //msg += " 새로운 작업을 시작하시겠습니까?";
                //if (MessageBox.Show(msg, "알림", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                //{
                //    // API Call 새로운 작업으로 변경
                //    this.DialogResult = true;
                //    this.Close();
                //}

                //WorkStartDialog dlg = new WorkStartDialog(DataModel.GetModel().OrderID, viewModel.OrderID);
                WorkStartDialog dlg = new WorkStartDialog(order);
                if (dlg.ShowDialog().Value)
                {
                    this.DialogResult = true;
                    this.Close();
                }
            }
            else if (btn == btnProduct)
            {
                ProductRecordWindow window = new ProductRecordWindow(order.OrderId);
                window.ShowDialog();
            }
            else
            {
                RunStopWindow window = new RunStopWindow(order.OrderId);
                window.ShowDialog();
            }
        }
    }
}
