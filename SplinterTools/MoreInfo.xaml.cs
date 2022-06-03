﻿using SplinterTools.Helpers;
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

namespace SplinterTools
{
    /// <summary>
    /// Interaction logic for MoreInfo.xaml
    /// </summary>
    public partial class MoreInfo : Window
    {
        public event Action<MoreInfo> NextAccount;

        public event Action<MoreInfo> PrevAccount;

        public MoreInfo()
        {
            InitializeComponent();
        }

        public UserModel UserModel { get; set; }

        public void ShowAccount(UserModel user)
        {
            UserModel = user;
            TxbAccount.Text = $"{UserModel.Name}";
            Show();
        }

        private void BtnPrev_Click(object sender, RoutedEventArgs e)
        {
            PrevAccount.Invoke(this);


        }

        private void BtnNext_Click(object sender, RoutedEventArgs e)
        {
            NextAccount.Invoke(this);
        }
    }


}
