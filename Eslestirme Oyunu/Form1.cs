using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eslestirme_Oyunu
{
    public partial class Form1 : Form
    {
        List<string> icons = new List<string>()
        {
            "!",",","b","k","v","w","z","N","A","B","C","D","E","F","G",
            "!",",","b","k","v","w","z","N","A","B","C","D","E","F","G"
        };

        Random rnd = new Random();
        Timer t = new Timer();
        Timer t2 = new Timer();
        Timer gameTimer = new Timer(); 
        Button first, second;
        int sayac = 0;
        int elapsedTime = 0; 

        public Form1()
        {
            InitializeComponent();
            InitializeGameTimer();
            t.Tick += T_Tick;
            t.Start();
            t.Interval = 3000;
            show();
            t2.Tick += T2_Tick;
        }

        private void InitializeGameTimer()
        {
            gameTimer.Interval = 1000; 
            gameTimer.Tick += GameTimer_Tick;
            label1.Text = "Süre: 0 saniye"; 
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            elapsedTime++;
            label1.Text = $"Süre: {elapsedTime} saniye";
        }

        private void T2_Tick(object sender, EventArgs e)
        {
            t2.Stop();
            first.ForeColor = first.BackColor;
            second.ForeColor = second.BackColor;
            first = null;
            second = null;
        }

        private void T_Tick(object sender, EventArgs e)
        {
            t.Stop();
            foreach (Button item in Controls.OfType<Button>())
            {
                item.ForeColor = item.BackColor;
            }
            gameTimer.Start(); 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void show()
        {
            List<Button> buttons = Controls.OfType<Button>().ToList();
           

            foreach (Button btn in buttons)
            {
                if (icons.Count > 0)
                {
                    int randomindex = rnd.Next(icons.Count);
                    btn.Text = icons[randomindex];
                    btn.ForeColor = Color.Black;
                    icons.RemoveAt(randomindex);
                }
            }
        }

  

        private void Buton_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (first == null)
            {
                first = btn;
                first.ForeColor = Color.Black;
                return;
            }

            second = btn;
            second.ForeColor = Color.Black;

            if (first.Text == second.Text)
            {
                first.ForeColor = Color.Black;
                second.ForeColor = Color.Black;
                first = null;
                second = null;
                sayac++;
                if (sayac == 15) 
                {
                    gameTimer.Stop(); 
                    MessageBox.Show($"Tebrikler, oyunu tamamladınız! Süre: {elapsedTime} saniye");
                    Close();
                }
            }
            else
            {
                t2.Start();
                t2.Interval = 1000;
            }
        }
    }
}
