using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Windows.Forms;

namespace The_System_That_Knows_You_Better_Than_You___
{
    public partial class Kişilik_Özellikleri : Form
    {
        string öğrenciNumarası;
        string alanBilgisi;
        string databasePath;
        string connectionString;

        public Kişilik_Özellikleri(string alan, string öğrenciNumarası)
        {
            InitializeComponent();
            this.alanBilgisi = alan;
            this.öğrenciNumarası = öğrenciNumarası;
        }

        private void Kişilik_Özellikleri_Load(object sender, EventArgs e)
        {
            // Form yüklendiğinde yapılacak işlemler
        }

        // Her bir GroupBox'taki RadioButtonların tag değerlerini toplayan fonksiyon.
        private int HesaplaToplam(GroupBox groupBox)
        {
            int toplam = 0;
            foreach (Control control in groupBox.Controls)
            {
                if (control is FlowLayoutPanel panel)
                {
                    foreach (Control innerControl in panel.Controls)
                    {
                        if (innerControl is RadioButton radioButton && radioButton.Checked)
                        {
                            toplam += Convert.ToInt32(radioButton.Tag);
                        }
                    }
                }
                else if (control is RadioButton radioBtn && radioBtn.Checked)
                {
                    toplam += Convert.ToInt32(radioBtn.Tag);
                }
            }
            return toplam;
        }

        private void btn_sonuclarıgöster_Click_1(object sender, EventArgs e)
        {
            // Veritabanı bağlantı yolu
            databasePath = @"C:\Users\enoca\source\repos\The System That Knows You Better Than You ))\bin\Debug\OgrenciProjesi.db";
            connectionString = $"Data Source={databasePath};Version=3;";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Kişilik özelliklerini toplamak
                    int açıklıkToplam = HesaplaToplam(gropubox_açıklık);
                    int dışadönüklükToplam = HesaplaToplam(groupbox_dışadönüklük);
                    int sorumlulukToplam = HesaplaToplam(groupbox_sorumluluk);
                    int uyumlulukToplam = HesaplaToplam(groupbox_uyumluluk);
                    int duygusalDengeToplam = HesaplaToplam(groupbox_duygusaldenge);

                    // Kişilik özelliklerini veritabanına kaydetmek
                    string insertQuery = "INSERT INTO KişilikPuanları (KullanıcıId,Açıklık,Dışadönüklülük,Sorumluluk,Uyumluluk,DuygusalDenge) " +
                                         "VALUES (@kullaniciId,@aciklik,@disadonukluk,@sorumluluk,@uyumluluk,@duygusalDenge)";

                    using (SQLiteCommand cmd = new SQLiteCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@kullaniciId", öğrenciNumarası);
                        cmd.Parameters.AddWithValue("@aciklik", açıklıkToplam);
                        cmd.Parameters.AddWithValue("@disadonukluk", dışadönüklükToplam);
                        cmd.Parameters.AddWithValue("@sorumluluk", sorumlulukToplam);
                        cmd.Parameters.AddWithValue("@uyumluluk", uyumlulukToplam);
                        cmd.Parameters.AddWithValue("@duygusalDenge", duygusalDengeToplam);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Kişilik özellikleri başarıyla kaydedildi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Şimdi meslek önerisini yapalım:
                    MeslekOnerisiYap(conn, öğrenciNumarası, alanBilgisi);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Kişilik özellikleri kaydedilirken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void MeslekOnerisiYap(SQLiteConnection conn, string ogrenciNumara, string ogrenciAlan)
        {
            // 1. Öğrenci notlarını DersID bazında çekmek için Dersler tablosu ile join yapıyoruz
            Dictionary<int, double> ogrenciNotlari = new Dictionary<int, double>();

            // Notlar tablosunda DersAdı var, DersID yok. Dersler tablosundan DersID'yi join ile alacağız.
            string notQuery = @"
                SELECT d.DersID, n.NotBilgisi
                FROM Notlar n
                INNER JOIN Dersler d ON n.DersAdı = d.DersAdı
                WHERE n.Kullanıcııd=@kid;
            ";

            using (SQLiteCommand cmdNot = new SQLiteCommand(notQuery, conn))
            {
                cmdNot.Parameters.AddWithValue("@kid", ogrenciNumara);
                using (SQLiteDataReader reader = cmdNot.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int dersId = Convert.ToInt32(reader["DersID"]);
                        double notDegeri = Convert.ToDouble(reader["NotBilgisi"]);
                        ogrenciNotlari[dersId] = notDegeri;
                    }
                }
            }

            // 2. Öğrenci kişilik puanlarını çek
            int aciklik = 0, disadonukluk = 0, sorumluluk = 0, uyumluluk = 0, duygusalDenge = 0;
            string kisilikQuery = "SELECT Açıklık, Dışadönüklülük, Sorumluluk, Uyumluluk, DuygusalDenge FROM KişilikPuanları WHERE KullanıcıId=@kid ORDER BY Id DESC LIMIT 1";
            using (SQLiteCommand cmdKisilik = new SQLiteCommand(kisilikQuery, conn))
            {
                cmdKisilik.Parameters.AddWithValue("@kid", ogrenciNumara);
                using (SQLiteDataReader reader = cmdKisilik.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        aciklik = Convert.ToInt32(reader["Açıklık"]);
                        disadonukluk = Convert.ToInt32(reader["Dışadönüklülük"]);
                        sorumluluk = Convert.ToInt32(reader["Sorumluluk"]);
                        uyumluluk = Convert.ToInt32(reader["Uyumluluk"]);
                        duygusalDenge = Convert.ToInt32(reader["DuygusalDenge"]);
                    }
                }
            }

            // 3. Öğrencinin alanına uygun meslekleri getir
            List<(int MeslekID, string MeslekAdi)> meslekListesi = new List<(int, string)>();
            string meslekQuery = "SELECT MeslekID, MeslekAdi FROM Meslekler WHERE Alan=@alan";
            using (SQLiteCommand cmdMeslek = new SQLiteCommand(meslekQuery, conn))
            {
                cmdMeslek.Parameters.AddWithValue("@alan", ogrenciAlan);
                using (SQLiteDataReader reader = cmdMeslek.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int mid = Convert.ToInt32(reader["MeslekID"]);
                        string madi = reader["MeslekAdi"].ToString();
                        meslekListesi.Add((mid, madi));
                    }
                }
            }

            // 4. Her meslek için skor hesapla
            List<(string MeslekAdi, double Skor)> meslekSkorlari = new List<(string, double)>();

            foreach (var meslek in meslekListesi)
            {
                double dersPuani = 0;
                double kisilikPuani = 0;

                // MeslekDersKriterleri'ne göre ders puanı hesapla
                string dersKriterQuery = "SELECT DersID, Katsayi FROM MeslekDersKriterleri WHERE MeslekID=@mid";
                using (SQLiteCommand cmdDersKriter = new SQLiteCommand(dersKriterQuery, conn))
                {
                    cmdDersKriter.Parameters.AddWithValue("@mid", meslek.MeslekID);
                    using (SQLiteDataReader dr = cmdDersKriter.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            int dID = Convert.ToInt32(dr["DersID"]);
                            int katsayi = Convert.ToInt32(dr["Katsayi"]);

                            if (ogrenciNotlari.ContainsKey(dID))
                            {
                                dersPuani += ogrenciNotlari[dID] * katsayi;
                            }
                        }
                    }
                }

                // MeslekKişilikKriterleri'ne göre kişilik puanı hesapla
                string kisilikKriterQuery = "SELECT AciklikKatsayi, DisadonuklukKatsayi, SorumlulukKatsayi, UyumlulukKatsayi, DuygusalDengeKatsayi " +
                                            "FROM MeslekKisilikKriterleri WHERE MeslekID=@mid";
                using (SQLiteCommand cmdKisilikKriter = new SQLiteCommand(kisilikKriterQuery, conn))
                {
                    cmdKisilikKriter.Parameters.AddWithValue("@mid", meslek.MeslekID);
                    using (SQLiteDataReader kr = cmdKisilikKriter.ExecuteReader())
                    {
                        if (kr.Read())
                        {
                            int aKat = Convert.ToInt32(kr["AciklikKatsayi"]);
                            int dKat = Convert.ToInt32(kr["DisadonuklukKatsayi"]);
                            int sKat = Convert.ToInt32(kr["SorumlulukKatsayi"]);
                            int uKat = Convert.ToInt32(kr["UyumlulukKatsayi"]);
                            int ddKat = Convert.ToInt32(kr["DuygusalDengeKatsayi"]);

                            kisilikPuani = (aciklik * aKat) + (disadonukluk * dKat) + (sorumluluk * sKat) + (uyumluluk * uKat) + (duygusalDenge * ddKat);
                        }
                    }
                }

                double toplamSkor = dersPuani + kisilikPuani;
                meslekSkorlari.Add((meslek.MeslekAdi, toplamSkor));
            }

            // 5. Meslekleri skora göre sırala
            meslekSkorlari.Sort((x, y) => y.Skor.CompareTo(x.Skor)); // Yüksek skordan düşüğe

            // 6. İlk 3 mesleği göster (varsa)
            int count = Math.Min(3, meslekSkorlari.Count);
            if (count == 0)
            {
                MessageBox.Show("Uygun meslek bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // İstatistik güncellemesi yapmadan önce bu tabloyu böyle oluşturduğunuzu varsayın
                // veya veritabanında tabloyu değiştirin.

                foreach (var meslek in meslekSkorlari.Take(count))
                {
                    int meslekID = MeslekIDyiGetir(meslek.MeslekAdi, conn);
                    string updateQuery = @"
        INSERT INTO MeslekOneriIstatistik (MeslekID, OnerilmeSayisi)
        VALUES (@mid,1)
        ON CONFLICT(MeslekID)
        DO UPDATE SET OnerilmeSayisi = OnerilmeSayisi + 1;
    ";

                    using (var cmdUpdate = new SQLiteCommand(updateQuery, conn))
                    {
                        cmdUpdate.Parameters.AddWithValue("@mid", meslekID);
                        cmdUpdate.ExecuteNonQuery();
                    }
                }

                string mesaj = "Sana önerdiğimiz meslekler:\n\n";
                for (int i = 0; i < count; i++)
                {
                    mesaj += $"{i + 1}. {meslekSkorlari[i].MeslekAdi} (Skor: {meslekSkorlari[i].Skor})\n";
                }
                MessageBox.Show(mesaj, "Meslek Önerisi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Grafik_Formu grafikformu = new Grafik_Formu(); // Örnek ekran
                grafikformu.Show();
                this.Hide();
            }

        }
        private int MeslekIDyiGetir(string meslekAdi, SQLiteConnection conn)
        {
            string q = "SELECT MeslekID FROM Meslekler WHERE MeslekAdi=@madi LIMIT 1";
            using (var c = new SQLiteCommand(q, conn))
            {
                c.Parameters.AddWithValue("@madi", meslekAdi);
                return Convert.ToInt32(c.ExecuteScalar());
            }
        }
    }
}
