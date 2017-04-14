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
    /// Window1.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class EquipmentWindow : Window
    {
        public EquipmentWindow()
        {
            InitializeComponent();
            CreateButton(30);
        }

        private void CreateButton(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Button btn = new Button();
                btn.Name = "btnEquipment" + i.ToString();
                btn.Content = "설비" + i.ToString();
                btn.Click += ClickWorkCenterButton;
                wp.Children.Add(btn);
            }
        }

        private void ClickWorkCenterButton(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            ProcessWindow window = new ProcessWindow();
            DataModel.GetModel().Equipment = btn.Content.ToString();
            window.Show();
            this.Close();
        }
    }
}
