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
        string orderID;

        public OrderWindow()
        {
            InitializeComponent();
            this.DataContext = new OrderViewModel();
        }

        public OrderWindow(string orderID)
        {
            InitializeComponent();
            this.orderID = orderID;
            this.DataContext = new OrderViewModel();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateWorkCenterForm();
            UpdateForm();
        }

        private void UpdateWorkCenterForm()
        {
            var viewModel = this.DataContext as OrderViewModel;
            DataModel model = DataModel.GetModel();
            viewModel.WorkCenter = model.WorkCenter;
            viewModel.Equipment = model.Equipment;
            viewModel.Worker = model.Worker;

            viewModel.OrderID = orderID;
        }

        private void UpdateForm()
        {
            // GetOrderInfo Call 하여 작업지시 정보를 폼에 출력

        }

        private void GetOrderInfo()
        {

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
                string _orderID = DataModel.GetModel().OrderID;
                string msg = "";
                if (!string.IsNullOrEmpty(_orderID))
                {
                    msg += "진행중이던 작업[" + _orderID + "]을 취소하고\n";
                }
                msg += " 새로운 작업을 시작하시겠습니까?";
                if (MessageBox.Show(msg, "알림", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    // API Call 새로운 작업으로 변경
                    this.DialogResult = true;
                    this.Close();
                }
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
    }
}
