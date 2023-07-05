using LabBook_WF_EF.Dto;
using LabBook_WF_EF.EntityModels;
using LabBook_WF_EF.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabBook_WF_EF.Forms.LabBook
{
    public partial class LabBookForm : Form
    {
        private readonly LabBookService _service;
        private readonly UserDto _user;
        private readonly LabBookContext _context;
        public bool isAdmin => _user.Permission.ToLower().Equals("admin");


        public LabBookForm(UserDto user, LabBookContext context)
        {
            InitializeComponent();
            _user = user;
            _context = context;
            _service = new LabBookService(this, context, user);
        }

        public DataGridView GetDgvLabBook => DgvLabBook;
        public DataGridView GetDgvViscosity => DgvViscosity;
        public DataGridView GetDgvContrast => DgvContrast;
        public DataGridView GetDgvNormResultTab1 => DgvNormResultTab1;
        public ToolStripMenuItem GetApplicatorMenu => ApplicatorToolStripMenuItem;
        public ToolStripMenuItem GetTabResult1Menu => TabResult1ToolStripMenuItem;
        public ToolStripMenuItem GetTabResult2Menu => TabResult2ToolStripMenuItem;
        public ToolStripMenuItem GetTabResult3Menu => TabResult3ToolStripMenuItem;
        public ToolStripMenuItem GetTabResult4Menu => TabResult4ToolStripMenuItem;
        public Label GetLblNrD => LblNrD;
        public Label GetLblDate => LblDate;
        public TextBox GetTxtTitle => TxtTitle;
        public TextBox GetTxtObservation => TxtObservation;
        public TextBox GetTxtRemarks => TxtRemarks;
        public TextBox GetTxtBrush => TxtBrush;
        public TextBox GetTxtSponge => TxtSponge;
        public ComboBox GetComboContrastClass => CmbContrastClass;
        public ComboBox GetComboContrastYield => CmbContrastYield;
        public ComboBox GetComboGlossClass => CmbGlossClass;
        public ComboBox GetComboScrubClass => CmbScrubClass;
        public TabControl GetTabControlMain => TabControlMain;
        public TabPage GetTabPageResult1 => TabPageResult1;
        public TabPage GetTabPageResult2 => TabPageResult2;
        public TabPage GetTabPageResult3 => TabPageResult3;
        public TabPage GetTabPageResult4 => TabPageResult4;


        #region Form Open/Load/Closing

        private void LabBookForm_Load(object sender, EventArgs e)
        {
            if (!isAdmin)
            {
                DgvLabBook.RowPostPaint += DgvLabBook_RowPostPaint;
            }

            _service.LoadFormData(this);
            _service.PrepareData();
            BindingNavigatorMain.BindingSource = _service.GetLabBookBinding;
            DgvLabBook.Rows[0].Cells[1].Selected = true;
        }

        private void LabBookForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!e.Cancel)
            {
                _service.SaveFormData(this);
                FormClosing -= LabBookForm_FormClosing;
                _context.Dispose();
                Application.Exit();
            }
        }

        #endregion

        private void ToolStripSave_Click(object sender, EventArgs e)
        {
            _service.Save();
        }

        private void DgvLabBook_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            _service.IconInCellPainting(e);
        }

        private void TxtTitle_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                SendKeys.Send("{Tab}");
            }

            else
            {
                base.OnKeyPress(e);
            }
        }

        private void DgvViscosity_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            _service.DefaultvaluesNeededForVoscosity(e);
        }

        private void DgvViscosity_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var grid = (DataGridView)sender;
            if (grid.Columns.Count == 0 || grid.Rows.Count == 0) return;

            if (grid[e.ColumnIndex, e.RowIndex] is DataGridViewButtonCell)
            {
                long id = (long)grid.Rows[e.RowIndex].Cells["Id"].Value;
                _service.CellContentClickForViscosityButton(id, e);
            }
        }

        private void DgvContrast_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var grid = (DataGridView)sender;
            if (grid.Columns.Count == 0 || grid.Rows.Count == 0) return;

            if (grid[e.ColumnIndex, e.RowIndex] is DataGridViewButtonCell)
            {
                long id = (long)grid.Rows[e.RowIndex].Cells["Id"].Value;
                _service.CellContentClickForContrastButton(id, e);
            }
        }

        private void DgvViscosity_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            
        }

        private void DgvViscosity_Resize(object sender, EventArgs e)
        {
            if (DgvViscosity.Columns.Count > 0)
                _service.DataGridViscosityColumnSizeChanged();
        }

        private void DgvContrast_Resize(object sender, EventArgs e)
        {
            if (DgvContrast.Columns.Count > 0)
                _service.DataGridContrastColumnSizeChanged();
        }

        private void ViscosityViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;

            int value = 0;
            if (int.TryParse(item.Tag.ToString(), out value))
            {
                _service.ViscosityFieldVisibilityItem(value);
            }
        }

        private void TabControlMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabPage page = TabControlMain.SelectedTab;
            string tag = page.Tag != null ? page.Tag.ToString() : "-1";

            if (page.Name.Equals("TabPageContrast"))
                ApplicatorToolStripMenuItem.Enabled = true;
            else
                ApplicatorToolStripMenuItem.Enabled = false;

            if (tag == "-1")
                ResultNameToolStripMenuItem.Enabled = false;
            else
                ResultNameToolStripMenuItem.Enabled = true;
        }

        private void TxtSponge_Validating(object sender, CancelEventArgs e)
        {
            _service.TxtSponge_Validating(TxtSponge.Text, TxtBrush.Text);
        }

        private void ResultTabMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            _service.ShowOrHideResultTab(int.Parse(item.Tag.ToString()));
        }

        private void ResultNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPage page = TabControlMain.SelectedTab;
            string tag = page.Tag != null ? page.Tag.ToString() : "-1";

            if (tag == "-1")
                return;
            else
                _service.ChangeTabPageName(int.Parse(tag));
        }

        private void ToolStripAdd_Click(object sender, EventArgs e)
        {

        }

    }
}
