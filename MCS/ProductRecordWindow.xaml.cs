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
    /// ProductionRecordWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ProductRecordWindow : Window
    {
        private string orderID;

        public ProductRecordWindow()
        {
            InitializeComponent();
            this.DataContext = new ProductRecordViewModel();
        }

        public ProductRecordWindow(string orderID)
        {
            InitializeComponent();
            this.orderID = orderID;
            this.DataContext = new ProductRecordViewModel();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateWorkCenterForm();
            UpdateForm();
        }

        private void UpdateWorkCenterForm()
        {
            var viewModel = this.DataContext as ProductRecordViewModel;
            DataModel model = DataModel.GetModel();
            viewModel.WorkCenter = model.WorkCenter;
            viewModel.Equipment = model.Equipment;
            viewModel.Worker = model.Worker;
        }

        private void UpdateForm()
        {
            var viewModel = this.DataContext as ProductRecordViewModel;
            viewModel.OrderID = orderID;
        }

        private void ClickButton(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (btn == btnSave)
            {
                if (MessageBox.Show("현재 내용을 저장하시겠습니까?", "알림", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    // API Call 현재 내용 저장 후 
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
        }

    }

    public class ProductRecordReasonList : List<string>
    {
        public ProductRecordReasonList()
        {
            this.Add("휨");
            this.Add("재료불량");
            this.Add("찍힘");
            this.Add("공정불량");
            this.Add("스크레치");
            this.Add("기타");
        }
    }
}
