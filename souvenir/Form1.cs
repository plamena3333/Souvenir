using souvenir.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace souvenir
{
    public partial class Form1 : Form
    {
        public  Form1()
        {
            //Създаваме екземпляри на двата контролера
            SouvenirDbContext SouvenirController = new SouvenirDbContext();
            SouvenirType SouvenirTypeController = new SouvenirType();         
            

             InitializeComponent();



        }
        private void LoadRecord(Souvenir_ souvenir_)
        {
        textBox1.BackColor = Color.White;
        textBox1.Text = souvenir_.Id.ToString();
        textBox2.Text = souvenir_.Price.ToString();
        textBox3.Text = souvenir_.Description.ToString();
        comboBox1.Text = souvenir_.Name;
        }
        private void ClearScreen()
        {
            textBox1.BackColor = Color.White;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            comboBox1.Text = "";
        }

    private void Form1_Load(object sender, EventArgs e)
        {
            List<SouvenirType> allSouvenirs = SouvenirType.GetAllSouvenirType();
            //list = _dbContext.SouvenirType.ToList();
            comboBox1.DataSource = allSouvenirs;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Id";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
