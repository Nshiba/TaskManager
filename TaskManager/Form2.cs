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

        /// <summary>
        /// タスクの追加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void add_Click_1(object sender, EventArgs e)
        {
            var manager = new ManagerUtil();
            var taskName = nametext.Text;

            var task = new Task()
            {
                name = taskName,
                deadline = kigen.Value,
                tag = tagBox.Text,
                outline = outlineBox.Text
            };

            manager.createData(taskName, task);

            this.Close();

            
        }

        /// <summary>
        /// キャンセルが押されたとき
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cansel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// タグBoxの設定
        /// </summary>
        private void load_tagBox()
        {
            tagBox.Items.Clear();

            ManagerUtil manager = new ManagerUtil();
            var tagList = manager.getTagList();

            foreach (String tag in tagList)
            {
                tagBox.Items.Add(tag);
            }
            tagBox.SelectedIndex = 0;
        }

        /// <summary>
        /// タグの追加
        /// （新しいフォームの表示）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addTag_Click(object sender, EventArgs e)
        {
            var addFrom = new addTag();

            //閉じられたときに処理するためにコールバック関数の設定
            addFrom.FormClosed += this.formClosed;

            addFrom.Show();
        }

        ///フォームが閉じられたときの処理
        private void formClosed(object sender, FormClosedEventArgs e)
        {
            load_tagBox();
        }
    }
}
