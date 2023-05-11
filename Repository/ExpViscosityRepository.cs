using System.Collections.Generic;
using LabBook_WF_EF.Commons;

namespace LabBook_WF_EF.Repository
{
    public class ExpViscosityRepository
    {
        private readonly string _getViscosityByLabBookId = "Select id, labbook_id, date_created, date_update, pH, vis_type, " +
            "brook_1, brook_5, brook_10, brook_20, brook_30, brook_40, brook_50, brook_60, brook_70, brook_80, brook_90, " +
            "brook_100, brook_comment, brook_disc, brook_x_vis, brook_x_rpm, brook_x_disc, krebs, krebs_comment, ici, ici_disc, " +
            "ici_comment, temp from LabBook.dbo.ExpViscosity Where labbook_id=";

        public IList<ExpViscosityAdo> GetViscosityByLabBookId(long labBookId)
        {
            ObservableListSource<ExpViscosityAdo> list = new ObservableListSource<ExpViscosityAdo>();


            return list;
        }
    }
}
