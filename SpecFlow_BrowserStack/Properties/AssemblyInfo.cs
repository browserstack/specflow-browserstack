using NUnit.Framework;

// For more details on LevelOfParallelism Attribute review NUnit documentation- https://github.com/nunit/docs/wiki/LevelOfParallelism-Attribute
[assembly: LevelOfParallelism(5)]
[assembly: Parallelizable(ParallelScope.Fixtures)]
