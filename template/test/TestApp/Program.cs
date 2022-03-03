﻿using System;
using ProtoBuf.Grpc.Client;

namespace TestApp
{
    public class Program
    {
        private static void Main()
        {
            GrpcClientFactory.AllowUnencryptedHttp2 = true;

            Console.Write("Press enter to start");
            Console.ReadLine();

            Console.WriteLine("End");
            Console.ReadLine();
        }
    }
}
