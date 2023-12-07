using System;
using System.Windows.Forms;

namespace WindowsFormsTasks
{
    public partial class FrmEditor : Form
    {
        public string ItemName { get; set; }

        public FrmEditor()
        {
            InitializeComponent();
        }

        private void FrmEditor_Load(object sender, EventArgs e)
        {
            txtName.Text = ItemName;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text)) 
            {
                MessageBox.Show("Укажите название заметки");
                return;
            }

            ItemName = txtName.Text.Trim();
            DialogResult = DialogResult.OK;
        }

        private void txtName_Click(object sender, EventArgs e)
        {
            ColorDialog c = new ColorDialog();

            if (c.ShowDialog() == DialogResult.OK)
            {
                txtName.BackColor = c.Color;
            }
        }
    }
}
