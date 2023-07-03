using LabBook_WF_EF.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabBook_WF_EF.Repository
{
    public class ExpNormResultRepository
    {
        private readonly LabBookContext _context;

        public ExpNormResultRepository(LabBookContext context)
        {
            _context = context;
        }

    }
}
