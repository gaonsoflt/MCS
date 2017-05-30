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
    /// ProcessWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ProcessWindow : Window
    {
        OrderModel model;

        public ProcessWindow()
        {
            InitializeComponent();
            this.DataContext = new ProcessViewModel();
            model = new OrderModel();
            model.OnResult += new OrderModel.SetRestResponseHandler(OnResult);
        }

        private void OnResult(object obj)
        {
            if (obj != null)
            {
                if (obj.GetType() == typeof(WorkHistory))
                {
                    WorkHistory his = obj as WorkHistory;
                    model.GetOrder(his.WorkOrderNo);
                }
                else if (obj.GetType() == typeof(Order))
                {
                    Order order = obj as Order;
                    DataModel.GetModel().Order = order;
                    UpdateForm(order);
                }
            }
            else
            {
                UpdateForm(null);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateWorkCenterForm();
            GetWorkOrder();
        }

        private void GetWorkOrder()
        {
            if (DataModel.GetModel().IsTest)
            {
                UpdateForm(TestData.GetOrderInfo());
            }
            else
            {
                model.GetLatestWorkHistoryByToolId(DataModel.GetModel().Equipment.ToolId);
            }
        }

        private void UpdateWorkCenterForm()
        {
            var viewModel = this.DataContext as ProcessViewModel;
            DataModel model = DataModel.GetModel();
            viewModel.WorkCenter = model.WorkCenterName;
            viewModel.Equipment = model.EquipmentName;
            viewModel.Worker = model.Worker;
        }

        private void UpdateForm(Order order)
        {
            if (order != null)
            {
                EnableButton(true);
                gridForm.Visibility = Visibility.Visible;
                gridNonForm.Visibility = Visibility.Collapsed;

                var viewModel = this.DataContext as ProcessViewModel;
                viewModel.OrderID = order.OrderId;
                viewModel.Quantity = order.OrderQty;
            }
            else
            {
                EnableButton(false);
                gridForm.Visibility = Visibility.Collapsed;
                gridNonForm.Visibility = Visibility.Visible;
            }
        }

        private void EnableButton(bool enable)
        {
            btnProduct.IsEnabled = enable;
            btnOperation.IsEnabled = enable;
        }

        private void ClickButton(object sender, RoutedEventArgs e)
        {
            var viewModel = this.DataContext as ProcessViewModel;
            Button btn = sender as Button;
            if (btn == btnOrder)
            {
                OrderListWindow window = new OrderListWindow();
                window.Show();
                Close();
            }
            else if (btn == btnEquipment)
            {
                EquipmentWindow window = new EquipmentWindow();
                window.ShowDialog();
                this.Close();
            }
            else if (btn == btnProduct)
            {
                ProductRecordWindow window = new ProductRecordWindow(viewModel.OrderID);
                window.ShowDialog();
            }
            else
            {
                RunStopWindow window = new RunStopWindow(viewModel.OrderID);
                window.ShowDialog();
            }
        }

        private void btnCfg_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("로그아웃 하시겠습니까?", "알림", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                LoginWindow window = new LoginWindow();
                window.Show();
                this.Close();
            }
        }
    }
}
