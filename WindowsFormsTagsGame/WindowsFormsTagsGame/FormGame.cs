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

namespace WindowsFormsTagsGame
{
    public partial class FormGame : Form
    {
        string path = "Easy.txt";
        Game game;
        public FormGame()
        {
            InitializeComponent();
            tableLayoutPanel1.Visible = false;
            int countSize = 4 ;
            game = new Game(countSize);
            label6.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
            label13.Visible = false;
            label14.Visible = false;
            label15.Visible = false;

        }
        
        private void FormGame_Load(object sender, EventArgs e)
        {
            if (File.Exists("Easy.txt") == false)
            {
                FileStream str=File.Create("Easy.txt");
                str.Close();
            }
            if (File.Exists("Medium.txt") == false)
            {
                FileStream str = File.Create("Medium.txt");
                str.Close();
            }
            if (File.Exists("Hard.txt") == false)
            {
                FileStream str = File.Create("Hard.txt");
                str.Close();
            }
        }
        /// <summary>
        /// Количество ходов
        /// </summary>
        public int CountMove = 0;
        private void button15_Click(object sender, EventArgs e)
        {
            int position = Convert.ToInt32( ((Button)sender).Tag ); // Sender - кнопка, которая была нажата. Конвертируем в целое число.
            
            game.change(position);
            update();
            timer1.Start();
        
            CountMove = CountMove + 1;
            label3.Text= "Количество ходов: " +  CountMove.ToString();
            if (game.ConditionWin())
            {
                timer1.Stop();
                MessageBox.Show("Игрок "+textBox1.Text+" победил!","Поздравление.");
                string result = "";
                int check = 0;
                result = textBox1.Text + " " + labelMinutes.Text + ":" + labelSeconds.Text + ":" + labelMiliseconds.Text;
                for (int i = richTextBox1.Lines.Length-1; i >=0; i--)
                {
                    if(richTextBox1.Lines[i] != "")
                    {
                        if (Game.Score(result.Split(' ')[1]) >= Game.Score(richTextBox1.Lines[i].Split(' ')[1]))
                        {
                            check = i + 1;
                            break;
                        }
                    }
                }
                StreamWriter Writer = new StreamWriter(path);
                int j = 0;
                bool flag = true;
                if (richTextBox1.Lines.Length==0)
                {
                    Writer.WriteLine(textBox1.Text + " " + labelMinutes.Text + ":" + labelSeconds.Text + ":" + labelMiliseconds.Text);
                }
                else
                {
                    while (j < richTextBox1.Lines.Length)
                    {
                        if (j == check & flag == true)
                        {
                            Writer.WriteLine(textBox1.Text + " " + labelMinutes.Text + ":" + labelSeconds.Text + ":" + labelMiliseconds.Text);
                            flag = false;
                        }
                        else
                        {
                            Writer.WriteLine(richTextBox1.Lines[j]);
                            j++;
                        }
                    }
                }
                //Writer.WriteLine(textBox1.Text+" "+labelMinutes.Text+":" + labelSeconds.Text + ":" + labelMiliseconds.Text);
                Writer.Close();
                StreamReader Stream = new StreamReader(path);
                richTextBox1.Text = Stream.ReadToEnd();
                Stream.Close();
                game.Filling();
            }
                
        }

      
        /// <summary>
        /// Сложность
        /// </summary>
        public int Complexity = 9;

        private void GameMenu_Click(object sender, EventArgs e)
        {
            game.Filling();
            StreamReader Stream = new StreamReader(path);
            richTextBox1.Text = Stream.ReadToEnd();
            Stream.Close();
            label6.Visible = true;
            label9.Visible = true;
            label10.Visible = true;
            label11.Visible = true;
            label12.Visible = true;
            label13.Visible = true;
            label14.Visible = true;
            label15.Visible = true;

            CountMove = 0;
            labelMiliseconds.Text = "00";
            labelSeconds.Text = "00";
            labelMinutes.Text = "00";
            label3.Text = "Количество ходов:";

            for (int i = 0; i < Complexity; i++)
            {
                game.Mixing();
            }
            update();
            tableLayoutPanel1.Visible = true;
            label1.Visible = false;
        }

        /// <summary>
        /// Обновление расположение кнопок
        /// </summary>
        private void update()
        {
            int SizeTags = 16;
            for (int position = 0; position < SizeTags; position++)
            {
                button(position).Text = game.get_number_position(position).ToString();
                button(position).Visible = (game.get_number_position(position) > 0);
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {
        }

        private void button18_Click(object sender, EventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (labelMiliseconds.Text == "9")
            {
                labelMiliseconds.Text = "0";
                labelSeconds.Text = Convert.ToString(Convert.ToInt32(labelSeconds.Text) + 1);
            }
            else if (labelSeconds.Text == "59")
            {
                labelSeconds.Text = "0";
                labelMiliseconds.Text = "0";
                labelMinutes.Text = Convert.ToString(Convert.ToInt32(labelMinutes.Text) + 1);
            }
            else
                labelMiliseconds.Text = Convert.ToString(Convert.ToInt32(labelMiliseconds.Text) + 1);
            
        }

        private void запуститьРоботаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //game.MixingRobot();
            //update();
            //MessageBox.Show("Робот выиграл!", "Поздравление.");
            ////game.start();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void labelSeconds_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

        private void лёгкаяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            path = "Easy.txt";
            Complexity = 10;
        }

        private void средняяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            path = "Medium.txt";
            Complexity = 50;
        }

        private void тяжёлаяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            path = "Hard.txt";
            Complexity = 100;
        }
        //там формулы даны, надо значения подставить. Ответ там есть.   
        private void таблицаРекордовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result;
            string ErorAnt = "Суть работы: \n " +
                " Проект представляет возможность сыграть в игру 'Пятнашки '.\n " +
                "Они представляют собой набор из 15 одинаковых квадратных элементов с номерами, находящихся в поле 4 на 4." +
                "Цель игры — упорядочить элементы по возрастанию номеров, перемещая их внутри игрового поля. \n \n " +
                "-Чтобы начать игру, нужно нажать кнопку 'Играть' в меню." +
                "Появится игровое поле в котором будут находиться 15 пронумерованных элементов и одно пустое поле." +
                "Элементы котоые можно перемещать находятся сверху, справа, снизу, и слева от пустого поля, если они имеются." +
                "Для перемещения, нажмите на элемент который хотите переместить, и он встанет на место пустого поля, " +
                "а место в котором он стоял станет пустым полем. \n \n" +
                "Перед началом игры занесите в поле 'Имя игрока' имя под которым стоит занести ваш рекорд в таблицу рекордов." +
                "Имя не должно содержать пробелов!\n \n" +
                "-В начале игры как только вы переместите элемент, запустится таймер который будет подсчитывать время игры. \n \n " +
                "-Как только вы поставите все элементы в правильном порядке, и пустое поле окажется в правом нижнем углу" +
                "появится окно с сообщением о том что вы победили. После этого в таблицу рекордов запишется ваше имя и справа от него " +
                "время за которое вы прошли игру. \n \n" +
                "-Игра представляет 3 уровня сложности. Для того чтобы изменить сложность, нажмите на кнопку 'Сложность' в меню. \n \n" +
                "-Так же данный проект предоставляет возможность поиграть в пятнашки различных размеров (только 3x3, 4x4, 5x5)";

            result = MessageBox.Show(this, ErorAnt, "***СПРАВКА***");
        }

        private void дополнительноToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Visible = true;
        }

        private void таблицаИгроковToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        //передача позиции на кнопку, которую нам нужно получить
        private Button button(int position)
        {
            switch (position)
            {
                case 0: return button1;
                case 1: return button2;
                case 2: return button3;
                case 3: return button4;
                case 4: return button5;
                case 5: return button6;
                case 6: return button7;
                case 7: return button8;
                case 8: return button9;
                case 9: return button10;
                case 10: return button11;
                case 11: return button12;
                case 12: return button13;
                case 13: return button14;
                case 14: return button15;
                case 15: return button16;
                default: return null;


            }
        }
    }
}
