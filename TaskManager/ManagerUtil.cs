using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Windows.Forms;
using System.Collections;
using TaskManager;

namespace TaskManager
{
    /// <summary>
    /// データを取り扱うクラス
    /// </summary>
    class ManagerUtil
    {
        /// <summary>
        /// データの作成
        /// データ形式はJSON
        /// </summary>
        /// <param name="filename">名前</param>
        /// <param name="data">Task型</param>
        public void createData(String filename, Task data)
        {
            if (!Directory.Exists("data"))
            {
                Directory.CreateDirectory("data");
            }

            filename = "data\\" + filename + ".json";

            var existNames = allFilename();

            foreach (var name in allFilename())
            {
                if (name.Equals(filename))
                {
                    MessageBox.Show("同一名のタスクは作成できません");
                    return;
                }
            }

            //DataContractSerializreをインスタンス化
            var serializer = new DataContractJsonSerializer(typeof(Task));

            FileStream fs = new FileStream(filename, FileMode.Create);

            try
            {
                serializer.WriteObject(fs, data);
            }
            finally
            {
                fs.Close();
            }
        }


        /// <summary>
        /// ファイル名を指定してデータの読み込み
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public Task readData(String filename)
        {
            if (!File.Exists(filename))
            {
                return null;
            }

            var serializer = new DataContractJsonSerializer(typeof(Task));
            var obj = default(Task);

            if (new FileInfo(filename).Length == 0)
            {
                return obj;
            }

            MemoryStream data = null;

            try
            {

                using (data = new MemoryStream(
                    Encoding.UTF8.GetBytes(
                    File.ReadAllText(filename, Encoding.UTF8))))
                {

                    System.Xml.XmlDictionaryReader xmlReader = null;

                    try
                    {
                        using (xmlReader = JsonReaderWriterFactory.CreateJsonReader(
                            data, System.Xml.XmlDictionaryReaderQuotas.Max))
                        {
                            obj = (Task)serializer.ReadObject(xmlReader);
                        }
                    }
                    finally
                    {
                        if (xmlReader != null)
                        {
                            GC.SuppressFinalize(xmlReader);
                            xmlReader = null;
                        }
                    }
                }
            }
            finally
            {
                serializer = null;
            }
            return obj;
        }

        /// <summary>
        /// dataフォルダ以下のファイル名をすべて取得
        /// </summary>
        /// <returns>String型の配列</returns>
        public String[] allFilename(){
            if (!Directory.Exists("data"))
            {
                Directory.CreateDirectory("data");
            }
            return Directory.GetFiles("data\\");
        }

        /// <summary>
        /// データを削除するメソッド
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool deleteData(String name)
        {
            var filename = name;
            filename = "data\\" + filename + ".json";

            if (!File.Exists(filename))
            {
                MessageBox.Show(name + "というタスクは存在しません");
                return false;
            }

            System.IO.File.Delete(filename);
            return true;
        }

        /// <summary>
        /// すべてのタグの読み込み
        /// </summary>
        /// <returns></returns>
        public ArrayList getTagList()
        {
            String path = "tags.csv";
            if (!File.Exists(path))
            {
                writeTag("タグ無し");
            }
            
            //csvファイル読み込み
            var csvText = new StreamReader(path, Encoding.GetEncoding("UTF-8"));

            var csvList = new ArrayList();
            
            //1行ずつ読み込み
            var csvTextLine = csvText.ReadLine();
            while (csvTextLine != null)
            {
                csvList.Add(csvTextLine);
                csvTextLine = csvText.ReadLine();
            }

            csvText.Close();

            return csvList;
        }

        /// <summary>
        /// 新規タグの追加
        /// データ形式はcsv
        /// </summary>
        /// <param name="newtag"></param>
        public void writeTag(String newtag)
        {
            //書込み用stream
            var writer = new StreamWriter("tags.csv", true, Encoding.GetEncoding("UTF-8"));

            writer.WriteLine(newtag);
            writer.Close();
        }

        /// <summary>
        /// 指定したtagを削除
        /// </summary>
        /// <param name="deletetag"></param>
        public void deleteTag(String deletetag)
        {
            ManagerUtil manager = new ManagerUtil();

            //タグリストの読み込み
            var tagList = manager.getTagList();

            if (!tagList.Contains(deletetag))
            {
                MessageBox.Show(deletetag + "というタグはありません");
                return;
            }

            tagList.Remove(deletetag);

            //csvファイルに削除後のリストを上書きで書き込み
            var writer = new StreamWriter("tags.csv", false, Encoding.GetEncoding("UTF-8"));
            foreach (String tag in tagList)
            {
                writer.WriteLine(tag);
            }
            writer.Close();
        }

        /// <summary>
        /// タグが削除されたときにそのタグに属しているタスクを削除するメソッド
        /// </summary>
        /// <param name="targetTag"></param>
        public void deleteDataOfTag(String targetTag)
        {
            ManagerUtil manager = new ManagerUtil();
            var taskList = manager.roadTask();

            //一つずつ確認して削除
            foreach (Task task in taskList)
            {
                if (targetTag.Equals(task.tag))
                {
                    manager.deleteData(task.name);
                }
            }
        }

        /// <summary>
        /// 現在あるすべてのタスクを取得
        /// </summary>
        /// <returns></returns>
        public ArrayList roadTask()
        {
            ManagerUtil manager = new ManagerUtil();

            //すべてのタスクをリストに格納
            var nameList = manager.allFilename();
            var taskList = new ArrayList();

            //タスクリストを取得
            foreach (String tagName in nameList)
            {
                var task = manager.readData(tagName);
                taskList.Add(task);
            }
            return taskList;
        }
    }
}
