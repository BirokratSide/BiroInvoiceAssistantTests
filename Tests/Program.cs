using System;
using System.Net.Http;
using System.Threading;

using Common.utils;

namespace SystemTests
{
    class Program
    {
        static void Main(string[] args)
        {
            Tests.Tests tes = new Tests.Tests();

            tes.StartTestJustOne();

            Thread.Sleep(15000);

            tes.GetNextInvoiceTest();
        }
    }
}
