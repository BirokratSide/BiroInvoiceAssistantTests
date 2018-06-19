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
            Tests.Tests tes = new Tests.Tests();

            tes.StartTestPlacila();

            tes.GetNextInvoiceTest();
        }
    }
}
