﻿
namespace LabBook_WF_EF.Forms.LabBook
{
    partial class LabBookForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LabBookForm));
            this.TabControlMain = new System.Windows.Forms.TabControl();
            this.TabPageMain = new System.Windows.Forms.TabPage();
            this.DgvLabBook = new System.Windows.Forms.DataGridView();
            this.TabPageRemarks = new System.Windows.Forms.TabPage();
            this.TxtRemarks = new System.Windows.Forms.TextBox();
            this.TabPageObservation = new System.Windows.Forms.TabPage();
            this.TxtObservation = new System.Windows.Forms.TextBox();
            this.TabPageViscosity = new System.Windows.Forms.TabPage();
            this.DgvViscosity = new System.Windows.Forms.DataGridView();
            this.TabPageContrast = new System.Windows.Forms.TabPage();
            this.BtnContrastDown = new System.Windows.Forms.Button();
            this.BtnContrastUp = new System.Windows.Forms.Button();
            this.DgvContrast = new System.Windows.Forms.DataGridView();
            this.TabPageGloss = new System.Windows.Forms.TabPage();
            this.BtnGlossDown = new System.Windows.Forms.Button();
            this.BtnGlossUp = new System.Windows.Forms.Button();
            this.LblGloss = new System.Windows.Forms.Label();
            this.CmbGlossClass = new System.Windows.Forms.ComboBox();
            this.DgvGloss = new System.Windows.Forms.DataGridView();
            this.TabPageClassification = new System.Windows.Forms.TabPage();
            this.LblContrastYield = new System.Windows.Forms.Label();
            this.CmbContrastYield = new System.Windows.Forms.ComboBox();
            this.LblContarstClass = new System.Windows.Forms.Label();
            this.CmbContrastClass = new System.Windows.Forms.ComboBox();
            this.BindingNavigatorMain = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ToolStripAdd = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSave = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.plikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dodajToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ApplicatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.widokToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lepkosciToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.standardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prbToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.brookPelnyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.brookKrebsStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.brookIciStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TxtTitle = new System.Windows.Forms.TextBox();
            this.LblNrD = new System.Windows.Forms.Label();
            this.LblDate = new System.Windows.Forms.Label();
            this.TabControlMain.SuspendLayout();
            this.TabPageMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvLabBook)).BeginInit();
            this.TabPageRemarks.SuspendLayout();
            this.TabPageObservation.SuspendLayout();
            this.TabPageViscosity.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvViscosity)).BeginInit();
            this.TabPageContrast.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvContrast)).BeginInit();
            this.TabPageGloss.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvGloss)).BeginInit();
            this.TabPageClassification.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BindingNavigatorMain)).BeginInit();
            this.BindingNavigatorMain.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabControlMain
            // 
            this.TabControlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TabControlMain.Controls.Add(this.TabPageMain);
            this.TabControlMain.Controls.Add(this.TabPageRemarks);
            this.TabControlMain.Controls.Add(this.TabPageObservation);
            this.TabControlMain.Controls.Add(this.TabPageViscosity);
            this.TabControlMain.Controls.Add(this.TabPageContrast);
            this.TabControlMain.Controls.Add(this.TabPageGloss);
            this.TabControlMain.Controls.Add(this.TabPageClassification);
            this.TabControlMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.TabControlMain.Location = new System.Drawing.Point(0, 131);
            this.TabControlMain.Name = "TabControlMain";
            this.TabControlMain.SelectedIndex = 0;
            this.TabControlMain.Size = new System.Drawing.Size(1163, 468);
            this.TabControlMain.TabIndex = 0;
            this.TabControlMain.SelectedIndexChanged += new System.EventHandler(this.TabControlMain_SelectedIndexChanged);
            // 
            // TabPageMain
            // 
            this.TabPageMain.BackColor = System.Drawing.SystemColors.Control;
            this.TabPageMain.Controls.Add(this.DgvLabBook);
            this.TabPageMain.Location = new System.Drawing.Point(4, 29);
            this.TabPageMain.Name = "TabPageMain";
            this.TabPageMain.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageMain.Size = new System.Drawing.Size(1155, 435);
            this.TabPageMain.TabIndex = 0;
            this.TabPageMain.Text = "Strona główna";
            // 
            // DgvLabBook
            // 
            this.DgvLabBook.AllowUserToAddRows = false;
            this.DgvLabBook.AllowUserToDeleteRows = false;
            this.DgvLabBook.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvLabBook.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvLabBook.Location = new System.Drawing.Point(3, 49);
            this.DgvLabBook.Name = "DgvLabBook";
            this.DgvLabBook.RowHeadersWidth = 51;
            this.DgvLabBook.RowTemplate.Height = 24;
            this.DgvLabBook.Size = new System.Drawing.Size(1146, 380);
            this.DgvLabBook.TabIndex = 0;
            // 
            // TabPageRemarks
            // 
            this.TabPageRemarks.BackColor = System.Drawing.SystemColors.Control;
            this.TabPageRemarks.Controls.Add(this.TxtRemarks);
            this.TabPageRemarks.Location = new System.Drawing.Point(4, 29);
            this.TabPageRemarks.Name = "TabPageRemarks";
            this.TabPageRemarks.Size = new System.Drawing.Size(1155, 435);
            this.TabPageRemarks.TabIndex = 2;
            this.TabPageRemarks.Text = "Uwagi";
            // 
            // TxtRemarks
            // 
            this.TxtRemarks.AcceptsReturn = true;
            this.TxtRemarks.AcceptsTab = true;
            this.TxtRemarks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtRemarks.Location = new System.Drawing.Point(3, 3);
            this.TxtRemarks.Multiline = true;
            this.TxtRemarks.Name = "TxtRemarks";
            this.TxtRemarks.Size = new System.Drawing.Size(1149, 429);
            this.TxtRemarks.TabIndex = 1;
            // 
            // TabPageObservation
            // 
            this.TabPageObservation.BackColor = System.Drawing.SystemColors.Control;
            this.TabPageObservation.Controls.Add(this.TxtObservation);
            this.TabPageObservation.Location = new System.Drawing.Point(4, 29);
            this.TabPageObservation.Name = "TabPageObservation";
            this.TabPageObservation.Size = new System.Drawing.Size(1155, 435);
            this.TabPageObservation.TabIndex = 3;
            this.TabPageObservation.Text = "Obserwacje";
            // 
            // TxtObservation
            // 
            this.TxtObservation.AcceptsReturn = true;
            this.TxtObservation.AcceptsTab = true;
            this.TxtObservation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtObservation.Location = new System.Drawing.Point(3, 3);
            this.TxtObservation.Multiline = true;
            this.TxtObservation.Name = "TxtObservation";
            this.TxtObservation.Size = new System.Drawing.Size(1149, 429);
            this.TxtObservation.TabIndex = 1;
            // 
            // TabPageViscosity
            // 
            this.TabPageViscosity.BackColor = System.Drawing.SystemColors.Control;
            this.TabPageViscosity.Controls.Add(this.DgvViscosity);
            this.TabPageViscosity.Location = new System.Drawing.Point(4, 29);
            this.TabPageViscosity.Name = "TabPageViscosity";
            this.TabPageViscosity.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageViscosity.Size = new System.Drawing.Size(1155, 435);
            this.TabPageViscosity.TabIndex = 1;
            this.TabPageViscosity.Text = "Lepkość";
            // 
            // DgvViscosity
            // 
            this.DgvViscosity.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvViscosity.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvViscosity.Location = new System.Drawing.Point(0, 6);
            this.DgvViscosity.Name = "DgvViscosity";
            this.DgvViscosity.RowHeadersWidth = 51;
            this.DgvViscosity.RowTemplate.Height = 24;
            this.DgvViscosity.Size = new System.Drawing.Size(1152, 423);
            this.DgvViscosity.TabIndex = 0;
            this.DgvViscosity.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvViscosity_CellContentClick);
            this.DgvViscosity.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.DgvViscosity_ColumnWidthChanged);
            this.DgvViscosity.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.DgvViscosity_DefaultValuesNeeded);
            this.DgvViscosity.Resize += new System.EventHandler(this.DgvViscosity_Resize);
            // 
            // TabPageContrast
            // 
            this.TabPageContrast.BackColor = System.Drawing.SystemColors.Control;
            this.TabPageContrast.Controls.Add(this.BtnContrastDown);
            this.TabPageContrast.Controls.Add(this.BtnContrastUp);
            this.TabPageContrast.Controls.Add(this.DgvContrast);
            this.TabPageContrast.Location = new System.Drawing.Point(4, 29);
            this.TabPageContrast.Name = "TabPageContrast";
            this.TabPageContrast.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageContrast.Size = new System.Drawing.Size(1155, 435);
            this.TabPageContrast.TabIndex = 4;
            this.TabPageContrast.Text = "Krycie";
            // 
            // BtnContrastDown
            // 
            this.BtnContrastDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnContrastDown.BackgroundImage = global::LabBook_WF_EF.Properties.Resources.strzałka_dol;
            this.BtnContrastDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnContrastDown.Location = new System.Drawing.Point(1112, 205);
            this.BtnContrastDown.Name = "BtnContrastDown";
            this.BtnContrastDown.Size = new System.Drawing.Size(36, 39);
            this.BtnContrastDown.TabIndex = 10;
            this.BtnContrastDown.UseVisualStyleBackColor = true;
            // 
            // BtnContrastUp
            // 
            this.BtnContrastUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnContrastUp.BackgroundImage = global::LabBook_WF_EF.Properties.Resources.strzałka_góra;
            this.BtnContrastUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnContrastUp.Location = new System.Drawing.Point(1112, 160);
            this.BtnContrastUp.Name = "BtnContrastUp";
            this.BtnContrastUp.Size = new System.Drawing.Size(36, 39);
            this.BtnContrastUp.TabIndex = 9;
            this.BtnContrastUp.UseVisualStyleBackColor = true;
            // 
            // DgvContrast
            // 
            this.DgvContrast.AllowUserToAddRows = false;
            this.DgvContrast.AllowUserToDeleteRows = false;
            this.DgvContrast.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvContrast.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvContrast.Location = new System.Drawing.Point(0, 6);
            this.DgvContrast.Name = "DgvContrast";
            this.DgvContrast.RowHeadersWidth = 51;
            this.DgvContrast.RowTemplate.Height = 24;
            this.DgvContrast.Size = new System.Drawing.Size(1106, 423);
            this.DgvContrast.TabIndex = 0;
            this.DgvContrast.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvContrast_CellContentClick);
            this.DgvContrast.Resize += new System.EventHandler(this.DgvContrast_Resize);
            // 
            // TabPageGloss
            // 
            this.TabPageGloss.BackColor = System.Drawing.SystemColors.Control;
            this.TabPageGloss.Controls.Add(this.BtnGlossDown);
            this.TabPageGloss.Controls.Add(this.BtnGlossUp);
            this.TabPageGloss.Controls.Add(this.LblGloss);
            this.TabPageGloss.Controls.Add(this.CmbGlossClass);
            this.TabPageGloss.Controls.Add(this.DgvGloss);
            this.TabPageGloss.Location = new System.Drawing.Point(4, 29);
            this.TabPageGloss.Name = "TabPageGloss";
            this.TabPageGloss.Size = new System.Drawing.Size(1155, 435);
            this.TabPageGloss.TabIndex = 5;
            this.TabPageGloss.Text = "Połysk";
            // 
            // BtnGlossDown
            // 
            this.BtnGlossDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnGlossDown.BackgroundImage = global::LabBook_WF_EF.Properties.Resources.strzałka_dol;
            this.BtnGlossDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnGlossDown.Location = new System.Drawing.Point(1111, 207);
            this.BtnGlossDown.Name = "BtnGlossDown";
            this.BtnGlossDown.Size = new System.Drawing.Size(36, 39);
            this.BtnGlossDown.TabIndex = 6;
            this.BtnGlossDown.UseVisualStyleBackColor = true;
            // 
            // BtnGlossUp
            // 
            this.BtnGlossUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnGlossUp.BackgroundImage = global::LabBook_WF_EF.Properties.Resources.strzałka_góra;
            this.BtnGlossUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnGlossUp.Location = new System.Drawing.Point(1111, 162);
            this.BtnGlossUp.Name = "BtnGlossUp";
            this.BtnGlossUp.Size = new System.Drawing.Size(36, 39);
            this.BtnGlossUp.TabIndex = 5;
            this.BtnGlossUp.UseVisualStyleBackColor = true;
            // 
            // LblGloss
            // 
            this.LblGloss.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LblGloss.AutoSize = true;
            this.LblGloss.Location = new System.Drawing.Point(8, 406);
            this.LblGloss.Name = "LblGloss";
            this.LblGloss.Size = new System.Drawing.Size(64, 20);
            this.LblGloss.TabIndex = 4;
            this.LblGloss.Text = "Połysk";
            // 
            // CmbGlossClass
            // 
            this.CmbGlossClass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CmbGlossClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbGlossClass.FormattingEnabled = true;
            this.CmbGlossClass.Location = new System.Drawing.Point(78, 403);
            this.CmbGlossClass.Name = "CmbGlossClass";
            this.CmbGlossClass.Size = new System.Drawing.Size(152, 28);
            this.CmbGlossClass.TabIndex = 3;
            // 
            // DgvGloss
            // 
            this.DgvGloss.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvGloss.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvGloss.Location = new System.Drawing.Point(3, 3);
            this.DgvGloss.Name = "DgvGloss";
            this.DgvGloss.RowHeadersWidth = 51;
            this.DgvGloss.RowTemplate.Height = 24;
            this.DgvGloss.Size = new System.Drawing.Size(1102, 394);
            this.DgvGloss.TabIndex = 0;
            // 
            // TabPageClassification
            // 
            this.TabPageClassification.BackColor = System.Drawing.SystemColors.Control;
            this.TabPageClassification.Controls.Add(this.LblContrastYield);
            this.TabPageClassification.Controls.Add(this.CmbContrastYield);
            this.TabPageClassification.Controls.Add(this.LblContarstClass);
            this.TabPageClassification.Controls.Add(this.CmbContrastClass);
            this.TabPageClassification.Location = new System.Drawing.Point(4, 29);
            this.TabPageClassification.Name = "TabPageClassification";
            this.TabPageClassification.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageClassification.Size = new System.Drawing.Size(1155, 435);
            this.TabPageClassification.TabIndex = 6;
            this.TabPageClassification.Text = "Klasyfikacja";
            // 
            // LblContrastYield
            // 
            this.LblContrastYield.AutoSize = true;
            this.LblContrastYield.Location = new System.Drawing.Point(315, 22);
            this.LblContrastYield.Name = "LblContrastYield";
            this.LblContrastYield.Size = new System.Drawing.Size(45, 20);
            this.LblContrastYield.TabIndex = 12;
            this.LblContrastYield.Text = "przy";
            // 
            // CmbContrastYield
            // 
            this.CmbContrastYield.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbContrastYield.FormattingEnabled = true;
            this.CmbContrastYield.Location = new System.Drawing.Point(384, 19);
            this.CmbContrastYield.Name = "CmbContrastYield";
            this.CmbContrastYield.Size = new System.Drawing.Size(132, 28);
            this.CmbContrastYield.TabIndex = 11;
            // 
            // LblContarstClass
            // 
            this.LblContarstClass.AutoSize = true;
            this.LblContarstClass.Location = new System.Drawing.Point(13, 22);
            this.LblContarstClass.Name = "LblContarstClass";
            this.LblContarstClass.Size = new System.Drawing.Size(112, 20);
            this.LblContarstClass.TabIndex = 10;
            this.LblContarstClass.Text = "Klasa krycia";
            // 
            // CmbContrastClass
            // 
            this.CmbContrastClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbContrastClass.FormattingEnabled = true;
            this.CmbContrastClass.Location = new System.Drawing.Point(152, 19);
            this.CmbContrastClass.Name = "CmbContrastClass";
            this.CmbContrastClass.Size = new System.Drawing.Size(131, 28);
            this.CmbContrastClass.TabIndex = 9;
            // 
            // BindingNavigatorMain
            // 
            this.BindingNavigatorMain.AddNewItem = this.bindingNavigatorAddNewItem;
            this.BindingNavigatorMain.CountItem = this.bindingNavigatorCountItem;
            this.BindingNavigatorMain.DeleteItem = this.bindingNavigatorDeleteItem;
            this.BindingNavigatorMain.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BindingNavigatorMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.BindingNavigatorMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem});
            this.BindingNavigatorMain.Location = new System.Drawing.Point(0, 602);
            this.BindingNavigatorMain.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.BindingNavigatorMain.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.BindingNavigatorMain.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.BindingNavigatorMain.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.BindingNavigatorMain.Name = "BindingNavigatorMain";
            this.BindingNavigatorMain.PositionItem = this.bindingNavigatorPositionItem;
            this.BindingNavigatorMain.Size = new System.Drawing.Size(1163, 27);
            this.BindingNavigatorMain.TabIndex = 1;
            this.BindingNavigatorMain.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorAddNewItem.Text = "Dodaj nowy";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(38, 24);
            this.bindingNavigatorCountItem.Text = "z {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Suma elementów";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorDeleteItem.Text = "Usuń";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMoveFirstItem.Text = "Przenieś pierwszy";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMovePreviousItem.Text = "Przenieś poprzedni";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Pozycja";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 27);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Bieżąca pozycja";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMoveNextItem.Text = "Przenieś następny";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMoveLastItem.Text = "Przenieś ostatni";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripAdd,
            this.ToolStripSave});
            this.toolStrip1.Location = new System.Drawing.Point(0, 31);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1163, 27);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // ToolStripAdd
            // 
            this.ToolStripAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolStripAdd.Image = global::LabBook_WF_EF.Properties.Resources.Add_new3;
            this.ToolStripAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripAdd.Name = "ToolStripAdd";
            this.ToolStripAdd.Size = new System.Drawing.Size(29, 24);
            this.ToolStripAdd.Text = "Dodaj nowy";
            // 
            // ToolStripSave
            // 
            this.ToolStripSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolStripSave.Image = global::LabBook_WF_EF.Properties.Resources.Save1;
            this.ToolStripSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripSave.Name = "ToolStripSave";
            this.ToolStripSave.Size = new System.Drawing.Size(29, 24);
            this.ToolStripSave.Text = "Zapisz";
            this.ToolStripSave.Click += new System.EventHandler(this.ToolStripSave_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.plikToolStripMenuItem,
            this.dodajToolStripMenuItem,
            this.widokToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1163, 31);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // plikToolStripMenuItem
            // 
            this.plikToolStripMenuItem.Name = "plikToolStripMenuItem";
            this.plikToolStripMenuItem.Size = new System.Drawing.Size(51, 27);
            this.plikToolStripMenuItem.Text = "Plik";
            // 
            // dodajToolStripMenuItem
            // 
            this.dodajToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ApplicatorToolStripMenuItem});
            this.dodajToolStripMenuItem.Name = "dodajToolStripMenuItem";
            this.dodajToolStripMenuItem.Size = new System.Drawing.Size(69, 27);
            this.dodajToolStripMenuItem.Text = "Dodaj";
            // 
            // ApplicatorToolStripMenuItem
            // 
            this.ApplicatorToolStripMenuItem.Enabled = false;
            this.ApplicatorToolStripMenuItem.Name = "ApplicatorToolStripMenuItem";
            this.ApplicatorToolStripMenuItem.Size = new System.Drawing.Size(224, 28);
            this.ApplicatorToolStripMenuItem.Text = "Nowe krycie";
            // 
            // widokToolStripMenuItem
            // 
            this.widokToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lepkosciToolStripMenuItem});
            this.widokToolStripMenuItem.Name = "widokToolStripMenuItem";
            this.widokToolStripMenuItem.Size = new System.Drawing.Size(73, 27);
            this.widokToolStripMenuItem.Text = "Widok";
            // 
            // lepkosciToolStripMenuItem
            // 
            this.lepkosciToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.standardToolStripMenuItem,
            this.prbToolStripMenuItem,
            this.brookPelnyToolStripMenuItem,
            this.brookKrebsStripMenuItem,
            this.brookIciStripMenuItem});
            this.lepkosciToolStripMenuItem.Name = "lepkosciToolStripMenuItem";
            this.lepkosciToolStripMenuItem.Size = new System.Drawing.Size(159, 28);
            this.lepkosciToolStripMenuItem.Text = "Lepkości";
            // 
            // standardToolStripMenuItem
            // 
            this.standardToolStripMenuItem.Name = "standardToolStripMenuItem";
            this.standardToolStripMenuItem.Size = new System.Drawing.Size(203, 28);
            this.standardToolStripMenuItem.Tag = "1";
            this.standardToolStripMenuItem.Text = "Standard";
            this.standardToolStripMenuItem.Click += new System.EventHandler(this.ViscosityViewToolStripMenuItem_Click);
            // 
            // prbToolStripMenuItem
            // 
            this.prbToolStripMenuItem.Name = "prbToolStripMenuItem";
            this.prbToolStripMenuItem.Size = new System.Drawing.Size(203, 28);
            this.prbToolStripMenuItem.Tag = "2";
            this.prbToolStripMenuItem.Text = "Brook PRB";
            this.prbToolStripMenuItem.Click += new System.EventHandler(this.ViscosityViewToolStripMenuItem_Click);
            // 
            // brookPelnyToolStripMenuItem
            // 
            this.brookPelnyToolStripMenuItem.Name = "brookPelnyToolStripMenuItem";
            this.brookPelnyToolStripMenuItem.Size = new System.Drawing.Size(203, 28);
            this.brookPelnyToolStripMenuItem.Tag = "3";
            this.brookPelnyToolStripMenuItem.Text = "Brook pełny";
            this.brookPelnyToolStripMenuItem.Click += new System.EventHandler(this.ViscosityViewToolStripMenuItem_Click);
            // 
            // brookKrebsStripMenuItem
            // 
            this.brookKrebsStripMenuItem.Name = "brookKrebsStripMenuItem";
            this.brookKrebsStripMenuItem.Size = new System.Drawing.Size(203, 28);
            this.brookKrebsStripMenuItem.Tag = "4";
            this.brookKrebsStripMenuItem.Text = "Brook + Krebs";
            this.brookKrebsStripMenuItem.Click += new System.EventHandler(this.ViscosityViewToolStripMenuItem_Click);
            // 
            // brookIciStripMenuItem
            // 
            this.brookIciStripMenuItem.Name = "brookIciStripMenuItem";
            this.brookIciStripMenuItem.Size = new System.Drawing.Size(203, 28);
            this.brookIciStripMenuItem.Tag = "5";
            this.brookIciStripMenuItem.Text = "Brook + ICI";
            this.brookIciStripMenuItem.Click += new System.EventHandler(this.ViscosityViewToolStripMenuItem_Click);
            // 
            // TxtTitle
            // 
            this.TxtTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.TxtTitle.Location = new System.Drawing.Point(115, 77);
            this.TxtTitle.Name = "TxtTitle";
            this.TxtTitle.Size = new System.Drawing.Size(790, 27);
            this.TxtTitle.TabIndex = 4;
            this.TxtTitle.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtTitle_KeyPress);
            // 
            // LblNrD
            // 
            this.LblNrD.AutoSize = true;
            this.LblNrD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LblNrD.ForeColor = System.Drawing.Color.Blue;
            this.LblNrD.Location = new System.Drawing.Point(3, 80);
            this.LblNrD.Name = "LblNrD";
            this.LblNrD.Size = new System.Drawing.Size(59, 20);
            this.LblNrD.TabIndex = 6;
            this.LblNrD.Text = "10000";
            // 
            // LblDate
            // 
            this.LblDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblDate.AutoSize = true;
            this.LblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LblDate.ForeColor = System.Drawing.Color.Blue;
            this.LblDate.Location = new System.Drawing.Point(1022, 80);
            this.LblDate.Name = "LblDate";
            this.LblDate.Size = new System.Drawing.Size(131, 20);
            this.LblDate.TabIndex = 7;
            this.LblDate.Text = " DD-MM-YYYY";
            // 
            // LabBookForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1163, 629);
            this.Controls.Add(this.LblDate);
            this.Controls.Add(this.LblNrD);
            this.Controls.Add(this.TxtTitle);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.BindingNavigatorMain);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.TabControlMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "LabBookForm";
            this.Text = "Dziennik laboratoryjny";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LabBookForm_FormClosing);
            this.Load += new System.EventHandler(this.LabBookForm_Load);
            this.TabControlMain.ResumeLayout(false);
            this.TabPageMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvLabBook)).EndInit();
            this.TabPageRemarks.ResumeLayout(false);
            this.TabPageRemarks.PerformLayout();
            this.TabPageObservation.ResumeLayout(false);
            this.TabPageObservation.PerformLayout();
            this.TabPageViscosity.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvViscosity)).EndInit();
            this.TabPageContrast.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvContrast)).EndInit();
            this.TabPageGloss.ResumeLayout(false);
            this.TabPageGloss.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvGloss)).EndInit();
            this.TabPageClassification.ResumeLayout(false);
            this.TabPageClassification.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BindingNavigatorMain)).EndInit();
            this.BindingNavigatorMain.ResumeLayout(false);
            this.BindingNavigatorMain.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl TabControlMain;
        private System.Windows.Forms.TabPage TabPageMain;
        private System.Windows.Forms.DataGridView DgvLabBook;
        private System.Windows.Forms.TabPage TabPageViscosity;
        private System.Windows.Forms.BindingNavigator BindingNavigatorMain;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton ToolStripSave;
        private System.Windows.Forms.ToolStripButton ToolStripAdd;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem plikToolStripMenuItem;
        private System.Windows.Forms.TextBox TxtTitle;
        private System.Windows.Forms.Label LblNrD;
        private System.Windows.Forms.Label LblDate;
        private System.Windows.Forms.TabPage TabPageRemarks;
        private System.Windows.Forms.TextBox TxtRemarks;
        private System.Windows.Forms.TabPage TabPageObservation;
        private System.Windows.Forms.TextBox TxtObservation;
        private System.Windows.Forms.DataGridView DgvViscosity;
        private System.Windows.Forms.ToolStripMenuItem widokToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lepkosciToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem standardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem prbToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem brookPelnyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem brookKrebsStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem brookIciStripMenuItem;
        private System.Windows.Forms.TabPage TabPageContrast;
        private System.Windows.Forms.DataGridView DgvContrast;
        private System.Windows.Forms.ToolStripMenuItem dodajToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ApplicatorToolStripMenuItem;
        private System.Windows.Forms.TabPage TabPageGloss;
        private System.Windows.Forms.Label LblGloss;
        private System.Windows.Forms.ComboBox CmbGlossClass;
        private System.Windows.Forms.DataGridView DgvGloss;
        private System.Windows.Forms.Button BtnGlossUp;
        private System.Windows.Forms.Button BtnGlossDown;
        private System.Windows.Forms.Button BtnContrastDown;
        private System.Windows.Forms.Button BtnContrastUp;
        private System.Windows.Forms.TabPage TabPageClassification;
        private System.Windows.Forms.Label LblContrastYield;
        private System.Windows.Forms.ComboBox CmbContrastYield;
        private System.Windows.Forms.Label LblContarstClass;
        private System.Windows.Forms.ComboBox CmbContrastClass;
    }
}