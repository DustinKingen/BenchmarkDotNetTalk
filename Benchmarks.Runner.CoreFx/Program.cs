using System;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Validators;

namespace Benchmarks.Runner.CoreFx
{
    class Program
    {
        static void Main(string[] args)
        {
            //var summary = Example1();
            //var summary = Example2();
            var summary = Example3();
        }

        // Simple example
        static Summary Example1()
        {
            return BenchmarkRunner.Run<Md5VsSha256>();
        }

        // Example with manual config
        static Summary Example2()
        {
            return
                BenchmarkRunner
                    .Run<Md5VsSha256>(
                        ManualConfig
                            .Create(DefaultConfig.Instance)
                            .With(Job.RyuJitX64)
                            .With(Job.Core)
                            .With(ExecutionValidator.FailOnError));
        }

        static Summary Example3()
        {
            return BenchmarkRunner.Run<Md5VsSha256WithConfig>();
        }
    }
}