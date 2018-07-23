using System;
using System.Collections.Generic;
using System.Text;

using Tests.birotest;

namespace Tests.logic
{
    class BirotestLogic : IBirotestLogic
    {

        BiroInvoiceAssistantTestingOnlyContext context;

        public BirotestLogic() {
            context = new BiroInvoiceAssistantTestingOnlyContext();
        }

        public void DeleteAllRecordsFromDatabase() {
            // remove all partners

            // remove all options
        }

        public void InsertPartner(string sifra, string davcnaStevilka) {
            // insert the specified partner
        }

        public void InsertOpcija(string sifra, bool rih, string rihd, float rihk, float rihz, int rihc, string rihp) {
            // insert all of these options for the specified partner
        }
    }
}
