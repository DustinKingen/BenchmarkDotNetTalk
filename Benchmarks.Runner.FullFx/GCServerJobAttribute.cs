using System;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;

namespace Benchmarks.Runner.FullFx
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Assembly)]
    public class GCServerJobAttribute : Attribute, IConfigSource
    {
        public GCServerJobAttribute()
        {
            var job = new Job("GCServerJob", RunMode.Default);
            job.Env.Gc.Server = true;
            Config = ManualConfig.CreateEmpty().With(job);
        }

        public IConfig Config { get; }
    }
}