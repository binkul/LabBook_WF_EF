using LabBook_WF_EF.Commons;
using LabBook_WF_EF.Dto;
using LabBook_WF_EF.EntityModels;
using LabBook_WF_EF.Forms.LabBook;
using LabBook_WF_EF.Properties;
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
        private readonly UserDto _user;

        private ObservableListSource<ExpLabBook> _labBook;
        private BindingSource _labBookBinding;

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

            #region Prepare DataGrids

            PrepareDataGridViewLabBook();

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

        private ObservableListSource<ExpLabBook> GetAllLabBook()
        {
            var list = _context.ExpLabBook
                .Include(x => x.ExpViscosity)
                .Include(x => x.User)
                .OrderBy(x => x.Id)
                .ToList();

            return new ObservableListSource<ExpLabBook>(list);
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
            }
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
