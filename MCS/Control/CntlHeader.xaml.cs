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
    /// CntlHeader.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class CntlHeader : UserControl
    {
        public CntlHeader()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty TitleTextProperty =
           DependencyProperty.Register("TitleText", typeof(string), typeof(CntlHeader), new FrameworkPropertyMetadata(string.Empty));
        public string TitleText
        {
            get { return GetValue(TitleTextProperty).ToString(); }
            set { SetValue(TitleTextProperty, value); }
        }

        public static readonly DependencyProperty BackBtnVisibleProperty =
            DependencyProperty.Register("BackBtnVisible", typeof(Enum), typeof(CntlHeader), new FrameworkPropertyMetadata(Visibility.Visible));
        public Visibility BackBtnVisible
        {
            get { return (Visibility)GetValue(BackBtnVisibleProperty); }
            set { SetValue(BackBtnVisibleProperty, value); }
        }
    }
}
