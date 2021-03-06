﻿using System;
using BenchmarkDotNet.Characteristics;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Reports;
using JetBrains.Annotations;

namespace BenchmarkDotNet.Engines
{
    public interface IEngine : IDisposable
    {
        [NotNull]
        IHost Host { get; }

        void WriteLine();

        void WriteLine(string line);

        [NotNull]
        Job TargetJob { get; }

        long OperationsPerInvoke { get; }

        [CanBeNull]
        Action GlobalSetupAction { get; }

        [CanBeNull]
        Action GlobalCleanupAction { get; }

        [NotNull]
        Action<long> WorkloadAction { get; }

        [NotNull]
        Action<long> OverheadAction { get; }

        IResolver Resolver { get; }

        Measurement RunIteration(IterationData data);

        RunResults Run();
    }
}