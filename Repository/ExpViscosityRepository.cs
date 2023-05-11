using System.Collections.Generic;
using LabBook_WF_EF.Commons;

namespace LabBook_WF_EF.Repository
{
    public class ExpViscosityRepository
    {

        public IList<ExpViscosityAdo> GetViscosityByLabBookId(long labBookId)
        {
            ObservableListSource<ExpViscosityAdo> list = new ObservableListSource<ExpViscosityAdo>();


            return list;
        }
    }
}
