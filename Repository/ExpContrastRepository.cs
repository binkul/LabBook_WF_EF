using Microsoft.Data.SqlClient;

namespace LabBook_WF_EF.Repository
{
    public class ExpContrastRepository
    {
        public static readonly string SaveContrastSql = "Insert Into LabBook.dbo.ExpContrast(labbook_id, applicator_id, position, " +
            "contrast, tw, sp, comments, date_created, date_updated) Values(@labbook_id, @applicator_id, @position, @contrast, " +
            "@tw, @sp, @comments, @date_created, @date_updated)";
        public static readonly string UpdateContrastSql = "Update LabBook.dbo.ExpContrast Set " +
            "applicator_id=@applicator_id, position=@position, contrast=@contrast, tw=@tw, sp=@sp, comments=@comments, " +
            "date_created=@date_created, date_updated=@date_updated Where id=@id";

        private readonly SqlConnection _connection;

        public ExpContrastRepository(SqlConnection connection)
        {
            _connection = connection;
        }

    }
}
