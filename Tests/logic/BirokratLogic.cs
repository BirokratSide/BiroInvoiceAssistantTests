using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

using Microsoft.Extensions.Configuration;
using Tests.data;
using Tests.data.structs;

namespace Tests.logic
{
    /*
    Responsibility: While birodata in data is a low level accessor to the birokrat database, This class exposes high level operations
                    that transform the database - like cleaning (deleting all relevant records) and adding a whole set of new
                    test cases.
    */
    public class BirokratLogic
    {
        IConfiguration Configuration;

        CBirokrat birokrat;
        TestCaseAdder TestCaseAdder;

        public BirokratLogic()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(StaticConst.SETTINGS_PATH);
            Configuration = builder.Build();

            // database
            birokrat = new CBirokrat();

            // test case adder
            TestCaseAdder = new TestCaseAdder(birokrat);

        }
        #region [public]
        public string[] AddTestRecordsToDatabase(string company_year, string tipPoste)
        {
            // returns the Oznake of added test cases
            return InsertNewTestCasesToDatabaseKPAndSlike(company_year, tipPoste);
        }

        public void AddHardcodedTestCase(string company_year) {
            TestCaseAdder.HardcodedCase();
        }

        public void DeleteAllTestRecords(string company_year)
        {

            if (company_year == "")
                throw new Exception("BirokratLogic.DeleteAllRecords: company_year cannot be empty string, because then all records will be deleted!!!");

            DeleteAllFromKnjigaPoste(company_year);
            DeleteAllFromSlike(company_year);
        }

        public List<SSlike> GetAllSlike(string company_year) {
            SListRequest lrq = new SListRequest();
            SListResponse<SSlike> s = birokrat.Slike.List(new SListRequest());
            List<SSlike> data = s.data;
            data = data.Where((x) => (x.YearCode == company_year)).ToList();
            return data;
        }
        #endregion

        #region [private]
        private void DeleteAllFromKnjigaPoste(string company_year)
        {
            List<SPostnaKnjiga> data = birokrat.PostnaKnjiga.List(new SListRequest()).data;
            data = data.Where((x) => (x.YearCode == company_year)).ToList();
            foreach (SPostnaKnjiga pk in data)
                birokrat.PostnaKnjiga.Delete(pk);
        }

        private void DeleteAllFromSlike(string company_year)
        {
            List<SSlike> data = birokrat.Slike.List(new SListRequest()).data;
            data = data.Where((x) => (x.YearCode == company_year)).ToList();
            foreach (SSlike slk in data)
                birokrat.Slike.Delete(slk);
        }

        private string[] InsertNewTestCasesToDatabaseKPAndSlike(string company_year, string TipPoste)
        {
            string directory = Configuration.GetValue<string>("HappyPathInputDirectory");
            string[] fileArray = Directory.GetFiles(directory, "*.pdf");

            // add new records into the database
            int num_recs = Configuration.GetValue<int>("Testing:NumCases");
            string[] oznake = new string[num_recs];
            for (int i = 0; i < num_recs; i++)
            {
                string date = DateTime.Now.ToString("yyyyMMdd") + "0000";
                oznake[i] = TestCaseAdder.AddTestCaseToDatabase(date, (short)i, company_year, fileArray[i], TipPoste);
            }
            return oznake;
        }
        #endregion
    }
}
