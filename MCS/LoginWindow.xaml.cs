﻿using MCS.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
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
        LoginModel loginModel;
        public LoginWindow()
        {
            InitializeComponent();

            this.DataContext = new LoginViewModel();
            this.loginModel = new LoginModel();

            loginModel.OnLogin += new LoginModel.SetLoginHandler(OnLogin);
            loginModel.OnResult += new LoginModel.SetRestResponseHandler(OnResult);
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            Keyboard.Focus(cbWorkCenter);
            GetWorkCenterList();
        }

        private void GetWorkCenterList()
        {
            if (cbTest.IsChecked.Value)
            {
                var viewModel = this.DataContext as LoginViewModel;
                viewModel.WorkCenterList = TestData.GetWorkCenterList();
            }
            else
            {
                // API를 통해 작정장 정보를 가져오기
                loginModel.GetWorkCenterList();
            }
        }

        private void OnResult(object obj)
        {
            if (obj != null)
            {
                var viewModel = this.DataContext as LoginViewModel;
                if (obj.GetType() == typeof(List<WorkCenter>))
                {
                    List<WorkCenter> list = obj as List<WorkCenter>;
                    if (list.Count > 0)
                    {
                        viewModel.WorkCenterList = list;
                    }
                    else
                    {
                        MessageBox.Show("작업장을 가져오지 못했습니다.\n관리부서에 확인해주시기 바랍니다.");
                    }
                }
            }
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = this.DataContext as LoginViewModel;
            if (string.IsNullOrEmpty(viewModel.SelectedWorkCenterName))
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

            CheckLoginInfo(viewModel.LoginID, viewModel.LoginPW);
        }

        private void ClearLoginForm()
        {
            var viewModel = this.DataContext as LoginViewModel;
            Keyboard.Focus(tbLoginID);
            viewModel.LoginID = "";
            viewModel.LoginPW = "";
        }

        private void CheckLoginInfo(string id, string pw)
        {
            //MessageBox.Show(string.Format("ID={0}, Password={1}", id, pw));

            if (cbTest.IsChecked.Value)
            {
                // test data
                string _id = "test";
                string _pw = "a1234";
                if (id.Equals(_id) && pw.Equals(_pw))
                {
                    // 인증결과로 사용자 정보를 받아서 DataModel 에 담기
                    DataModel.GetModel().User = new User(id, "", "홍길동");
                    OnLogin(true);
                }
                else
                {
                    OnLogin(false);
                }
            }
            else
            {
                // API call 사용자 인증
                loginModel.CheckLogin(id, pw);
            }
        }

        private void OnLogin(bool success)
        {
            var viewModel = this.DataContext as LoginViewModel;
            if (success)
            {
                DataModel.GetModel().WorkCenter = viewModel.SelectedWorkCenter;
                DataModel.GetModel().IsTest = cbTest.IsChecked.Value;

                if (viewModel.IsSaveLoginInfo)
                {
                    viewModel.SaveLoginInfo();
                }
                else
                {
                    viewModel.ClearLoginInfo();
                }

                MessageBox.Show("로그인 성공\n" + DataModel.GetModel().Worker + "님 반갑습니다.");
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

        private void cbTest_Click(object sender, RoutedEventArgs e)
        {
            GetWorkCenterList();
        }
    }
}
