using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;


namespace The_System_That_Knows_You_Better_Than_You___
{


    public partial class Öğrenci_girişi : Form
    {
        string databasePath;
        string connectionString;
        

        public Öğrenci_girişi()
        {
            InitializeComponent();
        }
        private void Öğrenci_girişi_Load(object sender, EventArgs e)
        {
            databasePath = @"C:\Users\enoca\source\repos\The System That Knows You Better Than You ))\bin\Debug\OgrenciProjesi.db";
            connectionString = $"DataSource = {databasePath}";
        }

        private void burayatıkla_btn_Click(object sender, EventArgs e)
        {
            Buraya_tıkla buraya_Tıkla = new Buraya_tıkla();
            buraya_Tıkla.Show();
        }

        private void btn_giris_Click(object sender, EventArgs e)
        {

            // Kullanıcıdan alınan bilgiler
            string numara = txtbox_numara.Text.Trim();
            string ad = txtbox_name.Text.Trim();
            string soyad = txtbox_surname.Text.Trim();
            string alan = ""; // Seçilen alan

            // Radiobutton'lar üzerinden alanı belirleme
            if (rdbtn_sayisal.Checked)
                alan = "Sayısal";
            else if (rdbtn_esitagirlik.Checked)
                alan = "Eşit Ağırlık";
            else if (rdbtn_alanimyok.Checked)
                alan = "Belirsiz"; // "Alanım Yok" seçildiğinde de Belirsiz olarak ata
            else if (rdbtn_memnundegilim.Checked)
                alan = "Belirsiz"; // "Alanımdan Memnun Değilim" seçildiğinde de Belirsiz



            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();

                    // Öğrenci bilgilerini kontrol eden sorgu
                    string query = "SELECT COUNT(*) FROM Öğrenciler WHERE Numara = @numara AND Ad = @ad";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@numara", numara);
                        cmd.Parameters.AddWithValue("@ad", ad);
                       

                        // Sonucu kontrol et
                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        if (count > 0)
                        {
                            MessageBox.Show("Giriş başarılı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Burada bir sonraki ekrana yönlendirebilirsiniz (ör. Not Giriş Ekranı)
                            Not_Giriş_Formu notGirisi = new Not_Giriş_Formu(alan, txtbox_numara.Text); // Örnek ekran
                            notGirisi.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show($"Numara: {numara}, Ad: {ad}, Alan: {alan}");
                            MessageBox.Show("Hatalı giriş. Lütfen bilgilerinizi kontrol edin!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
    }
}


