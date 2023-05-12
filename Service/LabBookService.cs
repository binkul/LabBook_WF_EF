using LabBook_WF_EF.Commons;
using LabBook_WF_EF.Dto;
using LabBook_WF_EF.EntityModels;
using LabBook_WF_EF.Forms.LabBook;
using LabBook_WF_EF.Properties;
using LabBook_WF_EF.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace LabBook_WF_EF.Service
{
    public class LabBookService
    {
        private static readonly string dataFormFileName = "LabBookForm";
        private static readonly Image noImg = Resources._lock;
        private static readonly Image img = Resources.Ok_icon1;
        private static readonly Image noAccess = noImg.GetThumbnailImage(18, 18, null, System.IntPtr.Zero);
        private static readonly Image access = img.GetThumbnailImage(18, 18, null, System.IntPtr.Zero);
        private static readonly SolidBrush redBrush = new SolidBrush(Color.Red);

        private readonly LabBookForm _form;
        private readonly LabBookContext _context;
        private readonly ExpViscosityRepository _visRepository = new ExpViscosityRepository();
        private readonly UserDto _user;

        private ObservableListSource<ExpLabBook> _labBook;
        private BindingSource _labBookBinding;
        private ObservableListSource<ExpViscosity> _viscosities;
        //private ObservableListSource<ExpViscosityAdo> _viscosities;
        private BindingSource _viscosityBinding;

        public LabBookService(LabBookForm form, LabBookContext context, UserDto user)
        {
            _form = form;
            _context = context;
            _user = user;
        }

        public BindingSource GetLabBookBinding => _labBookBinding;
        public ExpLabBook GetCurrentLabBook => (ExpLabBook)_labBookBinding.Current;

        #region Prepare all data

        public void PrepareData()
        {
            _labBook = GetAllLabBook();
            _labBookBinding = new BindingSource { DataSource = _labBook };
            _labBookBinding.PositionChanged += LabBookBinding_PositionChanged;

            _viscosities = GetViscosities(0); // new ObservableListSource<ExpViscosityAdo>(_visRepository.GetViscosityByLabBookId(0));
            _viscosityBinding = new BindingSource { DataSource = _viscosities };

            #region Prepare DataGrids

            PrepareDataGridViewLabBook();
            PrepareDataGridViewViscosity();

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
            //view.Columns.Remove("Modified");
            view.Columns.Remove("ActualState");

            view.Columns["DateCreated"].HeaderText = "Pomiar";
            view.Columns["DateCreated"].ReadOnly = true;
            view.Columns["DateCreated"].DisplayIndex = 0;
            view.Columns["DateCreated"].SortMode = DataGridViewColumnSortMode.NotSortable;
            view.Columns["DateCreated"].Width = 100;
            view.Columns["DateCreated"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //view.Columns["pH"].HeaderText = "pH";
            //view.Columns["pH"].DisplayIndex = 1;
            //view.Columns["pH"].SortMode = DataGridViewColumnSortMode.NotSortable;
            //view.Columns["pH"].Width = 60;
            //view.Columns["pH"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            view.Columns["PH"].HeaderText = "pH";
            view.Columns["PH"].DisplayIndex = 1;
            view.Columns["PH"].SortMode = DataGridViewColumnSortMode.NotSortable;
            view.Columns["PH"].Width = 60;
            view.Columns["pH"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            view.Columns["Brook1"].HeaderText = "Lep 1";
            view.Columns["Brook1"].DisplayIndex = 2;
            view.Columns["Brook1"].SortMode = DataGridViewColumnSortMode.NotSortable;
            view.Columns["Brook1"].Width = 100;
            view.Columns["Brook1"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            view.Columns["Brook5"].HeaderText = "Lep 5";
            view.Columns["Brook5"].DisplayIndex = 3;
            view.Columns["Brook5"].SortMode = DataGridViewColumnSortMode.NotSortable;
            view.Columns["Brook5"].Width = 100;
            view.Columns["Brook5"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            view.Columns["Brook10"].HeaderText = "Lep 10";
            view.Columns["Brook10"].DisplayIndex = 4;
            view.Columns["Brook10"].SortMode = DataGridViewColumnSortMode.NotSortable;
            view.Columns["Brook10"].Width = 100;
            view.Columns["Brook10"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            view.Columns["Brook20"].HeaderText = "Lep 20";
            view.Columns["Brook20"].DisplayIndex = 5;
            view.Columns["Brook20"].SortMode = DataGridViewColumnSortMode.NotSortable;
            view.Columns["Brook20"].Width = 100;
            view.Columns["Brook20"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            view.Columns["Brook30"].HeaderText = "Lep 30";
            view.Columns["Brook30"].DisplayIndex = 6;
            view.Columns["Brook30"].SortMode = DataGridViewColumnSortMode.NotSortable;
            view.Columns["Brook30"].Width = 100;
            view.Columns["Brook30"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            view.Columns["Brook40"].HeaderText = "Lep 40";
            view.Columns["Brook40"].DisplayIndex = 7;
            view.Columns["Brook40"].SortMode = DataGridViewColumnSortMode.NotSortable;
            view.Columns["Brook40"].Width = 100;
            view.Columns["Brook40"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            view.Columns["Brook50"].HeaderText = "Lep 50";
            view.Columns["Brook50"].DisplayIndex = 8;
            view.Columns["Brook50"].SortMode = DataGridViewColumnSortMode.NotSortable;
            view.Columns["Brook50"].Width = 100;
            view.Columns["Brook50"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            view.Columns["Brook60"].HeaderText = "Lep 60";
            view.Columns["Brook60"].DisplayIndex = 9;
            view.Columns["Brook60"].SortMode = DataGridViewColumnSortMode.NotSortable;
            view.Columns["Brook60"].Width = 100;
            view.Columns["Brook60"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            view.Columns["Brook70"].HeaderText = "Lep 70";
            view.Columns["Brook70"].DisplayIndex = 10;
            view.Columns["Brook70"].SortMode = DataGridViewColumnSortMode.NotSortable;
            view.Columns["Brook70"].Width = 100;
            view.Columns["Brook70"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            view.Columns["Brook80"].HeaderText = "Lep 80";
            view.Columns["Brook80"].DisplayIndex = 11;
            view.Columns["Brook80"].SortMode = DataGridViewColumnSortMode.NotSortable;
            view.Columns["Brook80"].Width = 100;
            view.Columns["Brook80"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            view.Columns["Brook90"].HeaderText = "Lep 90";
            view.Columns["Brook90"].DisplayIndex = 12;
            view.Columns["Brook90"].SortMode = DataGridViewColumnSortMode.NotSortable;
            view.Columns["Brook90"].Width = 100;
            view.Columns["Brook90"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            view.Columns["Brook100"].HeaderText = "Lep 100";
            view.Columns["Brook100"].DisplayIndex = 13;
            view.Columns["Brook100"].SortMode = DataGridViewColumnSortMode.NotSortable;
            view.Columns["Brook100"].Width = 100;
            view.Columns["Brook100"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            view.Columns["BrookDisc"].HeaderText = "Dysk";
            view.Columns["BrookDisc"].DisplayIndex = 14;
            view.Columns["BrookDisc"].SortMode = DataGridViewColumnSortMode.NotSortable;
            view.Columns["BrookDisc"].Width = 60;
            view.Columns["BrookDisc"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            view.Columns["BrookXVis"].HeaderText = "Lep X";
            view.Columns["BrookXVis"].DisplayIndex = 15;
            view.Columns["BrookXVis"].SortMode = DataGridViewColumnSortMode.NotSortable;
            view.Columns["BrookXVis"].Width = 100;
            view.Columns["BrookXVis"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            view.Columns["BrookXRpm"].HeaderText = "Obr. X";
            view.Columns["BrookXRpm"].DisplayIndex = 16;
            view.Columns["BrookXRpm"].SortMode = DataGridViewColumnSortMode.NotSortable;
            view.Columns["BrookXRpm"].Width = 100;
            view.Columns["BrookXRpm"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            view.Columns["BrookXDisc"].HeaderText = "Dysk X";
            view.Columns["BrookXDisc"].DisplayIndex = 17;
            view.Columns["BrookXDisc"].SortMode = DataGridViewColumnSortMode.NotSortable;
            view.Columns["BrookXDisc"].Width = 70;
            view.Columns["BrookXDisc"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            view.Columns["BrookComment"].HeaderText = "Brookfield uwagi";
            view.Columns["BrookComment"].DisplayIndex = 18;
            view.Columns["BrookComment"].SortMode = DataGridViewColumnSortMode.NotSortable;
            view.Columns["BrookComment"].Width = 200;
            view.Columns["BrookComment"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            view.Columns["Krebs"].HeaderText = "Krebs";
            view.Columns["Krebs"].DisplayIndex = 19;
            view.Columns["Krebs"].SortMode = DataGridViewColumnSortMode.NotSortable;
            view.Columns["Krebs"].Width = 100;
            view.Columns["Krebs"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            view.Columns["KrebsComment"].HeaderText = "Krebs uwagi";
            view.Columns["KrebsComment"].DisplayIndex = 20;
            view.Columns["KrebsComment"].SortMode = DataGridViewColumnSortMode.NotSortable;
            view.Columns["KrebsComment"].Width = 200;
            view.Columns["KrebsComment"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            view.Columns["Ici"].HeaderText = "Ici";
            view.Columns["Ici"].DisplayIndex = 21;
            view.Columns["Ici"].SortMode = DataGridViewColumnSortMode.NotSortable;
            view.Columns["Ici"].Width = 60;
            view.Columns["Ici"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            view.Columns["IciDisc"].HeaderText = "Ici dysk";
            view.Columns["IciDisc"].DisplayIndex = 22;
            view.Columns["IciDisc"].SortMode = DataGridViewColumnSortMode.NotSortable;
            view.Columns["IciDisc"].Width = 80;
            view.Columns["IciDisc"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            view.Columns["IciComment"].HeaderText = "Ici uwagi";
            view.Columns["IciComment"].DisplayIndex = 23;
            view.Columns["IciComment"].SortMode = DataGridViewColumnSortMode.NotSortable;
            view.Columns["IciComment"].Width = 200;
            view.Columns["IciComment"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            view.Columns["Temp"].HeaderText = "Temp.";
            view.Columns["Temp"].DisplayIndex = 24;
            view.Columns["Temp"].SortMode = DataGridViewColumnSortMode.NotSortable;
            view.Columns["Temp"].Width = 60;
            view.Columns["Temp"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private ObservableListSource<ExpLabBook> GetAllLabBook()
        {
            var list = _context.ExpLabBook
                .Include(x => x.User)
                .OrderBy(x => x.Id)
                .ToList();

            return new ObservableListSource<ExpLabBook>(list);
        }

        private ObservableListSource<ExpViscosity> GetViscosities(long labbook_id)
        {
            var list = _context.ExpViscosity
                .Where(i => i.LabBookId == labbook_id)
                .ToList();

            return new ObservableListSource<ExpViscosity>(list);
        }

        #endregion

        #region Painting

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

        #endregion

        #region Current

        private void LabBookBinding_PositionChanged(object sender, System.EventArgs e)
        {
            ExpLabBook currentLabBook = GetCurrentLabBook;

            if (currentLabBook != null)
            {
                _form.GetLblNrD.Text = "D " + currentLabBook.Id.ToString();
                _form.GetLblDate.Text = currentLabBook.Created.ToString("dd.MM.yyyy");

                SaveViscosity();
                //IList<ExpViscosityAdo> tmplist = _visRepository.GetViscosityByLabBookId(currentLabBook.Id);
                IList<ExpViscosity> tmplist = GetViscosities(currentLabBook.Id);
                _viscosities.Clear();
                //foreach (ExpViscosityAdo vis in tmplist)
                //{
                //    _viscosities.Add(vis);
                //}
                foreach (ExpViscosity vis in tmplist)
                {
                    _viscosities.Add(vis);
                }

            }
        }

        #endregion


        #region Save, Update, Delete

        private void SaveViscosity()
        {
            if (_viscosities == null || _viscosities.Count == 0) return;
            
        }

        private void Save()
        {
            _context.SaveChanges();
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
