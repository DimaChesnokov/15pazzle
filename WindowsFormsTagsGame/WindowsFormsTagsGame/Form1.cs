using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsTagsGame
{
    public partial class Form1 : Form
    {
        Game game;
        int countSize ;
        public Form1()
        {
            InitializeComponent();
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            button7.Visible = false;
            button8.Visible = false;
            button9.Visible = false;
            button10.Visible = false;
            button11.Visible = false;
            button12.Visible = false;
            button13.Visible = false;
            button14.Visible = false;
            button15.Visible = false;
            button16.Visible = false;
            button17.Visible = false;
            button18.Visible = false;
            button19.Visible = false;
            button20.Visible = false;
            button21.Visible = false;
            button22.Visible = false;
            button23.Visible = false;
            button24.Visible = false;
            button25.Visible = false;


        }

        private void button9_Click(object sender, EventArgs e)
        {
           int position =  Convert.ToInt32(((Button)sender).Tag);
            game.change(position);
            update();

            if (game.ConditionWin())
            {
                MessageBox.Show("Победа!", "Поздравление.");
                game.Filling();
            }
        }

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
                case 16: return button17;
                case 17: return button18;
                case 18: return button19;
                case 19: return button20;
                case 20: return button21;
                case 21: return button22;
                case 22: return button23;
                case 23: return button24;
                case 24: return button25;


                default: return null;


            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            game = new Game(countSize);
            game.Filling();


            for (int i = 0; i < 25; i++)
            {
                game.Mixing();
            }
            update();
        }

        int SizeTags;
        private void update()
        {
          
            for (int position = 0; position < SizeTags; position++)
            {
                button(position).Text = game.get_number_position(position).ToString();
                button(position).Visible = (game.get_number_position(position) > 0);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void на3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            countSize = 3;
            SizeTags = 9;
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
            button5.Visible = true;
            button6.Visible = true;
            button7.Visible = true;
            button8.Visible = true;
            button9.Visible = true;

            button1.Location = new Point(37, 68);
            button2.Location = new Point(156, 68);
            button3.Location = new Point(275, 68);

            button4.Location = new Point(37, 172);
            button5.Location = new Point(156, 172);
            button6.Location = new Point(275, 172);

            button7.Location = new Point(37, 276);
            button8.Location = new Point(156, 276);
            button9.Location = new Point(275, 276);

            button10.Visible = false;
            button11.Visible = false;
            button12.Visible = false;
            button13.Visible = false;
            button14.Visible = false;
            button15.Visible = false;
            button16.Visible = false;
            button17.Visible = false;
            button18.Visible = false;
            button19.Visible = false;
            button20.Visible = false;
            button21.Visible = false;
            button22.Visible = false;
            button23.Visible = false;
            button24.Visible = false;
            button25.Visible = false;
            

        }

        private void на4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            countSize = 4;
            SizeTags = 16;
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
            button5.Visible = true;
            button6.Visible = true;
            button7.Visible = true;
            button8.Visible = true;
            button9.Visible = true;
            button10.Visible = true;
            button11.Visible = true;
            button12.Visible = true;
            button13.Visible = true;
            button14.Visible = true;
            button15.Visible = true;
            button16.Visible = true;

            button1.Location = new Point(37, 68);
            button2.Location = new Point(156, 68);
            button3.Location = new Point(275, 68);
            button4.Location = new Point(394, 68);

            button5.Location = new Point(37, 172);
            button6.Location = new Point(156, 172);
            button7.Location = new Point(275, 172);
            button8.Location = new Point(394, 172);

            button9.Location = new Point(37, 276);
            button10.Location = new Point(155, 276);
            button11.Location = new Point(275, 276);
            button12.Location = new Point(394, 276);

            button13.Location = new Point(37, 380);
            button14.Location = new Point(155, 380);
            button15.Location = new Point(275, 380);
            button16.Location = new Point(394, 380);


            button17.Visible = false;
            button18.Visible = false;
            button19.Visible = false;
            button20.Visible = false;
            button21.Visible = false;
            button22.Visible = false;
            button23.Visible = false;
            button24.Visible = false;
            button25.Visible = false;
          
        }

        private void на5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            countSize = 5;
            SizeTags = 25;
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
            button5.Visible = true;
            button6.Visible = true;
            button7.Visible = true;
            button8.Visible = true;
            button9.Visible = true;
            button10.Visible = true;
            button11.Visible = true;
            button12.Visible = true;
            button13.Visible = true;
            button14.Visible = true;
            button15.Visible = true;
            button16.Visible = true;
            button17.Visible = true;
            button18.Visible = true;
            button19.Visible = true;
            button20.Visible = true;
            button21.Visible = true;
            button22.Visible = true;
            button23.Visible = true;
            button24.Visible = true;
            button25.Visible = true;



            button1.Location = new Point(37, 68);
            button2.Location = new Point(156, 68);
            button3.Location = new Point(275, 68);
            button4.Location = new Point(394, 68);
            button5.Location = new Point(513, 68);

            button6.Location = new Point(37, 172);
            button7.Location = new Point(156, 172);
            button8.Location = new Point(275, 172);
            button9.Location = new Point(394, 172);
            button10.Location = new Point(513, 172);

            button11.Location = new Point(37, 276);
            button12.Location = new Point(156, 276);
            button13.Location = new Point(275, 276);
            button14.Location = new Point(394, 276);
            button15.Location = new Point(513, 276);

            button16.Location = new Point(37, 380);
            button17.Location = new Point(156, 380);
            button18.Location = new Point(275, 380);
            button19.Location = new Point(394, 380);
            button20.Location = new Point(513, 380);

            button21.Location = new Point(37, 484);
            button22.Location = new Point(156, 484);
            button23.Location = new Point(275, 484);
            button24.Location = new Point(394, 484);
            button25.Location = new Point(513, 484);
            
        }
    }
}
