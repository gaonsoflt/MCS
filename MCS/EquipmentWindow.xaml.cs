using MCS.Model;
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
        EquipmentModel equipModel;

        public EquipmentWindow()
        {
            InitializeComponent();
            equipModel = new EquipmentModel();
            equipModel.OnResult += new EquipmentModel.SetRestResponseHandler(OnResult);

            CreateButton();
        }

        private void CreateButton()
        {
            if (DataModel.GetModel().IsTest)
            {
                for (int i = 0; i < 30; i++)
                {
                    Button btn = new Button();
                    btn.Name = "btnEquipment" + i.ToString();
                    btn.Content = "설비" + i.ToString();
                    btn.Click += ClickEquipmentTestButton;
                    wp.Children.Add(btn);
                }
            }
            else
            {
                equipModel.GetEquipmentList();
            }
        }

        private void OnResult(object obj)
        {
            if (obj != null)
            {
                if (obj.GetType() == typeof(List<Equipment>))
                {
                    List<Equipment> list = obj as List<Equipment>;
                    if (list.Count > 0)
                    {
                        CreateButton(list);
                    }
                    else
                    {
                        MessageBox.Show("설비를 가져오지 못했습니다.\n관리부서에 확인해주시기 바랍니다.");
                    }
                }
            }
        }

        private void CreateButton(List<Equipment> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Button btn = new Button();
                //Binding binding = new Binding("ToolName");
                //binding.Source = list[i];
                btn.Content = list[i].ToolName + "\n[" + ((list[i].Status != null) ? list[i].Status.MinorName : "알수없음") + "]";
                btn.Resources = list[i].ConvertResourceDic();
                //btn.SetBinding(ContentProperty, binding);
                if (list[i].ToolStatus == 11660001)
                {
                    btn.IsEnabled = true;
                    btn.Click += ClickEquipmentButton;
                }
                else
                {
                    btn.IsEnabled = false;
                }
                wp.Children.Add(btn);
            }
        }

        private void ClickEquipmentButton(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            ProcessWindow window = new ProcessWindow();
            DataModel.GetModel().Equipment = Equipment.ConvertResourceToClass(btn.Resources);
            window.Show();
            this.Close();
        }

        private void ClickEquipmentTestButton(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            ProcessWindow window = new ProcessWindow();
            DataModel.GetModel().Equipment = new Equipment(1, 1, btn.Name, btn.Content.ToString());
            window.Show();
            this.Close();
        }
    }
}
