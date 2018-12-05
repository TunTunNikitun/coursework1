using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Coursa4Library1;

namespace Yandex.Coursa4
{
    public partial class Form1 : Form
    {
        List<Person> HumanTreat = new List<Person>();

        public Form1()
        {
            InitializeComponent();
            openFileDialog1.Filter = "XML files(*.xml)|*.xml";
            saveFileDialog1.Filter = "XML files(*.xml)|*.xml";  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                dataGridView1.Rows.RemoveAt(dataGridView1.RowCount - 1);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add();
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount == 0)
            {
                MessageBox.Show("Вы ничего не ввели", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
                
            for (int i = 0; i < dataGridView1.RowCount; i++)
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    if (dataGridView1[j, i].Value == null || dataGridView1.RowCount == 0)
                    {
                        MessageBox.Show("Не все ячейки заполнены", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                }
            for (int i = 0; i < dataGridView1.RowCount; i++ )
            {
            HumanTreat.Add(new Person());
            HumanTreat.ElementAt(i).Firstname = dataGridView1[0, i].Value.ToString();
            HumanTreat.ElementAt(i).Secondname = dataGridView1[1, i].Value.ToString();
            HumanTreat.ElementAt(i).Delivery = dataGridView1[2, i].Value.ToString();
            HumanTreat.ElementAt(i).Sname = dataGridView1[3, i].Value.ToString();
            HumanTreat.ElementAt(i).Product = dataGridView1[4, i].Value.ToString();
            HumanTreat.ElementAt(i).Count = dataGridView1[5, i].Value.ToString();
            HumanTreat.ElementAt(i).Comments = dataGridView1[6, i].Value.ToString();
            HumanTreat.ElementAt(i).Adres = dataGridView1[7, i].Value.ToString();
            HumanTreat.ElementAt(i).Car = dataGridView1[8, i].Value.ToString();
           }
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            Xml xmlSerializer = new Xml();
            xmlSerializer.Serializer(saveFileDialog1.FileName, HumanTreat);
            HumanTreat.Clear();

        }
        private void Delete(int Row)
        {
            this.dataGridView1.SuspendLayout();
            for (int i = 0; i < Row; i++)
            {
                if (dataGridView1.RowCount > 0)
                {
                    dataGridView1.Rows.RemoveAt(dataGridView1.RowCount - 1);                     
                }
            }
            this.dataGridView1.ResumeLayout(false);
            this.dataGridView1.PerformLayout();
        }
        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            Delete(dataGridView1.RowCount - 2);
            Xml xmlDeSerializer = new Xml();
            HumanTreat = xmlDeSerializer.DeSerializer(openFileDialog1.FileName, HumanTreat);
            for (int i = 0; i < HumanTreat.Count; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1[0, i].Value = HumanTreat.ElementAt(i).Firstname;//[0,i].Value.ToString();
                dataGridView1[1, i].Value = HumanTreat.ElementAt(i).Secondname;
                dataGridView1[2, i].Value = HumanTreat.ElementAt(i).Delivery;
                dataGridView1[3, i].Value = HumanTreat.ElementAt(i).Sname; 
                dataGridView1[4, i].Value = HumanTreat.ElementAt(i).Product;
                dataGridView1[5, i].Value = HumanTreat.ElementAt(i).Count;
                dataGridView1[6, i].Value = HumanTreat.ElementAt(i).Comments;
                dataGridView1[7, i].Value = HumanTreat.ElementAt(i).Adres;
                dataGridView1[8, i].Value = HumanTreat.ElementAt(i).Car;

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void всеПоляДолжныБытьЗаполненыЕслиНетДанныхНеоьходимоСтавитьПрочеркToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
