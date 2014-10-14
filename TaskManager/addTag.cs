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
    public partial class addTag : Form
    {
        public addTag()
        {
            InitializeComponent();
        }

        private void add_Click(object sender, EventArgs e)
        {
            var manager = new ManagerUtil();

            String newtag = tagName.Text;

        /*    //現在のタグリストを取得
            var tagList = manager.tagList();
            tagList.Add(name);
         */

            //新しいタグをcsvファイルに書き込む
            manager.writeTag(newtag);
            this.Close();
        }

        private void cansel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
