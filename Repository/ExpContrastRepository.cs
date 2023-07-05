using LabBook_WF_EF.EntityModels;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace LabBook_WF_EF.Repository
{
    public class ExpContrastRepository
    {
        private static readonly string SaveContrastSql = "Insert Into LabBook.dbo.ExpContrast(labbook_id, applicator_id, position, " +
            "contrast, tw, sp, comments, date_created, date_updated) Values(@labbook_id, @applicator_id, @position, @contrast, " +
            "@tw, @sp, @comments, @date_created, @date_updated)";
        private static readonly string UpdateContrastSql = "Update LabBook.dbo.ExpContrast Set " +
            "applicator_id=@applicator_id, position=@position, contrast=@contrast, tw=@tw, sp=@sp, comments=@comments, " +
            "date_created=@date_created, date_updated=@date_updated Where id=@id";
        private static readonly string _deleteContrastById = "Delete From LabBook.dbo.ExpContrast Where id={0}";

        private readonly LabBookContext _context;

        public ExpContrastRepository(LabBookContext context)
        {
            _context = context;
        }

        public void DeleteViscosityById(long id)
        {
            try
            {
                _context.Database
                    .ExecuteSqlRaw(_deleteContrastById, id);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Problem z usuwanie z tabeli ExpViscosity: '" + ex.Message + "'. Błąd z poziomu DeleteViscosity.",
                    "Błąd Zapisu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problem z usuwanie z tabeli ExpViscosity: '" + ex.Message + "'. Błąd z poziomu DeleteViscosity.",
                    "Błąd połączenia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void QuickSaveContrast(IList<ExpContrast> contrasts)
        {
            if (contrasts == null || contrasts.Count == 0) return;

            var modList = contrasts
                .Where(i => i.Added || i.Modified)
                .ToList();

            foreach (ExpContrast contrast in modList)
            {
                contrast.DateUpdated = DateTime.Now;
                object[] parameters = new object[]
                {
                    new SqlParameter("@id", contrast.Id),
                    new SqlParameter("@labbook_id", contrast.LabBookId),
                    new SqlParameter("@date_created", contrast.DateCreated),
                    new SqlParameter("@date_update", contrast.DateUpdated),
                    new SqlParameter("@applicator_id", contrast.ApplicatiorId),
                    new SqlParameter("@position", contrast.Position),
                    new SqlParameter("@contrast", contrast.Contrast ?? (object)DBNull.Value),
                    new SqlParameter("@tw", contrast.Tw ?? (object)DBNull.Value),
                    new SqlParameter("@sp", contrast.Sp ?? (object)DBNull.Value),
                    new SqlParameter("@comments", contrast.Comments ?? (object)DBNull.Value),
                };

                if (contrast.Added)
                    _context.Database
                        .ExecuteSqlRaw(ExpContrastRepository.SaveContrastSql, parameters);
                else
                    _context.Database
                        .ExecuteSqlRaw(ExpContrastRepository.UpdateContrastSql, parameters);
            }
        }

    }
}
