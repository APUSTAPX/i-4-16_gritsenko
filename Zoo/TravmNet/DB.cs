using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows;
using Word = Microsoft.Office.Interop.Word;

namespace Zoo
{
    class DB
    {
        public SqlConnection sql = new SqlConnection(string.Format("Data Source = {0}; Initial Catalog = {1}; Persist Security Info = {2}; integrated security = {3}", "Home", "Zoopark", "True", "True"));
        private static string Auth = "select Role_ID from Users where [Login] = '{0}' and [Password] = '{1}'";
        private static string Reg = "begin if ((select count([Login]) from dbo.Users where[Login] = '{0}') > 0) select 0 else begin insert into Users([Login], [Password], [Role_ID]) values('{0}', '{1}', 1) select 1 end end";
        private static string TypeBilet = "select [Name] from Ticket_types";
        private static string InfoBiletType = "select ID_Ticket_Type as 'Номер', Adults_Num as 'Взрослые', Kids_Num as 'Дети', Cost as 'Цена' from Ticket_types where [Name] = '{0}'";
        private static string AddTicket = "insert into Sold_Tickets([Ticket_Num], Date_Of_Sale, Ticket_Type_ID) values ({0}, '{1}', {2})";
        private static string StringInfoRaz = "Кол-во взрослых: {1}\nКол-во детей: {2}\nСтоимость билета: {3}";
        private static string TicketView = "select Ticket_Num as 'Номер билета', Date_of_Sale as 'Дата', [Name] as 'Наименование', Adults_Num as 'Кол-во взрослых', Kids_Num as 'Кол-во детей', Cost as 'Стоимость' from Sold_Tickets join Ticket_types on ID_Ticket_Type = Ticket_Type_ID where ID_Ticket = {0}";
        private static string ViewT = "Номер билета: {0}; Дата покупки: {1}; Наименование: {2}; Кол-во взрослых: {3}; Кол-во детей: {4}; Стоимость: {5} рублей.";

        public DB()
        {
            sql.Open();
        }

        ~DB()
        {
            try
            {
                sql.Close();
            }
            catch { }
        }

        public int Avtorization(string Login, string Password)
        {
            try
            {
                return (int)new SqlCommand(String.Format(Auth, Login, Password), sql).ExecuteScalar();
            }
            catch { return 0; }
        }

        public int Registration(string Login, string Password)
        {
            try
            {
                return (int)new SqlCommand(String.Format(Reg, Login, Password), sql).ExecuteScalar();
            }
            catch { return -1; }
        }

        public string[] getTypeBilet()
        {
            DataTable dt = new DataTable();
            dt.Load((SqlDataReader)new SqlCommand(TypeBilet, sql).ExecuteReader());
            string[] str = new string[dt.Rows.Count];
            byte i = 0;
            foreach (DataRow row in dt.Rows)
                str[i++] += row[0].ToString();
            return str;
        }


        public DataTable getInfoBiletType(string BiletName)
        {
            DataTable dt = new DataTable();
            dt.Load((SqlDataReader)new SqlCommand(String.Format(InfoBiletType, BiletName), sql).ExecuteReader());
            return dt;
        }

        public string getFilledInfo(DataRow row)
        {
            return string.Format(StringInfoRaz, row.ItemArray);
        }

        public string addTicket(int num)
        {
            new SqlCommand(string.Format(AddTicket, new Random().Next(100000, 999999), DateTime.Now.ToShortDateString(), num), sql).ExecuteNonQuery();
            DataTable dataTable = new DataTable();
            dataTable.Load((SqlDataReader)new SqlCommand(String.Format(TicketView, (int)new SqlCommand("SELECT MAX(ID_Ticket) from Sold_Tickets", sql).ExecuteScalar()), sql).ExecuteReader());
            return string.Format(ViewT, dataTable.Rows[0].ItemArray);
        }
    }
        
}
