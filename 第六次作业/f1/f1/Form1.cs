using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace f1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeTreeView();
            InitializeListView();
        }

        private void InitializeTreeView()
        {
            TreeNode rootNode = new TreeNode("C:\\");
            rootNode.Tag = "C:\\";
            GetDirectories(rootNode, 1);
            treeView1.Nodes.Add(rootNode);
        }

        // 初始化 ListView
        private void InitializeListView()
        {
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.GridLines = true;

            // 添加列
            listView1.Columns.Add("Name", 150);  // 150 是列宽
            listView1.Columns.Add("Full Path", 300);

            // 如果你想添加图标
            ImageList imgList = new ImageList();
            imgList.Images.Add(SystemIcons.WinLogo.ToBitmap());
            imgList.Images.Add(SystemIcons.WinLogo.ToBitmap());
            listView1.SmallImageList = imgList;
        }

        private void GetDirectories(TreeNode node, int depth)
        {
            if (depth > 4)
            {
                return;
            }

            string path = (string)node.Tag;
            DirectoryInfo directoryInfo = new DirectoryInfo(path);

            try
            {
                foreach (var directory in directoryInfo.GetDirectories())
                {
                    TreeNode newnode = new TreeNode(directory.Name);
                    newnode.Tag = directory.FullName;
                    node.Nodes.Add(newnode);
                    GetDirectories(newnode, depth + 1);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string path = (string)e.Node.Tag;
            PopulateListView(path);
        }

        private void PopulateListView(string path)
        {
            listView1.Items.Clear();
            DirectoryInfo directoryInfo = new DirectoryInfo(path);

            try
            {
                foreach (var directory in directoryInfo.GetDirectories())
                {
                    ListViewItem listViewItem = new ListViewItem(directory.Name, 0);
                    listViewItem.Tag = directory.FullName;
                    AddItemToListView(directory.Name, directory.FullName, 0);
                }
                foreach (var directory in directoryInfo.GetFiles())
                {
                    //ListViewItem listViewItem = new ListViewItem(directory.FullName, 1);
                    //listViewItem.Tag = directory.FullName;
                    AddItemToListView(directory.Name, directory.FullName, 1);
                }
            }
            catch (Exception ex)
            {
                // 处理异常，比如弹窗通知用户
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 添加文件或文件夹
        private void AddItemToListView(string name, string fullPath, int iconIndex)
        {
            ListViewItem item = new ListViewItem(name, iconIndex);
            item.SubItems.Add(fullPath);  // 添加到第二列
            listView1.Items.Add(item);
        }

        private void listView1_DoubleClick(object sender, MouseEventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                string fullPath = listView1.SelectedItems[0].SubItems[1].Text;
                if (Directory.Exists(fullPath))
                {
                    // 如果是文件夹，刷新ListView
                    PopulateListView(fullPath);
                }
                else if (File.Exists(fullPath))
                {
                    // 根据文件类型决定打开方式
                    string extension = Path.GetExtension(fullPath).ToLower();
                    if (extension == ".txt")
                    {
                        Process.Start("notepad.exe", fullPath);
                    }
                    else if (extension == ".exe")
                    {
                        Process.Start(fullPath);
                    }
                    // 其他类型文件暂不处理
                }
            }

        }
    }
}
