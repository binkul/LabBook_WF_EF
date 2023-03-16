using LabBook_WF_EF.Commons;
using LabBook_WF_EF.Dto;
using LabBook_WF_EF.EntityModels;
using LabBook_WF_EF.Forms.LabBook;
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

        #region Prepare all data

        public void PrepareData()
        {
            _labBook = GetAllLabBook();
            _labBookBinding = new BindingSource { DataSource = _labBook };
            _labBookBinding.PositionChanged += _labBookBinding_PositionChanged;

            PrepareDataGridViewLabBook();
        }

        private void PrepareDataGridViewLabBook()
        {
            DataGridView view = _form.GetDgvLabBook;
            view.DataSource = _labBookBinding;
            view.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            view.RowsDefaultCellStyle.Font = new Font(view.DefaultCellStyle.Font.Name, 9, FontStyle.Regular);
            view.ColumnHeadersDefaultCellStyle.Font = new Font(view.DefaultCellStyle.Font.Name, 9, FontStyle.Bold);
            view.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            view.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            view.RowHeadersWidth = 35;
            view.DefaultCellStyle.ForeColor = Color.Black;
            view.MultiSelect = false;
            view.SelectionMode = DataGridViewSelectionMode.CellSelect;
            view.AutoGenerateColumns = false;

            view.Columns["Id"].Visible = false;
            view.Columns["UserId"].Visible = false;
            view.Columns["CycleId"].Visible = false;
            view.Columns["ProjectId"].Visible = false;
            view.Columns["Deleted"].Visible = false;
            view.Columns["User"].Visible = false;

            view.Columns["Title"].HeaderText = "Tytuł";
            view.Columns["Title"].ReadOnly = true;
            view.Columns["Title"].DisplayIndex = 0;
            view.Columns["Title"].SortMode = DataGridViewColumnSortMode.NotSortable;
            view.Columns["Title"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }

        private ObservableListSource<ExpLabBook> GetAllLabBook()
        {
            var list = _context.ExpLabBook
                .Include(x => x.ExpViscosity)
                .OrderBy(x => x.Id)
                .ToList();

            return new ObservableListSource<ExpLabBook>(list);
        }

        #endregion

        #region Current

        private void _labBookBinding_PositionChanged(object sender, System.EventArgs e)
        {

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
