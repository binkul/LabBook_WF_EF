﻿using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using LabBook_WF_EF.EntityModels;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace LabBook_WF_EF.Repository
{
    public class ExpViscosityRepository
    {
        private readonly string _getViscosityByLabBookId = "Select id, labbook_id, date_created, date_update, pH, vis_type, " +
            "brook_1, brook_5, brook_10, brook_20, brook_30, brook_40, brook_50, brook_60, brook_70, brook_80, brook_90, " +
            "brook_100, brook_comment, brook_disc, brook_x_vis, brook_x_rpm, brook_x_disc, krebs, krebs_comment, ici, ici_disc, " +
            "ici_comment, temp from LabBook.dbo.ExpViscosity Where labbook_id=";
        private static readonly string _saveViscositySql = "Insert Into LabBook.dbo.ExpViscosity(labbook_id, date_created, date_update, " +
            "pH, vis_type, brook_1, brook_5, brook_10, brook_20, brook_30, brook_40, brook_50, brook_60, brook_70, brook_80, " +
            "brook_90, brook_100, brook_comment, brook_disc, brook_x_vis, brook_x_rpm, brook_x_disc, krebs, krebs_comment, " +
            "ici, ici_disc, ici_comment, temp) Values(@labbook_id, @date_created, @date_update, @pH, @vis_type, @brook_1, " +
            "@brook_5, @brook_10, @brook_20, @brook_30, @brook_40, @brook_50, @brook_60, @brook_70, @brook_80, " +
            "@brook_90, @brook_100, @brook_comment, @brook_disc, @brook_x_vis, @brook_x_rpm, @brook_x_disc, @krebs, " +
            "@krebs_comment, @ici, @ici_disc, @ici_comment, @temp)";
        private static readonly string _updateViscositySQL = "Update LabBook.dbo.ExpViscosity Set date_created=@date_created, " +
            "date_update=@date_update, pH=@pH, vis_type=@vis_type, brook_1=@brook_1, brook_5=@brook_5, brook_10=@brook_10, " +
            "brook_20=@brook_20, brook_30=@brook_30, brook_40=@brook_40, brook_50=@brook_50, brook_60=@brook_60, brook_70=@brook_70, " +
            "brook_80=@brook_80, brook_90=@brook_90, brook_100=@brook_100, brook_comment=@brook_comment, brook_disc=@brook_disc, " +
            "brook_x_vis=@brook_x_vis, brook_x_rpm=@brook_x_rpm, brook_x_disc=@brook_x_disc, krebs=@krebs, krebs_comment=@krebs_comment, " +
            "ici=@ici, ici_disc=@ici_disc, ici_comment=@ici_comment, temp=@temp Where id=@id ";
        private static readonly string _deleteViscosityById = "Delete From LabBook.dbo.ExpViscosity Where id={0}";
        private static readonly string _deleteViscosityFieldByLabbookId = "Delete from LabBook.dbo.ExpViscosityFields Where labbook_id={0}";
        private static readonly string _insertViscosityField = "Insert Into LabBook.dbo.ExpViscosityFields(labbook_id, name, user_id) Values({0}, {1}, {2})";

        private readonly LabBookContext _context;

        public ExpViscosityRepository(LabBookContext context)
        {
            _context = context;
        }

        public void DeleteViscosityById(long id)
        {
            try
            {
                _context.Database
                    .ExecuteSqlRaw(_deleteViscosityById, id);
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

        public void QuickSaveViscosity(IList<ExpViscosity> viscosities)
        {
            if (viscosities == null || viscosities.Count == 0) return;

            var modList = viscosities
                .Where(i => i.Added || i.Modified)
                .ToList();

            foreach (ExpViscosity vis in modList)
            {
                vis.DateUpdate = DateTime.Now;
                object[] parameters = new object[]
                {
                    new SqlParameter("@id", vis.Id),
                    new SqlParameter("@labbook_id", vis.LabBookId),
                    new SqlParameter("@date_created", vis.DateCreated),
                    new SqlParameter("@date_update", vis.DateUpdate),
                    new SqlParameter("@pH", vis.PH ?? (object)DBNull.Value),
                    new SqlParameter("@vis_type", vis.VisType ?? (object)DBNull.Value),
                    new SqlParameter("@brook_1", vis.Brook1 ?? (object)DBNull.Value),
                    new SqlParameter("@brook_5", vis.Brook5 ?? (object)DBNull.Value),
                    new SqlParameter("@brook_10", vis.Brook10 ?? (object)DBNull.Value),
                    new SqlParameter("@brook_20", vis.Brook20 ?? (object)DBNull.Value),
                    new SqlParameter("@brook_30", vis.Brook30 ?? (object)DBNull.Value),
                    new SqlParameter("@brook_40", vis.Brook40 ?? (object)DBNull.Value),
                    new SqlParameter("@brook_50", vis.Brook50 ?? (object)DBNull.Value),
                    new SqlParameter("@brook_60", vis.Brook60 ?? (object)DBNull.Value),
                    new SqlParameter("@brook_70", vis.Brook70 ?? (object)DBNull.Value),
                    new SqlParameter("@brook_80", vis.Brook80 ?? (object)DBNull.Value),
                    new SqlParameter("@brook_90", vis.Brook90 ?? (object)DBNull.Value),
                    new SqlParameter("@brook_100", vis.Brook100 ?? (object)DBNull.Value),
                    new SqlParameter("@brook_comment", vis.BrookComment ?? (object)DBNull.Value),
                    new SqlParameter("@brook_disc", vis.BrookDisc ?? (object)DBNull.Value),
                    new SqlParameter("@brook_x_vis", vis.BrookXVis ?? (object)DBNull.Value),
                    new SqlParameter("@brook_x_rpm", vis.BrookXRpm ?? (object)DBNull.Value),
                    new SqlParameter("@brook_x_disc", vis.BrookXDisc ?? (object)DBNull.Value),
                    new SqlParameter("@krebs", vis.Krebs ?? (object)DBNull.Value),
                    new SqlParameter("@krebs_comment", vis.KrebsComment ?? (object)DBNull.Value),
                    new SqlParameter("@ici", vis.Ici ?? (object)DBNull.Value),
                    new SqlParameter("@ici_disc", vis.IciDisc ?? (object)DBNull.Value),
                    new SqlParameter("@ici_comment", vis.IciDisc ?? (object)DBNull.Value),
                    new SqlParameter("@temp", vis.Temp ?? (object)DBNull.Value)
                };

                try
                {
                    if (vis.Added)
                        _context.Database
                            .ExecuteSqlRaw(_saveViscositySql, parameters);
                    else
                        _context.Database
                            .ExecuteSqlRaw(_updateViscositySQL, parameters);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Problem z zapisem do tabeli ExpViscosity: '" + ex.Message + "'. Błąd z poziomu QuickSaveViscosity.",
                        "Błąd Zapisu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Problem z zapisem do tabeli ExpViscosity: '" + ex.Message + "'. Błąd z poziomu QuickSaveViscosity.",
                        "Błąd połączenia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        public void QuickSaveViscosityFields(String fieldType, long labbookId, long userId)
        {
            try
            {
                _context.Database
                    .ExecuteSqlRaw(_deleteViscosityFieldByLabbookId, labbookId);
                _context.Database
                    .ExecuteSqlRaw(_insertViscosityField, labbookId, fieldType, userId);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Problem z zapisem do tabeli ExpViscosityFields: '" + ex.Message + "'. Błąd z poziomu LabBookService.QuickSaveViscosityFields.",
                    "Błąd Zapisu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problem z zapisem do tabeli ExpViscosityFields: '" + ex.Message + "'. Błąd z poziomu LabBookService.QuickSaveViscosityFields.",
                    "Błąd połączenia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //public IList<ExpViscosityAdo> GetViscosityByLabBookId(long labBookId)
        //{
        //    ObservableListSource<ExpViscosityAdo> list = new ObservableListSource<ExpViscosityAdo>();

        //    try
        //    {
        //        string query = _getViscosityByLabBookId + labBookId.ToString();
        //        SqlCommand command = new SqlCommand(query, _connection);
        //        _connection.Open();
        //        SqlDataReader reader = command.ExecuteReader();

        //        if (reader.HasRows)
        //        {
        //            while (reader.Read())
        //            {
        //                long id = reader.GetInt64(0);
        //                long labId = reader.GetInt64(1);
        //                DateTime createDate = reader.GetDateTime(2);
        //                DateTime updateDate = reader.GetDateTime(3);
        //                double? pH = CommonFunctions.DBNullToDoubleConv(reader.GetValue(4));
        //                string visType = CommonFunctions.DBNullToStringConv(reader.GetValue(5));
        //                double? b1 = CommonFunctions.DBNullToDoubleConv(reader.GetValue(6));
        //                double? b5 = CommonFunctions.DBNullToDoubleConv(reader.GetValue(7));
        //                double? b10 = CommonFunctions.DBNullToDoubleConv(reader.GetValue(8));
        //                double? b20 = CommonFunctions.DBNullToDoubleConv(reader.GetValue(9));
        //                double? b30 = CommonFunctions.DBNullToDoubleConv(reader.GetValue(10));
        //                double? b40 = CommonFunctions.DBNullToDoubleConv(reader.GetValue(11));
        //                double? b50 = CommonFunctions.DBNullToDoubleConv(reader.GetValue(12));
        //                double? b60 = CommonFunctions.DBNullToDoubleConv(reader.GetValue(13));
        //                double? b70 = CommonFunctions.DBNullToDoubleConv(reader.GetValue(14));
        //                double? b80 = CommonFunctions.DBNullToDoubleConv(reader.GetValue(15));
        //                double? b90 = CommonFunctions.DBNullToDoubleConv(reader.GetValue(16));
        //                double? b100 = CommonFunctions.DBNullToDoubleConv(reader.GetValue(17));
        //                string bComment = CommonFunctions.DBNullToStringConv(reader.GetValue(18));
        //                string bDisk = CommonFunctions.DBNullToStringConv(reader.GetValue(19));
        //                double? bxv = CommonFunctions.DBNullToDoubleConv(reader.GetValue(20));
        //                string bxrpm = CommonFunctions.DBNullToStringConv(reader.GetValue(21));
        //                string brookXDisc = CommonFunctions.DBNullToStringConv(reader.GetValue(22));
        //                double? krebs = CommonFunctions.DBNullToDoubleConv(reader.GetValue(23));
        //                string krebsComment = CommonFunctions.DBNullToStringConv(reader.GetValue(24));
        //                double? ici = CommonFunctions.DBNullToDoubleConv(reader.GetValue(25));
        //                string iciDisc = CommonFunctions.DBNullToStringConv(reader.GetValue(26));
        //                string iciComment = CommonFunctions.DBNullToStringConv(reader.GetValue(27));
        //                string temp = CommonFunctions.DBNullToStringConv(reader.GetValue(28));

        //                ExpViscosityAdo visc = new ExpViscosityAdo(id, labBookId, createDate, updateDate, pH, visType, b1, b5, b10,
        //                        b20, b30, b40, b50, b60, b70, b80, b90, b100, bComment, bDisk, bxv, bxrpm, brookXDisc, krebs, krebsComment,
        //                        ici, iciDisc, iciComment, temp);

        //                list.Add(visc);
        //            }
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        MessageBox.Show("Problem z połączeniem z serwerem. Prawdopodobnie serwer jest wyłączony, błąd w nazwie serwera lub dostępie do bazy: '" + ex.Message + "'. Błąd z poziomu MaterialRepository - pobieranie surowców.",
        //            "Błąd połaczenia", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Problem z połączeniem z serwerem. Prawdopodobnie serwer jest wyłączony: '" + ex.Message + "'. Błąd z poziomu MaterialRepository - pobieranie surowców.",
        //            "Błąd połączenia", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        if (_connection.State == ConnectionState.Open)
        //            _connection.Close();
        //    }
        //    return list;
        //}

        //public bool Save(ExpViscosity viscosity)
        //{
        //    bool result = true;

        //    using (SqlCommand cmd = new SqlCommand())
        //    {
        //        try
        //        {
        //            cmd.Connection = _connection;
        //            cmd.CommandText = SaveViscositySql;
        //            cmd.Parameters.AddWithValue("@labbook_id", viscosity.LabBookId);
        //            cmd.Parameters.AddWithValue("@date_created", viscosity.DateCreated);
        //            cmd.Parameters.AddWithValue("@date_update", viscosity.DateUpdate);

        //            FillCmdParameters(viscosity, cmd);

        //            _connection.Open();
        //            cmd.ExecuteNonQuery();
        //        }
        //        catch (SqlException ex)
        //        {
        //            MessageBox.Show("Problem z połączeniem z serwerem. Prawdopodobnie serwer jest wyłączony, błąd w nazwie serwera lub dostępie do bazy: '" + ex.Message + "'. Błąd z poziomu MaterialRepository - pobieranie surowców.",
        //                "Błąd połaczenia", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            result = false;
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show("Problem z połączeniem z serwerem. Prawdopodobnie serwer jest wyłączony: '" + ex.Message + "'. Błąd z poziomu MaterialRepository - pobieranie surowców.",
        //                "Błąd połączenia", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            result = false;
        //        }
        //        finally
        //        {
        //            if (_connection.State == ConnectionState.Open)
        //                _connection.Close();
        //        }
        //    }
        //    return result;
        //}

        //public bool Update(ExpViscosity viscosity)
        //{
        //    bool result = true;

        //    using (SqlCommand cmd = new SqlCommand())
        //    {
        //        try
        //        {
        //            cmd.Connection = _connection;
        //            cmd.CommandText = UpdateViscositySQL;
        //            cmd.Parameters.AddWithValue("@labbook_id", viscosity.LabBookId);
        //            cmd.Parameters.AddWithValue("@date_update", viscosity.DateUpdate);
        //            cmd.Parameters.AddWithValue("@id", viscosity.Id);

        //            FillCmdParameters(viscosity, cmd);

        //            _connection.Open();
        //            cmd.ExecuteNonQuery();
        //        }
        //        catch (SqlException ex)
        //        {
        //            MessageBox.Show("Problem z połączeniem z serwerem. Prawdopodobnie serwer jest wyłączony, błąd w nazwie serwera lub dostępie do bazy: '" + ex.Message + "'. Błąd z poziomu MaterialRepository - pobieranie surowców.",
        //                "Błąd połaczenia", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            result = false;
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show("Problem z połączeniem z serwerem. Prawdopodobnie serwer jest wyłączony: '" + ex.Message + "'. Błąd z poziomu MaterialRepository - pobieranie surowców.",
        //                "Błąd połączenia", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            result = false;
        //        }
        //        finally
        //        {
        //            if (_connection.State == ConnectionState.Open)
        //                _connection.Close();
        //        }
        //    }
        //    return result;
        //}

        //private void FillCmdParameters(ExpViscosity viscosity, SqlCommand cmd)
        //{
        //    cmd.Parameters.AddWithValue("@pH", viscosity.PH ?? (object)DBNull.Value);
        //    cmd.Parameters.AddWithValue("@vis_type", viscosity.VisType ?? (object)DBNull.Value);
        //    cmd.Parameters.AddWithValue("@brook_1", viscosity.Brook1 ?? (object)DBNull.Value);
        //    cmd.Parameters.AddWithValue("@brook_5", viscosity.Brook5 ?? (object)DBNull.Value);
        //    cmd.Parameters.AddWithValue("@brook_10", viscosity.Brook10 ?? (object)DBNull.Value);
        //    cmd.Parameters.AddWithValue("@brook_20", viscosity.Brook20 ?? (object)DBNull.Value);
        //    cmd.Parameters.AddWithValue("@brook_30", viscosity.Brook30 ?? (object)DBNull.Value);
        //    cmd.Parameters.AddWithValue("@brook_40", viscosity.Brook40 ?? (object)DBNull.Value);
        //    cmd.Parameters.AddWithValue("@brook_50", viscosity.Brook50 ?? (object)DBNull.Value);
        //    cmd.Parameters.AddWithValue("@brook_60", viscosity.Brook60 ?? (object)DBNull.Value);
        //    cmd.Parameters.AddWithValue("@brook_70", viscosity.Brook70 ?? (object)DBNull.Value);
        //    cmd.Parameters.AddWithValue("@brook_80", viscosity.Brook80 ?? (object)DBNull.Value);
        //    cmd.Parameters.AddWithValue("@brook_90", viscosity.Brook90 ?? (object)DBNull.Value);
        //    cmd.Parameters.AddWithValue("@brook_100", viscosity.Brook100 ?? (object)DBNull.Value);
        //    cmd.Parameters.AddWithValue("@brook_comment", viscosity.BrookComment ?? (object)DBNull.Value);
        //    cmd.Parameters.AddWithValue("@brook_disc", viscosity.BrookDisc ?? (object)DBNull.Value);
        //    cmd.Parameters.AddWithValue("@brook_x_vis", viscosity.BrookXVis ?? (object)DBNull.Value);
        //    cmd.Parameters.AddWithValue("@brook_x_rpm", viscosity.BrookXRpm ?? (object)DBNull.Value);
        //    cmd.Parameters.AddWithValue("@brook_x_disc", viscosity.BrookXDisc ?? (object)DBNull.Value);
        //    cmd.Parameters.AddWithValue("@krebs", viscosity.Krebs ?? (object)DBNull.Value);
        //    cmd.Parameters.AddWithValue("@krebs_comment", viscosity.KrebsComment ?? (object)DBNull.Value);
        //    cmd.Parameters.AddWithValue("@ici", viscosity.Ici ?? (object)DBNull.Value);
        //    cmd.Parameters.AddWithValue("@ici_disc", viscosity.IciDisc ?? (object)DBNull.Value);
        //    cmd.Parameters.AddWithValue("@ici_comment", viscosity.IciComment ?? (object)DBNull.Value);
        //    cmd.Parameters.AddWithValue("@temp", viscosity.Temp ?? (object)DBNull.Value);
        //}

    }
}
