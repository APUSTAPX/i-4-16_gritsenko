using System;
using System.Windows;
using System.Windows.Controls;

namespace Zoo
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DB db = new DB();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int role = db.Avtorization(TBLogin.Text, PasswordBox.Password);
            if (role == 0)
            {
                MessageBox.Show("Неверная комбинация логина и пароля!");
                return;
            }
            else showTable(role);
        }

        private void showTable(int role)
        {
            Table table = new Table(this);
            Hide();
            table.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Reg reg = new Reg(this);
            this.Hide();
            reg.Show();
        }
    }
}
