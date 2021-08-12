using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using static проба.Class_For_Visable;


namespace проба
{
    public partial class Form1 : Form
    {
      
        Class_For_Visable CFV = new Class_For_Visable();
        Bitmap bmp;

        public Form1()
        {            
            InitializeComponent();
            bmp = new Bitmap(pictureBox1.Width,pictureBox1.Height);
            this.Activate();
            colorF();
            CFV.currItem = Item.Pencil;
        }
        
        void colorF()
        {
            labelClose.BackColor = Color.White;
            label_bs.BackColor = Color.White;
            toolStrip1.Width = 1800;
        }

        void Initialize()
        {
            Thread first = new Thread(new ThreadStart(pictureColor));
            first.Start();
        }

        public void pictureColor()
        {
            labelClose.BackColor = Color.White;
       
            for (int i = 0; i < 256; i++)
            {
                for (int b = 0; b < 256; b += 10)
                {
                    for (int c = 0; c < 256; c += 20)
                    {
                        labelClose.ForeColor = Color.FromArgb(i, b, c);
                        label_bs.ForeColor = Color.FromArgb(i, b, c);
                        menuStripMain.ForeColor = Color.FromArgb(i, b, c);
                        labelhide.ForeColor = Color.FromArgb(i, b, c);
                        Thread.Sleep(2);                    
                    }
                }
           
            }
            labelClose.ForeColor = Color.Black;
            labelhide.ForeColor = Color.Black;
            label_bs.ForeColor = Color.Black;
            menuStripMain.ForeColor = Color.Black;
        }
     
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void видToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        Point lastPoint = new Point();

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint.X = e.X;
            lastPoint.Y= e.Y;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void labelClose_MouseMove(object sender, MouseEventArgs e)
        {
            labelClose.BackColor = Color.Pink;
        }

        private void labelClose_MouseLeave(object sender, EventArgs e)
        {
            labelClose.BackColor = Color.White;
        }
        bool trg_KD = false;
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.F1 && trg_KD == false && e.Control)
            {
                Initialize();
                trg_KD = !trg_KD;
            }
            else if(trg_KD == true && e.KeyCode == Keys.F1 && e.Control)
            {
                Form1 form = new Form1();
                form.Show();
                if (this.WindowState.ToString() == "Maximized")
                {
                    form.WindowState = FormWindowState.Maximized;
                }
                else
                {
                    form.WindowState = FormWindowState.Normal;
                }
               // this.Close();
            }
            else if(e.KeyCode == Keys.Escape)
            {
                Application.Exit();
               
            }
            else if(e.KeyCode == Keys.Delete)
            {
                pictureBox1.Image = null;
            }
        }
     
        public void ShowMyImage(String fileToDisplay, int xSize, int ySize)
        {
            pictureBox1.Load(fileToDisplay);

        }
        Point LastPoint = new Point();
        private void menuStrip1_MouseDown(object sender, MouseEventArgs e)
        {
            LastPoint.X = e.X;
            LastPoint.Y = e.Y;
        }

        private void menuStrip1_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                this.Left += e.X - LastPoint.X;
                this.Top += e.Y - LastPoint.Y;
            }

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        bool flag_bl = false;
        private void label1_Click_1(object sender, EventArgs e)
        {
            if(flag_bl == false)
            {
                this.WindowState = FormWindowState.Maximized;
                     
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
            flag_bl = !flag_bl;
        }

        private void label_bs_MouseMove(object sender, MouseEventArgs e)
        {
            label_bs.BackColor = Color.Wheat;
        }

        private void label_bs_MouseLeave(object sender, EventArgs e)
        {
            label_bs.BackColor = Color.White;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            labelhide.BackColor = Color.Wheat;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            labelhide.BackColor = Color.White;
        }

        private void label1_Click_2(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void выгрузитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if(openFile.ShowDialog() == DialogResult.OK)
            {
                up:
                try
                {
                    ShowMyImage(openFile.FileName, pictureBox1.Width, pictureBox1.Height);
                }
                catch (Exception)
                {
                    goto up;
                }
            }
        }


        private bool flag_tools = false;
        private void инструментыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (flag_tools == false)
            {
                panel_tools.Visible = true;
            }
            else
            {
                panel_tools.Visible = false;
            }
            flag_tools = !flag_tools;
        }

        private void panel_tools_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            //colorDialog1.AllowFullOpen = false;
            colorDialog1.ShowHelp = true;
            if(colorDialog1.ShowDialog() == DialogResult.OK)
            {
                CFV.pen.Color = colorDialog1.Color;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            CFV.currItem = Item.Pencil;          
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            CFV.currItem = Item.Ellipse;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            CFV.currItem = Item.Rectangle;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            CFV.currItem = Item.Line;
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            CFV.currItem = Item.eraser;
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
        }
       
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            CFV.draw = true;
            CFV.x = e.X;
            CFV.y = e.Y;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (CFV.draw)
                {
                    Graphics g = Graphics.FromImage(bmp);
                    //s
                    switch (CFV.currItem) {
                        case Item.Pencil:
                            g.FillEllipse(new SolidBrush(colorDialog1.Color), e.X - CFV.x + CFV.x, e.Y - CFV.y + CFV.y, Convert.ToInt32(toolStripTextBox1.Text), Convert.ToInt32(toolStripTextBox1.Text));
                            pictureBox1.Image = bmp;
                            break;
                    }

                    g.Dispose();
                }
            }
            catch (Exception)
            {

            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                Graphics g = Graphics.FromImage(bmp);
                CFV.draw = false;
                int lx = e.X;
                int ly = e.Y;
                if (CFV.currItem == Item.Line)
                {
                    g.DrawLine(new Pen(new SolidBrush(colorDialog1.Color), Convert.ToInt32(toolStripTextBox1.Text)), new Point(CFV.x, CFV.y), new Point(lx, ly));
                    pictureBox1.Image = bmp;
                    g.Dispose();
                }
                //swap on move
                switch (CFV.currItem)
                {
                    case Item.Rectangle:
                        g.DrawRectangle(new Pen(colorDialog1.Color), CFV.x, CFV.y, e.X + CFV.x, e.Y + CFV.y);
                        pictureBox1.Image = bmp;
                        break;
                    case Item.Ellipse:
                        g.DrawEllipse(new Pen(colorDialog1.Color), CFV.x, CFV.y, CFV.x + e.X, CFV.y + e.Y);
                        pictureBox1.Image = bmp;
                        break;               
                    case Item.eraser:
                        g.FillEllipse(new SolidBrush(pictureBox1.BackColor), e.X - CFV.x + CFV.x, e.Y - CFV.y + CFV.y, Convert.ToInt32(toolStripTextBox1.Text), Convert.ToInt32(toolStripTextBox1.Text));
                        pictureBox1.Image = bmp;
                        break;
                }
            }
            catch (Exception)
            {

            }
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
           //if(pictureBox1.Image != null){
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.Title = "Сохранить картинку как...";
                saveFile.OverwritePrompt = true;
                saveFile.CheckPathExists = true;
                saveFile.Filter = "Image Files(*.BMP)|*.BMP|Image Files(*.JPG)|*.JPG|Image Files(*.GIF)|*.GIF|Image Files(*.PNG)|*.PNG|All files (*.*)|*.*";
                saveFile.ShowHelp = true;
                if(saveFile.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
               
                    //Graphics g = Graphics.FromImage(bmp);
                    //g.FillRectangle(Brushes.Green, new Rectangle(25, 75, 10, 30));

                    // Set bitmap into picture box
                    //pictureBox1.Image = bmp;
                   // bmp = (Bitmap)pictureBox1.Image;

                    bmp.Save(saveFile.FileName);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Произошла ошибка: Невозможно сохранить изображение.", "Ошибка" , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
           // }
        }
        bool flag_close = false;
        private void toolStripButton8_Click(object sender, EventArgs e)
        {

        }
    }
}
