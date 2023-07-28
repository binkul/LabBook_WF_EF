using LabBook_WF_EF.Dto;
using LabBook_WF_EF.EntityModels;
using LabBook_WF_EF.Service;
using System;
using System.ComponentModel;
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
        public ToolStripMenuItem GetNormMenu => NormToolStripMenuItem;
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


        private void DgvLabBook_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            _service.IconInCellPainting(e);
        }

        private void DgvViscosity_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            _service.DefaultvaluesNeededForVoscosity(e);
        }

        private void DgvDeleteButton_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var grid = (DataGridView)sender;
            if (grid.Columns.Count == 0 || grid.Rows.Count == 0) return;
            if (grid.Rows[e.RowIndex].IsNewRow) return;

            if (grid[e.ColumnIndex, e.RowIndex] is DataGridViewButtonCell)
            {
                long id = (long)grid.Rows[e.RowIndex].Cells["Id"].Value;

                string tag = grid.Name;
                switch (tag)
                {
                    case "DgvViscosity":
                        _service.CellContentClickForViscosityButton(id, e);
                        break;
                    case "DgvContrast":
                        _service.CellContentClickForContrastButton(id, e);
                        break;
                    case "DgvNormResultTab1":
                        _service.CellContentClickForNormButton(id, e);
                        break;
                    default:
                        break;                    
                }
            }
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

        private void DgvNormResultTab_Resize(object sender, EventArgs e)
        {
            var dgv = (DataGridView)sender;
            if (dgv.Columns.Count > 0)
                _service.DataGridResultsColumnSizeChanged(dgv);
        }

        private void DgvNormResultTab_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var dgv = (DataGridView)sender;
            if (dgv.Columns.Count > 0)
                _service.DataGridNormResultHideRows(dgv);
        }

        private void DgvDeleteButton_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            if ((e.ColumnIndex == DgvViscosity.Columns["Del"].Index) && e.Value != null)
            {
                DataGridViewCell cell = DgvViscosity.Rows[e.RowIndex].Cells[e.ColumnIndex];
                cell.ToolTipText = "Usuń";
            }
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
            {
                ResultNameToolStripMenuItem.Enabled = false;
                NormToolStripMenuItem.Enabled = false;
            }
            else
            {
                ResultNameToolStripMenuItem.Enabled = true;
                NormToolStripMenuItem.Enabled = true;
            }
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

        private void NormTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menu = (ToolStripMenuItem)sender;
            string type = menu.Tag != null ? menu.Tag.ToString() : "Pusty";

            TabPage page = TabControlMain.SelectedTab;
            string pageName = page.Name;
            int index;
            switch (pageName)
            {
                case "TabPageResult2":
                    index = 2;
                    break;
                case "TabPageResult3":
                    index = 3;
                    break;
                case "TabPageResult4":
                    index = 4;
                    break;
                default:
                    index = 1;
                    break;
            }

            _service.InsertNormResultTest(type, index);
        }

        private void ToolStripAdd_Click(object sender, EventArgs e)
        {
            
        }

    }
}
