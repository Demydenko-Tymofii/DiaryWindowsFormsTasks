using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsTasks.Model;

namespace WindowsFormsTasks
{
    public partial class FrmMain : Form
    {
        TaskItemManager items;

        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            /*
             ДЗ: Добавить кнопку Настройки и отркытие соответсвующей формы с полями настройк цветов важности задач (High, Normal, Low)
             */

            items = new TaskItemManager();

            (chkListBoxTasks as ListBox).DataSource = items;
            (chkListBoxTasks as ListBox).DisplayMember = "Name";
            (chkListBoxTasks as ListBox).ValueMember = "Id";        
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (FrmEditor frm = new FrmEditor()) 
            {
                if (frm.ShowDialog(this) == DialogResult.OK) 
                    items.Add(frm.ItemName);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var item = chkListBoxTasks.SelectedItem as TaskItem;

            using (FrmEditor frm = new FrmEditor())
            {
                frm.ItemName = item.Name;

                if (frm.ShowDialog(this) == DialogResult.OK)
                    items.Edit(item.Id, frm.ItemName);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var item = chkListBoxTasks.SelectedItem as TaskItem;

            items.Delete(item.Id);
        }
    }
}
