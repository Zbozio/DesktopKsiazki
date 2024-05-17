using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DesktopKsiazki
{
   

    public partial class Form1 : Form
    {
        private string connectionString = "Data Source=HP-GAMING\\SQLEXPRESS;Initial Catalog=NowaAplikacjaDesktop;Integrated Security=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private string textBox1Value = string.Empty;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PopulateComboBox();
           
            this.button1.Click += new System.EventHandler(this.button1_Click);

            WypelnijDataGridView();
        }

        private void PopulateComboBox()
        {
         
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT
                         K.ID_KSIAZKA AS 'ID Ksi¹¿ki',
                         K.TYTUL AS 'Tytu³ Ksi¹¿ki',
                         G.NAZWA_GATUNKU AS 'Gatunek',
                         K.ILOSC_STRON AS 'Iloœæ Stron',
                         K.ROK_WYDANIA AS 'Data Wydania'
                     FROM
                         KSIAZKA AS K
                     JOIN
                         GATUNKOWOSC AS GK ON K.ID_KSIAZKA = GK.ID_KSIAZKA
                     JOIN
                         GATUNEK AS G ON GK.ID_GATUNKU = G.ID_GATUNKU";

              
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();

                try
                {
                   
                    connection.Open();

                
                    adapter.Fill(dataTable);

                    
                    foreach (DataRow row in dataTable.Rows)
                    {
                        comboBox1.Items.Add(new KsiazkaComboBoxItem
                        {
                            DisplayText = $"{row["Tytu³ Ksi¹¿ki"]} - Gatunek: {row["Gatunek"]}, Strony: {row["Iloœæ Stron"]}, Data Wydania: {((DateTime)row["Data Wydania"]).ToShortDateString()}",
                            IdKsiazki = Convert.ToInt32(row["ID Ksi¹¿ki"])
                        });
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("B³¹d podczas pobierania danych z bazy danych: " + ex.Message);
                }
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            int wartoscOceny = (int)numericUpDown1.Value;
            int idUzytkownika = 2; 
            string opinia = textBox1.Text;

            if (comboBox1.SelectedItem is KsiazkaComboBoxItem selectedComboItem)
            {
                int idKsiazki = selectedComboItem.IdKsiazki;
                

                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                       

                        try
                        {
                            string insertOcenaQuery = "INSERT INTO OCENA (ID_UZYTKOWNIK, ID_KSIAZKA, OCENA, OPINIA) VALUES (@IdUzytkownika, @IdKsiazki, @WartoscOceny, @Opinia)";
                            using (SqlCommand commandOcena = new SqlCommand(insertOcenaQuery, connection))
                            {
                                commandOcena.Parameters.AddWithValue("@IdUzytkownika", idUzytkownika);
                                commandOcena.Parameters.AddWithValue("@IdKsiazki", idKsiazki);
                                commandOcena.Parameters.AddWithValue("@WartoscOceny", wartoscOceny);
                                commandOcena.Parameters.AddWithValue("@Opinia", opinia);

                                commandOcena.ExecuteNonQuery();
                                MessageBox.Show("Ocena zosta³a dodana pomyslnie!");
                            }

                        
                        }
                        catch (Exception ex)
                        {
                           

                            MessageBox.Show("B³¹d podczas dodawania oceny, aktualizowania statusu ksi¹¿ki i przypisywania statusu u¿ytkownikowi: " + ex.Message);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("B³¹d podczas otwierania po³¹czenia: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Proszê wybraæ ksi¹¿kê i status z listy.");
            }
        }





        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1Value = textBox1.Text;
        }

        private void WypelnijDataGridView()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                int idUzytkownika = 2;

                string query = @"
            SELECT
                    K.TYTUL AS 'Tytu³ Ksi¹¿ki',
                    O.OPINIA AS 'OPINIA',
                    O.OCENA AS 'OCENA',
                    G.NAZWA_GATUNKU AS 'Gatunek',
                    K.ILOSC_STRON AS 'Iloœæ Stron',
                    K.ROK_WYDANIA AS 'Data Wydania'
                FROM
                    KSIAZKA AS K
                JOIN
                    GATUNKOWOSC AS GK ON K.ID_KSIAZKA = GK.ID_KSIAZKA
                JOIN
                    GATUNEK AS G ON GK.ID_GATUNKU = G.ID_GATUNKU
                JOIN 
                    OCENA AS O ON O.ID_KSIAZKA = K.ID_KSIAZKA
                JOIN 
                    UZYTKOWNIK AS U ON U.ID_UZYTKOWNIK = O.ID_UZYTKOWNIK
                WHERE
                    U.ID_UZYTKOWNIK = 2
                ";
            
               

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();

                try
                {
                    connection.Open();

                    

                    adapter.Fill(dataTable);

                   
                    dataGridView1.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("B³¹d podczas pobierania danych z bazy danych: " + ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    WypelnijDataGridView();

                    MessageBox.Show("Baza danych zosta³a zaktualizowana pomyœlnie!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("B³¹d podczas aktualizacji bazy danych: " + ex.Message);
                }
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown1.Value > 10)
            {
                numericUpDown1.Value = 10;
            }
        }
    }
    public class KsiazkaComboBoxItem
    {
        public string DisplayText { get; set; }
        public int IdKsiazki { get; set; }

        public override string ToString()
        {
            return DisplayText;
        }
    }
}
