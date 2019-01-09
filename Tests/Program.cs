using System;
using System.Net.Http;
using System.Threading;

using Common.utils;
using Tests.tests;

namespace SystemTests
{
    class Program
    {
        static void Main(string[] args)
        {
            //HappyPathTest tst = new HappyPathTest();
            //tst.Start();

            SadPathTest tst = new SadPathTest();
            tst.Start();
        }
    }
}