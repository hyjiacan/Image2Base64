using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
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

        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            tab1Init();
            tab2Init();

            lbVersion.Text = "v " + Application.ProductVersion;
        }

        #region tab1
        /// <summary>
        /// 生成CSS类结构模板
        /// </summary>
        private const string clsTemp = @"
.{0}{1}{2} {{
    {3}: url({4}) {5};
}}
";

        /// <summary>
        /// tab1 初始化
        /// </summary>
        private void tab1Init()
        {
            t1_tFileName.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "style-" + DateTime.Now.ToString("yyMMddHHmmss") + ".css");

            // 这里调用是为了在窗口打开的时候显示模板
            UpdateDemo();
        }

        #region // 窗体按钮功能
        /// <summary>
        /// 选择图片文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bSelectImage_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            var files = openFileDialog.FileNames
                .Where(f => GetMime(f) != string.Empty);
            ShowImages(files);
        }

        /// <summary>
        /// 移除列表中选中的图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bRemoveSelected_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection items = t1_imageList.SelectedItems;
            foreach (ListViewItem item in items)
            {
                t1_imageList.Items.Remove(item);
                xImageList.Images.RemoveByKey(item.Tag.ToString());
            }
        }

        /// <summary>
        /// 移除列表中的所有文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bRemoveAll_Click(object sender, EventArgs e)
        {
            t1_imageList.Items.Clear();
            xImageList.Images.Clear();
        }

        /// <summary>
        /// 开始处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bRun_Click(object sender, EventArgs e)
        {
            Start();
        }

        #endregion

        #region // 生成任务

        /// <summary>
        /// 启动后台线程
        /// </summary>
        void Start()
        {
            if (t1_imageList.Items.Count > 0)
            {
                t1_log.Text = "开始生成...";
                t1_backgroundWorker.RunWorkerAsync();
            }
            else
            {
                t1_log.Text = "没有图片";
            }
        }

        /// <summary>
        /// 后台线程的处理方法，此函数将根据图片生成对应的CSS文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void t1_backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
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
                    Invoke(new MethodInvoker(() =>
                    {
                        t1_tStyleName.Text = "background";
                    }));
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
                    filename = Path.GetFileNameWithoutExtension(filename);

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
                Invoke(new MethodInvoker(() =>
                {
                    t1_log.Text = "生成完成，正在写文件...";
                }));
                File.WriteAllText(t1_tFileName.Text, sb.ToString(), Encoding.UTF8);
                Invoke(new MethodInvoker(() =>
                {
                    t1_log.Text = "写文件完成";
                }));
            }
            catch (Exception ex)
            {
                Invoke(new MethodInvoker(() =>
                {
                    t1_log.Text = ex.Message;
                }));
            }
        }
        #endregion

        #region 处理拖拽的图片
        /// <summary>
        /// 松开拖放的鼠标按钮，将图片显示到列表中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void t1_imageList_DragDrop(object sender, DragEventArgs e)
        {
            dropWorker.RunWorkerAsync(e.Data.GetData("FileDrop"));
        }

        /// <summary>
        /// 鼠标拖动文件到列表中，判断文件是否是图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void t1_imageList_DragEnter(object sender, DragEventArgs e)
        {
            string[] ps = e.Data.GetData("FileDrop") as string[];
            if (ps == null || ps.Length == 0)
            {
                return;
            }
            if (ps.Any(f => !string.IsNullOrEmpty(GetMime(f))))
            {
                e.Effect = DragDropEffects.Link;
            }
        }
        #endregion

        #region // 事件绑定
        /// <summary>
        /// 模板属性编辑时，实时更新模板内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void input_TextChanged(object sender, EventArgs e)
        {
            UpdateDemo();
        }

        /// <summary>
        /// 列表中的项激活（双击项）时，复制项对应图片的Base64编码数据到剪贴板中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void imageList_ItemActivate(object sender, EventArgs e)
        {
            var name = t1_imageList.FocusedItem.Tag.ToString();
            Clipboard.SetText(GetBase64(name), TextDataFormat.Text);
            t1_log.Text = "已复制\"" + name + "\"的数据";
        }
        #endregion

        #region // 私有功能

        /// <summary>
        /// 将图片依次添加到列表中显示
        /// </summary>
        /// <param name="files"></param>
        private void ShowImages(IEnumerable<string> files)
        {
            Invoke(new MethodInvoker(() =>
            {
                var count = files.Count();
                dropProgress.Maximum = count;
                dropProgress.Value = 1;
                Cursor = Cursors.WaitCursor;
                var i = 0;
                // 向图片列表中添加项            
                foreach (string filename in files)
                {
                    try
                    {
                        // 这里使用文件流，解决程序不关闭会一直占用资源的问题
                        using (FileStream fs = new FileStream(filename, FileMode.Open))
                        {
                            i++;
                            Bitmap image = new Bitmap(fs);
                            fs.Close();
                            xImageList.Images.Add(filename, image);
                            ListViewItem item = t1_imageList.Items.Add(Path.GetFileNameWithoutExtension(filename));
                            item.Tag = item.ImageKey = filename;

                            dropProgress.PerformStep();

                            if (count > 8 && (i % 8 == 0 || count == i))
                            {
                                Application.DoEvents();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        t1_log.Text = ex.Message;
                    }
                }
                Cursor = Cursors.Default;
            }));
        }

        /// <summary>
        /// 更新生成的CSS类模板
        /// </summary>
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

        #region tab2
        // 工作目录或文件
        string path;
        // 当前扫描目录
        string currentPath;
        // 要删除的图片文件
        List<string> delImgs;
        // 需要处理的目录列表
        List<string> dirs;

        private void tab2Init()
        {
            delImgs = new List<string>();
            dirs = new List<string>();
        }
        /// <summary>
        /// 选择CSS文件或目录 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void t2_bSelect_Click(object sender, EventArgs e)
        {
            if (t2_rPath.Checked && folderBrowserDialog.ShowDialog(this) == DialogResult.OK)
            {
                t2_tPath.Text = folderBrowserDialog.SelectedPath;
                return;
            }

            if (openCssFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                t2_tPath.Text = openCssFileDialog.FileName;
            }
        }
        /// <summary>
        /// 开始处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void t2_bStart_Click(object sender, EventArgs e)
        {
            t2_backgroundWorker.RunWorkerAsync();
        }
        /// <summary>
        /// 停止处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void t2_bStop_Click(object sender, EventArgs e)
        {
            try { t2_backgroundWorker.CancelAsync(); }
            catch (Exception ex)
            {
                x("停止失败", ex.Message);
            }
        }
        /// <summary>
        /// 使用BASE64替换图片地址
        /// </summary>
        /// <param name="match"></param>
        /// <returns></returns>
        string ReplaceURL(Match match)
        {
            string base64 = match.Value;
            if (!match.Success)
            {
                return base64;
            }

            //取匹配结果中的子项
            GroupCollection grps = match.Groups;
            if (grps.Count <= 1)
            {
                return base64;
            }

            // 匹配到了地址
            string url = grps[1].Value;

            if (string.IsNullOrEmpty(url))
            {
                return base64;
            }

            url = url.Trim(new char[] { '\t', ' ', '"', '\'' });

            try
            {
                // 图片的地址
                string imgname = Path.Combine(currentPath, url);
                if (!File.Exists(imgname))
                {
                    return base64;
                }
                // 判断是否是图片
                if (string.Empty == GetMime(imgname))
                {
                    return base64;
                }
                base64 = "url(\"" + GetBase64(imgname) + "\")";
                delImgs.Add(imgname);

                return base64;
            }
            catch
            {
                return base64;
            }
        }

        /// <summary>
        /// 处理CSS文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void t2_backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                delImgs.Clear();
                dirs.Clear();

                List<string> files = null;
                path = t2_tPath.Text.Trim();
                if (t2_rPath.Checked)
                {
                    x("开始扫描...");
                    // 扫描目录
                    if (!Directory.Exists(path))
                    {
                        x("路径", path, "不存在");
                        return;
                    }
                    files = EnumFile(path, new string[] { ".css" });
                    x("共扫描到" + files.Count + "个CSS文件");
                    if (files.Count == 0)
                    {
                        return;
                    }
                }
                else
                {
                    files = new List<string>(){
                        path
                    };
                }

                t2_tTotal.Text = files.Count.ToString();
                int proceed = 0;

                if (MessageBox.Show(this, t2_rPath.Checked ? "共扫描到" + files.Count + "个CSS文件，是否开始处理？" : "是否立即处理？", "操作确认", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    x("开始处理...");
                    // 匹配  url (地址)
                    Regex reg = new Regex(@"url\s*\(\s*[\'\""]{0,1}\s*(.+?\.(png|jpg|jpeg|bmp|gif|svg))\s*[\'\""]{0,1}\s*\)", RegexOptions.IgnoreCase & RegexOptions.Multiline);
                    foreach (string filename in files)
                    {
                        currentPath = Path.GetDirectoryName(filename);
                        this.Invoke(new MethodInvoker(delegate
                        {
                            t2_tCurrent.Text = (++proceed).ToString();
                        }));
                        //读取　CSS文件内容                        
                        string content = File.ReadAllText(filename);

                        if (!reg.IsMatch(content))
                        {
                            x("-不需处理-" + filename);
                            continue;
                        }

                        x("处理文件" + filename);
                        string newContent = reg.Replace(content, new MatchEvaluator(ReplaceURL));
                        // 写文件
                        File.WriteAllText(filename, newContent);
                    }
                    // 删除图片文件
                    if (t2_cbDeleteImage.Checked)
                    {
                        x("删除处理过的图片...");
                        foreach (string filename in delImgs)
                        {
                            try
                            {
                                File.Delete(filename);
                                string dir = Path.GetDirectoryName(filename);
                                if (!dirs.Contains(dir))
                                {
                                    dirs.Add(dir);
                                }
                            }
                            catch (Exception ex)
                            {
                                x(ex.Message);
                            }
                        }
                    }
                    // 排序，名称最长的是子目录
                    dirs.Sort(xSort);
                    foreach (string dir in dirs)
                    {
                        if (Directory.GetFileSystemEntries(dir).Length == 0)
                        {
                            try { Directory.Delete(dir); }
                            catch (Exception ex)
                            {
                                x(ex.Message);
                            }
                        }
                    }
                }
                x("处理结束");
            }
            catch (Exception ex)
            {
                t2_log.Text = ex.Message;
            }
        }

        /// <summary>
        /// 对目录排序，使目录从子到根（目录名长度从长到短）排序
        /// </summary>
        /// <param name="y"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        private int xSort(string y, string x)
        {
            if (x == null && y == null)
            {
                return 0;
            }

            if (x == null)
            {
                return -1;
            }

            if (y == null)
            {
                return 1;
            }

            int xLen = x.Length;
            int yLen = y.Length;
            if (xLen == yLen)
            {
                return 0;
            }

            if (xLen > yLen)
            {
                return 1;
            }
            return -1;

        }
        /// <summary>
        /// 遍历指定目录下的文件
        /// </summary>
        /// <param name="path">要遍历的路径</param>
        /// <param name="pattern">匹配的文件扩展名 需要包含 .</param>
        /// <param name="currentPathOnly">是否只遍历当前目录（不处理子目录），默认为false（处理子目录）</param>
        /// <returns>所有文件列表</returns>
        public static List<string> EnumFile(string path, string[] pattern, bool currentPathOnly = false)
        {
            List<string> files = new List<string>();
            // 检查目录是否存在
            if (!Directory.Exists(path))
            {
                return files;
            }

            FileSystemInfo[] fs = new DirectoryInfo(path).GetFileSystemInfos();

            foreach (FileSystemInfo fsi in fs)
            {
                if ((fsi.Attributes & FileAttributes.System) == FileAttributes.System)
                { // 跳过系统
                    continue;
                }
                if ((fsi.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden)
                { // 跳过隐藏
                    continue;
                }
                if ((fsi.Attributes & FileAttributes.Directory) == FileAttributes.Directory)
                {   // 目录
                    files.AddRange(EnumFile(fsi.FullName, pattern, false));
                    continue;
                }

                // 文件
                if (pattern != null && pattern.Length > 0 && !new List<string>(string.Join(",", pattern).ToUpper().Split(new char[] { ',' })).Contains(fsi.Extension.ToUpper()))
                { // 筛选指定的文件类型
                    continue;
                }
                files.Add(fsi.FullName);
            }

            return files;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            t2_log.Clear();
        }

        /// <summary>
        /// 输出日志
        /// </summary>
        /// <param name="args"></param>
        private void x(params object[] args)
        {
            if (args == null || args.Length == 0)
            {
                if (!InvokeRequired)
                {
                    t2_log.AppendText(Environment.NewLine);
                    return;
                }
                Invoke(new MethodInvoker(() =>
                {
                    t2_log.AppendText(Environment.NewLine);
                }));
                return;
            }
            if (!InvokeRequired)
            {
                t2_log.AppendText(string.Join("", args) + Environment.NewLine);
                return;
            }
            Invoke(new MethodInvoker(() =>
            {
                t2_log.AppendText(string.Join("", args) + Environment.NewLine);
            }));
        }
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
                Process.Start("http://www.hyjiacan.com/i2b?ref=i2b");
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
            }
        }


        #endregion

        private void dropWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            ShowImages(e.Argument as string[]);
        }
    }
}
