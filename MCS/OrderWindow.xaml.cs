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
        public OrderWindow()
        {
            InitializeComponent();
        }

        public OrderWindow(string orderID)
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // 작업장 리스트 가져오기
            // 작업자 리스트 가져오기
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ClickButton(object sender, RoutedEventArgs e)
        {
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
                    this.DialogResult = true;
                }
            }
            else if (btn == btnProduct)
            {
            }
            else
            {
            }
        }
    }
}
