using souvenir.Controller;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace souvenir
{
    public partial class Form1 : Form
    {
        SouvenirController souvenirController = new SouvenirController();
        SouvenirTypeController souvenirTypeController = new SouvenirTypeController();
        //Създаваме екземпляри на двата контролера
        public Form1()
        {
           
            

             InitializeComponent();



        }
        private void LoadRecord(Souvenir souvenir_)
        {
        textBox1.BackColor = Color.White;
        textBox1.Text = souvenir_.Id.ToString();
        textBox2.Text = souvenir_.Price.ToString();
        textBox3.Text = souvenir_.Description.ToString();
        cmb1.Text = souvenir_.Name;
        }
        private void ClearScreen()
        {
            textBox1.BackColor = Color.White;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            cmb1.Text = "";
        }

    private void Form1_Load(object sender, EventArgs e)
        {
            List<SouvenirType> allSouvenirs = souvenirTypeController.GetAllSouvenirTypes();
            //list = _dbContext.SouvenirType.ToList();
            cmb1.DataSource = allSouvenirs;
            cmb1.DisplayMember = "Name";
            cmb1.ValueMember = "Id";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text) || textBox2.Text=="")
                 {
                      MessageBox.Show("Въведете данни!");
                      textBox2.Focus();
                      return;
                 }
            Souvenir newSouvenir = new Souvenir();
            newSouvenir.Price = double.Parse (textBox2.Text);
            newSouvenir.Name = txtname.Text;
  
            newSouvenir.SouvenirTypeId = (int)cmb1.SelectedValue;
            
            souvenirController.Create(newSouvenir);
            MessageBox.Show("Записът е успешно добавен!");
            ClearScreen();
            button1_Click(sender, e);
            SelectAll();
        }

        private void button2_Click(object sender, EventArgs e)
        {
          
               {
                  int findId = 0;
                     if (string.IsNullOrEmpty(textBox1.Text) || !textBox1.Text.All(char.IsDigit))
                     {
                       MessageBox.Show("Въведете Id за търсене!");
                       textBox1.BackColor = Color.Red;
                       textBox1.Focus();
                         return;
                     }
                     else
                     {
                     findId = int.Parse(textBox1.Text);
                     }
                      Souvenir findedSouvenir = souvenirController.Get(findId);
                        if (findedSouvenir == null)
                        {
                           MessageBox.Show("НЯМА ТАКЪВ ЗАПИС в БД! \n Въведете Id за търсене!");
                           textBox1.BackColor = Color.Red;
                           textBox1.Focus();
                           return;
                        }
                        LoadRecord(findedSouvenir);
                
                        DialogResult answer = MessageBox.Show("Наистина ли искате да изтриете запис No " +
                            findId + " ?",
                            "PROMPT", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
                         if (answer == DialogResult.Yes)
                         {
                           souvenirController.Delete(findId);
                         }
                
                          button2_Click(sender, e);
                SelectAll();
               }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            {
                 int findId = 0;
                 if (string.IsNullOrEmpty(textBox1.Text) || !textBox1.Text.All(char.IsDigit))
                     {
                    MessageBox.Show("Въведете Id за търсене!");
                    textBox1.BackColor = Color.Red;
                    textBox1.Focus();
                     return;
                     }
                 else
                 {
                   findId = int.Parse(textBox1.Text);
                     }
                 //Ако няма намерен запис търсим по Id и визуализираме на екрана
                     if (string.IsNullOrEmpty(textBox2.Text))
                     {
                    Souvenir findedDog = souvenirController.Get(findId);
                     if (findedDog == null)
                         {
                        MessageBox.Show("НЯМА ТАКЪВ ЗАПИС в БД! \n Въведете Id за търсене!");
                        textBox1.BackColor = Color.Red;
                        textBox1.Focus();
                         return;
                         }
                    LoadRecord(findedDog);
                     }
                 else //Ако има намерен вече запис променяме по полетата
                     {
                    Souvenir updatedDog = new Souvenir();
                    updatedDog.Name = textBox2.Text;
                    
                    updatedDog.SouvenirTypeId = (int)cmb1.SelectedValue;
                    
                    souvenirController.Update(findId, updatedDog);
                     }

                    button3_Click(sender, e);
                SelectAll();
                 }

        }

        private void txtname_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        private void SelectAll()
        {
            List<Souvenir> souvenirs = souvenirController.GetAll();
            foreach(var item in souvenirs)
            {
                listBox1.Items.Add($"{item.Id} {item.Name}");
            }

            souvenirs.Clear();
        }
    }
}
