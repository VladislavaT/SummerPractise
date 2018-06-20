using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using calcul;

namespace uadratic_equation
{
    public partial class Form1 : Form
    {
        string x1= null, x2 = null;
        double a, b, c, d;
        double rezult1, rezult2;
        int vibor;
        bool act = true;

        public void Calcul(double a, double b, double c, ref string x1, ref string x2)
        {
            d = b * b - 4 * a * c; // Нахождение дискриминанта 
            if (d < 0) // Дискриминант меньше 0
            {
                d *= -1;
                rezult1 = (-b / 2 * a);
                rezult2 = (Math.Sqrt(d) / 2 * a); // нахождение комплексных корней 

                x1 = String.Format("{0:G3}", rezult1) + '+' + String.Format("{0:G3}", rezult2) + 'i';
                x2 = String.Format("{0:G3}", rezult1) + '-' + String.Format("{0:G3}", rezult2) + 'i';
                return;
            }
            else if (d == 0) // Дискриминант равен 0
            {
                rezult1 = (-b / (2 * a));
                x1 = String.Format("{0:G3}", rezult1);
                x2 = x1;
            }
            if (d > 0)// Дискриминант больше 0
            {
                {
                    rezult1 = ((-b - Math.Sqrt(d)) / (2 * a));
                    rezult2 = ((-b + Math.Sqrt(d)) / (2 * a));
                    x1 = String.Format("{0:G3}", rezult1);
                    x2 = String.Format("{0:G3}", rezult2);
                }
            }
        }
        private void Calculate_Click(object sender, EventArgs e) // кнопка вычислений 
        {
            if ((textBox2.Text.Length == 0) || (textBox3.Text.Length == 0) || (textBox8.Text.Length == 0)) // проверка введены ли исход. данные
            {
                MessageBox.Show("Введите данные!");
                return;
            }
            a = Convert.ToDouble(textBox2.Text);
            b = Convert.ToDouble(textBox3.Text);
            c = Convert.ToDouble(textBox8.Text);
           
            if (a == 0) // деление на 0
            {
                MessageBox.Show("Деление на ноль");
                return;
            }
            switch (vibor) // каким способом решать уравнение 
            {
                case 1: // Через обработчик
                    d = (b * b) - (4 * a * c);
                    if (d < 0)
                    { d *= -1;
                    rezult1 = (-b / 2 * a);
                    rezult2 = (Math.Sqrt(d) / 2 * a);
                    textBox1.Text = String.Format("{0:G3}", rezult1) + '+' + String.Format("{0:G3}", rezult2) + 'i';
                    textBox4.Text = String.Format("{0:G3}", rezult1) + '-' + String.Format("{0:G3}", rezult2) + 'i';
                    return; }
                    else if (d == 0)
                    {
                        rezult1 = (-b / (2 * a));
                        textBox1.Text = String.Format("{0:G3}", rezult1);
                        textBox4.Text = String.Format("{0:G3}", rezult1);

                    }
                    if (d > 0)
                    {
                        {
                            rezult1 = ((-b - Math.Sqrt(d)) / (2 * a));
                            rezult2 = ((-b + Math.Sqrt(d)) / (2 * a));
                            textBox1.Text = String.Format("{0:G3}", rezult1);
                            textBox4.Text = String.Format("{0:G3}", rezult2);
                        }
                    }
                    break;
                case 2: // Метод класса в форме

                    Form1 j = new Form1();
                    j.Calcul(a, b, c, ref x1, ref x2);
                    textBox1.Text = x1;
                    textBox4.Text = x2;
                    break;
                case 3: // Отдельный класс с методом
                    Class1 k = new Class1();
                    k.Calcul(a, b, c, ref x1, ref x2);
                    textBox1.Text = x1;
                    textBox4.Text = x2;
                    break;
            } 
        }

        private void Novoe_Click(object sender, EventArgs e) // очистка формы
        {
            radioButton1.Checked = true;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox1.Text = null;
            textBox4.Text = null;
            textBox8.Text = null;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = (sender as TextBox);
            try
            {
                textBox.Focus();
                if (Char.IsDigit(e.KeyChar) || (e.KeyChar == '-') || (e.KeyChar == ','))
                {
                    switch (e.KeyChar)
                    {
                        case '-':  // клавиша '-'
                           
                            if (textBox.Text.Length != 0)
                                e.KeyChar = (char)Keys.None; break;
                        case ',':     // клавиша ','
                            if (textBox.SelectionStart < textBox.Text.Length - 2)
                            {
                                e.KeyChar = (char)Keys.None; break;
                            }
                            else if (textBox.Text.IndexOf('-') == 0 && textBox.SelectionStart == 1)
                                if (textBox.Text == "-")
                                {
                                    textBox.Text = null;
                                    e.KeyChar = (char)Keys.None; break;
                                }  // проверка на корректность ввода ',' при диапазоне
                                else if (textBox.Text.IndexOf('-') == 0 && textBox.SelectionStart == 1)
                                    e.KeyChar = (char)Keys.None; break;
                            if (textBox.Text == "4000000" || textBox.Text == "-2000000" || (textBox.Text.IndexOf(',') != (-1)) || textBox.Text == "")
                                e.KeyChar = (char)Keys.None; break;
                    }   // если символ  ',' присутствует и после него уже имеется 2 цифры
                    if ((((textBox.Text).Length - 1) - textBox.Text.IndexOf(',')) > 4 && textBox.Text.IndexOf(',') != -1)
                        e.KeyChar = (char)Keys.None;
                    // если выход за перделы диапазона
                    if (textBox.Text != "" && (Convert.ToDouble(textBox.Text + e.KeyChar) > 4000000 || Convert.ToDouble(textBox.Text + e.KeyChar) < -2000000))
                        e.KeyChar = (char)Keys.None;
                }
                 // запрет клавиши Back при значении флага act=false
                else if (e.KeyChar != (char)Keys.Back || act == false)
                e.KeyChar = (char)Keys.None;
            // запрет клавиши Back при значении флага act=false
            if (e.KeyChar == (char)Keys.Back && textBox2.Text.Length == 2 && textBox2.Text[0] == '-')
                textBox2.Text = "";
            // перевод фокуса на textBox1 после нажатия клавиши Enter
            if (textBox.Text.IndexOf('-') != -1 && textBox.SelectionStart == 0)
                    {
                        e.KeyChar = (char)Keys.None; return;
                    }  
            if (e.KeyChar == (char)Keys.Enter) textBox2.Focus();
            }
        
            catch (Exception)
            {
                e.KeyChar = (char)Keys.None;
            }
            if (textBox.Text.IndexOf('-') != -1 && textBox.SelectionStart == 0)
            {
                e.KeyChar = (char)Keys.None; return;
            }
            else if (textBox.Text.IndexOf('-') == 0 && textBox.Text.IndexOf(',') == 2 && textBox.SelectionStart == 2 && e.KeyChar == (char)Keys.Back)
            {
                e.KeyChar = (char)Keys.None; return;
            }
        }
        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {  // обработчик события отпуска клавиши в окне ввода
            if (e.KeyCode == Keys.Delete)
                e.SuppressKeyPress = true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox=(sender as TextBox);
            if (textBox.Text.Length > 1 && textBox.Text[0] == '0' && textBox.Text[1] != ',')
                textBox.Text = textBox.Text.Substring(1, textBox.Text.Length - 1);
            if (textBox.Text != "" && textBox.Text[0] == ',')
                textBox.Text = "0," + textBox.Text.Substring(1, textBox.Text.Length - 1);
            textBox.SelectionStart = textBox.Text.Length;
            textBox.Focus();
            textBox.SelectionStart = textBox.Text.Length;
            if (textBox.Text.Length > 2 && textBox.Text[0] == '-' && textBox.Text[1] == '0' && (textBox.Text[2] >= '0' && textBox.Text[2] <= '9'))
                textBox.Text = "-" + textBox.Text.Substring(2);
          
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            vibor = 1;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            vibor = 2;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            vibor = 3;
        }
        private void Complete_Click(object sender, EventArgs e)
        {
            Close(); // Закрытие формы 
        }
    }
}