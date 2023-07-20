using LabBook_WF_EF.EntityModels;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace LabBook_WF_EF.Repository
{
    public class ExpNormResultRepository
    {
        private static readonly string _saveTabs = "Insert Into LabBook.dbo.ExpNormResultTabs(labbook_id, user_id, page_nr, visibility, header_name) " +
            "values(@labbook_id, @user_id, @page_nr, @visibility, @header_name)";
        private static readonly string _updateTabs = "Update LabBook.dbo.ExpNormResultTabs Set labbook_id=@labbook_id, user_id=@user_id, page_nr=@page_nr, " +
            "visibility=@visibility, header_name=@header_name Where id=@id";
        private static readonly string _save = "Insert Into LabBook.dbo.ExpNormResult(labbook_id, position, page_nr, description, " +
            "norm, requirement, result, substrate, comment, date_created, date_updated) Values(@labbook_id, @position, @page_nr, " +
            "@description, @norm, @requirement, @result, @substrate, @comment, @date_created, @date_updated)";
        private static readonly string _update = "Update LabBook.dbo.ExpNormResult Set labbook_id=@labbook_id, position=@position, " +
            "page_nr=@page_nr, description=@description, norm=@norm, requirement=@requirement, result=@result, substrate=@substrate, " +
            "comment=@comment, date_created=@date_created, date_updated=@date_updated Where id=@id";
        private static readonly string _deleteById = "Delete From LabBook.dbo.ExpNormResult Where id={0}";

        private readonly LabBookContext _context;

        public ExpNormResultRepository(LabBookContext context)
        {
            _context = context;
        }

        public void QuickUpdateTabsData(ExpNormResultTabs tab)
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
                .ExecuteSqlRaw(_updateTabs, parameters);
        }

        public void QuickSaveTabsData(ExpNormResultTabs tab)
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
                .ExecuteSqlRaw(_saveTabs, parameters);
        }

        public void QuickSaveResult(IList<ExpNormResult> results)
        {
            if (results == null || results.Count == 0) return;

            var modList = results
                .Where(i => i.Added || i.Modified)
                .ToList();

            foreach (ExpNormResult result in modList)
            {
                result.DateUpdated = DateTime.Now;
                object[] parameters = new object[]
                {
                    new SqlParameter("@id", result.Id),
                    new SqlParameter("@labbook_id", result.LabBookId),
                    new SqlParameter("@date_created", result.DateCreated),
                    new SqlParameter("@date_updated", result.DateUpdated),
                    new SqlParameter("@position", result.Position),
                    new SqlParameter("@page_nr", result.PageNumber),
                    new SqlParameter("@description", result.Description ?? (object)DBNull.Value),
                    new SqlParameter("@norm", result.Norm ?? (object)DBNull.Value),
                    new SqlParameter("@requirement", result.Requirement ?? (object)DBNull.Value),
                    new SqlParameter("@result", result.Result ?? (object)DBNull.Value),
                    new SqlParameter("@substrate", result.Substrate ?? (object)DBNull.Value),
                    new SqlParameter("@comment", result.Comment ?? (object)DBNull.Value)
                };

                try
                {
                    if (result.Added)
                    {
                        _context.Database
                            .ExecuteSqlRaw(_save, parameters);
                        long id = GetLastSavedId(result);
                        result.Id = id > 0 ? id : 0;
                    }
                    else
                        _context.Database
                            .ExecuteSqlRaw(_update, parameters);

                    result.Modified = false;
                    result.Added = false;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Problem z zapisem do tabeli ExpNormResult: '" + ex.Message + "'. Błąd z poziomu Save lub Update.",
                        "Błąd Zapisu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Problem z zapisem do tabeli ExpNormResult: '" + ex.Message + "'. Błąd z poziomu Save lub Update.",
                        "Błąd połączenia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        public void QuickDeleteById(long id)
        {
            try
            {
                _context.Database
                    .ExecuteSqlRaw(_deleteById, id);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Problem z usuwanie z tabeli ExpNormResult: '" + ex.Message + "'. Błąd z poziomu DeleteNorm.",
                    "Błąd Zapisu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problem z usuwanie z tabeli ExpNormResult: '" + ex.Message + "'. Błąd z poziomu DeleteNorm.",
                    "Błąd połączenia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private long GetLastSavedId(ExpNormResult expNormResult)
        {
            return _context.ExpNormResult
                .Where(i => i.LabBookId == expNormResult.LabBookId)
                .Where(i => i.DateCreated == expNormResult.DateCreated)
                .Where(i => i.DateUpdated == expNormResult.DateUpdated)
                .Where(i => i.Position == expNormResult.Position)
                .Where(i => i.PageNumber == expNormResult.PageNumber)
                .Select(i => i.Id)
                .FirstOrDefault();
        }
    }
}
