using LabBook_WF_EF.Commons;
using LabBook_WF_EF.EntityModels;
using System.Collections.Generic;

namespace LabBook_WF_EF.Dto
{
    public class NormDto
    {
        public IList<ExpNormResult> NormList { get; } = new ObservableListSource<ExpNormResult>();
        public string TabName { get; set; } = "";

        public void AddNew(ExpNormResult expNormResult)
        {
            NormList.Add(expNormResult);
        }
    }
}
