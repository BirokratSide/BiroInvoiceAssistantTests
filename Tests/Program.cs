using System;
using System.Net.Http;

using Common.utils;

namespace SystemTests
{
    class Program
    {
        static void Main(string[] args)
        {
            Tests.Tests tes = new Tests.Tests();

            tes.StartTest();
        }
    }
}
