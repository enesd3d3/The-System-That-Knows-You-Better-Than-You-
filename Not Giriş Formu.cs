using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace The_System_That_Knows_You_Better_Than_You___
{
    public partial class Not_Giriş_Formu : Form
    {
        string databasePath;
        string connectionString;
        string alanBilgisi;
        string öğrenciNumarası;
        
        
        public Not_Giriş_Formu(string alan,string öğrenciNumarası)
        {
            InitializeComponent();
            this.alanBilgisi = alan;
            this.öğrenciNumarası = öğrenciNumarası;
            
        }

        public Not_Giriş_Formu(string alan)
        {
        }

        private void Not_Giriş_Formu_Load(object sender, EventArgs e)
        {
            // Veritabanı bağlantı yolu
            databasePath = @"C:\Users\enoca\source\repos\The System That Knows You Better Than You ))\bin\Debug\OgrenciProjesi.db";
            connectionString = $"Data Source={databasePath};Version=3;";

            // Öğrenci alanına göre dersleri yükle
            DersleriYukle(alanBilgisi);

        }

        private void DersleriYukle(string alanBilgisi)
        {
            
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();

                    // Dersleri getiren SQL sorgusu (Alanına göre dersler)
                    string query;
                    if (alanBilgisi == "Sayısal")
                    {
                        query = "SELECT DersAdı FROM Dersler WHERE Alan = 'Sayısal'";
                    }
                    else if (alanBilgisi == "Eşit Ağırlık")
                    {
                        query = "SELECT DersAdı FROM Dersler WHERE Alan = 'EşitAğırlık'";
                    }
                    else
                    {
                        // Alan Yok veya Belirsiz durumunda genel ders listesi yüklenir
                        query = "SELECT DersAdı FROM Dersler WHERE Alan = 'Belirsiz'";
                    }

                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@alan", alanBilgisi);

                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Dersleri DataGridView'e ekle
                                data_gridNotlar.Rows.Add(reader["DersAdı"].ToString(), ""); // Not sütunu boş
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dersler yüklenirken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void data_gridNotlar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_kaydetvedevamet_Click_1(object sender, EventArgs e)
        {
            try
            {
                int ogrenciNumarasi = Convert.ToInt32(öğrenciNumarası); // Öğrenci numarasını alıyoruz

                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();

                    // Her bir satırdaki ders adı ve notu kaydet
                    foreach (DataGridViewRow row in data_gridNotlar.Rows)
                    {
                        if (row.IsNewRow) continue; // Yeni boş satırları atla

                        string dersAdi = row.Cells[0].Value?.ToString();
                        string notDegeri = row.Cells[1].Value?.ToString();

                        // Notu veritabanına ekleme sorgusu
                        string insertQuery = "INSERT INTO Notlar (Kullanıcııd, DersAdı, NotBilgisi) VALUES (@kullaniciId, @dersadı, @notbilgisi)";

                        using (SQLiteCommand insertCmd = new SQLiteCommand(insertQuery, conn))
                        {
                            // Öğrenci ID'sini burada ekliyoruz
                            insertCmd.Parameters.AddWithValue("@kullaniciId", ogrenciNumarasi); // Öğrenci numarasını KullanıcıId olarak ekliyoruz
                            insertCmd.Parameters.AddWithValue("@dersadı", dersAdi); // Bulunan Ders adı
                            insertCmd.Parameters.AddWithValue("@notbilgisi", notDegeri); // Girilen Not

                            insertCmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Notlar başarıyla kaydedildi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Kişilik_Özellikleri kişiliközellikleri = new Kişilik_Özellikleri(alanBilgisi,öğrenciNumarası); // Örnek ekran
                    kişiliközellikleri.Show();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Notlar kaydedilirken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}

