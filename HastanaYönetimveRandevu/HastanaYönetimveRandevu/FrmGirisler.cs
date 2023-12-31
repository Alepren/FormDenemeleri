namespace HastanaYönetimveRandevu
{
    public partial class FrmGirisler : Form
    {
        public FrmGirisler()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void BtnHastaGirisi_Click(object sender, EventArgs e)
        {
            FrmHastaGiris FrmHastaGiris= new FrmHastaGiris();
            FrmHastaGiris.Show();
            this.Hide();
        }

        private void BtnDoktorGirisi_Click(object sender, EventArgs e)
        {
            FrmDoktorGiris FrmDoktorGiris= new FrmDoktorGiris();
            FrmDoktorGiris.Show();
            this.Hide();
        }

        private void BtnSekreterGirisi_Click(object sender, EventArgs e)
        {
            FrmSekreterGiris frmSekreterGiris= new FrmSekreterGiris();
            frmSekreterGiris.Show();
            this.Hide();
        }
    }
}