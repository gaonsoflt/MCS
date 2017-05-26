using MCS.Model;
using MCS.Utils;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// OrderListWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class OrderListWindow : Window
    {
        OrderListModel orderListModel;
        public OrderListWindow()
        {
            InitializeComponent();
            this.DataContext = new OrderListViewModel();
            this.orderListModel = new OrderListModel();

            orderListModel.OnResult += new OrderListModel.SetRestResponseHandler(OnResult);
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateWorkCenterForm();
            UpdateForm();
        }

        private void UpdateWorkCenterForm()
        {
            var viewModel = this.DataContext as OrderListViewModel;
            DataModel model = DataModel.GetModel();
            viewModel.WorkCenter = model.WorkCenterName;
            viewModel.Equipment = model.EquipmentName;
            viewModel.Worker = model.Worker;
        }

        private void UpdateForm()
        {
            DataModel model = DataModel.GetModel();
            var viewModel = this.DataContext as OrderListViewModel;
            viewModel.SelectedToDate = DateTime.Today;
            viewModel.SelectedFromDate = viewModel.SelectedToDate.AddDays(-7);
            GetOrderList();
        }

        private void GetOrderList()
        {
            var viewModel = this.DataContext as OrderListViewModel;
            if (DataModel.GetModel().IsTest)
            {
                SetOrderList(TestData.GetOrderData());
            }
            else
            {
                //orderListModel.GetOrderList(viewModel.SelectedFromDate.Ticks, viewModel.SelectedToDate.Ticks);
                orderListModel.GetOrderList(viewModel.SelectedFromDate, viewModel.SelectedToDate);
            }
        }

        private void OnResult(object obj)
        {
            if (obj != null)
            {
                if (obj.GetType() == typeof(List<Order>))
                {
                    List<Order> list = obj as List<Order>;
                    SetOrderList(list);
                }
            }
        }

        private void SetOrderList(List<Order> list)
        {
            var viewModel = this.DataContext as OrderListViewModel;
            viewModel.OrderList = list;
        }


        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = this.DataContext as OrderListViewModel;
            if (orderListModel.CheckSearchPeriodSize(viewModel.SelectedFromDate, viewModel.SelectedToDate))
            {
                MessageBox.Show("조회: " + viewModel.SelectedFromDate.ToString() + " ~ " + viewModel.SelectedToDate.ToString());
                GetOrderList();
            }
            else
            {
                MessageBox.Show("최대 7일까지만 조회할 수 있습니다.", "알림", MessageBoxButton.OK);
            }
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView rowView = dataGrid.SelectedItem as DataRowView;
            string orderID = rowView.Row["OrderId"].ToString();
            string msg = "[" + orderID + "] 을 선택하시겠습니까?";
            if (MessageBox.Show(msg, "알림", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                OrderWindow window = new OrderWindow(orderID);
                if (window.ShowDialog().Value)
                {
                    // 정상적으로 처리 되었기때문에 ture가 넘어오면 바로 가동현황으로 넘어간다
                    this.Close();
                }
            }
        }
    }
}
