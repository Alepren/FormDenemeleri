namespace OkulSistemi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OgrenciNotlar OGR=new OgrenciNotlar();
            OGR.numara = textBox1.Text;
            OGR.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Ogretmen frm=new Ogretmen();
            frm.Show();
            this.Hide();
        }
    }
}