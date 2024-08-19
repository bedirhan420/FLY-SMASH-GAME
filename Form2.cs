using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace sinek_avı_güncel
{
    public partial class Form2 : Form
    {
        private Timer timerCreate;
        private Timer timerDelete;
        private int score;
        private int bombasayaci;
        private int sure=30;
        private Random random;
        private bool surekontrol =true;
        private bool resimkontrol =true;
        private int bombaKalmaSuresi =0;
        int[] scores = new int[100];
        int anlikScore = 0;
        int maxScore = 0;


        Timer timer2 = new Timer();
        

        Timer timer4 = new Timer();





        public Form2()
        {
            InitializeComponent();
            random = new Random();
            timerCreate = new Timer();
            timerCreate.Interval = 200;
            timerCreate.Tick += TimerCreate_Tick;
            timerCreate.Start();



            Timer timer3= new Timer();
            timer3.Interval = 100;
            timer3.Tick += Timer_Tick;
            timer3.Start();
             


            timer4.Interval = 1000;
            timer4.Tick += Timer4_Tick; ;
            timer4.Start();

            timer2.Interval = 1000;
            timer2.Tick += Timer2_Tick;
            timer2.Start();


            Bitmap image = new Bitmap(new Bitmap(Properties.Resources.şaplak_removebg_preview), 32, 32);
            this.Cursor = new Cursor(image.GetHicon());
        }


        

        private void Btn_Click(object sender, EventArgs e)
        {

            Button btn = (Button)sender;
            


            score = 0;
            sure = 30;
            surekontrol = true;
            timer2.Start();

            foreach (Control control in this.Controls)
            {
                if (control is PictureBox)
                {
                    control.Dispose();

                }
                
              
            }
            btn.Dispose();
            anlikScore= 0;

        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            if (surekontrol)
            {
                Timer timer3 = sender as Timer;
                Timer timer2 = sender as Timer;

                PictureBox pictureBox = timer2.Tag as PictureBox;


                sure -= 1;
                label2.Text = sure.ToString();

                if (sure == 0)
                {

                    timer3.Stop();
                    

                    
                    surekontrol = false;

                    MessageBox.Show("GAME OVER");

                    Button btn = new Button();
                    btn.Location = new Point(250, 150);
                    btn.BackColor = Color.MintCream;
                    btn.Height = 60;
                    btn.Width = 60;
                    btn.Text = "TEKRAR OYNA";
                    this.Controls.Add(btn);

                    btn.Click += Btn_Click;

                    SaveScore(score);
                }


            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (surekontrol)
            {
                foreach (Control item in this.Controls)
                {
                    if (item is PictureBox)
                    {

                        int x = item.Location.X;
                        int y = item.Location.Y;

                        item.Location = new Point(x + random.Next(-10, 10), y + random.Next(-10, 10));

                        if (x > 700 || y > 350)
                        {
                            this.Controls.Remove(item);
                        }
                    }

                }
            }
            
        }

        private void TimerCreate_Tick(object sender, EventArgs e)
        {

            bombasayaci++;

            if (surekontrol)
            {
                PictureBox pictureBox = new PictureBox();
                pictureBox.Size = new System.Drawing.Size(100, 100);

                pictureBox.Location = new Point(random.Next(0, 800), random.Next(0, 400));

                if (bombasayaci % 3 == 0)
                {
                    Bitmap image2 = new Bitmap(new Bitmap(Properties.Resources.png_clipart_bomb_bomb_removebg_preview), 30, 30);
                    pictureBox.Image = image2;
                    pictureBox.Tag = "bomba";
                }
                else
                {
                    Bitmap image = new Bitmap(new Bitmap(Properties.Resources.indir__1__removebg_preview), 30, 30);
                    pictureBox.Image = image;
                    pictureBox.Tag = "sinek";

                }

                pictureBox.MouseEnter += PictureBox_MouseEnter;
                this.Controls.Add(pictureBox);
            }

            




        }

        private void PictureBox_MouseEnter(object sender, EventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;
          

            Bitmap image = new Bitmap(new Bitmap(Properties.Resources.indir__1__removebg_preview), 30, 30);//sinek
            Bitmap image2 = new Bitmap(new Bitmap(Properties.Resources.png_clipart_bomb_bomb_removebg_preview), 30, 30);//bomba
            Bitmap image3 = new Bitmap(new Bitmap(Properties.Resources.png_clipart_explosion_bomb_black_bomb_explosion_effect_effect_logo_thumbnail_removebg_preview), 30, 30);//pat
            Bitmap image1 = new Bitmap(new Bitmap(Properties.Resources.squashed_fly_vector_82262_removebg_preview), 30, 30);//ez

            if (surekontrol)
            {
                if (pictureBox.Tag.ToString() == "sinek")
                {
                    pictureBox.Image = image1;
                    
                }
                else if(pictureBox.Tag.ToString() == "bomba")
                {
                    pictureBox.Image = image3;
                }


               

                timerDelete = new Timer();
                timerDelete.Interval = 100;
                timerDelete.Tick += TimerDelete_Tick;
                timerDelete.Tag = pictureBox;
                timerDelete.Start();

               
                lbl.BringToFront();
                lbl1.BringToFront();
            }

            







            
        }

        private void TimerDelete_Tick(object sender, EventArgs e)
        {
            Timer timer1 = sender as Timer;
            PictureBox pictureBox = timer1.Tag as PictureBox;
            Bitmap image = new Bitmap(new Bitmap(Properties.Resources.indir__1__removebg_preview), 30, 30);
            Bitmap image2 = new Bitmap(new Bitmap(Properties.Resources.png_clipart_bomb_bomb_removebg_preview), 30, 30);

            if (pictureBox.Tag.ToString() == "sinek")
            {
                score+=2;

            }
            else if (pictureBox.Tag.ToString() == "bomba")
            {
                score--;
            }


            this.Controls.Remove(pictureBox);
            pictureBox.Dispose();
           
            label1.Text = "Score: " + score.ToString();
            timer1.Stop();
        }


        private void Timer4_Tick(object sender, EventArgs e)
        {
            Timer timer1 = sender as Timer;
          
            PictureBox pictureBox = timer4.Tag as PictureBox;


            bombaKalmaSuresi++;
            if (pictureBox != null)
            {
                

                if (bombaKalmaSuresi % 3 == 0 && pictureBox.Tag.ToString() == "bomba")
                {
                  
                    pictureBox.Dispose();
                }
            }
           
        }

        private void SaveScore(int score)
        {
            anlikScore = score;
            scores[scores.Length - 1] = score;
            Array.Sort(scores);
            Array.Reverse(scores);
            maxScore = scores[0];
            ShowScore();

        }

        private void ShowScore()
        {
           
         

            lbl.Text = "Current Score: " + anlikScore.ToString();
            lbl1.Text = "Highest Score: " + maxScore.ToString();
        }



        private void Form2_Load(object sender, EventArgs e)
        {

        }

    }
}
