using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Invoice_Matcher
{
    public class MyDbConnect
    {
        readonly string ConnStr;
        readonly MySqlConnection Conn;
        public MyDbConnect(string connStr)
        {
            ConnStr = connStr; //format "server=...;user=...;database=...;port=...;password=..."
            Conn = new MySqlConnection(connStr); //creates our connection
        }
        public List<object> SearchCommand(string po)
        {//will return the result of the first collumn as a list, must be a valid MySQL Query
            var resultsList = new List<object>();
            try
            {
                Conn.Open();
                var cmd = new MySqlCommand("SELECT * FROM po_match WHERE po_number=" + po, Conn);
                var rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    resultsList.Add(rdr[0]);
                    resultsList.Add(rdr[1]);
                    resultsList.Add(rdr[2]);
                    resultsList.Add(rdr[3]);
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            Conn.Close();
            return resultsList;
        }
        public void AddEntries(string value)
        {
            try
            {
                Conn.Open();
                var cmd = new MySqlCommand("INSERT INTO po_match (po_number, invoice, po, filed) VALUES " + value, Conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            Conn.Close();
        }
        public void ChangeRow(string column, string po, string value)
        {
            try
            {
                Conn.Open();
                var cmd = new MySqlCommand("UPDATE po_match SET " + column + "='" + value + "' WHERE po_number = " + po, Conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            Conn.Close();
        }
    }
}
