using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class From1 : Form
    {
        public From1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Fill();
        }

        public void Fill()
        {
            var s = new ServiceReference1.Service1Client();
            dataGridView1.DataSource = s.GetData();
            dataGridView1.Columns[0].HeaderText = "Код работы";
            dataGridView1.Columns[1].HeaderText = "Фирма оборудования";
            dataGridView1.Columns[2].HeaderText = "Модель оборудования";
            dataGridView1.Columns[3].HeaderText = "Название вида работ";
            dataGridView1.Columns[4].HeaderText = "Дата получения";
            dataGridView1.Columns[5].HeaderText = "Дата по плану";
            dataGridView1.Columns[6].HeaderText = "Дата выполнения";
            dataGridView1.Columns[7].HeaderText = "Кол-во просроченных дней";
            dataGridView1.Columns[8].HeaderText = "Цена по плану";
            dataGridView1.Columns[9].HeaderText = "Цена итогавая";
            dataGridView1.Update();
            comboBox1.DataSource = s.FillVid_rabot();
            comboBox1.DisplayMember = "Vid_rabot";
            comboBox1.ValueMember = "ID_VID_RABOT";
            comboBox2.DataSource = s.FillOboryd();
            comboBox2.DisplayMember = "Model_oboryd";
            comboBox2.ValueMember = "ID_OBORYD";

        }    

        private void Button_add_Click(object sender, EventArgs e)
        {
            comboBox1.Validating += comboBox1_Validating;
            comboBox2.Validating += comboBox2_Validating;
            var s = new ServiceReference1.Service1Client();
            string ID_OBORYD = comboBox1.SelectedValue.ToString();
            string ID_VID_RABOT = comboBox2.SelectedValue.ToString();
            string Data_polychen = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string Data_vipolnen = dateTimePicker2.Value.ToString("yyyy-MM-dd");

            s.InsertMethod(ID_OBORYD, ID_VID_RABOT, Data_polychen, Data_vipolnen);
            Fill();
        }



         private void comboBox1_Validating(object sender, CancelEventArgs e)
         {
             if (String.IsNullOrEmpty(comboBox1.Text))
             {
                 errorProvider1.SetError(comboBox1, "Не указана модель оборудования!!!");
                 return;
             }
             errorProvider1.Clear();       
         }

         private void comboBox2_Validating(object sender, CancelEventArgs e)
         {
             if (String.IsNullOrEmpty(comboBox2.Text))
             {
                 errorProvider2.SetError(comboBox2, "Не указан вид работы!!!");
                 return;
             }
             errorProvider2.Clear();

         }


    }
}
