
namespace SokakHayvanlari.Forms
{
    partial class SahiplendirmeFormu
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblBaslik;
        private System.Windows.Forms.Label lblHayvan;
        private System.Windows.Forms.Label lblDurum;

        private System.Windows.Forms.ComboBox cmbHayvan;
        private System.Windows.Forms.ComboBox cmbDurum;

        private System.Windows.Forms.Button btnBasvuruYap;
        private System.Windows.Forms.Button btnDurumGuncelle;
        private System.Windows.Forms.Button btnListele;

        private System.Windows.Forms.DataGridView dgvBasvurular;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblBaslik = new System.Windows.Forms.Label();
            lblHayvan = new System.Windows.Forms.Label();
            lblDurum = new System.Windows.Forms.Label();

            cmbHayvan = new System.Windows.Forms.ComboBox();
            cmbDurum = new System.Windows.Forms.ComboBox();

            btnBasvuruYap = new System.Windows.Forms.Button();
            btnDurumGuncelle = new System.Windows.Forms.Button();
            btnListele = new System.Windows.Forms.Button();

            dgvBasvurular = new System.Windows.Forms.DataGridView();

            this.SuspendLayout();

            lblBaslik.Text = "SAHİPLENDİRME BAŞVURULARI";
            lblBaslik.Location = new System.Drawing.Point(260, 20);
            lblBaslik.AutoSize = true;

            lblHayvan.Text = "Hayvan Seç:";
            lblHayvan.Location = new System.Drawing.Point(30, 75);
            lblHayvan.AutoSize = true;

            cmbHayvan.Location = new System.Drawing.Point(140, 70);
            cmbHayvan.Size = new System.Drawing.Size(220, 25);
            cmbHayvan.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;

            btnBasvuruYap.Text = "Başvuru Yap";
            btnBasvuruYap.Location = new System.Drawing.Point(140, 115);
            btnBasvuruYap.Size = new System.Drawing.Size(110, 35);

            btnListele.Text = "Listele";
            btnListele.Location = new System.Drawing.Point(260, 115);
            btnListele.Size = new System.Drawing.Size(100, 35);

            lblDurum.Text = "Başvuru Durumu:";
            lblDurum.Location = new System.Drawing.Point(30, 180);
            lblDurum.AutoSize = true;

            cmbDurum.Location = new System.Drawing.Point(140, 175);
            cmbDurum.Size = new System.Drawing.Size(220, 25);
            cmbDurum.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;

            cmbDurum.Items.AddRange(new object[]
            {
                "Beklemede",
                "Onaylandı",
                "Reddedildi"
            });

            cmbDurum.SelectedIndex = 0;

            btnDurumGuncelle.Text = "Durumu Güncelle";
            btnDurumGuncelle.Location = new System.Drawing.Point(140, 215);
            btnDurumGuncelle.Size = new System.Drawing.Size(150, 35);

            dgvBasvurular.Location = new System.Drawing.Point(30, 280);
            dgvBasvurular.Size = new System.Drawing.Size(720, 230);
            dgvBasvurular.AutoSizeColumnsMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvBasvurular.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvBasvurular.MultiSelect = false;
            dgvBasvurular.ReadOnly = true;
            dgvBasvurular.AllowUserToAddRows = false;

            this.Controls.Add(lblBaslik);
            this.Controls.Add(lblHayvan);
            this.Controls.Add(lblDurum);

            this.Controls.Add(cmbHayvan);
            this.Controls.Add(cmbDurum);

            this.Controls.Add(btnBasvuruYap);
            this.Controls.Add(btnDurumGuncelle);
            this.Controls.Add(btnListele);

            this.Controls.Add(dgvBasvurular);

            this.ClientSize = new System.Drawing.Size(800, 550);
            this.Name = "SahiplendirmeFormu";
            this.Text = "Sahiplendirme Yönetimi";

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
