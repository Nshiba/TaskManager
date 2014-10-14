using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using TaskManager;

namespace TaskManager
{
    public partial class Form1 : Form
    {
        private ManagerUtil manager = new ManagerUtil();
        private bool first = true;

        public Form1()
        {
            InitializeComponent();
            loadData();
        }

        //閉じられたときのイベント
        private void form_Closed(object sender, FormClosedEventArgs e)
        {
            loadData();
        }

        //ツリーがクリックされたとき
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (first)
            {
                first = false;
                return;
            }
            
            //タグだったら展開
            treeView1.SelectedNode.Expand();


            //タスクを読み込み
            var taskName = "data\\" + e.Node.Text + ".json";

            Task task = manager.readData(taskName);
            if (task == null)
            {
                return;
            }
            kigen.Text = task.deadline;
            name.Text = task.name;
            outline.Text = task.outline;
        }

        //data以下のファイルを読み込む
        private void loadData()
        {
            treeView1.Nodes.Clear();

            var names = manager.allFilename();
            var tags = manager.tagList();

            //親タグを格納するノードリスト
            var nodeList = new ArrayList();

            foreach (String tagName in tags)
            {
                var node = new TreeNode(tagName);
                nodeList.Add(node);
            }

            foreach (String name in names)
            {
                Task task = manager.readData(name);

                //タグリストから同じタグ名を検索して挿入
                foreach (TreeNode node in nodeList)
                {
                    if (node.Text.Equals(task.tag))
                        node.Nodes.Add(new TreeNode(task.name));
                }
            }

            //親要素をすべてtreeViewに追加
            foreach (TreeNode node in nodeList)
            {
                treeView1.Nodes.Add(node);
            }
            
        }

        private void add_Click(object sender, EventArgs e)
        {
            var form2 = new Form2();

            form2.FormClosed += this.form_Closed;

            form2.Show();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            //現在選択されているノードを取得
            TreeNode selectNode = treeView1.SelectedNode;
            //選択されていなければメソッド終了
            if (selectNode == null)
                return;

            var result = manager.deleteData(selectNode.Text);

            if (!result)
                return;

            loadData();
            kigen.Text = "";
            name.Text = "";
            outline.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void deleteTag_Click(object sender, EventArgs e)
        {
            //現在選択されているノードを取得
            TreeNode selectNode = treeView1.SelectedNode;
            //選択されていなければメソッド終了
            if (selectNode == null)
                return;

            var deletetag = selectNode.Text;

            if (deletetag.Equals("タグ無し"))
            {
                MessageBox.Show("「タグ無し」は削除できません");
                return;
            }

            var result = MessageBox.Show("タグを削除するとこのタグがついたタスクがすべて削除されますがよろしいですか？", "タグを削除", MessageBoxButtons.YesNo);

            if (result == DialogResult.No)
                return;
            
            manager.deleteTag(deletetag);
            manager.deleteDataOfTag(deletetag);

            loadData();
            kigen.Text = "";
            name.Text = "";
            outline.Text = "";
        }
    }
}
