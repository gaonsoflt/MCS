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
        public ProcessWindow()
        {
            InitializeComponent();
            this.DataContext = new ProcessViewModel();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            UpdateForm(GetOrderInfo());
        }

        private DataModel GetOrderInfo()
        {
            // API call get order data
            //DataModel model = null;
            DataModel model = DataModel.GetModel();
            model.Worker = "홍길동";
            model.OrderID = "작업지시서-201704020394";
            model.WorkStartDT = DateTime.Now;
            model.Quantity = 10000;
            /******************************************/
            return model;
        }

        private void UpdateForm(DataModel model)
        {
            if (model != null)
            {
                EnableButton(true);
                gridForm.Visibility = Visibility.Visible;
                gridNonForm.Visibility = Visibility.Collapsed;
                var viewModel = this.DataContext as ProcessViewModel;
                viewModel.WorkCenter = model.WorkCenter;
                viewModel.Equipment = model.Equipment;
                viewModel.Worker = model.Worker;
                viewModel.WorkStartDT = model.WorkStartDT;
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
            Button btn = sender as Button;
            if (btn == btnOrder)
            {
                OrderListWindow window = new OrderListWindow();
                window.ShowDialog();
            }
            else if (btn == btnEquipment)
            {
                EquipmentWindow window = new EquipmentWindow();
                window.ShowDialog();
                this.Close();
            }
            else if (btn == btnProduct)
            {

            }
            else
            {

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
