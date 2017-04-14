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
        public OrderListWindow()
        {
            InitializeComponent();
            this.DataContext = new OrderListViewModel();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var modelView = this.DataContext as OrderListViewModel;
            modelView.OrderList = OrderListViewModel.GetSampleData();
            modelView.SelectedDate = DateTime.Today;
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("조회: " + dpOrderDt.SelectedDate.Value.ToString()); 
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView rowView = dataGrid.SelectedItem as DataRowView;
            string msg = "[" + rowView.Row["OrderID"].ToString() + "] 을 선택하시겠습니까?";
            if (MessageBox.Show(msg, "알림", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                OrderWindow window = new OrderWindow();
                if (window.ShowDialog().Value)
                {
                    this.Close();
                }
            }
        }
    }
}
