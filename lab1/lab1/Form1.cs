using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace lab2
{
    public partial class Form1 : Form
    {
        SqlConnection connection;
        SqlCommand command;
        SqlDataAdapter adapter;
        DataTable table;
        public Form1()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = true;
            // УКАЖИТЕ СВОЙ АДРЕС СЕРВЕРА ИЗ СРЕДЫ SSMS!
            connection = new SqlConnection("Server=DESKTOP-SMSF93E\\SQLEXPRESS;Database=aero;Trusted_Connection=True;");
            command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            adapter = new SqlDataAdapter(command);
            table = new DataTable();
            dataGridView1.DataSource = table;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.tripTableAdapter.Fill(this.aeroDataSet.Trip);
        }
        private void ShowTable(string text)
        {
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = null;
            command.CommandText = text;
            table.Clear();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }
        private void company_click(object sender, EventArgs e)
        {
            ShowTable("SELECT * FROM Company");
        }
        private void add_Click(object sender, EventArgs e)
        {
            connection.Open();
            command.CommandText = "INSERT INTO Company VALUES (\'" + name.Text + "\');";
            command.ExecuteReader();
            connection.Close();
            ShowTable("SELECT * FROM Company");
        }
        private void delete_Click(object sender, EventArgs e)
        {
            connection.Open();
            command.CommandText = "DELETE FROM Company WHERE ID_comp>= 6";
            command.ExecuteReader();
            connection.Close();
            ShowTable("SELECT * FROM Company");
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "aeroDataSet1.Trip". При необходимости она может быть перемещена или удалена.
            this.tripTableAdapter.Fill(this.aeroDataSet1.Trip);

        }
    }
}

