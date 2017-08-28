using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System;

public class ReadData : MonoBehaviour
{
       
    public class weatherinfo : Singleton<weatherinfo>
    {
        public double weather_cloudCirrusAmt;//(0.0-1.0)
        public double weather_cloudCumulusAmt ;//(0.0-1.0)
        public double weather_OvercastAmt;
        public double weather_cloudScale;
        public double weather_cloudSpeed;
        public double weather_RainAmt;// (0.0-1.0)
        public double weather_SnowAmt;// (0.0-1.0)
        public double weather_FogAmt;// (0.0-1.0)
        public double weather_WindAmt;// (0.0-1.0)
        public double weather_WindDir;// (0.0-360.0)
        public string datecon;

        void Start()
        {               
        }

        void Update()
        {
            string year = TimeManager.Instance.Year.ToString();
            string month = TimeManager.Instance.Month.ToString();
            string day = TimeManager.Instance.Day.ToString();
            datecon = day + '/' + month + '/' + year;
            getWeather("WeatherData", datecon);
           
        }
        public void getWeather(string tableName, string condition) {
        
            string conn = "data source=testWD.db";
            IDbConnection dbconn;
            dbconn = (IDbConnection)new SqliteConnection(conn);
            dbconn.Open(); //Open connection to the database.
            Debug.Log(dbconn.State);
            IDbCommand dbcmd = dbconn.CreateCommand();            
            string sqlQuery = "SELECT * FROM " + tableName + " WHERE WDate = '" + condition + "';";
            Debug.Log(sqlQuery);
            dbcmd.CommandText = sqlQuery;
            IDataReader reader = dbcmd.ExecuteReader();
          //  if (!reader.Read()) Debug.Log("failed to open");
            while (reader.Read())
            {
               // double testdata=reader.GetDouble(reader.GetOrdinal("weather_WindAmt"));
                  weatherinfo.Instance.weather_cloudCirrusAmt = reader.GetDouble(reader.GetOrdinal("weather_cloudCirrusAmt"));
                  weatherinfo.Instance.weather_cloudCumulusAmt = reader.GetDouble(reader.GetOrdinal("weather_cloudCumulusAmt"));
                  weatherinfo.Instance.weather_OvercastAmt = reader.GetDouble(reader.GetOrdinal("weather_OvercastAmt"));
                  weatherinfo.Instance.weather_cloudScale = reader.GetDouble(reader.GetOrdinal("weather_cloudScale"));
                  weatherinfo.Instance.weather_cloudSpeed = reader.GetDouble(reader.GetOrdinal("weather_cloudSpeed"));
                  weatherinfo.Instance.weather_RainAmt = reader.GetDouble(reader.GetOrdinal("weather_RainAmt"));
                  weatherinfo.Instance.weather_SnowAmt = reader.GetDouble(reader.GetOrdinal("weather_SnowAmt"));
                  weatherinfo.Instance.weather_FogAmt = reader.GetDouble(reader.GetOrdinal("weather_FogAmt"));
                  weatherinfo.Instance.weather_WindAmt = reader.GetDouble(reader.GetOrdinal("weather_WindAmt"));
                  weatherinfo.Instance.weather_WindDir = reader.GetDouble(reader.GetOrdinal("weather_WindDir"));                 
            }
            reader.Close();
            reader = null;
            dbcmd.Dispose();
            dbcmd = null;
            dbconn.Close();
            dbconn = null;
        }
        
    }
}