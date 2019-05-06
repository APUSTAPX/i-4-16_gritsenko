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
using System;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Data;

namespace Zoo
{
    /// <summary>
    /// Логика взаимодействия для Mail.xaml
    /// </summary>
    public partial class Mail : Window
    {
        Window wm;
        DataRow row;
        Table table; 

        public Mail(Window wm, DataRow row, Table table)
        {
            InitializeComponent();
            this.wm = wm;
            this.row = row;
            this.table = table;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // отправитель - устанавливаем адрес и отображаемое в письме имя
                MailAddress from = new MailAddress("zoopark-2019@mail.ru", "Зоопарк!");
                // кому отправляем
                MailAddress to = new MailAddress(TBMail.Text);
                // создаем объект сообщения
                MailMessage m = new MailMessage(from, to);
                // тема письма
                m.Subject = "Зоопарк!";
                // текст письма
                m.Body = table.BuyedTicket();
                // письмо представляет код html
                m.IsBodyHtml = true;
                // адрес smtp-сервера и порт, с которого будем отправлять письмо
                SmtpClient smtp = new SmtpClient("smtp.mail.ru", 587);
                // логин и пароль
                smtp.Credentials = new NetworkCredential("zoopark-2019@mail.ru", "Zoo228");
                smtp.EnableSsl = true;
                smtp.Send(m);
                MessageBox.Show("Билет успешно куплен!");
                Close();
            }
            catch { MessageBox.Show("Ошибка!"); }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            wm.Close();
        }
    }
}
