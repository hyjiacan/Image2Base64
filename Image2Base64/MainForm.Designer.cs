namespace hyjiacan.util.i2b
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabs = new System.Windows.Forms.TabControl();
            this.tab1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.t1_cbDelSpecCharTail = new System.Windows.Forms.CheckBox();
            this.t1_cbDelSpecCharHead = new System.Windows.Forms.CheckBox();
            this.t1_rSpecCharDash = new System.Windows.Forms.RadioButton();
            this.t1_rSpecCharUnderline = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.t1_log = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.t1_tDemo = new System.Windows.Forms.TextBox();
            this.btnGroup = new System.Windows.Forms.GroupBox();
            this.t1_bSelectImage = new System.Windows.Forms.Button();
            this.t1_bRemoveSelected = new System.Windows.Forms.Button();
            this.t1_bRemoveAll = new System.Windows.Forms.Button();
            this.t1_bRun = new System.Windows.Forms.Button();
            this.configGroup = new System.Windows.Forms.GroupBox();
            this.t1_tStyleName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.t1_tOther = new System.Windows.Forms.TextBox();
            this.t1_tFileName = new System.Windows.Forms.TextBox();
            this.t1_tSuffix = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.t1_tPrefix = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.imgGroup = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.t1_imageList = new System.Windows.Forms.ListView();
            this.xImageList = new System.Windows.Forms.ImageList(this.components);
            this.stateImageList = new System.Windows.Forms.ImageList(this.components);
            this.tabAbout = new System.Windows.Forms.TabPage();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ToolTip_Default = new System.Windows.Forms.ToolTip(this.components);
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.runWorker = new System.ComponentModel.BackgroundWorker();
            this.label11 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label12 = new System.Windows.Forms.Label();
            this.tabs.SuspendLayout();
            this.tab1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.btnGroup.SuspendLayout();
            this.configGroup.SuspendLayout();
            this.imgGroup.SuspendLayout();
            this.tabAbout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabs
            // 
            this.tabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabs.Controls.Add(this.tab1);
            this.tabs.Controls.Add(this.tabAbout);
            this.tabs.Location = new System.Drawing.Point(12, 12);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(836, 484);
            this.tabs.TabIndex = 0;
            // 
            // tab1
            // 
            this.tab1.Controls.Add(this.groupBox2);
            this.tab1.Controls.Add(this.t1_log);
            this.tab1.Controls.Add(this.groupBox1);
            this.tab1.Controls.Add(this.btnGroup);
            this.tab1.Controls.Add(this.configGroup);
            this.tab1.Controls.Add(this.imgGroup);
            this.tab1.Location = new System.Drawing.Point(4, 22);
            this.tab1.Name = "tab1";
            this.tab1.Padding = new System.Windows.Forms.Padding(3);
            this.tab1.Size = new System.Drawing.Size(828, 458);
            this.tab1.TabIndex = 0;
            this.tab1.Text = "处理图片";
            this.tab1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.t1_cbDelSpecCharTail);
            this.groupBox2.Controls.Add(this.t1_cbDelSpecCharHead);
            this.groupBox2.Controls.Add(this.t1_rSpecCharDash);
            this.groupBox2.Controls.Add(this.t1_rSpecCharUnderline);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(500, 179);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(311, 84);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "类名处理";
            // 
            // t1_cbDelSpecCharTail
            // 
            this.t1_cbDelSpecCharTail.AutoSize = true;
            this.t1_cbDelSpecCharTail.Checked = true;
            this.t1_cbDelSpecCharTail.CheckState = System.Windows.Forms.CheckState.Checked;
            this.t1_cbDelSpecCharTail.Location = new System.Drawing.Point(172, 62);
            this.t1_cbDelSpecCharTail.Name = "t1_cbDelSpecCharTail";
            this.t1_cbDelSpecCharTail.Size = new System.Drawing.Size(120, 16);
            this.t1_cbDelSpecCharTail.TabIndex = 28;
            this.t1_cbDelSpecCharTail.Text = "删除结尾特殊字符";
            this.t1_cbDelSpecCharTail.UseVisualStyleBackColor = true;
            // 
            // t1_cbDelSpecCharHead
            // 
            this.t1_cbDelSpecCharHead.AutoSize = true;
            this.t1_cbDelSpecCharHead.Checked = true;
            this.t1_cbDelSpecCharHead.CheckState = System.Windows.Forms.CheckState.Checked;
            this.t1_cbDelSpecCharHead.Location = new System.Drawing.Point(9, 62);
            this.t1_cbDelSpecCharHead.Name = "t1_cbDelSpecCharHead";
            this.t1_cbDelSpecCharHead.Size = new System.Drawing.Size(120, 16);
            this.t1_cbDelSpecCharHead.TabIndex = 27;
            this.t1_cbDelSpecCharHead.Text = "删除开头特殊字符";
            this.t1_cbDelSpecCharHead.UseVisualStyleBackColor = true;
            // 
            // t1_rSpecCharDash
            // 
            this.t1_rSpecCharDash.AutoSize = true;
            this.t1_rSpecCharDash.Checked = true;
            this.t1_rSpecCharDash.Location = new System.Drawing.Point(271, 25);
            this.t1_rSpecCharDash.Name = "t1_rSpecCharDash";
            this.t1_rSpecCharDash.Size = new System.Drawing.Size(29, 16);
            this.t1_rSpecCharDash.TabIndex = 26;
            this.t1_rSpecCharDash.TabStop = true;
            this.t1_rSpecCharDash.Text = "-";
            this.ToolTip_Default.SetToolTip(this.t1_rSpecCharDash, "连字符");
            this.t1_rSpecCharDash.UseVisualStyleBackColor = true;
            // 
            // t1_rSpecCharUnderline
            // 
            this.t1_rSpecCharUnderline.AutoSize = true;
            this.t1_rSpecCharUnderline.Location = new System.Drawing.Point(221, 25);
            this.t1_rSpecCharUnderline.Name = "t1_rSpecCharUnderline";
            this.t1_rSpecCharUnderline.Size = new System.Drawing.Size(29, 16);
            this.t1_rSpecCharUnderline.TabIndex = 25;
            this.t1_rSpecCharUnderline.Text = "_";
            this.ToolTip_Default.SetToolTip(this.t1_rSpecCharUnderline, "下划线");
            this.t1_rSpecCharUnderline.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(203, 12);
            this.label7.TabIndex = 24;
            this.label7.Text = "特殊字符替换为(字母数字和-字符外)";
            this.ToolTip_Default.SetToolTip(this.label7, "替换时会自动合并特殊字符");
            // 
            // t1_log
            // 
            this.t1_log.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.t1_log.AutoEllipsis = true;
            this.t1_log.BackColor = System.Drawing.Color.Black;
            this.t1_log.ForeColor = System.Drawing.Color.Red;
            this.t1_log.Location = new System.Drawing.Point(498, 426);
            this.t1_log.Name = "t1_log";
            this.t1_log.Size = new System.Drawing.Size(317, 23);
            this.t1_log.TabIndex = 21;
            this.t1_log.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.t1_tDemo);
            this.groupBox1.Location = new System.Drawing.Point(498, 334);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(313, 86);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "生成说明";
            // 
            // t1_tDemo
            // 
            this.t1_tDemo.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.t1_tDemo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.t1_tDemo.Location = new System.Drawing.Point(11, 19);
            this.t1_tDemo.Multiline = true;
            this.t1_tDemo.Name = "t1_tDemo";
            this.t1_tDemo.ReadOnly = true;
            this.t1_tDemo.Size = new System.Drawing.Size(294, 58);
            this.t1_tDemo.TabIndex = 0;
            // 
            // btnGroup
            // 
            this.btnGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGroup.Controls.Add(this.t1_bSelectImage);
            this.btnGroup.Controls.Add(this.t1_bRemoveSelected);
            this.btnGroup.Controls.Add(this.t1_bRemoveAll);
            this.btnGroup.Controls.Add(this.t1_bRun);
            this.btnGroup.Location = new System.Drawing.Point(498, 269);
            this.btnGroup.Name = "btnGroup";
            this.btnGroup.Size = new System.Drawing.Size(313, 59);
            this.btnGroup.TabIndex = 19;
            this.btnGroup.TabStop = false;
            this.btnGroup.Text = "操作";
            // 
            // t1_bSelectImage
            // 
            this.t1_bSelectImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.t1_bSelectImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.t1_bSelectImage.Location = new System.Drawing.Point(11, 22);
            this.t1_bSelectImage.Name = "t1_bSelectImage";
            this.t1_bSelectImage.Size = new System.Drawing.Size(66, 29);
            this.t1_bSelectImage.TabIndex = 4;
            this.t1_bSelectImage.Text = "选择图片";
            this.t1_bSelectImage.UseVisualStyleBackColor = true;
            this.t1_bSelectImage.Click += new System.EventHandler(this.bSelectImage_Click);
            // 
            // t1_bRemoveSelected
            // 
            this.t1_bRemoveSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.t1_bRemoveSelected.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.t1_bRemoveSelected.Location = new System.Drawing.Point(87, 22);
            this.t1_bRemoveSelected.Name = "t1_bRemoveSelected";
            this.t1_bRemoveSelected.Size = new System.Drawing.Size(66, 29);
            this.t1_bRemoveSelected.TabIndex = 12;
            this.t1_bRemoveSelected.Text = "移除选中";
            this.t1_bRemoveSelected.UseVisualStyleBackColor = true;
            this.t1_bRemoveSelected.Click += new System.EventHandler(this.bRemoveSelected_Click);
            // 
            // t1_bRemoveAll
            // 
            this.t1_bRemoveAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.t1_bRemoveAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.t1_bRemoveAll.Location = new System.Drawing.Point(163, 22);
            this.t1_bRemoveAll.Name = "t1_bRemoveAll";
            this.t1_bRemoveAll.Size = new System.Drawing.Size(66, 29);
            this.t1_bRemoveAll.TabIndex = 11;
            this.t1_bRemoveAll.Text = "移除所有";
            this.t1_bRemoveAll.UseVisualStyleBackColor = true;
            this.t1_bRemoveAll.Click += new System.EventHandler(this.bRemoveAll_Click);
            // 
            // t1_bRun
            // 
            this.t1_bRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.t1_bRun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.t1_bRun.Location = new System.Drawing.Point(239, 22);
            this.t1_bRun.Name = "t1_bRun";
            this.t1_bRun.Size = new System.Drawing.Size(66, 29);
            this.t1_bRun.TabIndex = 5;
            this.t1_bRun.Text = "生成CSS";
            this.t1_bRun.UseVisualStyleBackColor = true;
            this.t1_bRun.Click += new System.EventHandler(this.bRun_Click);
            // 
            // configGroup
            // 
            this.configGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.configGroup.Controls.Add(this.t1_tStyleName);
            this.configGroup.Controls.Add(this.label6);
            this.configGroup.Controls.Add(this.t1_tOther);
            this.configGroup.Controls.Add(this.t1_tFileName);
            this.configGroup.Controls.Add(this.t1_tSuffix);
            this.configGroup.Controls.Add(this.label1);
            this.configGroup.Controls.Add(this.t1_tPrefix);
            this.configGroup.Controls.Add(this.label2);
            this.configGroup.Controls.Add(this.label3);
            this.configGroup.Controls.Add(this.label4);
            this.configGroup.Location = new System.Drawing.Point(498, 6);
            this.configGroup.Name = "configGroup";
            this.configGroup.Size = new System.Drawing.Size(313, 167);
            this.configGroup.TabIndex = 18;
            this.configGroup.TabStop = false;
            this.configGroup.Text = "配置项";
            // 
            // t1_tStyleName
            // 
            this.t1_tStyleName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.t1_tStyleName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
            this.t1_tStyleName.Location = new System.Drawing.Point(91, 78);
            this.t1_tStyleName.Name = "t1_tStyleName";
            this.t1_tStyleName.Size = new System.Drawing.Size(216, 21);
            this.t1_tStyleName.TabIndex = 23;
            this.t1_tStyleName.TextChanged += new System.EventHandler(this.input_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(33, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 22;
            this.label6.Text = "样式名称";
            // 
            // t1_tOther
            // 
            this.t1_tOther.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.t1_tOther.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
            this.t1_tOther.Location = new System.Drawing.Point(91, 107);
            this.t1_tOther.Name = "t1_tOther";
            this.t1_tOther.Size = new System.Drawing.Size(216, 21);
            this.t1_tOther.TabIndex = 21;
            this.t1_tOther.Text = "no-repeat";
            this.t1_tOther.TextChanged += new System.EventHandler(this.input_TextChanged);
            // 
            // t1_tFileName
            // 
            this.t1_tFileName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.t1_tFileName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
            this.t1_tFileName.Location = new System.Drawing.Point(91, 136);
            this.t1_tFileName.Name = "t1_tFileName";
            this.t1_tFileName.Size = new System.Drawing.Size(216, 21);
            this.t1_tFileName.TabIndex = 9;
            // 
            // t1_tSuffix
            // 
            this.t1_tSuffix.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.t1_tSuffix.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
            this.t1_tSuffix.Location = new System.Drawing.Point(91, 49);
            this.t1_tSuffix.Name = "t1_tSuffix";
            this.t1_tSuffix.Size = new System.Drawing.Size(216, 21);
            this.t1_tSuffix.TabIndex = 20;
            this.t1_tSuffix.TextChanged += new System.EventHandler(this.input_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 140);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "输出样式文件";
            // 
            // t1_tPrefix
            // 
            this.t1_tPrefix.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.t1_tPrefix.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
            this.t1_tPrefix.Location = new System.Drawing.Point(91, 20);
            this.t1_tPrefix.Name = "t1_tPrefix";
            this.t1_tPrefix.Size = new System.Drawing.Size(216, 21);
            this.t1_tPrefix.TabIndex = 19;
            this.t1_tPrefix.TextChanged += new System.EventHandler(this.input_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 13;
            this.label2.Text = "样式类前缀";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 14;
            this.label3.Text = "样式类后缀";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 15;
            this.label4.Text = "其它属性";
            // 
            // imgGroup
            // 
            this.imgGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imgGroup.Controls.Add(this.label5);
            this.imgGroup.Controls.Add(this.t1_imageList);
            this.imgGroup.Location = new System.Drawing.Point(6, 6);
            this.imgGroup.Name = "imgGroup";
            this.imgGroup.Size = new System.Drawing.Size(486, 446);
            this.imgGroup.TabIndex = 17;
            this.imgGroup.TabStop = false;
            this.imgGroup.Text = "图片列表";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(63, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(185, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "提示：双击图标复制其BASE64数据";
            // 
            // t1_imageList
            // 
            this.t1_imageList.AllowDrop = true;
            this.t1_imageList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.t1_imageList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.t1_imageList.LargeImageList = this.xImageList;
            this.t1_imageList.Location = new System.Drawing.Point(3, 17);
            this.t1_imageList.Name = "t1_imageList";
            this.t1_imageList.Size = new System.Drawing.Size(480, 426);
            this.t1_imageList.StateImageList = this.stateImageList;
            this.t1_imageList.TabIndex = 8;
            this.t1_imageList.UseCompatibleStateImageBehavior = false;
            this.t1_imageList.ItemActivate += new System.EventHandler(this.imageList_ItemActivate);
            this.t1_imageList.DragDrop += new System.Windows.Forms.DragEventHandler(this.t1_imageList_DragDrop);
            this.t1_imageList.DragEnter += new System.Windows.Forms.DragEventHandler(this.t1_imageList_DragEnter);
            // 
            // xImageList
            // 
            this.xImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.xImageList.ImageSize = new System.Drawing.Size(48, 48);
            this.xImageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // stateImageList
            // 
            this.stateImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.stateImageList.ImageSize = new System.Drawing.Size(16, 16);
            this.stateImageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // tabAbout
            // 
            this.tabAbout.Controls.Add(this.label12);
            this.tabAbout.Controls.Add(this.linkLabel1);
            this.tabAbout.Controls.Add(this.label11);
            this.tabAbout.Controls.Add(this.pictureBox2);
            this.tabAbout.Controls.Add(this.textBox1);
            this.tabAbout.Controls.Add(this.label10);
            this.tabAbout.Controls.Add(this.label9);
            this.tabAbout.Controls.Add(this.label8);
            this.tabAbout.Controls.Add(this.pictureBox1);
            this.tabAbout.Location = new System.Drawing.Point(4, 22);
            this.tabAbout.Name = "tabAbout";
            this.tabAbout.Padding = new System.Windows.Forms.Padding(3);
            this.tabAbout.Size = new System.Drawing.Size(828, 458);
            this.tabAbout.TabIndex = 1;
            this.tabAbout.Text = "关于";
            this.tabAbout.ToolTipText = "Use Base64 Instead of Image-URL in CSS File(s)";
            this.tabAbout.UseVisualStyleBackColor = true;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(251, 73);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(90, 22);
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            this.ToolTip_Default.SetToolTip(this.pictureBox2, "点击加入QQ群");
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(184, 80);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(73, 14);
            this.textBox1.TabIndex = 6;
            this.textBox1.Text = "187786345";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(147, 81);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 12);
            this.label10.TabIndex = 4;
            this.label10.Text = "QQ群";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(182, 48);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 3;
            this.label9.Text = "hyjiacan";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(147, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 1;
            this.label8.Text = "作者";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(128, 128);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // openFileDialog
            // 
            this.openFileDialog.Multiselect = true;
            // 
            // runWorker
            // 
            this.runWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(147, 118);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 12);
            this.label11.TabIndex = 8;
            this.label11.Text = "网站";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(184, 117);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(143, 12);
            this.linkLabel1.TabIndex = 9;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "http://www.hyjiacan.com";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.DodgerBlue;
            this.label12.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(146, 6);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(195, 25);
            this.label12.TabIndex = 10;
            this.label12.Text = "Javascript中文社区";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(860, 511);
            this.Controls.Add(this.tabs);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "图片生成BASE64";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabs.ResumeLayout(false);
            this.tab1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.btnGroup.ResumeLayout(false);
            this.configGroup.ResumeLayout(false);
            this.configGroup.PerformLayout();
            this.imgGroup.ResumeLayout(false);
            this.imgGroup.PerformLayout();
            this.tabAbout.ResumeLayout(false);
            this.tabAbout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage tab1;
        private System.Windows.Forms.TabPage tabAbout;
        private System.Windows.Forms.ToolTip ToolTip_Default;
        private System.Windows.Forms.Label t1_log;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox t1_tDemo;
        private System.Windows.Forms.GroupBox btnGroup;
        private System.Windows.Forms.Button t1_bSelectImage;
        private System.Windows.Forms.Button t1_bRemoveSelected;
        private System.Windows.Forms.Button t1_bRemoveAll;
        private System.Windows.Forms.Button t1_bRun;
        private System.Windows.Forms.GroupBox configGroup;
        private System.Windows.Forms.TextBox t1_tOther;
        private System.Windows.Forms.TextBox t1_tFileName;
        private System.Windows.Forms.TextBox t1_tSuffix;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox t1_tPrefix;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox imgGroup;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListView t1_imageList;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.ComponentModel.BackgroundWorker runWorker;
        private System.Windows.Forms.ImageList xImageList;
        private System.Windows.Forms.ImageList stateImageList;
        private System.Windows.Forms.TextBox t1_tStyleName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton t1_rSpecCharDash;
        private System.Windows.Forms.RadioButton t1_rSpecCharUnderline;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox t1_cbDelSpecCharTail;
        private System.Windows.Forms.CheckBox t1_cbDelSpecCharHead;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label12;
    }
}