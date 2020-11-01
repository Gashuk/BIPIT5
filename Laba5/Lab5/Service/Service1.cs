using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Service
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде и файле конфигурации.
    public class Service1 : IService1
    {
        string connectionString = @"workstation id=Bipit33333.mssql.somee.com;packet size=4096;user id=Gashuk_SQLLogin_1;pwd=7jv4k2zihb;data source=Bipit33333.mssql.somee.com;persist security info=False;initial catalog=Bipit33333";

        public DataTable GetData()
        {
            var query = "Select ID_RABOT, Firma_oboryd, Model_oboryd , Name_vid_rabot ," +
               "format(Data_polychen, 'dd.MM.yyyy') , format(DATEADD(day, Plan_vid_rabot , Data_polychen), 'dd.MM.yyyy') , format(Data_vipolnen, 'dd.MM.yyyy') ," +
               " CASE WHEN DATEDIFF(day, Data_vipolnen , DATEADD(day, Plan_vid_rabot , Data_polychen)) > 0  then  0 ELSE -DATEDIFF(day, Data_vipolnen , DATEADD(day, Plan_vid_rabot , Data_polychen)) END ," +
               " Cost_vid_rabot ," +
               " CASE WHEN DATEDIFF(day, Data_vipolnen , DATEADD(day, Plan_vid_rabot , Data_polychen)) < 0  then  Cost_vid_rabot + (Cost_vid_rabot * (0.05 * DATEDIFF(day, Data_vipolnen , DATEADD(day, Plan_vid_rabot , Data_polychen)))) " +
               "ELSE Cost_vid_rabot END  from  Oboryd, Vid_rabot, Rabot  WHERE  Rabot.ID_oboryd = Oboryd.ID_OBORYD AND Rabot.ID_vid_rabot = Vid_rabot.ID_VID_RABOT";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            dt.TableName = "Rabot";
                            sda.Fill(dt);
                            return dt;
                        }
                    }
                }
            }            
        }

        public DataTable FillOboryd()
        {
            string query = "SELECT * FROM Oboryd";
            using (SqlConnection path = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        command.Connection = path;
                        sda.SelectCommand = command;
                        using (DataTable dt = new DataTable())
                        {
                            dt.TableName = "Oboryd";
                            sda.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
        }

        public DataTable FillVid_rabot()
        {
            string query = "SELECT * FROM Vid_rabot";
            using (SqlConnection path = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        command.Connection = path;
                        sda.SelectCommand = command;
                        using (DataTable dt = new DataTable())
                        {
                            dt.TableName = "Vid_rabot";
                            sda.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
        }



        public void InsertMethod(string ID_OBORYD, string ID_VID_RABOT, string Data_polychen, string Data_vipolnen)
        {
            var query = $"INSERT INTO Rabot VALUES ({ID_OBORYD},{ID_VID_RABOT},'{Data_polychen}','{Data_vipolnen}')";
            var connect = new SqlConnection(connectionString);
            connect.Open();
            SqlCommand command = connect.CreateCommand();
            command.CommandText = query;
            command.ExecuteNonQuery();
            connect.Close();
        }


        
    }
}
