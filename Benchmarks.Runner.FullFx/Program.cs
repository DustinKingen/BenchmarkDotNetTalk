using System;
using BenchmarkDotNet.Running;

namespace Benchmarks.Runner.FullFx
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<Md5VsSha256>();
        }
    }
}