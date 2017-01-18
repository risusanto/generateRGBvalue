using System;
using System.Drawing;
using System.Windows.Forms;

namespace citra
{
    public partial class Form1 : Form
    {
        bool gambar = false;
        string rgbValue;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            rgbValue = "";
            if (!gambar)
            {
                label4.Text = "Silahkan pilih gambar";
            }
            else
            {
                try
                {
                    getRGB();
                }
                catch
                {
                    label4.Text = "salah";
                }
            }
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Cari Gambar";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Bitmap bm = new Bitmap(dlg.FileName);
                image.Image = bm;
                gambar = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label4.Text = "";
        }

        void getRGB()
        {
            Bitmap a = new Bitmap(image.Image);
            if (a.Height > 30 || a.Width > 30)
                label4.Text = "Resulusi gambar terlalu besar! maksimal 30x30 pixel";
            else
            {
                for (int i = 0; i < a.Width; i++)
                {
                    for (int j = 0; j < a.Height; j++)
                    {
                        Color clr = a.GetPixel(i, j);
                        rgbValue = rgbValue + string.Format("f({0},{1})= RGB({2},{3},{4})", i, j, clr.R, clr.G, clr.B) + "\n";

                    }
                    rgbValue = rgbValue + "\n";
                }
                SaveFileDialog save1 = new SaveFileDialog();
                save1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                save1.FilterIndex = 2;
                save1.RestoreDirectory = true;
                if (save1.ShowDialog() == DialogResult.OK)
                {
                    System.IO.File.WriteAllText(save1.FileName, rgbValue);
                    label4.Text = "File tersimpan sebagai:\n" + save1.FileName;
                }
            }
        }
    }
}
