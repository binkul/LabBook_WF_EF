using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using LabBook_WF_EF.Commons;
using LabBook_WF_EF.EntityModels;

namespace LabBook_WF_EF.Repository
{
    public class ExpViscosityRepository
    {
        private readonly string _getViscosityByLabBookId = "Select id, labbook_id, date_created, date_update, pH, vis_type, " +
            "brook_1, brook_5, brook_10, brook_20, brook_30, brook_40, brook_50, brook_60, brook_70, brook_80, brook_90, " +
            "brook_100, brook_comment, brook_disc, brook_x_vis, brook_x_rpm, brook_x_disc, krebs, krebs_comment, ici, ici_disc, " +
            "ici_comment, temp from LabBook.dbo.ExpViscosity Where labbook_id=";
        public static readonly string _saveViscosity = "Insert Into LabBook.dbo.ExpViscosity(labbook_id, date_created, date_update, " +
            "pH, vis_type, brook_1, brook_5, brook_10, brook_20, brook_30, brook_40, brook_50, brook_60, brook_70, brook_80, " +
            "brook_90, brook_100, brook_comment, brook_disc, brook_x_vis, brook_x_rpm, brook_x_disc, krebs, krebs_comment, " +
            "ici, ici_disc, ici_comment, temp) Values(@labbook_id, @date_created, @date_update, @pH, @vis_type, @brook_1, " +
            "@brook_5, @brook_10, @brook_20, @brook_30, @brook_40, @brook_50, @brook_60, @brook_70, @brook_80, " +
            "@brook_90, @brook_100, @brook_comment, @brook_disc, @brook_x_vis, @brook_x_rpm, @brook_x_disc, @krebs, " +
            "@krebs_comment, @ici, @ici_disc, @ici_comment, @temp)";
        public static readonly string _updateViscosity = "Update LabBook.dbo.ExpViscosity Set " +
            "date_update=@date_update, pH=@pH, vis_type=@vis_type, brook_1=@brook_1, brook_5=@brook_5, brook_10=@brook_10, " +
            "brook_20=@brook_20, brook_30=@brook_30, brook_40=@brook_40, brook_50=@brook_50, brook_60=@brook_60, brook_70=@brook_70, " +
            "brook_80=@brook_80, brook_90=@brook_90, brook_100=@brook_100, brook_comment=@brook_comment, brook_disc=@brook_disc, " +
            "brook_x_vis=@brook_x_vis, brook_x_rpm=@brook_x_rpm, brook_x_disc=@brook_x_disc, krebs=@krebs, krebs_comment=@krebs_comment, " +
            "ici=@ici, ici_disc=@ici_disc, ici_comment=@ici_comment, temp=@temp Where id=@id ";

        private readonly SqlConnection _connection;

        public ExpViscosityRepository(SqlConnection connection)
        {
            _connection = connection;
        }

        public IList<ExpViscosityAdo> GetViscosityByLabBookId(long labBookId)
        {
            ObservableListSource<ExpViscosityAdo> list = new ObservableListSource<ExpViscosityAdo>();

            try
            {
                string query = _getViscosityByLabBookId + labBookId.ToString();
                SqlCommand command = new SqlCommand(query, _connection);
                _connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        long id = reader.GetInt64(0);
                        long labId = reader.GetInt64(1);
                        DateTime createDate = reader.GetDateTime(2);
                        DateTime updateDate = reader.GetDateTime(3);
                        double? pH = CommonFunctions.DBNullToDoubleConv(reader.GetValue(4));
                        string visType = CommonFunctions.DBNullToStringConv(reader.GetValue(5));
                        double? b1 = CommonFunctions.DBNullToDoubleConv(reader.GetValue(6));
                        double? b5 = CommonFunctions.DBNullToDoubleConv(reader.GetValue(7));
                        double? b10 = CommonFunctions.DBNullToDoubleConv(reader.GetValue(8));
                        double? b20 = CommonFunctions.DBNullToDoubleConv(reader.GetValue(9));
                        double? b30 = CommonFunctions.DBNullToDoubleConv(reader.GetValue(10));
                        double? b40 = CommonFunctions.DBNullToDoubleConv(reader.GetValue(11));
                        double? b50 = CommonFunctions.DBNullToDoubleConv(reader.GetValue(12));
                        double? b60 = CommonFunctions.DBNullToDoubleConv(reader.GetValue(13));
                        double? b70 = CommonFunctions.DBNullToDoubleConv(reader.GetValue(14));
                        double? b80 = CommonFunctions.DBNullToDoubleConv(reader.GetValue(15));
                        double? b90 = CommonFunctions.DBNullToDoubleConv(reader.GetValue(16));
                        double? b100 = CommonFunctions.DBNullToDoubleConv(reader.GetValue(17));
                        string bComment = CommonFunctions.DBNullToStringConv(reader.GetValue(18));
                        string bDisk = CommonFunctions.DBNullToStringConv(reader.GetValue(19));
                        double? bxv = CommonFunctions.DBNullToDoubleConv(reader.GetValue(20));
                        string bxrpm = CommonFunctions.DBNullToStringConv(reader.GetValue(21));
                        string brookXDisc = CommonFunctions.DBNullToStringConv(reader.GetValue(22));
                        double? krebs = CommonFunctions.DBNullToDoubleConv(reader.GetValue(23));
                        string krebsComment = CommonFunctions.DBNullToStringConv(reader.GetValue(24));
                        double? ici = CommonFunctions.DBNullToDoubleConv(reader.GetValue(25));
                        string iciDisc = CommonFunctions.DBNullToStringConv(reader.GetValue(26));
                        string iciComment = CommonFunctions.DBNullToStringConv(reader.GetValue(27));
                        string temp = CommonFunctions.DBNullToStringConv(reader.GetValue(28));
                        
                        ExpViscosityAdo visc = new ExpViscosityAdo(id, labBookId, createDate, updateDate, pH, visType, b1, b5, b10,
                                b20, b30, b40, b50, b60, b70, b80, b90, b100, bComment, bDisk, bxv, bxrpm, brookXDisc, krebs, krebsComment,
                                ici, iciDisc, iciComment, temp);

                        list.Add(visc);
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Problem z połączeniem z serwerem. Prawdopodobnie serwer jest wyłączony, błąd w nazwie serwera lub dostępie do bazy: '" + ex.Message + "'. Błąd z poziomu MaterialRepository - pobieranie surowców.",
                    "Błąd połaczenia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problem z połączeniem z serwerem. Prawdopodobnie serwer jest wyłączony: '" + ex.Message + "'. Błąd z poziomu MaterialRepository - pobieranie surowców.",
                    "Błąd połączenia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_connection.State == ConnectionState.Open)
                    _connection.Close();
            }
            return list;
        }

        public bool Save(ExpViscosity viscosity)
        {
            bool result = true;

            using (SqlCommand cmd = new SqlCommand())
            {
                try
                {
                    cmd.Connection = _connection;
                    cmd.CommandText = _saveViscosity;
                    cmd.Parameters.AddWithValue("@labbook_id", viscosity.LabBookId);
                    cmd.Parameters.AddWithValue("@date_created", viscosity.DateCreated);
                    cmd.Parameters.AddWithValue("@date_update", viscosity.DateUpdate);

                    FillCmdParameters(viscosity, cmd);

                    _connection.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Problem z połączeniem z serwerem. Prawdopodobnie serwer jest wyłączony, błąd w nazwie serwera lub dostępie do bazy: '" + ex.Message + "'. Błąd z poziomu MaterialRepository - pobieranie surowców.",
                        "Błąd połaczenia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    result = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Problem z połączeniem z serwerem. Prawdopodobnie serwer jest wyłączony: '" + ex.Message + "'. Błąd z poziomu MaterialRepository - pobieranie surowców.",
                        "Błąd połączenia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    result = false;
                }
                finally
                {
                    if (_connection.State == ConnectionState.Open)
                        _connection.Close();
                }
            }
            return result;
        }

        public bool Update(ExpViscosity viscosity)
        {
            bool result = true;

            using (SqlCommand cmd = new SqlCommand())
            {
                try
                {
                    cmd.Connection = _connection;
                    cmd.CommandText = _updateViscosity;
                    cmd.Parameters.AddWithValue("@labbook_id", viscosity.LabBookId);
                    cmd.Parameters.AddWithValue("@date_update", viscosity.DateUpdate);
                    cmd.Parameters.AddWithValue("@id", viscosity.Id);

                    FillCmdParameters(viscosity, cmd);

                    _connection.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Problem z połączeniem z serwerem. Prawdopodobnie serwer jest wyłączony, błąd w nazwie serwera lub dostępie do bazy: '" + ex.Message + "'. Błąd z poziomu MaterialRepository - pobieranie surowców.",
                        "Błąd połaczenia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    result = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Problem z połączeniem z serwerem. Prawdopodobnie serwer jest wyłączony: '" + ex.Message + "'. Błąd z poziomu MaterialRepository - pobieranie surowców.",
                        "Błąd połączenia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    result = false;
                }
                finally
                {
                    if (_connection.State == ConnectionState.Open)
                        _connection.Close();
                }
            }
            return result;
        }

        private void FillCmdParameters(ExpViscosity viscosity, SqlCommand cmd)
        {
            if (viscosity.PH != null)
                cmd.Parameters.AddWithValue("@pH", viscosity.PH);
            else
                cmd.Parameters.AddWithValue("@pH", DBNull.Value);

            if (!string.IsNullOrEmpty(viscosity.VisType))
                cmd.Parameters.AddWithValue("@vis_type", viscosity.VisType);
            else
                cmd.Parameters.AddWithValue("@vis_type", DBNull.Value);

            if (viscosity.Brook1 != null)
                cmd.Parameters.AddWithValue("@brook_1", viscosity.Brook1);
            else
                cmd.Parameters.AddWithValue("@brook_1", DBNull.Value);

            if (viscosity.Brook5 != null)
                cmd.Parameters.AddWithValue("@brook_5", viscosity.Brook5);
            else
                cmd.Parameters.AddWithValue("@brook_5", DBNull.Value);

            if (viscosity.Brook10 != null)
                cmd.Parameters.AddWithValue("@brook_10", viscosity.Brook10);
            else
                cmd.Parameters.AddWithValue("@brook_10", DBNull.Value);

            if (viscosity.Brook20 != null)
                cmd.Parameters.AddWithValue("@brook_20", viscosity.Brook20);
            else
                cmd.Parameters.AddWithValue("@brook_20", DBNull.Value);

            if (viscosity.Brook30 != null)
                cmd.Parameters.AddWithValue("@brook_30", viscosity.Brook30);
            else
                cmd.Parameters.AddWithValue("@brook_30", DBNull.Value);

            if (viscosity.Brook40 != null)
                cmd.Parameters.AddWithValue("@brook_40", viscosity.Brook40);
            else
                cmd.Parameters.AddWithValue("@brook_40", DBNull.Value);

            if (viscosity.Brook50 != null)
                cmd.Parameters.AddWithValue("@brook_50", viscosity.Brook50);
            else
                cmd.Parameters.AddWithValue("@brook_50", DBNull.Value);

            if (viscosity.Brook60 != null)
                cmd.Parameters.AddWithValue("@brook_60", viscosity.Brook60);
            else
                cmd.Parameters.AddWithValue("@brook_60", DBNull.Value);

            if (viscosity.Brook70 != null)
                cmd.Parameters.AddWithValue("@brook_70", viscosity.Brook70);
            else
                cmd.Parameters.AddWithValue("@brook_70", DBNull.Value);

            if (viscosity.Brook80 != null)
                cmd.Parameters.AddWithValue("@brook_80", viscosity.Brook80);
            else
                cmd.Parameters.AddWithValue("@brook_80", DBNull.Value);

            if (viscosity.Brook90 != null)
                cmd.Parameters.AddWithValue("@brook_90", viscosity.Brook90);
            else
                cmd.Parameters.AddWithValue("@brook_90", DBNull.Value);

            if (viscosity.Brook100 != null)
                cmd.Parameters.AddWithValue("@brook_100", viscosity.Brook100);
            else
                cmd.Parameters.AddWithValue("@brook_100", DBNull.Value);

            if (!string.IsNullOrEmpty(viscosity.BrookComment))
                cmd.Parameters.AddWithValue("@brook_comment", viscosity.BrookComment);
            else
                cmd.Parameters.AddWithValue("@brook_comment", DBNull.Value);

            if (!string.IsNullOrEmpty(viscosity.BrookDisc))
                cmd.Parameters.AddWithValue("@brook_disc", viscosity.BrookDisc);
            else
                cmd.Parameters.AddWithValue("@brook_disc", DBNull.Value);

            if (viscosity.BrookXVis != null)
                cmd.Parameters.AddWithValue("@brook_x_vis", viscosity.BrookXVis);
            else
                cmd.Parameters.AddWithValue("@brook_x_vis", DBNull.Value);

            if (!string.IsNullOrEmpty(viscosity.BrookXRpm))
                cmd.Parameters.AddWithValue("@brook_x_rpm", viscosity.BrookXRpm);
            else
                cmd.Parameters.AddWithValue("@brook_x_rpm", DBNull.Value);

            if (!string.IsNullOrEmpty(viscosity.BrookXDisc))
                cmd.Parameters.AddWithValue("@brook_x_disc", viscosity.BrookXDisc);
            else
                cmd.Parameters.AddWithValue("@brook_x_disc", DBNull.Value);

            if (viscosity.Krebs != null)
                cmd.Parameters.AddWithValue("@krebs", viscosity.Krebs);
            else
                cmd.Parameters.AddWithValue("@krebs", DBNull.Value);

            if (!string.IsNullOrEmpty(viscosity.KrebsComment))
                cmd.Parameters.AddWithValue("@krebs_comment", viscosity.KrebsComment);
            else
                cmd.Parameters.AddWithValue("@krebs_comment", DBNull.Value);

            if (viscosity.Ici != null)
                cmd.Parameters.AddWithValue("@ici", viscosity.Ici);
            else
                cmd.Parameters.AddWithValue("@ici", DBNull.Value);

            if (!string.IsNullOrEmpty(viscosity.IciDisc))
                cmd.Parameters.AddWithValue("@ici_disc", viscosity.IciDisc);
            else
                cmd.Parameters.AddWithValue("@ici_disc", DBNull.Value);

            if (!string.IsNullOrEmpty(viscosity.IciComment))
                cmd.Parameters.AddWithValue("@ici_comment", viscosity.IciComment);
            else
                cmd.Parameters.AddWithValue("@ici_comment", DBNull.Value);

            if (!string.IsNullOrEmpty(viscosity.Temp))
                cmd.Parameters.AddWithValue("@temp", viscosity.Temp);
            else
                cmd.Parameters.AddWithValue("@temp", DBNull.Value);
        }

    }
}
