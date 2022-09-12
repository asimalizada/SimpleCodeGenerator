namespace Generator
{
    partial class Generator
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
            this.panelHeader = new System.Windows.Forms.Panel();
            this.btnMinimize = new FontAwesome.Sharp.IconButton();
            this.btnClose = new FontAwesome.Sharp.IconButton();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.lblEntities = new System.Windows.Forms.Label();
            this.btnAdvancedMode = new FontAwesome.Sharp.IconButton();
            this.btnProjectPathFind = new FontAwesome.Sharp.IconButton();
            this.lblOperations = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbxBusinessConcrete = new System.Windows.Forms.TextBox();
            this.tbxBusinessAbstract = new System.Windows.Forms.TextBox();
            this.tbxDataAccessConcrete = new System.Windows.Forms.TextBox();
            this.tbxDataAccessAbstract = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbxContext = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbxBusinessNamespace = new System.Windows.Forms.TextBox();
            this.tbxDataAccessNamespace = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.tbxBusinessPath = new System.Windows.Forms.TextBox();
            this.tbxDataAccessPath = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxProjectPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxEntity = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelHeader.SuspendLayout();
            this.panelContainer.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(147)))));
            this.panelHeader.Controls.Add(this.btnMinimize);
            this.panelHeader.Controls.Add(this.btnClose);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1127, 48);
            this.panelHeader.TabIndex = 0;
            this.panelHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelHeader_MouseDown);
            // 
            // btnMinimize
            // 
            this.btnMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.IconChar = FontAwesome.Sharp.IconChar.WindowMinimize;
            this.btnMinimize.IconColor = System.Drawing.Color.White;
            this.btnMinimize.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMinimize.IconSize = 24;
            this.btnMinimize.Location = new System.Drawing.Point(1028, 12);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(35, 23);
            this.btnMinimize.TabIndex = 5;
            this.btnMinimize.UseVisualStyleBackColor = true;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkRed;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.IconChar = FontAwesome.Sharp.IconChar.Multiply;
            this.btnClose.IconColor = System.Drawing.Color.White;
            this.btnClose.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnClose.IconSize = 24;
            this.btnClose.Location = new System.Drawing.Point(1080, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(35, 23);
            this.btnClose.TabIndex = 7;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panelContainer
            // 
            this.panelContainer.Controls.Add(this.lblEntities);
            this.panelContainer.Controls.Add(this.btnAdvancedMode);
            this.panelContainer.Controls.Add(this.btnProjectPathFind);
            this.panelContainer.Controls.Add(this.lblOperations);
            this.panelContainer.Controls.Add(this.groupBox1);
            this.panelContainer.Controls.Add(this.tbxContext);
            this.panelContainer.Controls.Add(this.label8);
            this.panelContainer.Controls.Add(this.tbxBusinessNamespace);
            this.panelContainer.Controls.Add(this.tbxDataAccessNamespace);
            this.panelContainer.Controls.Add(this.label7);
            this.panelContainer.Controls.Add(this.label6);
            this.panelContainer.Controls.Add(this.btnGenerate);
            this.panelContainer.Controls.Add(this.tbxBusinessPath);
            this.panelContainer.Controls.Add(this.tbxDataAccessPath);
            this.panelContainer.Controls.Add(this.label4);
            this.panelContainer.Controls.Add(this.label3);
            this.panelContainer.Controls.Add(this.tbxProjectPath);
            this.panelContainer.Controls.Add(this.label2);
            this.panelContainer.Controls.Add(this.tbxEntity);
            this.panelContainer.Controls.Add(this.label1);
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(0, 48);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(1127, 706);
            this.panelContainer.TabIndex = 1;
            this.panelContainer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelHeader_MouseDown);
            // 
            // lblEntities
            // 
            this.lblEntities.AutoSize = true;
            this.lblEntities.Font = new System.Drawing.Font("High Tower Text", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEntities.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblEntities.Location = new System.Drawing.Point(548, 374);
            this.lblEntities.Name = "lblEntities";
            this.lblEntities.Size = new System.Drawing.Size(0, 20);
            this.lblEntities.TabIndex = 20;
            // 
            // btnAdvancedMode
            // 
            this.btnAdvancedMode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdvancedMode.FlatAppearance.BorderSize = 0;
            this.btnAdvancedMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdvancedMode.IconChar = FontAwesome.Sharp.IconChar.Check;
            this.btnAdvancedMode.IconColor = System.Drawing.Color.Gainsboro;
            this.btnAdvancedMode.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAdvancedMode.IconSize = 28;
            this.btnAdvancedMode.Location = new System.Drawing.Point(497, 172);
            this.btnAdvancedMode.Name = "btnAdvancedMode";
            this.btnAdvancedMode.Size = new System.Drawing.Size(30, 30);
            this.btnAdvancedMode.TabIndex = 19;
            this.btnAdvancedMode.UseVisualStyleBackColor = true;
            this.btnAdvancedMode.Click += new System.EventHandler(this.btnAdvancedMode_Click);
            // 
            // btnProjectPathFind
            // 
            this.btnProjectPathFind.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProjectPathFind.FlatAppearance.BorderSize = 0;
            this.btnProjectPathFind.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProjectPathFind.IconChar = FontAwesome.Sharp.IconChar.EllipsisH;
            this.btnProjectPathFind.IconColor = System.Drawing.Color.Gainsboro;
            this.btnProjectPathFind.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnProjectPathFind.IconSize = 28;
            this.btnProjectPathFind.Location = new System.Drawing.Point(497, 103);
            this.btnProjectPathFind.Name = "btnProjectPathFind";
            this.btnProjectPathFind.Size = new System.Drawing.Size(30, 30);
            this.btnProjectPathFind.TabIndex = 18;
            this.btnProjectPathFind.UseVisualStyleBackColor = true;
            this.btnProjectPathFind.Click += new System.EventHandler(this.btnProjectPathFind_Click);
            // 
            // lblOperations
            // 
            this.lblOperations.AutoSize = true;
            this.lblOperations.Font = new System.Drawing.Font("High Tower Text", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOperations.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblOperations.Location = new System.Drawing.Point(757, 374);
            this.lblOperations.Name = "lblOperations";
            this.lblOperations.Size = new System.Drawing.Size(0, 20);
            this.lblOperations.TabIndex = 17;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbxBusinessConcrete);
            this.groupBox1.Controls.Add(this.tbxBusinessAbstract);
            this.groupBox1.Controls.Add(this.tbxDataAccessConcrete);
            this.groupBox1.Controls.Add(this.tbxDataAccessAbstract);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Font = new System.Drawing.Font("High Tower Text", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Gainsboro;
            this.groupBox1.Location = new System.Drawing.Point(563, 42);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(530, 308);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Usings";
            this.groupBox1.Visible = false;
            // 
            // tbxBusinessConcrete
            // 
            this.tbxBusinessConcrete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(34)))), ((int)(((byte)(126)))));
            this.tbxBusinessConcrete.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxBusinessConcrete.Font = new System.Drawing.Font("High Tower Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxBusinessConcrete.ForeColor = System.Drawing.Color.Gainsboro;
            this.tbxBusinessConcrete.Location = new System.Drawing.Point(188, 249);
            this.tbxBusinessConcrete.Name = "tbxBusinessConcrete";
            this.tbxBusinessConcrete.Size = new System.Drawing.Size(297, 24);
            this.tbxBusinessConcrete.TabIndex = 22;
            this.tbxBusinessConcrete.Text = "__________";
            this.tbxBusinessConcrete.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbxBusinessConcrete.TextChanged += new System.EventHandler(this.tbx_TextChanged);
            this.tbxBusinessConcrete.Enter += new System.EventHandler(this.tbx_Enter);
            this.tbxBusinessConcrete.Leave += new System.EventHandler(this.tbx_Leave);
            // 
            // tbxBusinessAbstract
            // 
            this.tbxBusinessAbstract.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(34)))), ((int)(((byte)(126)))));
            this.tbxBusinessAbstract.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxBusinessAbstract.Font = new System.Drawing.Font("High Tower Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxBusinessAbstract.ForeColor = System.Drawing.Color.Gainsboro;
            this.tbxBusinessAbstract.Location = new System.Drawing.Point(188, 191);
            this.tbxBusinessAbstract.Name = "tbxBusinessAbstract";
            this.tbxBusinessAbstract.Size = new System.Drawing.Size(297, 24);
            this.tbxBusinessAbstract.TabIndex = 21;
            this.tbxBusinessAbstract.Text = "__________";
            this.tbxBusinessAbstract.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbxBusinessAbstract.TextChanged += new System.EventHandler(this.tbx_TextChanged);
            this.tbxBusinessAbstract.Enter += new System.EventHandler(this.tbx_Enter);
            this.tbxBusinessAbstract.Leave += new System.EventHandler(this.tbx_Leave);
            // 
            // tbxDataAccessConcrete
            // 
            this.tbxDataAccessConcrete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(34)))), ((int)(((byte)(126)))));
            this.tbxDataAccessConcrete.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxDataAccessConcrete.Font = new System.Drawing.Font("High Tower Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxDataAccessConcrete.ForeColor = System.Drawing.Color.Gainsboro;
            this.tbxDataAccessConcrete.Location = new System.Drawing.Point(188, 127);
            this.tbxDataAccessConcrete.Name = "tbxDataAccessConcrete";
            this.tbxDataAccessConcrete.Size = new System.Drawing.Size(297, 24);
            this.tbxDataAccessConcrete.TabIndex = 20;
            this.tbxDataAccessConcrete.Text = "__________";
            this.tbxDataAccessConcrete.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbxDataAccessConcrete.TextChanged += new System.EventHandler(this.tbx_TextChanged);
            this.tbxDataAccessConcrete.Enter += new System.EventHandler(this.tbx_Enter);
            this.tbxDataAccessConcrete.Leave += new System.EventHandler(this.tbx_Leave);
            // 
            // tbxDataAccessAbstract
            // 
            this.tbxDataAccessAbstract.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(34)))), ((int)(((byte)(126)))));
            this.tbxDataAccessAbstract.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxDataAccessAbstract.Font = new System.Drawing.Font("High Tower Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxDataAccessAbstract.ForeColor = System.Drawing.Color.Gainsboro;
            this.tbxDataAccessAbstract.Location = new System.Drawing.Point(188, 64);
            this.tbxDataAccessAbstract.Name = "tbxDataAccessAbstract";
            this.tbxDataAccessAbstract.Size = new System.Drawing.Size(297, 24);
            this.tbxDataAccessAbstract.TabIndex = 19;
            this.tbxDataAccessAbstract.Text = "__________";
            this.tbxDataAccessAbstract.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbxDataAccessAbstract.TextChanged += new System.EventHandler(this.tbx_TextChanged);
            this.tbxDataAccessAbstract.Enter += new System.EventHandler(this.tbx_Enter);
            this.tbxDataAccessAbstract.Leave += new System.EventHandler(this.tbx_Leave);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("High Tower Text", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Gainsboro;
            this.label11.Location = new System.Drawing.Point(17, 249);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(114, 22);
            this.label11.TabIndex = 18;
            this.label11.Text = "Business con";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("High Tower Text", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Gainsboro;
            this.label10.Location = new System.Drawing.Point(17, 191);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(112, 22);
            this.label10.TabIndex = 17;
            this.label10.Text = "Business abs";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("High Tower Text", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Gainsboro;
            this.label9.Location = new System.Drawing.Point(17, 127);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(128, 22);
            this.label9.TabIndex = 16;
            this.label9.Text = "Data acces con";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("High Tower Text", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Gainsboro;
            this.label5.Location = new System.Drawing.Point(17, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 22);
            this.label5.TabIndex = 15;
            this.label5.Text = "Data acces abs";
            // 
            // tbxContext
            // 
            this.tbxContext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(34)))), ((int)(((byte)(126)))));
            this.tbxContext.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxContext.Font = new System.Drawing.Font("High Tower Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxContext.ForeColor = System.Drawing.Color.Gainsboro;
            this.tbxContext.Location = new System.Drawing.Point(241, 425);
            this.tbxContext.Name = "tbxContext";
            this.tbxContext.Size = new System.Drawing.Size(223, 24);
            this.tbxContext.TabIndex = 15;
            this.tbxContext.Text = "__________";
            this.tbxContext.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbxContext.TextChanged += new System.EventHandler(this.tbx_TextChanged);
            this.tbxContext.Enter += new System.EventHandler(this.tbx_Enter);
            this.tbxContext.Leave += new System.EventHandler(this.tbx_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("High Tower Text", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Gainsboro;
            this.label8.Location = new System.Drawing.Point(29, 425);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 22);
            this.label8.TabIndex = 14;
            this.label8.Text = "Context ";
            // 
            // tbxBusinessNamespace
            // 
            this.tbxBusinessNamespace.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(34)))), ((int)(((byte)(126)))));
            this.tbxBusinessNamespace.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxBusinessNamespace.Enabled = false;
            this.tbxBusinessNamespace.Font = new System.Drawing.Font("High Tower Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxBusinessNamespace.ForeColor = System.Drawing.Color.Gainsboro;
            this.tbxBusinessNamespace.Location = new System.Drawing.Point(241, 360);
            this.tbxBusinessNamespace.Name = "tbxBusinessNamespace";
            this.tbxBusinessNamespace.Size = new System.Drawing.Size(223, 24);
            this.tbxBusinessNamespace.TabIndex = 13;
            this.tbxBusinessNamespace.Text = "__________";
            this.tbxBusinessNamespace.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbxBusinessNamespace.TextChanged += new System.EventHandler(this.tbx_TextChanged);
            this.tbxBusinessNamespace.Enter += new System.EventHandler(this.tbx_Enter);
            this.tbxBusinessNamespace.Leave += new System.EventHandler(this.tbx_Leave);
            // 
            // tbxDataAccessNamespace
            // 
            this.tbxDataAccessNamespace.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(34)))), ((int)(((byte)(126)))));
            this.tbxDataAccessNamespace.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxDataAccessNamespace.Enabled = false;
            this.tbxDataAccessNamespace.Font = new System.Drawing.Font("High Tower Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxDataAccessNamespace.ForeColor = System.Drawing.Color.Gainsboro;
            this.tbxDataAccessNamespace.Location = new System.Drawing.Point(241, 302);
            this.tbxDataAccessNamespace.Name = "tbxDataAccessNamespace";
            this.tbxDataAccessNamespace.Size = new System.Drawing.Size(223, 24);
            this.tbxDataAccessNamespace.TabIndex = 12;
            this.tbxDataAccessNamespace.Text = "__________";
            this.tbxDataAccessNamespace.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbxDataAccessNamespace.TextChanged += new System.EventHandler(this.tbx_TextChanged);
            this.tbxDataAccessNamespace.Enter += new System.EventHandler(this.tbx_Enter);
            this.tbxDataAccessNamespace.Leave += new System.EventHandler(this.tbx_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("High Tower Text", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Gainsboro;
            this.label7.Location = new System.Drawing.Point(29, 360);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(172, 22);
            this.label7.TabIndex = 11;
            this.label7.Text = "Business namespace";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("High Tower Text", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Gainsboro;
            this.label6.Location = new System.Drawing.Point(29, 302);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(193, 22);
            this.label6.TabIndex = 10;
            this.label6.Text = "Data access namespace";
            // 
            // btnGenerate
            // 
            this.btnGenerate.FlatAppearance.BorderSize = 0;
            this.btnGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerate.Font = new System.Drawing.Font("High Tower Text", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerate.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnGenerate.Location = new System.Drawing.Point(498, 611);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(153, 70);
            this.btnGenerate.TabIndex = 8;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // tbxBusinessPath
            // 
            this.tbxBusinessPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(34)))), ((int)(((byte)(126)))));
            this.tbxBusinessPath.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxBusinessPath.Enabled = false;
            this.tbxBusinessPath.Font = new System.Drawing.Font("High Tower Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxBusinessPath.ForeColor = System.Drawing.Color.Gainsboro;
            this.tbxBusinessPath.Location = new System.Drawing.Point(241, 238);
            this.tbxBusinessPath.Name = "tbxBusinessPath";
            this.tbxBusinessPath.Size = new System.Drawing.Size(223, 24);
            this.tbxBusinessPath.TabIndex = 7;
            this.tbxBusinessPath.Text = "__________";
            this.tbxBusinessPath.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbxBusinessPath.TextChanged += new System.EventHandler(this.tbx_TextChanged);
            this.tbxBusinessPath.Enter += new System.EventHandler(this.tbx_Enter);
            this.tbxBusinessPath.Leave += new System.EventHandler(this.tbx_Leave);
            // 
            // tbxDataAccessPath
            // 
            this.tbxDataAccessPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(34)))), ((int)(((byte)(126)))));
            this.tbxDataAccessPath.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxDataAccessPath.Enabled = false;
            this.tbxDataAccessPath.Font = new System.Drawing.Font("High Tower Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxDataAccessPath.ForeColor = System.Drawing.Color.Gainsboro;
            this.tbxDataAccessPath.Location = new System.Drawing.Point(241, 175);
            this.tbxDataAccessPath.Name = "tbxDataAccessPath";
            this.tbxDataAccessPath.Size = new System.Drawing.Size(223, 24);
            this.tbxDataAccessPath.TabIndex = 6;
            this.tbxDataAccessPath.Text = "__________";
            this.tbxDataAccessPath.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbxDataAccessPath.TextChanged += new System.EventHandler(this.tbx_TextChanged);
            this.tbxDataAccessPath.Enter += new System.EventHandler(this.tbx_Enter);
            this.tbxDataAccessPath.Leave += new System.EventHandler(this.tbx_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("High Tower Text", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Gainsboro;
            this.label4.Location = new System.Drawing.Point(29, 238);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 22);
            this.label4.TabIndex = 5;
            this.label4.Text = "Business path";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("High Tower Text", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Gainsboro;
            this.label3.Location = new System.Drawing.Point(29, 175);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 22);
            this.label3.TabIndex = 4;
            this.label3.Text = "Data access path";
            // 
            // tbxProjectPath
            // 
            this.tbxProjectPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(34)))), ((int)(((byte)(126)))));
            this.tbxProjectPath.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxProjectPath.Font = new System.Drawing.Font("High Tower Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxProjectPath.ForeColor = System.Drawing.Color.Gainsboro;
            this.tbxProjectPath.Location = new System.Drawing.Point(241, 108);
            this.tbxProjectPath.Name = "tbxProjectPath";
            this.tbxProjectPath.Size = new System.Drawing.Size(223, 24);
            this.tbxProjectPath.TabIndex = 3;
            this.tbxProjectPath.Text = "__________";
            this.tbxProjectPath.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbxProjectPath.TextChanged += new System.EventHandler(this.tbx_TextChanged);
            this.tbxProjectPath.Enter += new System.EventHandler(this.tbx_Enter);
            this.tbxProjectPath.Leave += new System.EventHandler(this.tbx_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("High Tower Text", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gainsboro;
            this.label2.Location = new System.Drawing.Point(29, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 22);
            this.label2.TabIndex = 2;
            this.label2.Text = "Project path";
            // 
            // tbxEntity
            // 
            this.tbxEntity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(34)))), ((int)(((byte)(126)))));
            this.tbxEntity.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxEntity.Font = new System.Drawing.Font("High Tower Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxEntity.ForeColor = System.Drawing.Color.Gainsboro;
            this.tbxEntity.Location = new System.Drawing.Point(241, 42);
            this.tbxEntity.Name = "tbxEntity";
            this.tbxEntity.Size = new System.Drawing.Size(223, 24);
            this.tbxEntity.TabIndex = 1;
            this.tbxEntity.Text = "__________";
            this.tbxEntity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbxEntity.TextChanged += new System.EventHandler(this.tbx_TextChanged);
            this.tbxEntity.Enter += new System.EventHandler(this.tbx_Enter);
            this.tbxEntity.Leave += new System.EventHandler(this.tbx_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("High Tower Text", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gainsboro;
            this.label1.Location = new System.Drawing.Point(29, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Entity";
            // 
            // Generator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(34)))), ((int)(((byte)(126)))));
            this.ClientSize = new System.Drawing.Size(1127, 754);
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Generator";
            this.Text = "Generator";
            this.panelHeader.ResumeLayout(false);
            this.panelContainer.ResumeLayout(false);
            this.panelContainer.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private FontAwesome.Sharp.IconButton btnMinimize;
        private FontAwesome.Sharp.IconButton btnClose;
        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.TextBox tbxEntity;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxProjectPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxBusinessPath;
        private System.Windows.Forms.TextBox tbxDataAccessPath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.TextBox tbxContext;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbxBusinessNamespace;
        private System.Windows.Forms.TextBox tbxDataAccessNamespace;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbxBusinessConcrete;
        private System.Windows.Forms.TextBox tbxBusinessAbstract;
        private System.Windows.Forms.TextBox tbxDataAccessConcrete;
        private System.Windows.Forms.TextBox tbxDataAccessAbstract;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblOperations;
        private FontAwesome.Sharp.IconButton btnProjectPathFind;
        private FontAwesome.Sharp.IconButton btnAdvancedMode;
        private System.Windows.Forms.Label lblEntities;
    }
}

