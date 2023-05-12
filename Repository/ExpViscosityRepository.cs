using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
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

            using (var connection = new SqlConnection(ConfigData.ConnectionStringAdo))
            {
                try
                {
                    string query = _getViscosityByLabBookId + labBookId.ToString();
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
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
                    if (connection.State == ConnectionState.Open)
                        connection.Close();
                }
            }
            return list;
        }
    }
}
