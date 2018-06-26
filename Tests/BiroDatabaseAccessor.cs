using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Common.utils;

namespace SystemTests
{
    class BiroDatabaseAccessor
    {
            CMsSqlConnection sqlConnection;

            public BiroDatabaseAccessor(CMsSqlConnection conn)
            {
                sqlConnection = conn;
            }

            #region [public]
            public List<SPlacilo> retrieveValidationRecordsKnjigaPoste(int countOfTopRecordsToRetrieve)
            {
                string sql = getValidationRecordsKnjigaPosteSqlString();
                sql = String.Format(sql, countOfTopRecordsToRetrieve);
                IDbCommand cmd = sqlConnection.GenerateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                DataTable dt = sqlConnection.ExecDataTable(cmd);

                List<SPlacilo> lstResult = new List<SPlacilo>();
                foreach (DataRow dr in dt.Rows)
                {
                    lstResult.Add(SPlacilo.FromOnlySlikaDataRow(dr));
                }
                return lstResult;
            }

            public List<SPlacilo> retrieveValidationRecordsPlacila(int countOfTopRecordsToRetrieve)
            {
                string sql = getValidationRecordsPlacilaSqlString();
                sql = String.Format(sql, countOfTopRecordsToRetrieve);
                IDbCommand cmd = sqlConnection.GenerateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                DataTable dt = sqlConnection.ExecDataTable(cmd);

                List<SPlacilo> lstResult = new List<SPlacilo>();
                foreach (DataRow dr in dt.Rows)
                {
                    lstResult.Add(new SPlacilo(dr));
                }
                return lstResult;
            }
            #endregion

            #region [private]

            private string getValidationRecordsKnjigaPosteSqlString()
            {
                string query = @"
            use [biro16010264]
                    SELECT TOP({0}) 

                    Slike.[Oznaka] as SlikaOznaka, 
                    Slike.[RecNo] as SlikaRecNo, 
                    Slike.[Vrsta] as SlikaVrsta,
                    Slike.[Vsebina] as SlikaVsebina,
                    Slike.[DatumVnosa] as SlikaDatumVnosa
            
                    from [Slike], [PostnaKnjiga]
                    where [Slike].[Vrsta] like '%Pošta%'
                    and [Slike].[DatumVnosa] = [PostnaKnjiga].[DatumVnosa]

                    and [Slike].[DatumVnosa] like '%2505%'";
                return query;
            
        }

        private string getValidationRecordsPlacilaSqlString()
            {
                string query = @"
            SELECT TOP({0}) 

            PA.[DavcnaStevilka] as VAT_ID_BUYER,
            PL.[Znesek] as GROSS, 
            PL.[StevilkaDokumenta] as INV_NUM,
            PL.[DatumRacuna] as INV_DATE, 
            PL.[DatumZapadlosti] as PAY_UNTIL,
            PL.[SklicOdobritve1] AS SKLIC,
            PL.[SklicOdobritve2] AS REFERENCE,

            SL.[Vsebina] as SlikaVsebina,
            SL.[Oznaka] as SlikaOznaka, 
            SL.[RecNo] as SlikaRecNo, 
            SL.[Vrsta] as SlikaVrsta,
            PL.[VDobroRacuna],
            PL.[NamenNakazila1],
            SL.[DatumVnosa] as SlikaDatumVnosa

            FROM [biro16010264].[dbo].[Placila] PL, [biro16010264].[dbo].[Slike] SL, [biro16010264].[dbo].[Partner] PA

            WHERE SL.[Oznaka] = PL.[StevilkaText]
            AND SL.[Vrsta] IN('Placila\PDF', 'Placila')
            AND PL.[Partner] = PA.[Sifra]

            ORDER BY SL.[Oznaka], SL.[RecNo]";
                return query;
            }
            #endregion

        }
}
