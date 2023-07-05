using LabBook_WF_EF.EntityModels;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;

namespace LabBook_WF_EF.Repository
{
    public class ExpNormResultRepository
    {
        private static readonly string _save = "Insert Into LabBook.dbo.ExpNormResultTabs(labbook_id, user_id, page_nr, visibility, header_name) " +
            "values(@labbook_id, @user_id, @page_nr, @visibility, @header_name)";
        private static readonly string _update = "Update LabBook.dbo.ExpNormResultTabs Set labbook_id=@labbook_id, user_id=@user_id, page_nr=@page_nr, " +
            "visibility=@visibility, header_name=@header_name Where id=@id";
        private readonly LabBookContext _context;

        public ExpNormResultRepository(LabBookContext context)
        {
            _context = context;
        }

        public void UpdateQuick(ExpNormResultTabs tab)
        {
            if (tab == null) return;

            object[] parameters = new object[]
            {
                    new SqlParameter("@id", tab.Id),
                    new SqlParameter("@labbook_id", tab.LabBookId),
                    new SqlParameter("@user_id", tab.UserId),
                    new SqlParameter("@page_nr", tab.PageNumber),
                    new SqlParameter("@visibility", tab.TabVisibility),
                    new SqlParameter("@header_name", tab.TabHeaderName)
            };

            _context.Database
                .ExecuteSqlRaw(_update, parameters);
        }

        public void SaveQuick(ExpNormResultTabs tab)
        {
            if (tab == null) return;

            object[] parameters = new object[]
            {
                    new SqlParameter("@labbook_id", tab.LabBookId),
                    new SqlParameter("@user_id", tab.UserId),
                    new SqlParameter("@page_nr", tab.PageNumber),
                    new SqlParameter("@visibility", tab.TabVisibility),
                    new SqlParameter("@header_name", tab.TabHeaderName ?? (object)DBNull.Value)
            };

            _context.Database
                .ExecuteSqlRaw(_save, parameters);
        }
    }
}
