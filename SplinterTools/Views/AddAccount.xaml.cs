using SplinterTools.Helpers;
using System;
using System.Windows;


namespace SplinterTools
{
    /// <summary>
    /// Interaction logic for addAccount.xaml
    /// </summary>
    public partial class AddAccount : Window
    {

        public event Action<AddAccount> SaveData;


        public AddAccount()
        {
            InitializeComponent();
        }

        public void ShowAddWindow()
        {
            Show();
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            Processors.AccountDetailsProcessor.updateAccounts(txtAccount.Text, Convert.ToInt32(txtPOwer.Text));
            SaveData.Invoke(this);
            this.Close();
        }
    }
}
