﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.logic
{
    interface IBirotestLogic
    {
        void InsertOpcija(string sifra, bool rih, string rihd, float rihk, float rihz, int rihc, string rihp);
        void InsertPartner(string sifra, string davcnaStevilka);
        void DeleteAllRecordsFromDatabase();
    }
}
