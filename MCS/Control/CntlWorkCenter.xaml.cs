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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MCS.Control
{
    /// <summary>
    /// CntlWorkCenter.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class CntlWorkCenter : UserControl
    {
        public CntlWorkCenter()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty WorkCenterTextProperty = 
            DependencyProperty.Register("WorkCenterText", typeof(string), typeof(CntlWorkCenter), new FrameworkPropertyMetadata(string.Empty));
        public string WorkCenterText
        {
            get { return GetValue(WorkCenterTextProperty).ToString(); }
            set { SetValue(WorkCenterTextProperty, value); }
        }

        public static readonly DependencyProperty EquipmentTextProperty =
            DependencyProperty.Register("EquipmentText", typeof(string), typeof(CntlWorkCenter), new FrameworkPropertyMetadata(string.Empty));
        public string EquipmentText
        {
            get { return GetValue(EquipmentTextProperty).ToString(); }
            set { SetValue(EquipmentTextProperty, value); }
        }

        public static readonly DependencyProperty WorkerTextProperty =
            DependencyProperty.Register("WorkerText", typeof(string), typeof(CntlWorkCenter), new FrameworkPropertyMetadata(string.Empty));
        public string WorkerText
        {
            get { return GetValue(WorkerTextProperty).ToString(); }
            set { SetValue(WorkerTextProperty, value); }
        }
    }
}
