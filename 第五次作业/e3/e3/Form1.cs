using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace e3
{
    public partial class Form1 : Form
    {
        string[] infileName = new string[2];
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            infileName[0] = "D:\\develop\\CSProgram\\MyWorks\\e3\\e3\\bin\\Debug\\file1.txt";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            infileName[1] = "D:\\develop\\CSProgram\\MyWorks\\e3\\e3\\bin\\Debug\\file2.txt";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FileStream[] fileIn = new FileStream[2];
            using (FileStream fileOut = new FileStream("D:\\develop\\CSProgram\\MyWorks\\e3\\e3\\bin\\Debug\\result.txt", FileMode.Create))
            {
                int b;
                for (int i = 0; i < fileIn.Length; i++)
                {
                    try
                    {
                        fileIn[i] = new FileStream(infileName[i], FileMode.Open);
                        while ((b = fileIn[i].ReadByte()) != -1)
                        {
                            fileOut.WriteByte((byte)b);
                        }
                        MessageBox.Show("合并成功！请在目录中查看！");
                    }
                    catch
                    {
                        MessageBox.Show("合并失败！请选择正确文件！");
                    }
                    finally
                    {
                        fileIn[i].Close();
                    }

                }
                fileOut.Close();
            }
        }
    }
}
