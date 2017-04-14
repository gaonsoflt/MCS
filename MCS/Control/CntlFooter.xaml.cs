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
    /// CntlFooter.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class CntlFooter : UserControl
    {
        public CntlFooter()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("CopyRight", typeof(string), typeof(CntlFooter), new UIPropertyMetadata());

        private void root_Loaded(object sender, RoutedEventArgs e)
        {
            CopyRight = "Copyright © 1997-2015 GaonSoft . All rights reserved.";
        }

        private string copyright;
        public string CopyRight
        {
            get { return copyright; }
            set
            {
                this.copyright = value;
            }
        }

        private void btnCfg_Click(object sender, RoutedEventArgs e)
        {
            //if (MessageBox.Show("로그아웃 하시겠습니까?", "알림", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            //{
            SettingWindow window = new SettingWindow();
            window.ShowDialog();
            //    this.Close();
            //}
        }

    }
}
