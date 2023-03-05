using LabBook_WF_EF.Commons;
using LabBook_WF_EF.Forms.LabBook;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LabBook_WF_EF.Service
{
    public class LabBookService
    {
        private static readonly string dataFormFileName = "LabBookForm";

        private readonly LabBookForm _form;

        public LabBookService(LabBookForm form)
        {
            _form = form;
        }





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
