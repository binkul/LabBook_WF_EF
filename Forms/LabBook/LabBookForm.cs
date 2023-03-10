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

        public LabBookForm(UserDto user, LabBookContext context)
        {
            InitializeComponent();
            _user = user;
            _context = context;
            _service = new LabBookService(this);
        }


        #region Form Open/Load/Closing

        private void LabBookForm_Load(object sender, EventArgs e)
        {

            _service.LoadFormData(this);
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
    }
}
