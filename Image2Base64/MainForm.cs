using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace hyjiacan.util.i2b
{
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

            tab1Init();
        }

        #region tab1
        private string clsTemp;


        private void tab1Init()
        {
            t1_tFileName.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "style-" + DateTime.Now.ToString("yyMMddHHmmss") + ".css");
            clsTemp = @"
.{0}{1}{2} {{
    {3}: url({4}) {5};
}}
";
            UpdateDemo();
        }

        #region // 窗体按钮功能
        /// <summary>
        /// 选择图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bSelectImage_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                List<string> files = new List<string>();
                foreach (string item in openFileDialog.FileNames)
                {
                    if (GetMime(item) != string.Empty)
                    {
                        files.Add(item);
                    }
                }
                ShowImages(files);
            }
        }

        private void bRemoveSelected_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection items = t1_imageList.SelectedItems;
            foreach (ListViewItem item in items)
            {
                t1_imageList.Items.Remove(item);
                xImageList.Images.RemoveByKey(item.Tag.ToString());
            }
        }

        private void bRemoveAll_Click(object sender, EventArgs e)
        {
            t1_imageList.Items.Clear();
            xImageList.Images.Clear();
        }
        /// <summary>
        /// 生成图片的base64
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bRun_Click(object sender, EventArgs e)
        {
            Start();
        }

        #endregion

        #region // 生成任务
        void Start()
        {
            if (t1_imageList.Items.Count > 0)
            {
                t1_log.Text = "开始生成...";
                runWorker.RunWorkerAsync();
            }
            else
            {
                t1_log.Text = "没有图片";
            }
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                string prefix = t1_tPrefix.Text.Trim();
                string suffix = t1_tSuffix.Text.Trim();
                string other = t1_tOther.Text.Trim();
                string name = t1_tStyleName.Text.Trim();
                char specChar = t1_rSpecCharUnderline.Checked ? '_' : '-';
                bool trimhead = t1_cbDelSpecCharHead.Checked;
                bool trimtail = t1_cbDelSpecCharTail.Checked;
                if (string.IsNullOrEmpty(name))
                {
                    t1_tStyleName.Text = "background";
                    name = "background";
                }
                StringBuilder sb = new StringBuilder();
                ListView.ListViewItemCollection items = t1_imageList.Items;

                Regex reg = new Regex(@"[^a-zA-Z0-9]+");

                foreach (ListViewItem item in items)
                {
                    string base64 = GetBase64(item.Tag.ToString());
                    string filename = item.Text;

                    // 获取不带扩展名的文件名
                    filename = filename.Substring(0, filename.LastIndexOf('.'));

                    // 替换文件名中的特殊字符
                    filename = reg.Replace(filename, specChar.ToString());
                    if (trimhead && filename[0] == specChar)
                    {
                        filename = filename.Substring(1);
                    }

                    if (trimtail && filename[filename.Length - 1] == specChar)
                    {
                        filename = filename.Substring(0, filename.Length - 1);
                    }

                    sb.AppendFormat(clsTemp, prefix, filename, suffix, name, base64, other);
                }
                t1_log.Text = "生成完成，正在写文件...";
                StreamWriter file = new StreamWriter(t1_tFileName.Text, false, Encoding.UTF8);
                file.WriteLine(sb.ToString());
                file.Flush();
                file.Close();
                t1_log.Text = "写文件完成";
            }
            catch (Exception ex)
            {
                t1_log.Text = "发生错误";
                MessageBox.Show(this, ex.Message, "错误");
            }
        }
        #endregion

        #region 处理拖拽的图片
        private void t1_imageList_DragDrop(object sender, DragEventArgs e)
        {
            ShowImages((string[])e.Data.GetData("FileDrop"));
        }

        private void t1_imageList_DragEnter(object sender, DragEventArgs e)
        {
            string[] ps = (string[])e.Data.GetData("FileDrop");
            if (ps.Length > 0)
            {
                string filename = ps[0];
                if (!string.IsNullOrEmpty(GetMime(filename)))
                {
                    e.Effect = DragDropEffects.Link;
                }
            }
        }
        #endregion

        #region // 事件绑定
        private void input_TextChanged(object sender, EventArgs e)
        {
            UpdateDemo();
        }

        private void imageList_ItemActivate(object sender, EventArgs e)
        {
            Clipboard.SetText(GetBase64(t1_imageList.FocusedItem.Tag.ToString()), TextDataFormat.Text);
            t1_log.Text = "已复制";
        }
        #endregion

        #region // 私有功能



        private void ShowImages(IList<string> files)
        {
            // 向图片列表中添加项
            foreach (string filename in files)
            {
                try
                {
                    // 这里使用文件流，解决程序不关闭会一直占用资源的问题
                    using (FileStream fs = new FileStream(filename, FileMode.Open))
                    {
                        Bitmap image = new Bitmap(fs);
                        fs.Close();
                        xImageList.Images.Add(filename, image);
                    }
                }
                catch { }
            }

            // 显示图片
            this.Invoke((MethodInvoker)delegate
            {
                foreach (string filename in files)
                {
                    ListViewItem item = t1_imageList.Items.Add(filename.Substring(filename.LastIndexOf(Path.DirectorySeparatorChar) + 1));
                    item.Tag = filename;
                    item.ImageKey = filename;
                }
            });
        }


        private void UpdateDemo()
        {
            string prefix = t1_tPrefix.Text.Trim();
            string suffix = t1_tSuffix.Text.Trim();
            string other = t1_tOther.Text.Trim();
            string name = t1_tStyleName.Text.Trim();
            if (string.IsNullOrEmpty(prefix))
            {
                prefix = "[前缀]";
            }
            if (string.IsNullOrEmpty(suffix))
            {
                suffix = "[后缀]";
            }
            if (string.IsNullOrEmpty(other))
            {
                other = "[其它属性]";
            }
            if (string.IsNullOrEmpty(name))
            {
                t1_tStyleName.Text = "background";
                name = "background";
            }
            t1_tDemo.Text = string.Format(clsTemp, prefix, "[文件名]", suffix, name, "[图片BASE64数据]", other);
        }
        #endregion

        #endregion


        #region 公共功能
        /// <summary>
        /// 根据文件头读取图片格式
        /// </summary>
        /// <param name="filename"></param>
        /// <returns>返回图片的mime，若不是图片，返回 string.Empty </returns>
        public static string GetMime(string filename)
        {
            byte[] flagByte = new byte[2];
            string mime = string.Empty;
            string flag = string.Empty;
            using (FileStream stream = new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
                stream.Read(flagByte, 0, 2);
                stream.Close();
            }

            if (flagByte != null && flagByte.Length > 0)
            {
                flag = flagByte[0].ToString() + flagByte[1].ToString();
            }

            switch (flag)
            {
                // JPG
                case "255216":
                    mime = "image/jpg";
                    break;
                // GIF
                case "7173":
                    mime = "image/gif";
                    break;
                // PNG
                case "13780":
                    mime = "image/png";
                    break;
                // BMP
                case "6677":
                    mime = "image/bmp";
                    break;
            }
            return mime;
        }
        /// <summary>
        /// 生成图片的Base64编码数据
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        private string GetBase64(string filename)
        {
            string mime = GetMime(filename);
            string base64string;
            using (FileStream stream = new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
                List<byte> bs = new List<byte>();
                byte[] buffer = new byte[1024];
                while (stream.Read(buffer, 0, buffer.Length) != 0)
                {
                    bs.AddRange(buffer);
                    Array.Clear(buffer, 0, buffer.Length);
                }
                stream.Close();
                byte[] data = bs.ToArray();

                base64string = string.Format("data:{0};base64,{1}", mime, Convert.ToBase64String(data));
            }
            return base64string;
        }
        /// <summary>
        /// 加群
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("http://shang.qq.com/wpa/qunwpa?idkey=db8d8453051fe1e188d7e601e8841a98959e73b497de0c59c02705a0515e2683");
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
            }
        }
        /// <summary>
        /// 打开网站
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Process.Start("http://www.hyjiacan.com?ref=i2b");
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
            }
        }

        #endregion
    }
}
