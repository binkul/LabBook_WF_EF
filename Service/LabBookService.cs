﻿using LabBook_WF_EF.Commons;
using LabBook_WF_EF.Dto;
using LabBook_WF_EF.EntityModels;
using LabBook_WF_EF.Forms.LabBook;
using LabBook_WF_EF.Properties;
using LabBook_WF_EF.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace LabBook_WF_EF.Service
{
    enum TabPages
    {
        One=1,
        Two=2,
        Three=3,
        Four=4
    }

    enum NormTests
    {
        Empty,
        Anti_Flash,
        Clemens,
        Cone_plate,
        Drying_time,
        Solids,
        Condensation_chamber,
        Salt_chamber,
        UV_chamber,
        Hiding,
        Visual_aspect,
        Vapour_permeablitiy,
        Stains,
        Gloss,
        Adhession,
        Hiding_power,
        Flow_limit,
        Scrubing,
        Yelowness_40,
        Yelowness_100,
        Flexibility
    }

    public class LabBookService
    {
        private static readonly string deleteColumn = "Del";
        private static readonly string dataFormFileName = "LabBookForm";
        private static readonly string contrastSubstrate = "Leneta cz/b";

        private static readonly Image noImg = Resources._lock;
        private static readonly Image img = Resources.Ok_icon1;
        private static readonly Image noAccess = noImg.GetThumbnailImage(18, 18, null, System.IntPtr.Zero);
        private static readonly Image access = img.GetThumbnailImage(18, 18, null, System.IntPtr.Zero);
        private static readonly SolidBrush redBrush = new SolidBrush(Color.Red);

        private readonly LabBookForm _form;
        private readonly LabBookContext _context;
        private readonly SqlConnection _sqlConnection;
        private readonly ExpViscosityRepository _visRepository;
        private readonly ExpContrastRepository _conRepository;
        private readonly NormResultService _normService;
        private readonly ExpNormResultRepository _normRepository;
        private readonly UserDto _user;

        private bool _blockCombBoxes = false;

        private IList<ExpLabBook> _labBook;
        private BindingSource _labBookBinding;
        private IList<ExpViscosity> _viscosities;
        private BindingSource _viscosityBinding;
        private IList<ExpContrast> _contrasts;
        private BindingSource _contrastBinding;
        private IList<ExpNormResult> _normResults;
        private BindingSource _normResultBinding;
        private IList<ExpContrastClass> _contrastClass;
        private BindingSource _contrastClassBinding;
        private IList<ExpGloss> _glosses;
        private BindingSource _glossesBinding;
        private IList<CmbContrastClass> _cmbContrastClasses;
        private IList<CmbContrastYield> _cmbContrastYields;
        private IList<CmbGlosClass> _cmbGlossClasses;
        private IList<CmbScrubClass> _cmbScrubClasses;
        private ViscosityFieldsType _viscosityFields = ViscosityFieldsType.StdBrook;

        public LabBookService(LabBookForm form, LabBookContext context, UserDto user)
        {
            _form = form;
            _context = context;
            _user = user;
            _sqlConnection = new SqlConnection(ConfigData.ConnectionStringAdo);
            _visRepository = new ExpViscosityRepository(_context);
            _conRepository = new ExpContrastRepository(_context);
            _normRepository = new ExpNormResultRepository(_context);
            _normService = new NormResultService();
        }

        public BindingSource GetLabBookBinding => _labBookBinding;
        public ExpLabBook GetCurrentLabBook => (ExpLabBook)_labBookBinding.Current;

        #region Prepare all data

        public void PrepareData()
        {
            _labBook = GetAllLabBook();
            _labBookBinding = new BindingSource { DataSource = _labBook };
            _labBookBinding.PositionChanged += LabBookBinding_PositionChanged;

            _viscosities = new ObservableListSource<ExpViscosity>();
            _viscosityBinding = new BindingSource { DataSource = _viscosities };

            _contrasts = new ObservableListSource<ExpContrast>();
            _contrastBinding = new BindingSource { DataSource = _contrasts };

            _normResults = new ObservableListSource<ExpNormResult>();
            _normResultBinding = new BindingSource { DataSource = _normResults };

            _cmbContrastClasses = GetCmbContrastClasses();
            _cmbContrastYields = GetCmbContrastYields();
            _cmbGlossClasses = GetCmbGlossClasses();
            _cmbScrubClasses = GetCmbScrubClasses();

            #region Prepare Menus

            PrepareApplicatorMenu();
            PrepareNormResultmenu();

            #endregion

            #region Prepare DataGrids

            PrepareDataGridViewLabBook();
            PrepareDataGridViewViscosity();
            PrepareDataGridViewContrast();
            PrepareDataGridViewNormResults();

            #endregion

            #region Prepare ComboBoxes

            ComboBox cClass = _form.GetComboContrastClass;
            cClass.DataSource = _cmbContrastClasses;
            cClass.ValueMember = "Id";
            cClass.DisplayMember = "Name";
            cClass.SelectedIndexChanged += CmbClass_SelectedIndexChanged;

            ComboBox yields = _form.GetComboContrastYield;
            yields.DataSource = _cmbContrastYields;
            yields.ValueMember = "Id";
            yields.DisplayMember = "Name";
            yields.SelectedIndexChanged += Yields_SelectedIndexChanged;

            ComboBox gloss = _form.GetComboGlossClass;
            gloss.DataSource = _cmbGlossClasses;
            gloss.ValueMember = "Id";
            gloss.DisplayMember = "Name";
            gloss.SelectedIndexChanged += Gloss_SelectedIndexChanged;

            ComboBox scrub = _form.GetComboScrubClass;
            scrub.DataSource = _cmbScrubClasses;
            scrub.ValueMember = "Id";
            scrub.DisplayMember = "Name";
            scrub.SelectedIndexChanged += Scrub_SelectedIndexChanged;

            #endregion

            #region Prepare others control

            _form.GetTxtTitle.DataBindings.Clear();
            _form.GetTxtObservation.DataBindings.Clear();
            _form.GetTxtRemarks.DataBindings.Clear();
            _form.GetTxtTitle.DataBindings.Add("Text", GetLabBookBinding, "Title");
            _form.GetTxtObservation.DataBindings.Add("Text", GetLabBookBinding, "Observation");
            _form.GetTxtRemarks.DataBindings.Add("Text", GetLabBookBinding, "Remarks");

            #endregion

            LabBookBinding_PositionChanged(null, null);
        }

        private void PrepareDataGridViewLabBook()
        {
            DataGridView view = _form.GetDgvLabBook;
            view.DataSource = _labBookBinding;
            view.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            view.RowsDefaultCellStyle.Font = new Font(view.DefaultCellStyle.Font.Name, 10, FontStyle.Regular);
            view.ColumnHeadersDefaultCellStyle.Font = new Font(view.DefaultCellStyle.Font.Name, 10, FontStyle.Bold);
            view.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            view.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            view.RowHeadersWidth = _form.isAdmin ? 35 : 40;
            view.DefaultCellStyle.ForeColor = Color.Black;
            view.MultiSelect = false;
            view.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            view.AutoGenerateColumns = false;

            view.Columns["UserId"].Visible = false;
            view.Columns["CycleId"].Visible = false;
            view.Columns["ProjectId"].Visible = false;
            view.Columns["Deleted"].Visible = false;
            view.Columns["User"].Visible = false;
            view.Columns.Remove("Observation");
            view.Columns.Remove("Remarks");
            view.Columns.Remove("Created");
            view.Columns.Remove("ExpContrastClass");
            view.Columns.Remove("ExpGlossClass");
            view.Columns.Remove("ExpScrubClass");

            view.Columns["Id"].HeaderText = "Nr D";
            view.Columns["Id"].ReadOnly = true;
            view.Columns["Id"].DisplayIndex = 0;
            view.Columns["Id"].Width = 70;
            view.Columns["Id"].SortMode = DataGridViewColumnSortMode.NotSortable;

            view.Columns["Title"].HeaderText = "Tytuł";
            view.Columns["Title"].ReadOnly = true;
            view.Columns["Title"].DisplayIndex = 1;
            view.Columns["Title"].SortMode = DataGridViewColumnSortMode.NotSortable;
            view.Columns["Title"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            view.Columns["Density"].HeaderText = "Gęstość";
            view.Columns["Density"].DisplayIndex = 2;
            view.Columns["Density"].Width = 95;
            view.Columns["Density"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            view.Columns["Density"].SortMode = DataGridViewColumnSortMode.NotSortable;

            view.Columns["UserInitial"].HeaderText = "User";
            view.Columns["UserInitial"].DisplayIndex = 3;
            view.Columns["UserInitial"].ReadOnly = true;
            view.Columns["UserInitial"].Width = 75;
            view.Columns["UserInitial"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            view.Columns["UserInitial"].SortMode = DataGridViewColumnSortMode.NotSortable;

            view.Columns["Modified"].HeaderText = "Modyfikacja";
            view.Columns["Modified"].DisplayIndex = 4;
            view.Columns["Modified"].ReadOnly = true;
            view.Columns["Modified"].Width = 120;
            view.Columns["Modified"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            view.Columns["Modified"].SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void PrepareDataGridViewViscosity()
        {
            DataGridView view = _form.GetDgvViscosity;
            view.DataSource = _viscosityBinding;
            view.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            view.RowsDefaultCellStyle.Font = new Font(view.DefaultCellStyle.Font.Name, 9, FontStyle.Regular);
            view.ColumnHeadersDefaultCellStyle.Font = new Font(view.DefaultCellStyle.Font.Name, 9, FontStyle.Bold);
            view.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            view.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            view.DefaultCellStyle.ForeColor = Color.Black;
            view.MultiSelect = false;
            view.SelectionMode = DataGridViewSelectionMode.CellSelect;
            view.AutoGenerateColumns = false;

            view.Columns["Id"].Visible = false;
            view.Columns["LabBookId"].Visible = false;
            view.Columns["DateUpdate"].Visible = false;
            view.Columns["VisType"].Visible = false;
            view.Columns["Added"].Visible = false;
            view.Columns.Remove("Modified");

            int displayIndex = 0;

            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.Name = deleteColumn;
            buttonColumn.HeaderText = "";
            buttonColumn.Text = "X";
            buttonColumn.FlatStyle = FlatStyle.Popup;
            buttonColumn.DefaultCellStyle.ForeColor = Color.Red;
            buttonColumn.DefaultCellStyle.BackColor = Color.LightGray;
            buttonColumn.UseColumnTextForButtonValue = true;
            buttonColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            buttonColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            buttonColumn.Resizable = DataGridViewTriState.False;
            buttonColumn.Width = 45;
            buttonColumn.DisplayIndex = displayIndex;
            buttonColumn.ToolTipText = "Usuń";
            view.Columns.Add(buttonColumn);

            view.Columns["DateCreated"].HeaderText = "Data";
            view.Columns["DateCreated"].DisplayIndex = ++displayIndex;
            view.Columns["DateCreated"].SortMode = DataGridViewColumnSortMode.NotSortable;
            view.Columns["DateCreated"].Width = 100;
            view.Columns["DateCreated"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            view.Columns["Days"].HeaderText = "Doba";
            view.Columns["Days"].ReadOnly = true;
            view.Columns["Days"].DisplayIndex = ++displayIndex;
            view.Columns["Days"].SortMode = DataGridViewColumnSortMode.NotSortable;
            view.Columns["Days"].Width = 80;
            view.Columns["Days"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            view.Columns["Temp"].HeaderText = "Temp.";
            view.Columns["Temp"].DisplayIndex = ++displayIndex;
            view.Columns["Temp"].SortMode = DataGridViewColumnSortMode.NotSortable;
            view.Columns["Temp"].Width = 80;
            view.Columns["Temp"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            view.Columns["PH"].HeaderText = "pH";
            view.Columns["PH"].DisplayIndex = ++displayIndex;
            view.Columns["PH"].SortMode = DataGridViewColumnSortMode.NotSortable;
            view.Columns["PH"].Width = 60;
            view.Columns["pH"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            view.Columns["Brook1"].HeaderText = "Lep 1";
            view.Columns["Brook1"].DisplayIndex = ++displayIndex;
            view.Columns["Brook1"].SortMode = DataGridViewColumnSortMode.NotSortable;
            view.Columns["Brook1"].Width = 100;
            view.Columns["Brook1"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            view.Columns["Brook5"].HeaderText = "Lep 5";
            view.Columns["Brook5"].DisplayIndex = ++displayIndex;
            view.Columns["Brook5"].SortMode = DataGridViewColumnSortMode.NotSortable;
            view.Columns["Brook5"].Width = 100;
            view.Columns["Brook5"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            view.Columns["Brook10"].HeaderText = "Lep 10";
            view.Columns["Brook10"].DisplayIndex = ++displayIndex;
            view.Columns["Brook10"].SortMode = DataGridViewColumnSortMode.NotSortable;
            view.Columns["Brook10"].Width = 100;
            view.Columns["Brook10"].Visible = false;
            view.Columns["Brook10"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            view.Columns["Brook20"].HeaderText = "Lep 20";
            view.Columns["Brook20"].DisplayIndex = ++displayIndex;
            view.Columns["Brook20"].SortMode = DataGridViewColumnSortMode.NotSortable;
            view.Columns["Brook20"].Width = 100;
            view.Columns["Brook20"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            view.Columns["Brook30"].HeaderText = "Lep 30";
            view.Columns["Brook30"].DisplayIndex = ++displayIndex;
            view.Columns["Brook30"].SortMode = DataGridViewColumnSortMode.NotSortable;
            view.Columns["Brook30"].Width = 100;
            view.Columns["Brook30"].Visible = false;
            view.Columns["Brook30"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            view.Columns["Brook40"].HeaderText = "Lep 40";
            view.Columns["Brook40"].DisplayIndex = ++displayIndex;
            view.Columns["Brook40"].SortMode = DataGridViewColumnSortMode.NotSortable;
            view.Columns["Brook40"].Width = 100;
            view.Columns["Brook40"].Visible = false;
            view.Columns["Brook40"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            view.Columns["Brook50"].HeaderText = "Lep 50";
            view.Columns["Brook50"].DisplayIndex = ++displayIndex;
            view.Columns["Brook50"].SortMode = DataGridViewColumnSortMode.NotSortable;
            view.Columns["Brook50"].Width = 100;
            view.Columns["Brook50"].Visible = false;
            view.Columns["Brook50"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            view.Columns["Brook60"].HeaderText = "Lep 60";
            view.Columns["Brook60"].DisplayIndex = ++displayIndex;
            view.Columns["Brook60"].SortMode = DataGridViewColumnSortMode.NotSortable;
            view.Columns["Brook60"].Width = 100;
            view.Columns["Brook60"].Visible = false;
            view.Columns["Brook60"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            view.Columns["Brook70"].HeaderText = "Lep 70";
            view.Columns["Brook70"].DisplayIndex = ++displayIndex;
            view.Columns["Brook70"].SortMode = DataGridViewColumnSortMode.NotSortable;
            view.Columns["Brook70"].Width = 100;
            view.Columns["Brook70"].Visible = false;
            view.Columns["Brook70"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            view.Columns["Brook80"].HeaderText = "Lep 80";
            view.Columns["Brook80"].DisplayIndex = ++displayIndex;
            view.Columns["Brook80"].SortMode = DataGridViewColumnSortMode.NotSortable;
            view.Columns["Brook80"].Width = 100;
            view.Columns["Brook80"].Visible = false;
            view.Columns["Brook80"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            view.Columns["Brook90"].HeaderText = "Lep 90";
            view.Columns["Brook90"].DisplayIndex = ++displayIndex;
            view.Columns["Brook90"].SortMode = DataGridViewColumnSortMode.NotSortable;
            view.Columns["Brook90"].Width = 100;
            view.Columns["Brook90"].Visible = false;
            view.Columns["Brook90"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            view.Columns["Brook100"].HeaderText = "Lep 100";
            view.Columns["Brook100"].DisplayIndex = ++displayIndex;
            view.Columns["Brook100"].SortMode = DataGridViewColumnSortMode.NotSortable;
            view.Columns["Brook100"].Width = 100;
            view.Columns["Brook100"].Visible = false;
            view.Columns["Brook100"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            view.Columns["BrookDisc"].HeaderText = "Dysk";
            view.Columns["BrookDisc"].DisplayIndex = ++displayIndex;
            view.Columns["BrookDisc"].SortMode = DataGridViewColumnSortMode.NotSortable;
            view.Columns["BrookDisc"].Width = 60;
            view.Columns["BrookDisc"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            view.Columns["BrookXVis"].HeaderText = "Lep X";
            view.Columns["BrookXVis"].DisplayIndex = ++displayIndex;
            view.Columns["BrookXVis"].SortMode = DataGridViewColumnSortMode.NotSortable;
            view.Columns["BrookXVis"].Width = 100;
            view.Columns["BrookXVis"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            view.Columns["BrookXRpm"].HeaderText = "Obr. X";
            view.Columns["BrookXRpm"].DisplayIndex = ++displayIndex;
            view.Columns["BrookXRpm"].SortMode = DataGridViewColumnSortMode.NotSortable;
            view.Columns["BrookXRpm"].Width = 100;
            view.Columns["BrookXRpm"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            view.Columns["BrookXDisc"].HeaderText = "Dysk X";
            view.Columns["BrookXDisc"].DisplayIndex = ++displayIndex;
            view.Columns["BrookXDisc"].SortMode = DataGridViewColumnSortMode.NotSortable;
            view.Columns["BrookXDisc"].Width = 70;
            view.Columns["BrookXDisc"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            view.Columns["BrookComment"].HeaderText = "Brookfield uwagi";
            view.Columns["BrookComment"].DisplayIndex = ++displayIndex;
            view.Columns["BrookComment"].SortMode = DataGridViewColumnSortMode.NotSortable;
            view.Columns["BrookComment"].Width = 200;
            view.Columns["BrookComment"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            view.Columns["Krebs"].HeaderText = "Krebs";
            view.Columns["Krebs"].DisplayIndex = ++displayIndex;
            view.Columns["Krebs"].SortMode = DataGridViewColumnSortMode.NotSortable;
            view.Columns["Krebs"].Width = 100;
            view.Columns["Krebs"].Visible = false;
            view.Columns["Krebs"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            view.Columns["KrebsComment"].HeaderText = "Krebs uwagi";
            view.Columns["KrebsComment"].DisplayIndex = ++displayIndex;
            view.Columns["KrebsComment"].SortMode = DataGridViewColumnSortMode.NotSortable;
            view.Columns["KrebsComment"].Width = 200;
            view.Columns["KrebsComment"].Visible = false;
            view.Columns["KrebsComment"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            view.Columns["Ici"].HeaderText = "Ici";
            view.Columns["Ici"].DisplayIndex = ++displayIndex;
            view.Columns["Ici"].SortMode = DataGridViewColumnSortMode.NotSortable;
            view.Columns["Ici"].Width = 60;
            view.Columns["Ici"].Visible = false;
            view.Columns["Ici"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            view.Columns["IciDisc"].HeaderText = "Ici dysk";
            view.Columns["IciDisc"].DisplayIndex = ++displayIndex;
            view.Columns["IciDisc"].SortMode = DataGridViewColumnSortMode.NotSortable;
            view.Columns["IciDisc"].Width = 80;
            view.Columns["IciDisc"].Visible = false;
            view.Columns["IciDisc"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            view.Columns["IciComment"].HeaderText = "Ici uwagi";
            view.Columns["IciComment"].DisplayIndex = ++displayIndex;
            view.Columns["IciComment"].SortMode = DataGridViewColumnSortMode.NotSortable;
            view.Columns["IciComment"].Width = 200;
            view.Columns["IciComment"].Visible = false;
            view.Columns["IciComment"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        }

        private void PrepareDataGridViewContrast()
        {
            DataGridView view = _form.GetDgvContrast;
            view.DataSource = _contrastBinding;
            view.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            view.RowsDefaultCellStyle.Font = new Font(view.DefaultCellStyle.Font.Name, 9, FontStyle.Regular);
            view.ColumnHeadersDefaultCellStyle.Font = new Font(view.DefaultCellStyle.Font.Name, 9, FontStyle.Bold);
            view.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            view.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            view.DefaultCellStyle.ForeColor = Color.Black;
            view.MultiSelect = false;
            view.SelectionMode = DataGridViewSelectionMode.CellSelect;
            view.AutoGenerateColumns = false;

            view.Columns["Id"].Visible = false;
            view.Columns["LabBookId"].Visible = false;
            view.Columns["DateUpdated"].Visible = false;
            view.Columns["Added"].Visible = false;
            view.Columns["Position"].Visible = false;
            view.Columns.Remove("Modified");
            view.Columns.Remove("ApplicatiorId");
            view.Columns.Remove("Applicator");

            int displayIndex = 0;

            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.Name = deleteColumn;
            buttonColumn.HeaderText = "";
            buttonColumn.Text = "X";
            buttonColumn.FlatStyle = FlatStyle.Popup;
            buttonColumn.DefaultCellStyle.ForeColor = Color.Red;
            buttonColumn.DefaultCellStyle.BackColor = Color.LightGray;
            buttonColumn.UseColumnTextForButtonValue = true;
            buttonColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            buttonColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            buttonColumn.Resizable = DataGridViewTriState.False;
            buttonColumn.Width = 45;
            buttonColumn.DisplayIndex = displayIndex;
            buttonColumn.ToolTipText = "Usuń";
            view.Columns.Add(buttonColumn);

            int width = view.Width - (view.RowHeadersWidth + view.Columns["Del"].Width);
            
            view.Columns["DateCreated"].HeaderText = "Data";
            view.Columns["DateCreated"].DisplayIndex = ++displayIndex;
            view.Columns["DateCreated"].SortMode = DataGridViewColumnSortMode.NotSortable;
            view.Columns["DateCreated"].Width = (int)(width * 0.1);
            view.Columns["DateCreated"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            view.Columns["Days"].HeaderText = "Doba";
            view.Columns["Days"].ReadOnly = true;
            view.Columns["Days"].DisplayIndex = ++displayIndex;
            view.Columns["Days"].SortMode = DataGridViewColumnSortMode.NotSortable;
            view.Columns["Days"].Width = (int)(width * 0.05);
            view.Columns["Days"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            view.Columns["ApplicatorName"].HeaderText = "Aplikator";
            view.Columns["ApplicatorName"].ReadOnly = true;
            view.Columns["ApplicatorName"].DisplayIndex = ++displayIndex;
            view.Columns["ApplicatorName"].SortMode = DataGridViewColumnSortMode.NotSortable;
            view.Columns["ApplicatorName"].Width = (int)(width * 0.15);
            view.Columns["ApplicatorName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            view.Columns["Substrate"].HeaderText = "Podłoże";
            view.Columns["Substrate"].DisplayIndex = ++displayIndex;
            view.Columns["Substrate"].SortMode = DataGridViewColumnSortMode.NotSortable;
            view.Columns["Substrate"].Width = (int)(width * 0.15);
            view.Columns["Substrate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            view.Columns["Contrast"].HeaderText = "Krycie";
            view.Columns["Contrast"].DisplayIndex = ++displayIndex;
            view.Columns["Contrast"].SortMode = DataGridViewColumnSortMode.NotSortable;
            view.Columns["Contrast"].Width = (int)(width * 0.1);
            view.Columns["Contrast"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            view.Columns["Tw"].HeaderText = "Tw";
            view.Columns["Tw"].DisplayIndex = ++displayIndex;
            view.Columns["Tw"].SortMode = DataGridViewColumnSortMode.NotSortable;
            view.Columns["Tw"].Width = (int)(width * 0.1);
            view.Columns["Tw"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            view.Columns["Sp"].HeaderText = "Sp";
            view.Columns["Sp"].DisplayIndex = ++displayIndex;
            view.Columns["Sp"].SortMode = DataGridViewColumnSortMode.NotSortable;
            view.Columns["Sp"].Width = (int)(width * 0.1);
            view.Columns["Sp"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            view.Columns["Comments"].HeaderText = "Uwagi";
            view.Columns["Comments"].DisplayIndex = ++displayIndex;
            view.Columns["Comments"].SortMode = DataGridViewColumnSortMode.NotSortable;
            view.Columns["Comments"].Width = (int)(width * 0.25);
            view.Columns["Comments"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        }

        private void PrepareDataGridViewNormResults()
        {
            DataGridView view = _form.GetDgvNormResultTab1;
            view.DataSource = _normResultBinding;
            view.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            view.RowsDefaultCellStyle.Font = new Font(view.DefaultCellStyle.Font.Name, 9, FontStyle.Regular);
            view.ColumnHeadersDefaultCellStyle.Font = new Font(view.DefaultCellStyle.Font.Name, 9, FontStyle.Bold);
            view.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            view.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            view.DefaultCellStyle.ForeColor = Color.Black;
            view.MultiSelect = false;
            view.SelectionMode = DataGridViewSelectionMode.CellSelect;
            view.AutoGenerateColumns = false;

            view.Columns["Id"].Visible = false;
            view.Columns["LabBookId"].Visible = false;
            view.Columns["DateUpdated"].Visible = false;
            view.Columns["Position"].Visible = false;
            view.Columns["PageNumber"].Visible = false;
            view.Columns["Added"].Visible = false;
            view.Columns.Remove("Modified");

            int displayIndex = 0;

            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.Name = deleteColumn;
            buttonColumn.HeaderText = "";
            buttonColumn.Text = "X";
            buttonColumn.FlatStyle = FlatStyle.Popup;
            buttonColumn.DefaultCellStyle.ForeColor = Color.Red;
            buttonColumn.DefaultCellStyle.BackColor = Color.LightGray;
            buttonColumn.UseColumnTextForButtonValue = true;
            buttonColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            buttonColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            buttonColumn.Resizable = DataGridViewTriState.False;
            buttonColumn.Width = 45;
            buttonColumn.DisplayIndex = displayIndex;
            buttonColumn.ToolTipText = "Usuń";
            view.Columns.Add(buttonColumn);

            view.Columns["DateCreated"].HeaderText = "Data";
            view.Columns["DateCreated"].DisplayIndex = ++displayIndex;
            view.Columns["DateCreated"].SortMode = DataGridViewColumnSortMode.NotSortable;
            view.Columns["DateCreated"].Width = 100;
            view.Columns["DateCreated"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            view.Columns["Days"].HeaderText = "Doba";
            view.Columns["Days"].ReadOnly = true;
            view.Columns["Days"].DisplayIndex = ++displayIndex;
            view.Columns["Days"].SortMode = DataGridViewColumnSortMode.NotSortable;
            view.Columns["Days"].Width = 80;
            view.Columns["Days"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            view.Columns["Description"].HeaderText = "Opis";
            view.Columns["Description"].DisplayIndex = ++displayIndex;
            view.Columns["Description"].SortMode = DataGridViewColumnSortMode.NotSortable;
            view.Columns["Description"].Width = 100;
            view.Columns["Description"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            view.Columns["Norm"].HeaderText = "Norma";
            view.Columns["Norm"].DisplayIndex = ++displayIndex;
            view.Columns["Norm"].SortMode = DataGridViewColumnSortMode.NotSortable;
            view.Columns["Norm"].Width = 100;
            view.Columns["Norm"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            view.Columns["Requirement"].HeaderText = "Wymogi";
            view.Columns["Requirement"].DisplayIndex = ++displayIndex;
            view.Columns["Requirement"].SortMode = DataGridViewColumnSortMode.NotSortable;
            view.Columns["Requirement"].Width = 100;
            view.Columns["Requirement"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            view.Columns["Result"].HeaderText = "Wynik";
            view.Columns["Result"].DisplayIndex = ++displayIndex;
            view.Columns["Result"].SortMode = DataGridViewColumnSortMode.NotSortable;
            view.Columns["Result"].Width = 100;
            view.Columns["Result"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            view.Columns["Substrate"].HeaderText = "Podłoże";
            view.Columns["Substrate"].DisplayIndex = ++displayIndex;
            view.Columns["Substrate"].SortMode = DataGridViewColumnSortMode.NotSortable;
            view.Columns["Substrate"].Width = 100;
            view.Columns["Substrate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            view.Columns["Comment"].HeaderText = "Uwagi";
            view.Columns["Comment"].DisplayIndex = ++displayIndex;
            view.Columns["Comment"].SortMode = DataGridViewColumnSortMode.NotSortable;
            view.Columns["Comment"].Width = 200;
            view.Columns["Comment"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        }

        private void PrepareApplicatorMenu()
        {
            ToolStripMenuItem menu = _form.GetApplicatorMenu;
            var applicators = GetCmbApplicators();

            foreach (CmbApplicator applicator in applicators)
            {
                ToolStripMenuItem newApp = new ToolStripMenuItem();
                newApp.Name = "ApplicatorToolStripMenuItem_" + applicator.Id.ToString();
                newApp.Text = applicator.Name;
                newApp.Tag = applicator.Id;
                newApp.Click += ApplicatorMenu_Click;
                menu.DropDownItems.Add(newApp);
            }
        }

        private void PrepareNormResultmenu()
        {
            ToolStripMenuItem menu = _form.GetNormMenu;
            var norms = GetNorms();

            long idEmpty = norms
                .Where(i => i.Description.Equals("Pusty"))
                .Select(i => i.Id)
                .FirstOrDefault();
            AddNewNormMenuItem(idEmpty, "-- Pusty --", menu, true);

            foreach (CmbNorm norm in norms)
            {
                if (norm.Description.Equals("Pusty"))
                    continue;
                
                switch(norm.Type)
                {
                    case "Korozja":
                        menu = _form.GetCorrosionMenu;
                        break;
                    case "Powłoka":
                        menu = _form.GetSurfaceMenu;
                        break;
                    case "Skład":
                        menu = _form.GetCompositionMenu;
                        break;
                    default:
                        menu = _form.GetDefaultMenu;
                        break;
                }

                AddNewNormMenuItem(norm.Id, norm.Description, menu, false);
            }
        }

        private void AddNewNormMenuItem(long id, string name, ToolStripMenuItem menu, bool isFirst)
        {
            ToolStripMenuItem newItem = new ToolStripMenuItem
            {
                Name = "NormToolStripItem_" + id,
                Text = name,
                Tag = id
            };
            newItem.Click += AddNormFromMenu_Click;

            if (isFirst)
                menu.DropDownItems.Insert(0, newItem);
            else
                menu.DropDownItems.Add(newItem);
        }

        #endregion

        #region Load Data from Database

        private IList<ExpLabBook> GetAllLabBook()
        {
            var list = _context.ExpLabBook
                .Include(x => x.User)
                .Include(x => x.ExpContrastClass).ThenInclude(y => y.CmbContrastClass)
                .Include(x => x.ExpContrastClass).ThenInclude(y => y.CmbContrastYield)
                .Include(x => x.ExpGlossClass).ThenInclude(y => y.CmbGlosClass)
                .Include(x => x.ExpScrubClass).ThenInclude(y => y.CmbScrubClass)
                .OrderBy(x => x.Id)
                .ToList();

            return new ObservableListSource<ExpLabBook>(list);
        }

        private IList<ExpViscosity> GetViscosities(long labbookId)
        {
            var list = _context.ExpViscosity
                .Where(i => i.LabBookId == labbookId)
                .ToList();

            //list.ForEach(i => i.Modified = false);

            return new ObservableListSource<ExpViscosity>(list);
        }

        private ViscosityFieldsType GetViscosityFields(long labbookId, long userId)
        {
            var list = _context.ExpViscosityFields
                .AsNoTracking()
                .Where(i => i.LabbookId == labbookId)
                .Where(i => i.UserId == userId)
                .ToList();

            ViscosityFieldsType type = ViscosityFieldsType.StdBrook;
            if (list.Count > 0)
            {
                switch (list[0].Name)
                {
                    case "PrbBrook":
                        type = ViscosityFieldsType.PrbBrook;
                        break;
                    case "FullBrok":
                        type = ViscosityFieldsType.FullBrok;
                        break;
                    case "StdBrookKrebs":
                        type = ViscosityFieldsType.StdBrookKrebs;
                        break;
                    case "StdBrookIci":
                        type = ViscosityFieldsType.StdBrookIci;
                        break;
                    default:
                        type = ViscosityFieldsType.StdBrook;
                        break;
                }
            }

            return type;
        }

        private IList<ExpContrast> GetContrasts(long labbookId)
        {
            var list = _context.ExpContrast
                .Where(i => i.LabBookId == labbookId)
                .Include(i => i.Applicator)
                .OrderBy(i => i.Position)
                .ToList();

            //list.ForEach(i => i.Modified = false);

            return new ObservableListSource<ExpContrast>(list);
        }

        private IList<ExpNormResult> GetNormResults(long labbookId)
        {
            var list = _context.ExpNormResult
                .Where(i => i.LabBookId == labbookId)
                .OrderBy(i => i.Position)
                .ToList();

            //list.ForEach(i => i.Modified = false);

            return new ObservableListSource<ExpNormResult>(list);
        }

        private IList<CmbApplicator> GetCmbApplicators()
        {
            return _context.CmbApplicator
                .AsNoTracking()
                .OrderBy(i => i.Number)
                .ToList();
        }

        private IList<CmbContrastClass> GetCmbContrastClasses()
        {
            return _context.CmbContrastClass
                .OrderBy(i => i.Id)
                .ToList();
        }

        private IList<CmbContrastYield> GetCmbContrastYields()
        {
            return _context.CmbContrastYield
                .OrderBy(i => i.Id)
                .ToList();
        }

        private IList<CmbGlosClass> GetCmbGlossClasses()
        {
            return _context.CmbGlosClass
                .OrderBy(i => i.Id)
                .ToList();
        }

        private IList<CmbScrubClass> GetCmbScrubClasses()
        {
            return _context.CmbScrubClass
                .OrderBy(i => i.Id)
                .ToList();
        }

        private IList<CmbGlosClass> GetGlossClasses()
        {
            return _context.CmbGlosClass
                .AsNoTracking()
                .OrderBy(i => i.Id)
                .ToList();
        }

        private IList<CmbNorm> GetNorms()
        {
            return _context.CmbNorm
                .AsNoTracking()
                .OrderBy(i => i.Description)
                .Include(i => i.CmbNormDetails)
                .ToList();
        }

        private ExpContrastClass GetContrastClass(long labbookId)
        {
            var cClass = _context.ExpContrastClass
                .Where(i => i.LabBookId == labbookId)
                .FirstOrDefault();

            return cClass;
        }

        private ExpGlossClass GetGlossClass(long labbookId)
        {
            var cClass = _context.ExpGlossClass
                .Where(i => i.LabBookId == labbookId)
                .FirstOrDefault();

            return cClass;
        }

        private IList<ExpNormResultTabs> GetNormResultTabs(long labbookId, long userId)
        {
            return _context.ExpNormResultTabs
                .AsNoTracking()
                .Where(i => i.LabBookId == labbookId)
                .Where(i => i.UserId == userId)
                .ToList();
        }

        private ExpNormResultTabs GetNormResultTabByTabIndex(long labbookId, long userId, int pageIndex)
        {
            return _context.ExpNormResultTabs
                .AsNoTracking()
                .Where(i => i.LabBookId == labbookId)
                .Where(i => i.UserId == userId)
                .Where(i => i.PageNumber == pageIndex)
                .FirstOrDefault();
        }

        #endregion

        #region Current

        private void LabBookBinding_PositionChanged(object sender, EventArgs e)
        {
            ExpLabBook currentLabBook = GetCurrentLabBook;
            _form.GetDgvContrast.EndEdit();
            _form.GetDgvViscosity.EndEdit();
            _viscosityBinding.EndEdit();
            _contrastBinding.EndEdit();

            if (currentLabBook != null)
            {
                _form.GetLblNrD.Text = "D " + currentLabBook.Id.ToString();
                _form.GetLblDate.Text = currentLabBook.Created.ToString("dd.MM.yyyy");

                _visRepository.QuickSaveViscosity(_viscosities);
                GetCurrentViscosity(currentLabBook.Id);
                PrepareCurrentField(currentLabBook.Id, currentLabBook.User.Id);

                _conRepository.QuickSaveContrast(_contrasts);
                GetCurrentContrast(currentLabBook.Id);

                _normRepository.QuickSaveResult(_normResults);
                GetCurrentNormResult(currentLabBook.Id);
                PrepareCurrentNormResultTabs(currentLabBook.Id, currentLabBook.User.Id);

                SetComboBoxes(currentLabBook);
                SetTextBoxes(currentLabBook);
            }
        }

        private void SetComboBoxes(ExpLabBook currentLabBook)
        {
            _blockCombBoxes = true;

            if (currentLabBook.ExpContrastClass != null)
            {
                _form.GetComboContrastClass.SelectedValue = currentLabBook.ExpContrastClass.CmbContrastClass.Id;
                _form.GetComboContrastYield.SelectedValue = currentLabBook.ExpContrastClass.CmbContrastYield.Id;
            }
            else
            {
                _form.GetComboContrastClass.SelectedIndex = 0;
                _form.GetComboContrastYield.SelectedIndex = 0;
            }

            if (currentLabBook.ExpGlossClass != null)
            {
                _form.GetComboGlossClass.SelectedValue = currentLabBook.ExpGlossClass.CmbGlosClass.Id;
            }
            else
            {
                _form.GetComboGlossClass.SelectedIndex = 0;
            }

            if (currentLabBook.ExpScrubClass != null)
            {
                _form.GetComboScrubClass.SelectedValue = currentLabBook.ExpScrubClass.CmbScrubClass.Id;
            }
            else
            {
                _form.GetComboScrubClass.SelectedIndex = 0;
            }

            _blockCombBoxes = false;
        }

        private void SetTextBoxes(ExpLabBook currentLabBook)
        {
            _blockCombBoxes = true;

            if (currentLabBook.ExpScrubClass != null)
            {
                _form.GetTxtSponge.Text = currentLabBook.ExpScrubClass.ScrubSponge;
                _form.GetTxtBrush.Text = currentLabBook.ExpScrubClass.ScrubBrush;
            }
            else
            {
                _form.GetTxtSponge.Text = "";
                _form.GetTxtBrush.Text = "";
            }

            _blockCombBoxes = false;
        }

        private void GetCurrentViscosity(long labbookId)
        {
            IList<ExpViscosity> tmplist = GetViscosities(labbookId);
            _viscosities.Clear();
            foreach (ExpViscosity vis in tmplist)
            {
                vis.Modified = false;
                _viscosities.Add(vis);
            }
        }

        private void PrepareCurrentField(long labbookId, long userId)
        {
            if (labbookId == 0) return;

            ViscosityFieldsType tmp = GetViscosityFields(labbookId, userId);
            if (tmp == _viscosityFields) return;

            _viscosityFields = tmp;
            DataGridViscosityColumnSizeChanged();
        }

        private void PrepareCurrentNormResultTabs(long labbookId, long userId)
        {
            if (labbookId == 0) return;

            IList<ExpNormResultTabs> expNormResultTabList = GetNormResultTabs(labbookId, userId);

            if (expNormResultTabList.Count == 0)
            {
                HideAllNormTabs();
            }
            else
            {
                IList<int> pageNumbers = expNormResultTabList.Select(i => i.PageNumber).ToList();
                var tabPages = _form.GetTabControlMain.TabPages;

                foreach(TabPages enumPage in Enum.GetValues(typeof(TabPages)))
                {
                    TabPage tabPage = GetTabPageByTab(enumPage);
                    if (pageNumbers.Contains((int)enumPage))
                    {
                        ExpNormResultTabs expNormResultTab = expNormResultTabList.FirstOrDefault(i => i.PageNumber == (int)enumPage);

                        if (expNormResultTab.TabVisibility)
                        {
                            tabPage.Text = expNormResultTab.TabHeaderName;
                            ShowOneTab(enumPage);
                        }
                        else
                        {
                            HideOneTab(enumPage);
                        }
                    }
                    else
                    {
                        HideOneTab(enumPage);
                    }
                }
            }
        }

        private void HideAllViscosityColumn(DataGridView grid)
        {
            foreach (DataGridViewColumn column in grid.Columns)
            {
                if (column.Name == deleteColumn || column.Name == "DateCreated" || column.Name == "PH" || column.Name == "Temp" 
                    || column.Name == "Days") continue;
                column.Visible = false;
            }
        }

        private void GetCurrentContrast(long labbookId)
        {
            IList<ExpContrast> tmplist = GetContrasts(labbookId);
            _contrasts.Clear();
            foreach (ExpContrast contrast in tmplist)
            {
                contrast.Modified = false;
                _contrasts.Add(contrast);
            }
        }

        private void GetCurrentNormResult(long labbookId)
        {
            IList<ExpNormResult> tmpList = GetNormResults(labbookId);
            _normResults.Clear();
            foreach (ExpNormResult result in tmpList)
            {
                result.Modified = false;
                _normResults.Add(result);
            }
        }

        #endregion

        #region TabControl and TabPage operation

        public void ShowOrHideResultTab(int pageIndex)
        {
            ExpNormResultTabs tab = GetFirstOrNewNormResultTab(pageIndex);
            if (tab == null) return;

            tab.TabVisibility = !tab.TabVisibility;

            if (tab.TabVisibility)
                ShowOneTab((TabPages)pageIndex);
            else
                HideOneTab((TabPages)pageIndex);

            SaveTabPageSettings(pageIndex, tab.TabHeaderName);
        }

        private void HideAllNormTabs()
        {
            HideOneTab(TabPages.One);
            HideOneTab(TabPages.Two);
            HideOneTab(TabPages.Three);
            HideOneTab(TabPages.Four);
        }

        private void HideOneTab(TabPages tab)
        {
            TabPage tabPage;

            switch(tab)
            {
                case TabPages.Two:
                    tabPage = _form.GetTabPageResult2;
                    _form.GetTabResult2Menu.Checked = false;
                    break;
                case TabPages.Three:
                    tabPage = _form.GetTabPageResult3;
                    _form.GetTabResult3Menu.Checked = false;
                    break;
                case TabPages.Four:
                    tabPage = _form.GetTabPageResult4;
                    _form.GetTabResult4Menu.Checked = false;
                    break;
                default:
                    tabPage = _form.GetTabPageResult1;
                    _form.GetTabResult1Menu.Checked = false;
                    break;
            }

            if (_form.GetTabControlMain.TabPages.Contains(tabPage))
            {
                tabPage.Hide();
                _form.GetTabControlMain.TabPages.Remove(tabPage);
            }
        }

        private void ShowOneTab(TabPages tab)
        {
            TabPage tabPage;
            int index = _form.GetTabControlMain.TabPages.Count;

            switch (tab)
            {
                case TabPages.Two:
                    tabPage = _form.GetTabPageResult2;
                    _form.GetTabResult2Menu.Checked = true;
                    break;
                case TabPages.Three:
                    tabPage = _form.GetTabPageResult3;
                    _form.GetTabResult3Menu.Checked = true;
                    break;
                case TabPages.Four:
                    tabPage = _form.GetTabPageResult4;
                    _form.GetTabResult4Menu.Checked = true;
                    break;
                default:
                    tabPage = _form.GetTabPageResult1;
                    _form.GetTabResult1Menu.Checked = true;
                    break;
            }

            if (!_form.GetTabControlMain.TabPages.Contains(tabPage))
            {
                _form.GetTabControlMain.TabPages.Insert(index, tabPage);
                tabPage.Show();
            }

        }

        private TabPage GetTabPageByTab(TabPages tab)
        {
            switch (tab)
            {
                case TabPages.Two:
                    return _form.GetTabPageResult2;
                case TabPages.Three:
                    return _form.GetTabPageResult3;
                case TabPages.Four:
                    return _form.GetTabPageResult4;
                default:
                    return _form.GetTabPageResult1;
            }
        }

        private ExpNormResultTabs GetFirstOrNewNormResultTab(int pageIndex)
        {
            ExpLabBook currentLabBook = GetCurrentLabBook;
            if (currentLabBook == null) return null;

            return GetNormResultTabByTabIndex(currentLabBook.Id, currentLabBook.UserId, pageIndex)
                ?? new ExpNormResultTabs(currentLabBook.Id, currentLabBook.UserId, pageIndex, true, "Wyniki " + pageIndex);
        }

        private void SetNewTabName(string name)
        {
            var tag = _form.GetTabControlMain.SelectedTab.Tag;
            if (tag != null && !tag.ToString().Equals("-1"))
                _form.GetTabControlMain.SelectedTab.Text = name;
        }

        public void ChangeTabPageName(int pageIndex)
        {
            var name = "";
            if (DialogBox.InputBox("Zmiana nazwy", "Podaj nową nazwę dla zakładki", ref name) != DialogResult.OK) return;

            if (string.IsNullOrEmpty(name)) return;

            SaveTabPageSettings(pageIndex, name);
        }

        public void InsertNormResultTest(string normTest, int pageNumber)
        {
            int position = _normResults.Count + 1;
            ExpLabBook currentLabBook = GetCurrentLabBook;
            if (currentLabBook == null) return;

            NormDto normDto = _normService.GetNormResult(currentLabBook.Id, position, pageNumber, normTest);

            if (!string.IsNullOrEmpty(normDto.TabName))
            {
                SaveTabPageSettings(pageNumber, normDto.TabName);
            }


            foreach (ExpNormResult expNormResult in normDto.NormList)
            {
                _normResults.Add(expNormResult);
            }
        }

        #endregion

        #region DataGridView and Others Events

        public void DefaultvaluesNeededForVoscosity(DataGridViewRowEventArgs e)
        {
            ExpLabBook currentLabBook = GetCurrentLabBook;

            e.Row.Cells["LabBookId"].Value = currentLabBook.Id;
            e.Row.Cells["DateCreated"].Value = DateTime.Today;
            e.Row.Cells["DateUpdate"].Value = DateTime.Today;
            e.Row.Cells["Added"].Value = true;
            e.Row.Cells["VisType"].Value = "brookfield";
            e.Row.Cells["Temp"].Value = "20oC";
        }
        
        public void IconInCellPainting(DataGridViewRowPostPaintEventArgs e)
        {
            int start = e.RowBounds.Left + 25;
            int width = 4;
            User user = (User)_form.GetDgvLabBook.Rows[e.RowIndex].Cells["User"].Value;
            if (_user.Id != user.Id)
            {
                Rectangle rectangleTop = new Rectangle(start, e.RowBounds.Top + 4, width, e.RowBounds.Height - 14);
                Rectangle rectangleBottom = new Rectangle(start, e.RowBounds.Top + e.RowBounds.Height - 8, width, 4);
                e.Graphics.FillRectangle(redBrush, rectangleTop);
                e.Graphics.FillRectangle(redBrush, rectangleBottom);
            }
        }

        public void CellContentClickForViscosityButton(long id, DataGridViewCellEventArgs e)
        {
            if (id > 0)
            {
                var entity = _viscosities.Where(i => i.Id == id).FirstOrDefault();
                if (entity != null)
                {
                    _context.Entry(entity).State = EntityState.Detached;
                }

                _visRepository.DeleteViscosityById(id);
            }
            _viscosities.RemoveAt(e.RowIndex);
        }

        public void CellContentClickForContrastButton(long id, DataGridViewCellEventArgs e)
        {
            if (id > 0)
            {
                var entity = _contrasts.Where(i => i.Id == id).FirstOrDefault();
                if (entity != null)
                {
                    _context.Entry(entity).State = EntityState.Detached;
                }

                _conRepository.QuickDeleteById(id);
            }
            _contrasts.RemoveAt(e.RowIndex);
        }

        public void CellContentClickForNormButton(long id, DataGridViewCellEventArgs e)
        {
            if (id > 0)
            {
                var entity = _normResults.Where(i => i.Id == id).FirstOrDefault();
                if (entity != null)
                {
                    _context.Entry(entity).State = EntityState.Detached;
                }

                _normRepository.QuickDeleteById(id);
            }
            _normResults.RemoveAt(e.RowIndex);
        }

        public void DataGridViscosityColumnSizeChanged()
        {
            DataGridView grid = _form.GetDgvViscosity;

            HideAllViscosityColumn(grid);
            int width = grid.Width - (grid.RowHeadersWidth + grid.Columns["Del"].Width + grid.Columns["DateCreated"].Width + grid.Columns["Days"].Width);
            switch (_viscosityFields)
            {
                case ViscosityFieldsType.PrbBrook:
                    {
                        grid.Columns["Brook1"].Visible = true;
                        grid.Columns["Brook5"].Visible = true;
                        grid.Columns["Brook10"].Visible = true;
                        grid.Columns["Brook20"].Visible = true;
                        grid.Columns["Brook50"].Visible = true;
                        grid.Columns["Brook100"].Visible = true;
                        grid.Columns["BrookDisc"].Visible = true;
                        grid.Columns["BrookComment"].Visible = true;

                        grid.Columns["PH"].Width = (int)(width * 0.05);
                        grid.Columns["Temp"].Width = (int)(width * 0.05);
                        grid.Columns["Brook1"].Width = (int)(width * 0.1);
                        grid.Columns["Brook5"].Width = (int)(width * 0.1);
                        grid.Columns["Brook10"].Width = (int)(width * 0.1);
                        grid.Columns["Brook20"].Width = (int)(width * 0.1);
                        grid.Columns["Brook50"].Width = (int)(width * 0.1);
                        grid.Columns["Brook100"].Width = (int)(width * 0.1);
                        grid.Columns["BrookDisc"].Width = (int)(width * 0.08);
                        grid.Columns["BrookComment"].Width = (int)(width * 0.22);
                    }
                    break;
                case ViscosityFieldsType.FullBrok:
                    {
                        grid.Columns["Brook1"].Visible = true;
                        grid.Columns["Brook5"].Visible = true;
                        grid.Columns["Brook10"].Visible = true;
                        grid.Columns["Brook20"].Visible = true;
                        grid.Columns["Brook30"].Visible = true;
                        grid.Columns["Brook40"].Visible = true;
                        grid.Columns["Brook50"].Visible = true;
                        grid.Columns["Brook60"].Visible = true;
                        grid.Columns["Brook70"].Visible = true;
                        grid.Columns["Brook80"].Visible = true;
                        grid.Columns["Brook90"].Visible = true;
                        grid.Columns["Brook100"].Visible = true;
                        grid.Columns["BrookDisc"].Visible = true;
                        grid.Columns["BrookComment"].Visible = true;

                        grid.Columns["PH"].Width = (int)(width * 0.05);
                        grid.Columns["Temp"].Width = (int)(width * 0.05);
                        grid.Columns["Brook1"].Width = (int)(width * 0.05);
                        grid.Columns["Brook5"].Width = (int)(width * 0.05);
                        grid.Columns["Brook10"].Width = (int)(width * 0.05);
                        grid.Columns["Brook20"].Width = (int)(width * 0.05);
                        grid.Columns["Brook30"].Width = (int)(width * 0.05);
                        grid.Columns["Brook40"].Width = (int)(width * 0.05);
                        grid.Columns["Brook50"].Width = (int)(width * 0.05);
                        grid.Columns["Brook60"].Width = (int)(width * 0.05);
                        grid.Columns["Brook70"].Width = (int)(width * 0.05);
                        grid.Columns["Brook80"].Width = (int)(width * 0.05);
                        grid.Columns["Brook90"].Width = (int)(width * 0.05);
                        grid.Columns["Brook100"].Width = (int)(width * 0.05);
                        grid.Columns["BrookDisc"].Width = (int)(width * 0.08);
                        grid.Columns["BrookComment"].Width = (int)(width * 0.22);
                    }
                    break;
                case ViscosityFieldsType.StdBrookKrebs:
                    {
                        grid.Columns["Brook1"].Visible = true;
                        grid.Columns["Brook5"].Visible = true;
                        grid.Columns["Brook20"].Visible = true;
                        grid.Columns["BrookDisc"].Visible = true;
                        grid.Columns["Krebs"].Visible = true;
                        grid.Columns["KrebsComment"].Visible = true;
                        grid.Columns["BrookComment"].Visible = true;

                        grid.Columns["PH"].Width = (int)(width * 0.05);
                        grid.Columns["Temp"].Width = (int)(width * 0.05);
                        grid.Columns["Brook1"].Width = (int)(width * 0.1);
                        grid.Columns["Brook5"].Width = (int)(width * 0.1);
                        grid.Columns["Brook20"].Width = (int)(width * 0.1);
                        grid.Columns["BrookDisc"].Width = (int)(width * 0.08);
                        grid.Columns["Krebs"].Width = (int)(width * 0.1);
                        grid.Columns["KrebsComment"].Width = (int)(width * 0.2);
                        grid.Columns["BrookComment"].Width = (int)(width * 0.22);
                    }
                    break;
                case ViscosityFieldsType.StdBrookIci:
                    {
                        grid.Columns["Brook1"].Visible = true;
                        grid.Columns["Brook5"].Visible = true;
                        grid.Columns["Brook20"].Visible = true;
                        grid.Columns["BrookDisc"].Visible = true;
                        grid.Columns["Ici"].Visible = true;
                        grid.Columns["IciDisc"].Visible = true;
                        grid.Columns["IciComment"].Visible = true;
                        grid.Columns["BrookComment"].Visible = true;

                        grid.Columns["PH"].Width = (int)(width * 0.05);
                        grid.Columns["Temp"].Width = (int)(width * 0.05);
                        grid.Columns["Brook1"].Width = (int)(width * 0.1);
                        grid.Columns["Brook5"].Width = (int)(width * 0.1);
                        grid.Columns["Brook20"].Width = (int)(width * 0.1);
                        grid.Columns["BrookDisc"].Width = (int)(width * 0.08);
                        grid.Columns["Ici"].Width = (int)(width * 0.1);
                        grid.Columns["IciDisc"].Width = (int)(width * 0.08);
                        grid.Columns["IciComment"].Width = (int)(width * 0.14);
                        grid.Columns["BrookComment"].Width = (int)(width * 0.2);
                    }
                    break;
                default:
                    {
                        grid.Columns["Brook1"].Visible = true;
                        grid.Columns["Brook5"].Visible = true;
                        grid.Columns["Brook20"].Visible = true;
                        grid.Columns["BrookDisc"].Visible = true;
                        grid.Columns["BrookXVis"].Visible = true;
                        grid.Columns["BrookXRpm"].Visible = true;
                        grid.Columns["BrookXDisc"].Visible = true;
                        grid.Columns["BrookComment"].Visible = true;

                        grid.Columns["PH"].Width = (int)(width * 0.05);
                        grid.Columns["Temp"].Width = (int)(width * 0.05);
                        grid.Columns["Brook1"].Width = (int)(width * 0.1);
                        grid.Columns["Brook5"].Width = (int)(width * 0.1);
                        grid.Columns["Brook20"].Width = (int)(width * 0.1);
                        grid.Columns["BrookDisc"].Width = (int)(width * 0.08);
                        grid.Columns["BrookXVis"].Width = (int)(width * 0.1);
                        grid.Columns["BrookXRpm"].Width = (int)(width * 0.1);
                        grid.Columns["BrookXDisc"].Width = (int)(width * 0.1);
                        grid.Columns["BrookComment"].Width = (int)(width * 0.22);
                    }
                    break;
            }
        }

        public void DataGridContrastColumnSizeChanged()
        {
            DataGridView view = _form.GetDgvContrast;
            int width = view.Width - (view.RowHeadersWidth + view.Columns["Del"].Width);

            view.Columns["DateCreated"].Width = (int)(width * 0.1);
            view.Columns["Days"].Width = (int)(width * 0.08);
            view.Columns["ApplicatorName"].Width = (int)(width * 0.12);
            view.Columns["Substrate"].Width = (int)(width * 0.12);
            view.Columns["Contrast"].Width = (int)(width * 0.1);
            view.Columns["Tw"].Width = (int)(width * 0.1);
            view.Columns["Sp"].Width = (int)(width * 0.1);
            view.Columns["Comments"].Width = (int)(width * 0.28);
        }

        public void DataGridResultsColumnSizeChanged(DataGridView dataGridView)
        {
            int width = dataGridView.Width - (dataGridView.RowHeadersWidth + dataGridView.Columns["Del"].Width);

            dataGridView.Columns["DateCreated"].Width = (int)(width * 0.07);
            dataGridView.Columns["Days"].Width = (int)(width * 0.05);
            dataGridView.Columns["Description"].Width = (int)(width * 0.15);
            dataGridView.Columns["Norm"].Width = (int)(width * 0.1);
            dataGridView.Columns["Requirement"].Width = (int)(width * 0.1);
            dataGridView.Columns["Result"].Width = (int)(width * 0.19);
            dataGridView.Columns["Substrate"].Width = (int)(width * 0.1);
            dataGridView.Columns["Comment"].Width = (int)(width * 0.24);
        }

        public void DataGridNormResultHideRows(DataGridView dataGridView)
        {
            string tagIndex = dataGridView.Tag.ToString();
            if (string.IsNullOrEmpty(tagIndex)) return;

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                string cellIndex = row.Cells["PageNumber"].Value.ToString();
                if (!cellIndex.Equals(tagIndex))
                {
                    row.Visible = false;
                }
            }
        }

        public void ViscosityFieldVisibilityItem(int value)
        {
            ViscosityFieldsType type;

            switch(value)
            {
                case 1:
                    type = ViscosityFieldsType.StdBrook;
                    break;
                case 2:
                    type = ViscosityFieldsType.PrbBrook;
                    break;
                case 3:
                    type = ViscosityFieldsType.FullBrok;
                    break;
                case 4:
                    type = ViscosityFieldsType.StdBrookKrebs;
                    break;
                case 5:
                    type = ViscosityFieldsType.StdBrookIci;
                    break;
                default:
                    type = ViscosityFieldsType.StdBrook;
                    break;
            }

            if (type != _viscosityFields)
            {
                _viscosityFields = type;
                DataGridViscosityColumnSizeChanged();
                _visRepository.QuickSaveViscosityFields(type.ToString(), GetCurrentLabBook.Id, _user.Id);
            }
        }

        private void ApplicatorMenu_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem applicator = (ToolStripMenuItem)sender;
            long id = long.Parse(applicator.Tag.ToString());
            string name = applicator.Text;
            CmbApplicator cmbApplicator = _context.CmbApplicator
                .Where(i => i.Id == id)
                .FirstOrDefault();

            ExpContrast contrast = new ExpContrast();
            contrast.LabBookId = GetCurrentLabBook.Id;
            contrast.ApplicatiorId = id;
            contrast.Applicator = cmbApplicator;
            contrast.Substrate = contrastSubstrate;
            contrast.DateCreated = DateTime.Today;
            contrast.DateUpdated = DateTime.Today;
            contrast.Position = _contrasts.Count > 0 ? _contrasts.Max(i => i.Position) + 1 : 1;
            contrast.Modified = false;

            _contrasts.Add(contrast);
        }
       
        private void AddNormFromMenu_Click(object sender, EventArgs e)
        {

        }
        private void CmbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_blockCombBoxes) return;

            ExpLabBook currentLabBook = GetCurrentLabBook;
            if (currentLabBook == null) return;

            ExpContrastClass contrastClass = currentLabBook.ExpContrastClass;
            if (contrastClass != null)
            {
                CmbContrastClass cmbClass = (CmbContrastClass)_form.GetComboContrastClass.SelectedItem ?? _cmbContrastClasses[0];
                contrastClass.CmbContrastClass = cmbClass;
                contrastClass.ClassId = cmbClass.Id;
            }
            else
            {
                AddNewExpContrastClass(currentLabBook);
            }
        }

        private void Yields_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_blockCombBoxes) return;

            ExpLabBook currentLabBook = GetCurrentLabBook;
            if (currentLabBook == null) return;

            ExpContrastClass contrastClass = currentLabBook.ExpContrastClass;
            if (contrastClass != null)
            {
                CmbContrastYield cmbYield = (CmbContrastYield)_form.GetComboContrastYield.SelectedItem ?? _cmbContrastYields[0];
                contrastClass.CmbContrastYield = cmbYield;
                contrastClass.YieldId = cmbYield.Id;
            }
            else
            {
                AddNewExpContrastClass(currentLabBook);
            }
        }

        private void Gloss_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_blockCombBoxes) return;

            ExpLabBook currentLabBook = GetCurrentLabBook;
            if (currentLabBook == null) return;

            ExpGlossClass glossClass = currentLabBook.ExpGlossClass;
            if (glossClass != null)
            {
                CmbGlosClass cmbGlosClass = (CmbGlosClass)_form.GetComboGlossClass.SelectedItem ?? _cmbGlossClasses[0];
                glossClass.CmbGlosClass = cmbGlosClass;
                glossClass.ClassId = cmbGlosClass.Id;
            }
            else
            {
                AddNewExpGlossClass(currentLabBook);
            }
        }

        private void Scrub_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_blockCombBoxes) return;

            ExpLabBook currentLabBook = GetCurrentLabBook;
            if (currentLabBook == null) return;

            ExpScrubClass scrubClass = currentLabBook.ExpScrubClass;
            if (scrubClass != null)
            {
                CmbScrubClass cmbScrubClass = (CmbScrubClass)_form.GetComboScrubClass.SelectedItem ?? _cmbScrubClasses[0];
                scrubClass.CmbScrubClass = cmbScrubClass;
                scrubClass.ClassId = cmbScrubClass.Id;
            }
            else
            {
                AddNewExpScrubClass(currentLabBook, _form.GetTxtSponge.Text, _form.GetTxtBrush.Text);
            }
        }

        public void TxtSponge_Validating(string sponge, string brush)
        {
            if (_blockCombBoxes) return;

            ExpLabBook currentLabBook = GetCurrentLabBook;
            if (currentLabBook == null) return;

            ExpScrubClass scrubClass = currentLabBook.ExpScrubClass;
            if (scrubClass != null)
            {
                scrubClass.ScrubSponge = sponge;
                scrubClass.ScrubBrush = brush;
            }
            else
            {
                AddNewExpScrubClass(currentLabBook, sponge, brush);
            }
        }

        #endregion

        #region New Items

        private void AddNewExpContrastClass(ExpLabBook labBook)
        {
            ExpContrastClass contrastClass = new ExpContrastClass();
            CmbContrastClass cmbClass = (CmbContrastClass)_form.GetComboContrastClass.SelectedItem ?? _cmbContrastClasses[0];
            CmbContrastYield cmbYield = (CmbContrastYield)_form.GetComboContrastYield.SelectedItem ?? _cmbContrastYields[0];

            contrastClass.CmbContrastClass = cmbClass;
            contrastClass.ClassId = cmbClass.Id;
            contrastClass.CmbContrastYield = cmbYield;
            contrastClass.YieldId = cmbYield.Id;
            contrastClass.ExpLabBook = labBook;
            contrastClass.LabBookId = labBook.Id;
            labBook.ExpContrastClass = contrastClass;

            _context.ExpContrastClass.Add(contrastClass);
        }

        private void AddNewExpGlossClass(ExpLabBook labBook)
        {
            ExpGlossClass glossClass = new ExpGlossClass();
            CmbGlosClass cmbGlosClass = (CmbGlosClass)_form.GetComboGlossClass.SelectedItem ?? _cmbGlossClasses[0];

            glossClass.CmbGlosClass = cmbGlosClass;
            glossClass.ClassId = cmbGlosClass.Id;
            glossClass.ExpLabBook = labBook;
            glossClass.LabBookId = labBook.Id;
            labBook.ExpGlossClass = glossClass;

            _context.ExpGlossClass.Add(glossClass);
        }

        private void AddNewExpScrubClass(ExpLabBook labBook, string sponge, string brush)
        {
            ExpScrubClass scrubClass = new ExpScrubClass();
            CmbScrubClass cmbScrubClass = (CmbScrubClass)_form.GetComboScrubClass.SelectedItem ?? _cmbScrubClasses[0];

            scrubClass.CmbScrubClass = cmbScrubClass;
            scrubClass.ClassId = cmbScrubClass.Id;
            scrubClass.ExpLabBook = labBook;
            scrubClass.LabBookId = labBook.Id;

            _context.ExpScrubClass.Add(scrubClass);
        }

        #endregion

        #region Save, Update, Delete

        public void Save()
        {
            _form.GetDgvLabBook.EndEdit();
            _form.GetDgvViscosity.EndEdit();
            _form.GetDgvContrast.EndEdit();
            _labBookBinding.EndEdit();
            _viscosityBinding.EndEdit();
            _contrastBinding.EndEdit();

            foreach (ExpViscosity viscosity in _viscosities)
            {
                if (viscosity.Added)
                {
                    viscosity.Added = false;
                    _context.ExpViscosity.Add(viscosity);
                }
                viscosity.Modified = false;
            }

            foreach (ExpContrast contrast in _contrasts)
            {
                if (contrast.Added)
                {
                    contrast.Added = false;
                    _context.ExpContrast.Add(contrast);
                }
                contrast.Modified = false;
            }

            _context.SaveChanges();
        }

        private void SaveTabPageSettings(int pageIndex, string name)
        {
            ExpNormResultTabs tab = GetFirstOrNewNormResultTab(pageIndex);
            if (tab == null) return;

            tab.TabHeaderName = name;
            SetNewTabName(name);

            if (tab.Id > 0)
                _normRepository.QuickUpdateTabsData(tab);
            else
                _normRepository.QuickSaveTabsData(tab);
        }

        #endregion

        #region Save and Load data form LabBook form

        public void SaveFormData(Form form)
        {
            List<double> list = new List<double>
            {
                form.Left,
                form.Top,
                form.Width,
                form.Height,
            };
            CommonFunctions.WriteWindowsData(list, dataFormFileName);
        }

        public void LoadFormData(Form form)
        {
            List<double> list = CommonFunctions.LoadWindowsData(dataFormFileName);

            if (list.Count == 4)
            {
                form.Left = (int)list[0];
                form.Top = (int)list[1];
                form.Width = (int)list[2];
                form.Height = (int)list[3];
            }
        }

        #endregion
    }
}