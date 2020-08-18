﻿using ONBOXAppl;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace ONBOXAppl
{
    /// <summary>
    /// Interaction logic for AboutUI.xaml
    /// </summary>
    public partial class AboutUI : Window
    {
        public AboutUI()
        {
            InitializeComponent();
        }

        private void AboutWindow_Loaded(object sender, RoutedEventArgs e)
        {
            string appVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            this.Title = Properties.WindowLanguage.About_Title + " " + appVersion;
            lblVersionInfo.Text = appVersion;
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.onboxdesign.com.br/");
        }

        private void btnLicense_Click(object sender, RoutedEventArgs e)
        {
            if (ONBOXApplication.isRegister)
            {
                MessageBoxResult warning = MessageBox.Show(Properties.Messages.About_LicenseConfirm, Properties.Messages.Common_Warning, MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                if (warning == MessageBoxResult.OK)
                {
                    try
                    {
                        File.Delete(ONBOXApplication.licenseFile);
                    }
                    catch (System.Exception)
                    {
                    }
                    ONBOXApplication.isRegister = false;
                    this.DialogResult = true;
                }
            }
        }

        /// <summary>
        /// 点击youtube——中转到youtube网页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void imgYoutube_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/user/mrthiagokurumada");
        }

        /// <summary>
        /// 点击onbox图片——跳转到主页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void imgOnbox_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.onboxdesign.com.br/");
        }

        /// <summary>
        /// 点击mail图片——跳转到联系
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void imgMail_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.onboxdesign.com.br/contato/");
        }
    }
}