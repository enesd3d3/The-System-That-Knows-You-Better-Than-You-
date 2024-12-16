using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace The_System_That_Knows_You_Better_Than_You___
{
    public partial class Grafik_Formu : Form
    {
        string databasePath;
        string connectionString;
        public Grafik_Formu()
        {
            InitializeComponent();
            
        }

        private void sonucgrafiği_Click(object sender, EventArgs e)
        {

        }

        private void Grafik_Formu_Load(object sender, EventArgs e)
        {
            databasePath = @"C:\Users\enoca\source\repos\The System That Knows You Better Than You ))\bin\Debug\OgrenciProjesi.db";
            connectionString = $"Data Source={databasePath};Version=3;";
            // Grafiği temizle veya başlat
            sonucgrafiği.Series.Clear();

            // Bir seri oluştur
            Series seri = new Series("Meslek Önerilme Sayıları");
            seri.ChartType = SeriesChartType.Column; // Bar veya Column tipi seçilebilir
            sonucgrafiği.Series.Add(seri);

            // Veritabanından istatistikleri çek
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = @"
                SELECT m.MeslekAdi, i.OnerilmeSayisi
                FROM MeslekOneriIstatistik i
                INNER JOIN Meslekler m ON m.MeslekID = i.MeslekID
                ORDER BY i.OnerilmeSayisi DESC
            ";

                using (var cmd = new SQLiteCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string meslekAdi = reader["MeslekAdi"].ToString();
                        int sayi = Convert.ToInt32(reader["OnerilmeSayisi"]);

                        // Chart serisine data noktası ekle
                        seri.Points.AddXY(meslekAdi, sayi);
                    }
                }
            }

            // İsteğe göre grafiğin eksen başlıklarını ayarla
            sonucgrafiği.ChartAreas[0].AxisX.Title = "Meslekler";
            sonucgrafiği.ChartAreas[0].AxisY.Title = "Önerilme Sayısı";
        }
    }
}
