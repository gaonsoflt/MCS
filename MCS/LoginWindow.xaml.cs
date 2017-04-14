using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace MCS
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();

            this.DataContext = new LoginViewModel();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            Keyboard.Focus(cbWorkCenter);
            GetWorkCenterList();
        }

        private void GetWorkCenterList()
        {
            // API를 통해 작정장 정보를 가져오기
            ObservableCollection<string> oc = new ObservableCollection<string>();
            oc.Add("작업장1");
            oc.Add("작업장2");
            oc.Add("작업장3");
            oc.Add("작업장4");
            oc.Add("작업장5");

            var viewModel = this.DataContext as LoginViewModel;
            viewModel.WorkCenterList = oc;
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = this.DataContext as LoginViewModel;
            if (string.IsNullOrEmpty(viewModel.SelectedWorkCenter))
            {
                MessageBox.Show("작업장을 선택해주세요.");
                Keyboard.Focus(cbWorkCenter);
                return;
            }
            if (string.IsNullOrEmpty(viewModel.LoginID))
            {
                MessageBox.Show("아이디를 입력해주세요.");
                Keyboard.Focus(tbLoginID);
                return;
            }
            if (string.IsNullOrEmpty(viewModel.LoginPW))
            {
                MessageBox.Show("패스워드를 입력해주세요.");
                Keyboard.Focus(tbLoginPW);
                return;
            }

            DoLogin(CheckLoginInfo(viewModel.LoginID, viewModel.LoginPW));
        }

        private void ClearLoginForm()
        {
            var viewModel = this.DataContext as LoginViewModel;
            Keyboard.Focus(tbLoginID);
            viewModel.LoginID = "";
            viewModel.LoginPW = "";
        }

        private bool CheckLoginInfo(string id, string pw)
        {
            //MessageBox.Show(string.Format("ID={0}, Password={1}", id, pw));
            string _id = "admin";
            string _pw = "1234";

            // API call 사용자 인증
            if (id.Equals(_id) && pw.Equals(_pw))
            {
                // 인증결과로 사용자 정보를 받아서 DataModel 에 담기
                return true;
            }
            return false;
        }

        private void DoLogin(bool success)
        {
            var viewModel = this.DataContext as LoginViewModel;
            if (CheckLoginInfo(viewModel.LoginID, viewModel.LoginPW))
            {
                DataModel.GetModel().WorkCenter = viewModel.SelectedWorkCenter;
                DataModel.GetModel().WorkerID = viewModel.LoginID;
                DataModel.GetModel().WorkerPW = viewModel.LoginPW;

                if (viewModel.IsSaveLoginInfo)
                {
                    viewModel.SaveLoginInfo();
                }
                else
                {
                    viewModel.ClearLoginInfo();
                }
                //  API call 사용자 정보 가져와서 담기
                DataModel.GetModel().Worker = "홍길동";
                ////////////////////////////////////////////////

                MessageBox.Show("로그인 성공");
                EquipmentWindow window = new EquipmentWindow();
                window.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("로그인 실패");
                ClearLoginForm();
            }
        }
    }
}
