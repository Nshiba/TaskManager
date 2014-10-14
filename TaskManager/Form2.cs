using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaskManager;

namespace TaskManager
{
    public partial class Form2 : Form
    {
        
        public Form2()
        {
            InitializeComponent();
            load_tagBox();
        }

        private void add_Click_1(object sender, EventArgs e)
        {

            if (nametext.Text.Equals(""))
            {
                MessageBox.Show("名前を入力してください。", "エラー", MessageBoxButtons.OK);
                return;
            }
            if (tukiBox.Text.Equals("") || hinitiBox.Text.Equals(""))
            {
                MessageBox.Show("期限を選択してください。", "エラー", MessageBoxButtons.OK);
                return;
            }

            var manager = new ManagerUtil();
            var taskName = nametext.Text;

            var task = new Task()
            {
                name = taskName,
                deadline = tukiBox.Text + hinitiBox.Text,
                tag = tagBox.Text,
                outline = outlineBox.Text
            };

            manager.createData(taskName, task);

            this.Close();

            
        }

        private void cansel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        //tagBoxの設定
        private void load_tagBox()
        {
            tagBox.Items.Clear();

            ManagerUtil manager = new ManagerUtil();
            var tagList = manager.tagList();

            foreach (String tag in tagList)
            {
                tagBox.Items.Add(tag);
            }
            tagBox.SelectedIndex = 0;
        }

        private void addTag_Click(object sender, EventArgs e)
        {
            var addFrom = new addTag();

            addFrom.FormClosed += this.formClosed;

            addFrom.Show();
        }

        private void formClosed(object sender, FormClosedEventArgs e)
        {
            load_tagBox();
        }
    }
}
