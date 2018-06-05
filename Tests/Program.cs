using System;
using System.Net.Http;
using System.Threading;

using Common.utils;
using Tests;

namespace SystemTests
{
    class Program
    {
        static void Main(string[] args)
        {
            TestCaseAdder tca = new TestCaseAdder();
            tca.AddHardcodedTestCaseToKnjigaPoste();

            /*
            Tests.Tests tes = new Tests.Tests();

            tes.StartTestJustOne();

            Thread.Sleep(15000);

            tes.GetNextInvoiceTest();
            */
        }
    }
}
