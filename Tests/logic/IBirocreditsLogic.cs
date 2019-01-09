using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.logic
{
    public interface IBirocreditsLogic
    {
        void InsertOpcija(string sifra, bool rih, string rihd, float rihk, float rihz, int rihc, string rihp);
        void InsertPartner(string sifra, string davcnaStevilka);
        void DeleteAllRecordsFromDatabase();
    }
}
