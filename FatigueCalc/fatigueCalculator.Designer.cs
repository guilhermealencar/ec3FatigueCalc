namespace FatigueCalc
{
    partial class fatigueCalculator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fatigueCalculator));
            this.lbDecimalPlacesText = new System.Windows.Forms.Label();
            this.gbSNCurve = new System.Windows.Forms.GroupBox();
            this.lbGamaMf = new System.Windows.Forms.TextBox();
            this.lbGamaMFText = new System.Windows.Forms.Label();
            this.lbKS = new System.Windows.Forms.TextBox();
            this.lbKSText = new System.Windows.Forms.Label();
            this.lbTypeStressText = new System.Windows.Forms.Label();
            this.lbEcCategory = new System.Windows.Forms.ComboBox();
            this.rbShearStress = new System.Windows.Forms.RadioButton();
            this.lbDeltaSigmaCText = new System.Windows.Forms.Label();
            this.rbNormalStress = new System.Windows.Forms.RadioButton();
            this.sfFatigueResults = new System.Windows.Forms.SaveFileDialog();
            this.lbRainflowText = new System.Windows.Forms.Label();
            this.resultsWindow = new System.Windows.Forms.WebBrowser();
            this.cbEnterStressRanges = new System.Windows.Forms.CheckBox();
            this.lbPictureText = new System.Windows.Forms.Label();
            this.lbDescriptionText = new System.Windows.Forms.Label();
            this.btPasteIn = new System.Windows.Forms.Button();
            this.btErase = new System.Windows.Forms.Button();
            this.containerWeb = new System.Windows.Forms.Panel();
            this.dgStressHistory = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgPeaksValleys = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgRainflowResults = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbRainflowCountingText = new System.Windows.Forms.Label();
            this.gbRainflowResults = new System.Windows.Forms.GroupBox();
            this.lbTensaoMaxima = new System.Windows.Forms.Label();
            this.lbDecimalPlaces = new System.Windows.Forms.DomainUpDown();
            this.dgRainflowSummary = new System.Windows.Forms.DataGridView();
            this.gbGeneralData = new System.Windows.Forms.GroupBox();
            this.btChoosePicture = new System.Windows.Forms.Button();
            this.lbPictureDetail = new System.Windows.Forms.TextBox();
            this.lbDescription = new System.Windows.Forms.TextBox();
            this.openPictureDialog = new System.Windows.Forms.OpenFileDialog();
            this.mainMenuProgram = new System.Windows.Forms.MainMenu(this.components);
            this.miFile = new System.Windows.Forms.MenuItem();
            this.miAbout = new System.Windows.Forms.MenuItem();
            this.miExit = new System.Windows.Forms.MenuItem();
            this.btSaveAs = new System.Windows.Forms.Button();
            this.btCalculate = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shortDescriptions = new System.Windows.Forms.ToolTip(this.components);
            this.gbSNCurve.SuspendLayout();
            this.containerWeb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgStressHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgPeaksValleys)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgRainflowResults)).BeginInit();
            this.gbRainflowResults.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgRainflowSummary)).BeginInit();
            this.gbGeneralData.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbDecimalPlacesText
            // 
            this.lbDecimalPlacesText.AutoSize = true;
            this.lbDecimalPlacesText.Location = new System.Drawing.Point(154, 25);
            this.lbDecimalPlacesText.Name = "lbDecimalPlacesText";
            this.lbDecimalPlacesText.Size = new System.Drawing.Size(83, 13);
            this.lbDecimalPlacesText.TabIndex = 29;
            this.lbDecimalPlacesText.Text = "Decimal Places:";
            // 
            // gbSNCurve
            // 
            this.gbSNCurve.Controls.Add(this.lbGamaMf);
            this.gbSNCurve.Controls.Add(this.lbGamaMFText);
            this.gbSNCurve.Controls.Add(this.lbKS);
            this.gbSNCurve.Controls.Add(this.lbKSText);
            this.gbSNCurve.Controls.Add(this.lbTypeStressText);
            this.gbSNCurve.Controls.Add(this.lbEcCategory);
            this.gbSNCurve.Controls.Add(this.rbShearStress);
            this.gbSNCurve.Controls.Add(this.lbDeltaSigmaCText);
            this.gbSNCurve.Controls.Add(this.rbNormalStress);
            this.gbSNCurve.Location = new System.Drawing.Point(12, 90);
            this.gbSNCurve.Name = "gbSNCurve";
            this.gbSNCurve.Size = new System.Drawing.Size(310, 99);
            this.gbSNCurve.TabIndex = 37;
            this.gbSNCurve.TabStop = false;
            this.gbSNCurve.Text = "S-N Curve (EN 1993-1-9)";
            // 
            // lbGamaMf
            // 
            this.lbGamaMf.Location = new System.Drawing.Point(148, 23);
            this.lbGamaMf.Name = "lbGamaMf";
            this.lbGamaMf.Size = new System.Drawing.Size(55, 20);
            this.lbGamaMf.TabIndex = 112;
            this.lbGamaMf.Text = "1.0";
            this.lbGamaMf.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbGamaMFText
            // 
            this.lbGamaMFText.AutoSize = true;
            this.lbGamaMFText.Location = new System.Drawing.Point(109, 26);
            this.lbGamaMFText.Name = "lbGamaMFText";
            this.lbGamaMFText.Size = new System.Drawing.Size(31, 13);
            this.lbGamaMFText.TabIndex = 111;
            this.lbGamaMFText.Text = " γMf:";
            // 
            // lbKS
            // 
            this.lbKS.Location = new System.Drawing.Point(245, 23);
            this.lbKS.Name = "lbKS";
            this.lbKS.Size = new System.Drawing.Size(55, 20);
            this.lbKS.TabIndex = 110;
            this.lbKS.Text = "1.0";
            this.lbKS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbKSText
            // 
            this.lbKSText.AutoSize = true;
            this.lbKSText.Location = new System.Drawing.Point(215, 26);
            this.lbKSText.Name = "lbKSText";
            this.lbKSText.Size = new System.Drawing.Size(22, 13);
            this.lbKSText.TabIndex = 109;
            this.lbKSText.Text = "Ks:";
            // 
            // lbTypeStressText
            // 
            this.lbTypeStressText.AutoSize = true;
            this.lbTypeStressText.Location = new System.Drawing.Point(6, 53);
            this.lbTypeStressText.Name = "lbTypeStressText";
            this.lbTypeStressText.Size = new System.Drawing.Size(76, 13);
            this.lbTypeStressText.TabIndex = 38;
            this.lbTypeStressText.Text = "Type of stress:";
            // 
            // lbEcCategory
            // 
            this.lbEcCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lbEcCategory.FormattingEnabled = true;
            this.lbEcCategory.Items.AddRange(new object[] {
            "160",
            "140",
            "125",
            "112",
            "100",
            "90",
            "80",
            "71",
            "63",
            "56",
            "50",
            "45",
            "40",
            "36"});
            this.lbEcCategory.Location = new System.Drawing.Point(42, 23);
            this.lbEcCategory.Name = "lbEcCategory";
            this.lbEcCategory.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbEcCategory.Size = new System.Drawing.Size(57, 21);
            this.lbEcCategory.TabIndex = 106;
            // 
            // rbShearStress
            // 
            this.rbShearStress.AutoSize = true;
            this.rbShearStress.Location = new System.Drawing.Point(100, 72);
            this.rbShearStress.Name = "rbShearStress";
            this.rbShearStress.Size = new System.Drawing.Size(53, 17);
            this.rbShearStress.TabIndex = 108;
            this.rbShearStress.TabStop = true;
            this.rbShearStress.Text = "Shear";
            this.rbShearStress.UseVisualStyleBackColor = true;
            this.rbShearStress.MouseCaptureChanged += new System.EventHandler(this.rbShearStress_MouseCaptureChanged);
            // 
            // lbDeltaSigmaCText
            // 
            this.lbDeltaSigmaCText.AutoSize = true;
            this.lbDeltaSigmaCText.Location = new System.Drawing.Point(6, 26);
            this.lbDeltaSigmaCText.Name = "lbDeltaSigmaCText";
            this.lbDeltaSigmaCText.Size = new System.Drawing.Size(30, 13);
            this.lbDeltaSigmaCText.TabIndex = 35;
            this.lbDeltaSigmaCText.Text = "Δσc:";
            // 
            // rbNormalStress
            // 
            this.rbNormalStress.AutoSize = true;
            this.rbNormalStress.Checked = true;
            this.rbNormalStress.Location = new System.Drawing.Point(9, 72);
            this.rbNormalStress.Name = "rbNormalStress";
            this.rbNormalStress.Size = new System.Drawing.Size(58, 17);
            this.rbNormalStress.TabIndex = 107;
            this.rbNormalStress.TabStop = true;
            this.rbNormalStress.Text = "Normal";
            this.rbNormalStress.UseVisualStyleBackColor = true;
            this.rbNormalStress.MouseCaptureChanged += new System.EventHandler(this.rbNormalStress_MouseCaptureChanged);
            // 
            // lbRainflowText
            // 
            this.lbRainflowText.AutoSize = true;
            this.lbRainflowText.Location = new System.Drawing.Point(154, 170);
            this.lbRainflowText.Name = "lbRainflowText";
            this.lbRainflowText.Size = new System.Drawing.Size(97, 13);
            this.lbRainflowText.TabIndex = 37;
            this.lbRainflowText.Text = "Rainflow Summary:";
            // 
            // resultsWindow
            // 
            this.resultsWindow.Location = new System.Drawing.Point(0, 0);
            this.resultsWindow.Margin = new System.Windows.Forms.Padding(0);
            this.resultsWindow.MinimumSize = new System.Drawing.Size(20, 20);
            this.resultsWindow.Name = "resultsWindow";
            this.resultsWindow.Size = new System.Drawing.Size(398, 442);
            this.resultsWindow.TabIndex = 38;
            this.resultsWindow.Visible = false;
            // 
            // cbEnterStressRanges
            // 
            this.cbEnterStressRanges.AutoSize = true;
            this.cbEnterStressRanges.Location = new System.Drawing.Point(157, 150);
            this.cbEnterStressRanges.Name = "cbEnterStressRanges";
            this.cbEnterStressRanges.Size = new System.Drawing.Size(123, 17);
            this.cbEnterStressRanges.TabIndex = 117;
            this.cbEnterStressRanges.Text = "Enter Stress Ranges";
            this.cbEnterStressRanges.UseVisualStyleBackColor = true;
            this.cbEnterStressRanges.CheckedChanged += new System.EventHandler(this.cbEnterStressRanges_CheckedChanged);
            // 
            // lbPictureText
            // 
            this.lbPictureText.AutoSize = true;
            this.lbPictureText.Location = new System.Drawing.Point(6, 51);
            this.lbPictureText.Name = "lbPictureText";
            this.lbPictureText.Size = new System.Drawing.Size(43, 13);
            this.lbPictureText.TabIndex = 52;
            this.lbPictureText.Text = "Picture:";
            // 
            // lbDescriptionText
            // 
            this.lbDescriptionText.AutoSize = true;
            this.lbDescriptionText.Location = new System.Drawing.Point(6, 22);
            this.lbDescriptionText.Name = "lbDescriptionText";
            this.lbDescriptionText.Size = new System.Drawing.Size(63, 13);
            this.lbDescriptionText.TabIndex = 51;
            this.lbDescriptionText.Text = "Description:";
            // 
            // btPasteIn
            // 
            this.btPasteIn.Image = global::FatigueCalc.Properties.Resources.page_white_paste;
            this.btPasteIn.Location = new System.Drawing.Point(6, 19);
            this.btPasteIn.Name = "btPasteIn";
            this.btPasteIn.Size = new System.Drawing.Size(23, 23);
            this.btPasteIn.TabIndex = 110;
            this.btPasteIn.UseVisualStyleBackColor = true;
            this.btPasteIn.Click += new System.EventHandler(this.btPasteIn_Click);
            // 
            // btErase
            // 
            this.btErase.Image = global::FatigueCalc.Properties.Resources.eraser;
            this.btErase.Location = new System.Drawing.Point(30, 19);
            this.btErase.Name = "btErase";
            this.btErase.Size = new System.Drawing.Size(23, 23);
            this.btErase.TabIndex = 111;
            this.btErase.UseVisualStyleBackColor = true;
            this.btErase.Click += new System.EventHandler(this.btErase_Click);
            // 
            // containerWeb
            // 
            this.containerWeb.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.containerWeb.Controls.Add(this.resultsWindow);
            this.containerWeb.Enabled = false;
            this.containerWeb.Location = new System.Drawing.Point(330, 12);
            this.containerWeb.Name = "containerWeb";
            this.containerWeb.Size = new System.Drawing.Size(402, 446);
            this.containerWeb.TabIndex = 39;
            // 
            // dgStressHistory
            // 
            this.dgStressHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgStressHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgStressHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1});
            this.dgStressHistory.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgStressHistory.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgStressHistory.Location = new System.Drawing.Point(6, 48);
            this.dgStressHistory.Name = "dgStressHistory";
            this.dgStressHistory.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgStressHistory.RowHeadersVisible = false;
            this.dgStressHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgStressHistory.Size = new System.Drawing.Size(145, 96);
            this.dgStressHistory.TabIndex = 113;
            this.dgStressHistory.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgStressHistory_RowsAdded);
            this.dgStressHistory.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgStressHistory_RowsRemoved);
            this.dgStressHistory.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgStressHistory_KeyDown);
            this.dgStressHistory.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgStressHistory_KeyUp);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Stress History (MPa)";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dgPeaksValleys
            // 
            this.dgPeaksValleys.AllowUserToAddRows = false;
            this.dgPeaksValleys.AllowUserToDeleteRows = false;
            this.dgPeaksValleys.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgPeaksValleys.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPeaksValleys.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2});
            this.dgPeaksValleys.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgPeaksValleys.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgPeaksValleys.Location = new System.Drawing.Point(157, 48);
            this.dgPeaksValleys.Name = "dgPeaksValleys";
            this.dgPeaksValleys.ReadOnly = true;
            this.dgPeaksValleys.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgPeaksValleys.RowHeadersVisible = false;
            this.dgPeaksValleys.Size = new System.Drawing.Size(145, 96);
            this.dgPeaksValleys.TabIndex = 114;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Column1";
            this.dataGridViewTextBoxColumn2.HeaderText = "Peaks and Valleys";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dgRainflowResults
            // 
            this.dgRainflowResults.AllowUserToAddRows = false;
            this.dgRainflowResults.AllowUserToDeleteRows = false;
            this.dgRainflowResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgRainflowResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgRainflowResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.Column2});
            this.dgRainflowResults.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgRainflowResults.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgRainflowResults.Location = new System.Drawing.Point(6, 186);
            this.dgRainflowResults.Name = "dgRainflowResults";
            this.dgRainflowResults.ReadOnly = true;
            this.dgRainflowResults.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgRainflowResults.RowHeadersVisible = false;
            this.dgRainflowResults.Size = new System.Drawing.Size(145, 96);
            this.dgRainflowResults.TabIndex = 115;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Column1";
            this.dataGridViewTextBoxColumn3.HeaderText = "Range";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Column2";
            this.Column2.HeaderText = "Cycle";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // lbRainflowCountingText
            // 
            this.lbRainflowCountingText.AutoSize = true;
            this.lbRainflowCountingText.Location = new System.Drawing.Point(3, 170);
            this.lbRainflowCountingText.Name = "lbRainflowCountingText";
            this.lbRainflowCountingText.Size = new System.Drawing.Size(130, 13);
            this.lbRainflowCountingText.TabIndex = 45;
            this.lbRainflowCountingText.Text = "Rainflow Cycles Counting:";
            // 
            // gbRainflowResults
            // 
            this.gbRainflowResults.Controls.Add(this.lbTensaoMaxima);
            this.gbRainflowResults.Controls.Add(this.lbDecimalPlaces);
            this.gbRainflowResults.Controls.Add(this.cbEnterStressRanges);
            this.gbRainflowResults.Controls.Add(this.dgRainflowSummary);
            this.gbRainflowResults.Controls.Add(this.btPasteIn);
            this.gbRainflowResults.Controls.Add(this.btErase);
            this.gbRainflowResults.Controls.Add(this.dgRainflowResults);
            this.gbRainflowResults.Controls.Add(this.lbRainflowText);
            this.gbRainflowResults.Controls.Add(this.lbRainflowCountingText);
            this.gbRainflowResults.Controls.Add(this.dgStressHistory);
            this.gbRainflowResults.Controls.Add(this.dgPeaksValleys);
            this.gbRainflowResults.Controls.Add(this.lbDecimalPlacesText);
            this.gbRainflowResults.Location = new System.Drawing.Point(12, 195);
            this.gbRainflowResults.Name = "gbRainflowResults";
            this.gbRainflowResults.Size = new System.Drawing.Size(312, 292);
            this.gbRainflowResults.TabIndex = 3;
            this.gbRainflowResults.TabStop = false;
            this.gbRainflowResults.Text = "Stress Cycle Counting (Rainflow) - ASTM E 1049-85";
            // 
            // lbTensaoMaxima
            // 
            this.lbTensaoMaxima.AutoSize = true;
            this.lbTensaoMaxima.Location = new System.Drawing.Point(7, 150);
            this.lbTensaoMaxima.Name = "lbTensaoMaxima";
            this.lbTensaoMaxima.Size = new System.Drawing.Size(0, 13);
            this.lbTensaoMaxima.TabIndex = 118;
            // 
            // lbDecimalPlaces
            // 
            this.lbDecimalPlaces.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbDecimalPlaces.Items.Add("4");
            this.lbDecimalPlaces.Items.Add("3");
            this.lbDecimalPlaces.Items.Add("2");
            this.lbDecimalPlaces.Items.Add("1");
            this.lbDecimalPlaces.Items.Add("0");
            this.lbDecimalPlaces.Location = new System.Drawing.Point(245, 22);
            this.lbDecimalPlaces.Name = "lbDecimalPlaces";
            this.lbDecimalPlaces.ReadOnly = true;
            this.lbDecimalPlaces.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbDecimalPlaces.Size = new System.Drawing.Size(57, 20);
            this.lbDecimalPlaces.TabIndex = 112;
            this.lbDecimalPlaces.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dgRainflowSummary
            // 
            this.dgRainflowSummary.AllowUserToAddRows = false;
            this.dgRainflowSummary.AllowUserToDeleteRows = false;
            this.dgRainflowSummary.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgRainflowSummary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgRainflowSummary.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
            this.dgRainflowSummary.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgRainflowSummary.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgRainflowSummary.Location = new System.Drawing.Point(157, 186);
            this.dgRainflowSummary.Name = "dgRainflowSummary";
            this.dgRainflowSummary.ReadOnly = true;
            this.dgRainflowSummary.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgRainflowSummary.RowHeadersVisible = false;
            this.dgRainflowSummary.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgRainflowSummary.Size = new System.Drawing.Size(145, 96);
            this.dgRainflowSummary.TabIndex = 116;
            this.dgRainflowSummary.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgRainflowSummary_RowsAdded);
            this.dgRainflowSummary.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgRainflowSummary_RowsRemoved);
            this.dgRainflowSummary.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgRainflowSummary_KeyDown);
            this.dgRainflowSummary.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgRainflowSummary_KeyUp);
            // 
            // gbGeneralData
            // 
            this.gbGeneralData.Controls.Add(this.btChoosePicture);
            this.gbGeneralData.Controls.Add(this.lbPictureDetail);
            this.gbGeneralData.Controls.Add(this.lbPictureText);
            this.gbGeneralData.Controls.Add(this.lbDescriptionText);
            this.gbGeneralData.Controls.Add(this.lbDescription);
            this.gbGeneralData.Location = new System.Drawing.Point(10, 7);
            this.gbGeneralData.Name = "gbGeneralData";
            this.gbGeneralData.Size = new System.Drawing.Size(312, 77);
            this.gbGeneralData.TabIndex = 1;
            this.gbGeneralData.TabStop = false;
            this.gbGeneralData.Text = "General Data";
            // 
            // btChoosePicture
            // 
            this.btChoosePicture.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btChoosePicture.Image = global::FatigueCalc.Properties.Resources.openfolderHS1;
            this.btChoosePicture.Location = new System.Drawing.Point(283, 46);
            this.btChoosePicture.Name = "btChoosePicture";
            this.btChoosePicture.Size = new System.Drawing.Size(23, 23);
            this.btChoosePicture.TabIndex = 102;
            this.btChoosePicture.UseVisualStyleBackColor = true;
            this.btChoosePicture.Click += new System.EventHandler(this.btChoosePicture_Click);
            // 
            // lbPictureDetail
            // 
            this.lbPictureDetail.Location = new System.Drawing.Point(70, 48);
            this.lbPictureDetail.Name = "lbPictureDetail";
            this.lbPictureDetail.Size = new System.Drawing.Size(207, 20);
            this.lbPictureDetail.TabIndex = 101;
            // 
            // lbDescription
            // 
            this.lbDescription.Location = new System.Drawing.Point(70, 19);
            this.lbDescription.Name = "lbDescription";
            this.lbDescription.Size = new System.Drawing.Size(207, 20);
            this.lbDescription.TabIndex = 100;
            this.lbDescription.Text = "Description of Structural Detail";
            // 
            // mainMenuProgram
            // 
            this.mainMenuProgram.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miFile});
            // 
            // miFile
            // 
            this.miFile.Index = 0;
            this.miFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miAbout,
            this.miExit});
            this.miFile.Text = "File";
            // 
            // miAbout
            // 
            this.miAbout.Index = 0;
            this.miAbout.Text = "Sobre";
            this.miAbout.Click += new System.EventHandler(this.miAbout_Click);
            // 
            // miExit
            // 
            this.miExit.Index = 1;
            this.miExit.Text = "Sair";
            this.miExit.Click += new System.EventHandler(this.miExit_Click);
            // 
            // btSaveAs
            // 
            this.btSaveAs.Enabled = false;
            this.btSaveAs.Image = global::FatigueCalc.Properties.Resources.gnome_media_floppy16x16;
            this.btSaveAs.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btSaveAs.Location = new System.Drawing.Point(632, 464);
            this.btSaveAs.Name = "btSaveAs";
            this.btSaveAs.Size = new System.Drawing.Size(100, 23);
            this.btSaveAs.TabIndex = 40;
            this.btSaveAs.Text = "   Save as";
            this.btSaveAs.UseVisualStyleBackColor = true;
            this.btSaveAs.Click += new System.EventHandler(this.btSaveAs_Click);
            // 
            // btCalculate
            // 
            this.btCalculate.Enabled = false;
            this.btCalculate.Image = global::FatigueCalc.Properties.Resources.calc;
            this.btCalculate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btCalculate.Location = new System.Drawing.Point(526, 464);
            this.btCalculate.Name = "btCalculate";
            this.btCalculate.Size = new System.Drawing.Size(100, 23);
            this.btCalculate.TabIndex = 4;
            this.btCalculate.Text = "    Calculate";
            this.btCalculate.UseVisualStyleBackColor = true;
            this.btCalculate.Click += new System.EventHandler(this.btCalculate_Click);
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Column1";
            this.dataGridViewTextBoxColumn4.HeaderText = "Range";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Column2";
            this.dataGridViewTextBoxColumn5.HeaderText = "Cycles";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // fatigueCalculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 495);
            this.Controls.Add(this.gbSNCurve);
            this.Controls.Add(this.btSaveAs);
            this.Controls.Add(this.gbGeneralData);
            this.Controls.Add(this.gbRainflowResults);
            this.Controls.Add(this.containerWeb);
            this.Controls.Add(this.btCalculate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Menu = this.mainMenuProgram;
            this.Name = "fatigueCalculator";
            this.Text = "Fatigue Damage Accumulation";
            this.gbSNCurve.ResumeLayout(false);
            this.gbSNCurve.PerformLayout();
            this.containerWeb.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgStressHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgPeaksValleys)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgRainflowResults)).EndInit();
            this.gbRainflowResults.ResumeLayout(false);
            this.gbRainflowResults.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgRainflowSummary)).EndInit();
            this.gbGeneralData.ResumeLayout(false);
            this.gbGeneralData.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btCalculate;
        private System.Windows.Forms.Button btPasteIn;
        private System.Windows.Forms.Label lbDecimalPlacesText;
        private System.Windows.Forms.GroupBox gbSNCurve;
        private System.Windows.Forms.Label lbDeltaSigmaCText;
        private System.Windows.Forms.SaveFileDialog sfFatigueResults;
        private System.Windows.Forms.Label lbRainflowText;
        private System.Windows.Forms.WebBrowser resultsWindow;
        private System.Windows.Forms.Panel containerWeb;
        public System.Windows.Forms.DataGridView dgStressHistory;
        private System.Windows.Forms.Button btErase;
        private System.Windows.Forms.DataGridView dgRainflowResults;
        private System.Windows.Forms.Label lbRainflowCountingText;
        private System.Windows.Forms.GroupBox gbRainflowResults;
        private System.Windows.Forms.DataGridView dgRainflowSummary;
        private System.Windows.Forms.DataGridView dgPeaksValleys;
        private System.Windows.Forms.DomainUpDown lbDecimalPlaces;
        private System.Windows.Forms.ComboBox lbEcCategory;
        private System.Windows.Forms.RadioButton rbShearStress;
        private System.Windows.Forms.RadioButton rbNormalStress;
        private System.Windows.Forms.Label lbTypeStressText;
        private System.Windows.Forms.CheckBox cbEnterStressRanges;
        private System.Windows.Forms.GroupBox gbGeneralData;
        private System.Windows.Forms.TextBox lbPictureDetail;
        private System.Windows.Forms.Label lbPictureText;
        private System.Windows.Forms.Label lbDescriptionText;
        private System.Windows.Forms.TextBox lbDescription;
        private System.Windows.Forms.OpenFileDialog openPictureDialog;
        private System.Windows.Forms.Button btChoosePicture;
        private System.Windows.Forms.MainMenu mainMenuProgram;
        private System.Windows.Forms.MenuItem miFile;
        private System.Windows.Forms.MenuItem miExit;
        private System.Windows.Forms.MenuItem miAbout;
        private System.Windows.Forms.Button btSaveAs;
        private System.Windows.Forms.TextBox lbKS;
        private System.Windows.Forms.Label lbKSText;
        private System.Windows.Forms.Label lbTensaoMaxima;
        private System.Windows.Forms.TextBox lbGamaMf;
        private System.Windows.Forms.Label lbGamaMFText;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.ToolTip shortDescriptions;
    }
}

