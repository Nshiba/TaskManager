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
using System.IO;
using System.Threading;

namespace TaskManager
{
    public partial class Form1 : Form
    {
        //データ処理用クラスのオブジェクト
        private ManagerUtil mManager = new ManagerUtil();
        private bool first = true;

        public Form1()
        {
            InitializeComponent();

            //gManager.createCalendarService();
            var manager = new ManagerUtil();

            //タグ、タスクの読み込み
            loadData();
        }

        /// <summary>
        /// 初回ロード時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// 別のフォームが閉じられて戻ってきたときの処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void form2_Closed(object sender, FormClosedEventArgs e)
        {
            loadData();
        }

        /// <summary>
        /// 左側タスクツリーがクリックされたときの処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (first)
            {
                first = false;
                return;
            }
            
            //タグだったら展開
            treeView1.SelectedNode.Expand();

            var taskName = "data\\" + e.Node.Text + ".json";

            //タスクを読み込み
            text_refresh();
            openTask(taskName);            
        }

        

        /// <summary>
        /// dataフォルダ以下のファイルをすべて読み込み
        /// ツリーに表示する
        /// </summary>
        private void loadData()
        {
            treeView1.Nodes.Clear();

            var tags = mManager.getTagList();

            //親タグを格納するノードリスト
            var nodeList = new ArrayList();

            foreach (String tagName in tags)
            {
                var node = new TreeNode(tagName,0,0);
                nodeList.Add(node);
            }

            var tasklist = mManager.roadTask();
            foreach (Task task in tasklist)
            {
                //タグリストから同じタグ名を検索して挿入
                foreach (TreeNode node in nodeList)
                {
                    if (node.Text.Equals(task.tag))
                        node.Nodes.Add(task.name,task.name,1,1);
                }
            }

            //親要素をすべてtreeViewに追加
            foreach (TreeNode node in nodeList)
            {
                treeView1.Nodes.Add(node);
            }
            
        }

        /// <summary>
        /// 追加ボタンがクリックされたときの処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void add_Click(object sender, EventArgs e)
        {
            var form2 = new Form2();

            //新しいフォームが閉じられたときに処理を実行したいので
            //コールバック関数を追加
            form2.FormClosed += this.form2_Closed;

            form2.Show();
        }

        /// <summary>
        /// task削除ボタンがクリックされた時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void delete_Click(object sender, EventArgs e)
        {
            //現在選択されているノードを取得
            TreeNode selectNode = treeView1.SelectedNode;
            //選択されていなければメソッド終了
            if (selectNode == null)
                return;

            var result = MessageBox.Show("本当に削除しますか？", "削除", MessageBoxButtons.YesNo);

            if (result == DialogResult.No)
                return;

            var deleteResult = mManager.deleteData(selectNode.Text);

            if (!deleteResult)
                return;


            loadData();
            text_refresh();
        }

        /// <summary>
        /// tag削除ボタンがクリックされたときの処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

            mManager.deleteTag(deletetag);
            mManager.deleteDataOfTag(deletetag);

            loadData();
            text_refresh();
        }

        /// <summary>
        /// タスクツリーのアイテムがクリックされたときの処理
        /// </summary>
        /// <param name="taskName"></param>
        private void openTask(String taskName)
        {
            Task task = mManager.readData(taskName);
            if (task == null)
            {
                return;
            }
            kigen.Text = task.deadline.ToLongDateString();
            name.Text = task.name;
            outline.Text = task.outline;
        }

        /// <summary>
        /// タスク情報の表示をクリア
        /// </summary>
        private void text_refresh()
        {
            kigen.Text = "";
            name.Text = "";
            outline.Text = "";
        }

        /// <summary>
        /// カレンダーアイテムをクリックしたときの処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            //リスト初期化
            formTasklist.Clear();

            var targettasklist = serch_date(monthCalendar1.SelectionStart);

            //リストビューに追加
            foreach (Task task in targettasklist)
            {
                formTasklist.Items.Add(task.name,1);
            }
        }

        /// <summary>
        /// 指定した日付のタスクを取り出す
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        private ArrayList serch_date(DateTime target){

            var tasklist = mManager.roadTask();
            ArrayList resultlist = new ArrayList();

            foreach (Task task in tasklist)
            {
                var taskDate = task.deadline;

                //targetとtaskの日付を整形
                var targetString = target.Year + target.Month + target.Day;
                var taskString = taskDate.Year + taskDate.Month + taskDate.Day;

                //targetと同じ日付だったらリストに追加
                if (taskString == targetString)
                {
                    resultlist.Add(task);
                }
            }

            return resultlist;
        }

        /// <summary>
        /// タスクアイテムがクリックしたときに特定のタスクデータを読み込む
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tasklist_SelectedIndexChanged(object sender, EventArgs e)
        {
            //項目が１つも選択されていない場合
            if (formTasklist.SelectedItems.Count == 0)
                //処理を抜ける
                return;

            var selectedTask = formTasklist.SelectedItems[0].Text;

            var taskName = "data\\" + selectedTask + ".json";

            //タスクを読み込み
            text_refresh();
            openTask(taskName);
        }
    }
}
