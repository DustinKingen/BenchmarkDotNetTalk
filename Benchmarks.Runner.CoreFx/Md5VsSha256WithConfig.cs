using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Horology;
using BenchmarkDotNet.Jobs;

namespace Benchmarks.Runner.CoreFx
{
    [Config(typeof(Config))]
    public class Md5VsSha256WithConfig : Md5VsSha256
    {
        private class Config : ManualConfig
        {
            public Config()
            {
                Add(MemoryDiagnoser.Default);
                Add(
                    new Job("MySuperJob", RunMode.Dry, EnvMode.RyuJitX64)
                    {
                        Env = { Runtime = Runtime.Core },
                        Run = { LaunchCount = 5, IterationTime = TimeInterval.Millisecond * 200 },
                        Accuracy = { MaxRelativeError = 0.01 }
                    });

                // The same, using the .With() factory methods:
                Add(
                    Job.Dry
                       .With(Platform.X64)
                       .With(Jit.RyuJit)
                       .With(Runtime.Core)
                       .WithLaunchCount(5)
                       .WithIterationTime(TimeInterval.Millisecond * 200)
                       .WithMaxRelativeError(0.01)
                       .WithId("MySuperJob2")); // IMPORTANT: Id assignment should be the last call in the chain or the id will be lost.
            }
        }
    }
}