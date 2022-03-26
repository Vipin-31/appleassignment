using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using MySql.Data;

namespace apple.Controllers
{
    public class DataAccess
    {
        string conString;
        MySqlConnection ACon;
        MySqlCommand ACom;
        MySqlDataAdapter AAdapter;

        public DataAccess()
        {
            conString = "server=localhost;user id=root;database=apple;pwd=;";
            ACon = new MySqlConnection(conString);
            ACom = new MySqlCommand();
            ACom.Connection = ACon;
            AAdapter = new MySqlDataAdapter(ACom);

        }
        public List<Models.AppleData> GetAppleDatas(string date)
        {
            List<Models.AppleData> appleList = new List<Models.AppleData>();
            
            DataTable dataTable = new DataTable();
            ACom.CommandText = "select * from appletable where date=@date;";
            ACom.CommandType = CommandType.Text;
            ACom.Parameters.AddWithValue("@date", date);
            try
            {
                ACon.Open();
                AAdapter.Fill(dataTable);
                foreach(DataRow row in dataTable.Rows)
                {
                    Models.AppleData aobj = new Models.AppleData();
                    aobj.Date = row["date"].ToString();
                    aobj.Open = row["open"].ToString();
                    aobj.High = row["high"].ToString();
                    aobj.Low = row["low"].ToString();
                    aobj.Close = row["close"].ToString();
                    aobj.AdjClose = row["adjclose"].ToString();
                    aobj.Volume = row["volume"].ToString();
                    appleList.Add(aobj);
                }
            }
            catch(Exception e)
            {
                dataTable = null;
            }
            finally
            {
                ACon.Close();
            }
            return appleList;
        }
    }
}
