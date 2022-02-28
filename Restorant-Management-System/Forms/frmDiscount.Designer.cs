namespace Restorant_Management_System.Forms
{
    partial class frmDiscount
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDiscount));
            this.PnlMain = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.cmbBarcode = new System.Windows.Forms.ComboBox();
            this.lbl = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.txtBarCode = new System.Windows.Forms.TextBox();
            this.PnlSub = new System.Windows.Forms.Panel();
            this.BtnChooseExcel = new System.Windows.Forms.Button();
            this.BtnApplyBarcode = new System.Windows.Forms.Button();
            this.cmbDepartment = new System.Windows.Forms.ComboBox();
            this.txtOfferID = new System.Windows.Forms.TextBox();
            this.SchBranches = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.chkIsActive = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.cmbSize = new System.Windows.Forms.ComboBox();
            this.cmbDesign = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbProductName = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbCompanyName = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtItemID = new System.Windows.Forms.TextBox();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.PnlMain.SuspendLayout();
            this.panel1.SuspendLayout();
            this.PnlSub.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // PnlMain
            // 
            this.PnlMain.BackColor = System.Drawing.Color.SteelBlue;
            this.PnlMain.Controls.Add(this.label7);
            this.PnlMain.Controls.Add(this.panel1);
            this.PnlMain.Controls.Add(this.cmbBarcode);
            this.PnlMain.Controls.Add(this.lbl);
            this.PnlMain.Controls.Add(this.checkBox1);
            this.PnlMain.Controls.Add(this.txtBarCode);
            this.PnlMain.Controls.Add(this.PnlSub);
            this.PnlMain.Controls.Add(this.txtItemID);
            this.PnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlMain.Location = new System.Drawing.Point(0, 0);
            this.PnlMain.Name = "PnlMain";
            this.PnlMain.Size = new System.Drawing.Size(956, 450);
            this.PnlMain.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(512, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 53;
            this.label7.Text = "Barcode";
            this.label7.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnNew);
            this.panel1.Controls.Add(this.btnEdit);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Location = new System.Drawing.Point(349, 370);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(325, 48);
            this.panel1.TabIndex = 40;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.btnDelete.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(227, 5);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(68, 33);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.btnNew.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.ForeColor = System.Drawing.Color.White;
            this.btnNew.Location = new System.Drawing.Point(24, 6);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(68, 33);
            this.btnNew.TabIndex = 2;
            this.btnNew.Text = "&New";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.btnEdit.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(90, 6);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(68, 33);
            this.btnEdit.TabIndex = 3;
            this.btnEdit.Text = "&Edit";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.btnSave.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(156, 6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(68, 33);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cmbBarcode
            // 
            this.cmbBarcode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbBarcode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbBarcode.FormattingEnabled = true;
            this.cmbBarcode.Location = new System.Drawing.Point(238, 22);
            this.cmbBarcode.Name = "cmbBarcode";
            this.cmbBarcode.Size = new System.Drawing.Size(121, 21);
            this.cmbBarcode.TabIndex = 157;
            this.cmbBarcode.Visible = false;
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.ForeColor = System.Drawing.Color.White;
            this.lbl.Location = new System.Drawing.Point(173, 26);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(47, 13);
            this.lbl.TabIndex = 156;
            this.lbl.Text = "Barcode";
            this.lbl.Visible = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.ForeColor = System.Drawing.Color.White;
            this.checkBox1.Location = new System.Drawing.Point(746, 24);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(67, 17);
            this.checkBox1.TabIndex = 50;
            this.checkBox1.Text = "Is Active";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.Visible = false;
            // 
            // txtBarCode
            // 
            this.txtBarCode.Location = new System.Drawing.Point(587, 27);
            this.txtBarCode.Name = "txtBarCode";
            this.txtBarCode.Size = new System.Drawing.Size(124, 20);
            this.txtBarCode.TabIndex = 51;
            this.txtBarCode.Visible = false;
            // 
            // PnlSub
            // 
            this.PnlSub.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PnlSub.Controls.Add(this.BtnChooseExcel);
            this.PnlSub.Controls.Add(this.BtnApplyBarcode);
            this.PnlSub.Controls.Add(this.cmbDepartment);
            this.PnlSub.Controls.Add(this.txtOfferID);
            this.PnlSub.Controls.Add(this.SchBranches);
            this.PnlSub.Controls.Add(this.label6);
            this.PnlSub.Controls.Add(this.label8);
            this.PnlSub.Controls.Add(this.label10);
            this.PnlSub.Controls.Add(this.label9);
            this.PnlSub.Controls.Add(this.dtpToDate);
            this.PnlSub.Controls.Add(this.dtpFromDate);
            this.PnlSub.Controls.Add(this.chkIsActive);
            this.PnlSub.Controls.Add(this.label1);
            this.PnlSub.Controls.Add(this.txtDiscount);
            this.PnlSub.Controls.Add(this.label19);
            this.PnlSub.Controls.Add(this.cmbSize);
            this.PnlSub.Controls.Add(this.cmbDesign);
            this.PnlSub.Controls.Add(this.label5);
            this.PnlSub.Controls.Add(this.cmbProductName);
            this.PnlSub.Controls.Add(this.label4);
            this.PnlSub.Controls.Add(this.cmbCompanyName);
            this.PnlSub.Controls.Add(this.label3);
            this.PnlSub.Controls.Add(this.cmbCategory);
            this.PnlSub.Controls.Add(this.label2);
            this.PnlSub.Controls.Add(this.label15);
            this.PnlSub.Location = new System.Drawing.Point(207, 67);
            this.PnlSub.Name = "PnlSub";
            this.PnlSub.Size = new System.Drawing.Size(569, 361);
            this.PnlSub.TabIndex = 0;
            // 
            // BtnChooseExcel
            // 
            this.BtnChooseExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnChooseExcel.Location = new System.Drawing.Point(443, 3);
            this.BtnChooseExcel.Name = "BtnChooseExcel";
            this.BtnChooseExcel.Size = new System.Drawing.Size(119, 20);
            this.BtnChooseExcel.TabIndex = 159;
            this.BtnChooseExcel.TabStop = false;
            this.BtnChooseExcel.Text = "Choose Excel ";
            this.BtnChooseExcel.UseVisualStyleBackColor = true;
            this.BtnChooseExcel.Visible = false;
            this.BtnChooseExcel.Click += new System.EventHandler(this.BtnChooseExcel_Click);
            // 
            // BtnApplyBarcode
            // 
            this.BtnApplyBarcode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnApplyBarcode.Location = new System.Drawing.Point(378, 90);
            this.BtnApplyBarcode.Name = "BtnApplyBarcode";
            this.BtnApplyBarcode.Size = new System.Drawing.Size(121, 21);
            this.BtnApplyBarcode.TabIndex = 158;
            this.BtnApplyBarcode.TabStop = false;
            this.BtnApplyBarcode.Text = "Apply on Barcode";
            this.BtnApplyBarcode.UseVisualStyleBackColor = true;
            this.BtnApplyBarcode.Click += new System.EventHandler(this.BtnApplyBarcode_Click);
            // 
            // cmbDepartment
            // 
            this.cmbDepartment.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbDepartment.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbDepartment.FormattingEnabled = true;
            this.cmbDepartment.Location = new System.Drawing.Point(154, 61);
            this.cmbDepartment.Name = "cmbDepartment";
            this.cmbDepartment.Size = new System.Drawing.Size(121, 21);
            this.cmbDepartment.TabIndex = 155;
            this.cmbDepartment.Leave += new System.EventHandler(this.cmbDepartment_Leave);
            // 
            // txtOfferID
            // 
            this.txtOfferID.Location = new System.Drawing.Point(155, 34);
            this.txtOfferID.Name = "txtOfferID";
            this.txtOfferID.ReadOnly = true;
            this.txtOfferID.Size = new System.Drawing.Size(121, 20);
            this.txtOfferID.TabIndex = 54;
            this.txtOfferID.TabStop = false;
            // 
            // SchBranches
            // 
            this.SchBranches.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SchBranches.Image = ((System.Drawing.Image)(resources.GetObject("SchBranches.Image")));
            this.SchBranches.Location = new System.Drawing.Point(155, 252);
            this.SchBranches.Name = "SchBranches";
            this.SchBranches.Size = new System.Drawing.Size(72, 20);
            this.SchBranches.TabIndex = 154;
            this.SchBranches.TabStop = false;
            this.SchBranches.UseVisualStyleBackColor = true;
            this.SchBranches.Click += new System.EventHandler(this.SchBranches_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(99, 37);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 52;
            this.label6.Text = "OfferID";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label8.Location = new System.Drawing.Point(76, 257);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 13);
            this.label8.TabIndex = 55;
            this.label8.Text = "Select Branch";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label10.Location = new System.Drawing.Point(351, 218);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(20, 13);
            this.label10.TabIndex = 54;
            this.label10.Text = "To";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label9.Location = new System.Drawing.Point(118, 217);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 13);
            this.label9.TabIndex = 53;
            this.label9.Text = "From";
            // 
            // dtpToDate
            // 
            this.dtpToDate.CustomFormat = "";
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpToDate.Location = new System.Drawing.Point(379, 214);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(121, 20);
            this.dtpToDate.TabIndex = 52;
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.CustomFormat = "";
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromDate.Location = new System.Drawing.Point(155, 214);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(121, 20);
            this.dtpFromDate.TabIndex = 49;
            // 
            // chkIsActive
            // 
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.ForeColor = System.Drawing.Color.White;
            this.chkIsActive.Location = new System.Drawing.Point(378, 185);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(67, 17);
            this.chkIsActive.TabIndex = 48;
            this.chkIsActive.Text = "Is Active";
            this.chkIsActive.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(99, 186);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 47;
            this.label1.Text = "Discount";
            // 
            // txtDiscount
            // 
            this.txtDiscount.Location = new System.Drawing.Point(155, 183);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(121, 20);
            this.txtDiscount.TabIndex = 46;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.ForeColor = System.Drawing.Color.White;
            this.label19.Location = new System.Drawing.Point(91, 65);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(62, 13);
            this.label19.TabIndex = 45;
            this.label19.Text = "Department";
            // 
            // cmbSize
            // 
            this.cmbSize.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbSize.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSize.FormattingEnabled = true;
            this.cmbSize.Location = new System.Drawing.Point(378, 151);
            this.cmbSize.Name = "cmbSize";
            this.cmbSize.Size = new System.Drawing.Size(121, 21);
            this.cmbSize.TabIndex = 43;
            // 
            // cmbDesign
            // 
            this.cmbDesign.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbDesign.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbDesign.FormattingEnabled = true;
            this.cmbDesign.Location = new System.Drawing.Point(155, 152);
            this.cmbDesign.Name = "cmbDesign";
            this.cmbDesign.Size = new System.Drawing.Size(121, 21);
            this.cmbDesign.TabIndex = 42;
            this.cmbDesign.SelectedIndexChanged += new System.EventHandler(this.cmbDesign_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(347, 155);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 36;
            this.label5.Text = "Size";
            // 
            // cmbProductName
            // 
            this.cmbProductName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbProductName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbProductName.FormattingEnabled = true;
            this.cmbProductName.Location = new System.Drawing.Point(378, 121);
            this.cmbProductName.Name = "cmbProductName";
            this.cmbProductName.Size = new System.Drawing.Size(121, 21);
            this.cmbProductName.TabIndex = 37;
            this.cmbProductName.SelectedIndexChanged += new System.EventHandler(this.cmbProductName_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(105, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 38;
            this.label4.Text = "Design";
            // 
            // cmbCompanyName
            // 
            this.cmbCompanyName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCompanyName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCompanyName.FormattingEnabled = true;
            this.cmbCompanyName.Location = new System.Drawing.Point(155, 123);
            this.cmbCompanyName.Name = "cmbCompanyName";
            this.cmbCompanyName.Size = new System.Drawing.Size(121, 21);
            this.cmbCompanyName.TabIndex = 34;
            this.cmbCompanyName.SelectedIndexChanged += new System.EventHandler(this.cmbCompanyName_SelectedIndexChanged);
            this.cmbCompanyName.Leave += new System.EventHandler(this.cmbCompanyName_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(302, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 39;
            this.label3.Text = "Product Name";
            // 
            // cmbCategory
            // 
            this.cmbCategory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCategory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(379, 59);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(120, 21);
            this.cmbCategory.TabIndex = 35;
            this.cmbCategory.SelectedValueChanged += new System.EventHandler(this.cmbCategory_SelectedValueChanged);
            this.cmbCategory.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbCategory_KeyDown);
            this.cmbCategory.Leave += new System.EventHandler(this.cmbCategory_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(64, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 40;
            this.label2.Text = "Company Name";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(293, 63);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(80, 13);
            this.label15.TabIndex = 41;
            this.label15.Text = "Category Name";
            // 
            // txtItemID
            // 
            this.txtItemID.Location = new System.Drawing.Point(364, 27);
            this.txtItemID.Name = "txtItemID";
            this.txtItemID.ReadOnly = true;
            this.txtItemID.Size = new System.Drawing.Size(85, 20);
            this.txtItemID.TabIndex = 49;
            this.txtItemID.TabStop = false;
            this.txtItemID.Visible = false;
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // frmDiscount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(221)))), ((int)(((byte)(190)))));
            this.ClientSize = new System.Drawing.Size(956, 450);
            this.Controls.Add(this.PnlMain);
            this.Name = "frmDiscount";
            this.Tag = "16";
            this.Text = "Discount Offer";
            this.Load += new System.EventHandler(this.frmDiscount_Load);
            this.PnlMain.ResumeLayout(false);
            this.PnlMain.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.PnlSub.ResumeLayout(false);
            this.PnlSub.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PnlMain;
        private System.Windows.Forms.Panel PnlSub;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox cmbSize;
        private System.Windows.Forms.ComboBox cmbDesign;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbProductName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbCompanyName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox chkIsActive;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtBarCode;
        private System.Windows.Forms.TextBox txtItemID;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button SchBranches;
        private System.Windows.Forms.TextBox txtOfferID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbDepartment;
        private System.Windows.Forms.ComboBox cmbBarcode;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.Button BtnApplyBarcode;
        private System.Windows.Forms.Button BtnChooseExcel;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}