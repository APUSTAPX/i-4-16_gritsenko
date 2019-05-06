using System;
using System.Data;
using System.Windows;

namespace Zoo
{
    public partial class Table : Window
    {
        DB db = new DB();
        MainWindow mn;
        
        public Table(MainWindow mn)
        {
            InitializeComponent();
            this.mn = mn;
            CBType.ItemsSource = db.getTypeBilet();
            CBType.SelectedIndex = 0;
        }
        

        private void Window_Closed(object sender, EventArgs e)
        {
            mn.Close();
        }

        private void CBType_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            string[] str = new string[3];
            DataRow row = db.getInfoBiletType(CBType.SelectedValue.ToString()).Rows[0];
            LBInfo.Content = db.getFilledInfo(row);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            BuyBilet bb = new BuyBilet(db.getInfoBiletType(CBType.SelectedValue.ToString()).Rows[0], this);
            //BuyedTicket();
            this.Hide();
            bb.Show();
        }

        public string BuyedTicket()
        {
            return db.addTicket((int)db.getInfoBiletType(CBType.SelectedValue.ToString()).Rows[0].ItemArray[0]);
        }
    }
}
