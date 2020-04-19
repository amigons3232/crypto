using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace WindowsFormsApplication1
{
    
    public partial class Form1 : Form
    {

        int move = 0;
        string[] array = new string[] { "а", "б", "в",
 "г", "д", "е", "ё", "ж",
"з", "и", "й", "к", "л", "м", "н", "о", "п", "р", "с",
"т", "у", "ф", "х",
 "ц", "ч", "ш", "щ", "ъ", "ы", "ь", "э", "ю", "я" };
        int nomer; // Номер в алфавите
        int d; // Смещение
        string s; //Результат
        int j, f; // Переменная для циклов
        int t = 0; // Преременная для нумерации символов ключа.
      
        
        char[] alfavit = { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я' };
        public Form1()
        {
            InitializeComponent();
        }


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
textBox3.Text = "";


 try
{
 move = Convert.ToInt32(textBox1.Text);
}
catch
{
MessageBox.Show("Установите шаг шифрования!"); 
return;
}

string[] array2;
 array2 = array.Skip(move).Concat(array.Take(move)).ToArray(); 

foreach (string element in array2)
 {
listBox1.Items.Add(element.ToString()); 
}

 string text = textBox2.Text;
 foreach (char bykva in text)
 {
 for (int i = 0; i < array.Length; i++)
 {
  if (bykva.ToString().ToLower() == array[i])
 {
  textBox3.Text += array2[i];
 break;
 }
  else
 {
if (bykva.ToString() == " " || bykva.ToString() == "." || 
bykva.ToString() == "," || bykva.ToString() == ":" || 
bykva.ToString() == ";" || bykva.ToString() == "?" ||
bykva.ToString() == "!") 
                        {
                            textBox3.Text += " ";
                            break;
                        }
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
textBox3.Text = "";

 try
{
 move = Convert.ToInt32(textBox1.Text);
}
catch
{
MessageBox.Show("Установите шаг шифрования!"); 
return;
}

string[] array2;

array2 = array.Skip(33 - move).Concat(array.Take(33 - move)).ToArray(); 

foreach (string element in array2)
 {
listBox1.Items.Add(element.ToString()); 
}

 string text = textBox2.Text;
 foreach (char bykva in text)
 {
 for (int i = 0; i < array.Length; i++)
 {
  if (bykva.ToString().ToLower() == array[i])
 {
  textBox3.Text += array2[i];
 break;
 }
  else
 {
if (bykva.ToString() == " " || bykva.ToString() == "." || 
bykva.ToString() == "," || bykva.ToString() == ":" || 
bykva.ToString() == ";" || bykva.ToString() == "?" ||
bykva.ToString() == "!") 
                        {
                            textBox3.Text += " ";
                            break;
                        }
                    }
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            move = 0;

            // Cчитываем из файла сообщения
            string m = textBox2.Text;
            string k = textBox1.Text;
           

            

            char[] massage = m.ToCharArray(); // Превращаем сообщение в массив символов.
            char[] key = k.ToCharArray(); // Превращаем ключ в массив символов.

            

            // Перебираем каждый символ сообщения
            for (int i = 0; i < massage.Length; i++)
            {
                // Ищем индекс буквы
                for (j = 0; j < alfavit.Length; j++)
                {
                    if (massage[i] == alfavit[j])
                    {
                        break;
                    }
                }

                if (j != 33) // Если j равно 33, значит символ не из алфавита
                {
                    nomer = j; // Индекс буквы

                    // Ключ закончился - начинаем сначала.
                    if (move > key.Length - 1) { move = 0; }

                    // Ищем индекс буквы ключа
                    for (f = 0; f < alfavit.Length; f++)
                    {
                        if (key[move] == alfavit[f])
                        {
                            break;
                        }
                    }

                    move++;

                    if (f != 33) // Если f равно 33, значит символ не из алфавита
                    {
                        d = nomer + f;
                    }
                    else
                    {
                        d = nomer;
                    }

                    // Проверяем, чтобы не вышли за пределы алфавита
                    if (d > 32)
                    {
                        d = d - 33;
                    }

                    massage[i] = alfavit[d]; // Меняем букву
                }
            }

            s = new string(massage); // Собираем символы обратно в строку.
            
           
            textBox3.Text = s;


        }

        private void button4_Click(object sender, EventArgs e)
        {
            move = 0;
            // Cчитываем из файла сообщения
            string m = textBox2.Text;
            string k = textBox1.Text;


            

            char[] massage = m.ToCharArray(); // Превращаем сообщение в массив символов.
            char[] key = k.ToCharArray(); // Превращаем ключ в массив символов.

           

            // Перебираем каждый символ сообщения
            for (int i = 0; i < massage.Length; i++)
            {
                // Ищем индекс буквы
                for (j = 0; j < alfavit.Length; j++)
                {
                    if (massage[i] == alfavit[j])
                    {
                        break;
                    }
                }

                if (j != 33) // Если j равно 33, значит символ не из алфавита
                {
                    nomer = j; // Индекс буквы

                    // Ключ закончился - начинаем сначала.
                    if (move > key.Length - 1) { move = 0; }

                    // Ищем индекс буквы ключа
                    for (f = 0; f < alfavit.Length; f++)
                    {
                        if (key[move] == alfavit[f])
                        {
                            break;
                        }
                    }

                    move++;

                    if (f != 33) // Если f равно 33, значит символ не из алфавита
                    {
                        d = nomer - f;
                    }
                    else
                    {
                        d = nomer;
                    }

                    // Проверяем, чтобы не вышли за пределы алфавита
                    if (d > 32)
                    {
                        d = d + 33;
                    }
                    if (d < 0)
                    {
                        d = d + 33;
                    }

                    massage[i] = alfavit[d]; // Меняем букву
                }
            }

            s = new string(massage); // Собираем символы обратно в строку.


            textBox3.Text = s;

        }

     

      
        
        }
        }
    

