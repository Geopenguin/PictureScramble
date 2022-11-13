using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PictureScramble
{
    public partial class uxScrambleMain : Form
    {
        /// <summary>
        /// Field for num of boxes
        /// </summary>
        private const int _boxes = 9;

        /// <summary>
        /// Private field to hold box info 
        /// </summary>
        private PictureBox[] p = new PictureBox[_boxes];

        /// <summary>
        /// Field for position values of pictures
        /// </summary>
        private Bitmap[,] _bmps = new Bitmap[3, 3]; //init bitmap

        /// <summary>
        /// Init Gui 
        /// </summary>
        public uxScrambleMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Main GUI 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxScrambleMain_Load(object sender, EventArgs e)
        {
            pictureBox1.Tag = 1;
            pictureBox2.Tag = 2;
            pictureBox3.Tag = 3;
            pictureBox4.Tag = 4;
            pictureBox5.Tag = 5;
            pictureBox6.Tag = 6;
            pictureBox7.Tag = 7;
            pictureBox8.Tag = 8;
            pictureBox9.Tag = -1;

            int i = 0;
            foreach (PictureBox pic in uxImageHolder.Controls) //init array with tag info 
            {
                p.SetValue(pic, i);
                i++;
            }

        }


        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        /// <summary>
        /// Event Handler for generating image 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (uxImageGetter.ShowDialog() == DialogResult.OK)
            {
                Image[] imageArray = new Image[_boxes]; //init image array 
                Image img = Image.FromFile(uxImageGetter.FileName); //gets image from user input 
                int widthThird = (int)((double)img.Width / 3.0 + 0.5); //proportions wdith
                int heightThird = (int)((double)img.Height / 3.0 + 0.5); //proportions height 

                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++) //iterates 9 times to set each image 
                    {
                        _bmps[i, j] = new Bitmap(widthThird, heightThird); //image at coordinate will have these dimensions
                        Graphics g = Graphics.FromImage(_bmps[i, j]); //init g to specified bitmap 
                        g.DrawImage(img, new Rectangle(0, 0, widthThird, heightThird), new Rectangle(j * widthThird, i * heightThird, widthThird, heightThird), GraphicsUnit.Pixel); //draws image out 
                        g.Dispose(); //dispose resources 
                    }

                }
                pictureBox1.Image = _bmps[0, 0];
                pictureBox2.Image = _bmps[0, 1];
                pictureBox3.Image = _bmps[0, 2];
                pictureBox4.Image = _bmps[1, 0];
                pictureBox5.Image = _bmps[1, 1];
                pictureBox6.Image = _bmps[1, 2];
                pictureBox7.Image = _bmps[2, 0];
                pictureBox8.Image = _bmps[2, 1];

            }
        }

        /// <summary>
        /// If current picture box selected is touching the empty spot, then eligible for switch 
        /// </summary>
        /// <param name="p2"></param>
        /// <returns></returns>
        private bool IsTouching(PictureBox p2)
        {
            if (p[8].Location.X + p[8].Width < p2.Location.X)
            {
                return false;
            }
            if (p2.Location.X + p2.Width < p[8].Location.X)
            {
                return false;
            }
            if (p[8].Location.Y + p[8].Height < p2.Location.Y)
            {
                return false;
            }
            if (p2.Location.Y + p2.Height < p[8].Location.Y)
            {
                return false;
            }
            return true;


        }


        /// <summary>
        /// Method to swap two Pictureboxes 
        /// </summary>
        /// <param name="one"> picture</param>
        /// <param name="two"> picture</param>
        public void Swap(PictureBox one, PictureBox two)
        {

            int indexAlpha = uxImageHolder.Controls.IndexOf(one);
            int indexBeta = uxImageHolder.Controls.IndexOf(two);

            uxImageHolder.Controls.SetChildIndex(one, indexBeta);
            uxImageHolder.Controls.SetChildIndex(two, indexAlpha);

        }

        /// <summary>
        /// Checks and compares tag info with other pictureboxes
        /// </summary>
        /// <param name="current"></param>
        public void CheckThenSwap(PictureBox current)
        {
            //Need help with swapping 
            if (!IsTouching(current))
            {
                Swap(p[8], current);
            }
            else
            {
               // MessageBox.Show("Cannot Perform Move"); 
            }

        }
        /// <summary>
        /// Picture 1 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_Click(object sender, EventArgs e)
        {

            CheckThenSwap(pictureBox1);
        }

        /// <summary>
        /// Picture box 2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            CheckThenSwap(pictureBox2);
        }

        /// <summary>
        /// Picture box 3
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            CheckThenSwap(pictureBox3);
        }

        /// <summary>
        /// Picture box 4
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            CheckThenSwap(pictureBox4);
        }

        /// <summary>
        /// Picture box 8
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox8_Click(object sender, EventArgs e)
        {
            CheckThenSwap(pictureBox8);
        }

        /// <summary>
        /// Picture box 5
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            CheckThenSwap(pictureBox5);
        }

        /// <summary>
        /// Picture box 6
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            CheckThenSwap(pictureBox6);
        }

        /// <summary>
        /// Picture box 7
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox7_Click(object sender, EventArgs e)
        {
            CheckThenSwap(pictureBox7);
        }

        /// <summary>
        /// Empty Picture box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }
    }
}
