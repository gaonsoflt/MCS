using MCS.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Globalization;
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
    /// RunStopWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class RunStopWindow : Window
    {
        private string orderID;
        public RunStopWindow(string orderID)
        {
            InitializeComponent();
            this.orderID = orderID;
            this.DataContext = new RunStopViewModel();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SetOperationDataList();
            UpdateWorkCenterForm();
            UpdateForm();
        }

        private void UpdateWorkCenterForm()
        {
            var viewModel = this.DataContext as RunStopViewModel;
            DataModel model = DataModel.GetModel();
            viewModel.WorkCenter = model.WorkCenter;
            viewModel.Equipment = model.Equipment;
            viewModel.Worker = model.Worker;

        }

        private void UpdateForm()
        {
            var viewModel = this.DataContext as RunStopViewModel;
            viewModel.OrderID = orderID;
        }

        private void SetOperationDataList()
        {
            // 비가동 요인을 가져와서 리스트 입력
            var viewModel = this.DataContext as RunStopViewModel;
            viewModel.OperationList = GetOperationData();
        }

        private ObservableCollection<RunStopDataModel> GetOperationData()
        {
            // orderID로 가동/비가동 정보 조회
            ObservableCollection<RunStopDataModel> data = new ObservableCollection<RunStopDataModel>();
            data.Add(new RunStopDataModel("2017-04-03", "17:00", "", 0, "가동", "ccccccccccccc"));
            data.Add(new RunStopDataModel("2017-04-03", "15:00", "17:00", 120, "비가동", "bbbbb"));
            data.Add(new RunStopDataModel("2017-04-03", "14:00", "15:00", 60, "가동", "aaaaaaaaaa"));
            return data;
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

    public class OperationReasonList : List<string>
    {
        public OperationReasonList()
        {
            this.Add("aaaaaaaaaa");
            this.Add("bbbbb");
            this.Add("ccccccccccccc");
            this.Add("dddddddd");
            this.Add("e");
        }
    }

    public class ReasonToVisibleMultiConverter : IMultiValueConverter
    {
        public Visibility visible { get; set; }

        public ReasonToVisibleMultiConverter()
        {
            visible = Visibility.Visible;
        }

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values != null && values.Count() == 2)
            {
                var cellValue = values[0] as string;
                var type = values[1] as string;
                if (!string.IsNullOrEmpty(cellValue))
                {
                    switch (type)
                    {
                        case "가동":
                            return Visibility.Collapsed;
                        case "비가동":
                            return Visibility.Visible;
                    }
                }
            }
            return Visibility.Visible;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class ReasonToReadOnlyConverter : IValueConverter
    {
        public ReasonToReadOnlyConverter()
        {
        }

        public object Convert(object values, Type targetType, object parameter, CultureInfo culture)
        {
            var type = values as string;
            switch (type)
            {
                case "가동":
                    return true;
                case "비가동":
                    return false;
                default:
                    return false;
            }
        }

        public object ConvertBack(object value, Type targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
