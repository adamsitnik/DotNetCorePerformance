
BenchmarkDotNet-Dev=v0.9.6.0+
OS=Microsoft Windows NT 6.2.9200.0
Processor=Intel(R) Core(TM) i7-4700MQ CPU 2.40GHz, ProcessorCount=8
Frequency=2338327 ticks, Resolution=427.6562 ns, Timer=TSC
HostCLR=MS.NET 4.0.30319.42000, Arch=64-bit RELEASE [RyuJIT]
JitModules=clrjit-v4.6.1055.0

Runtime=Core  Platform=X64  Jit=RyuJit  

    Method |     Median |    StdDev | Scaled |    Delta |  Gen 0 | Gen 1 | Gen 2 | Bytes Allocated/Op |
---------- |----------- |---------- |------- |--------- |------- |------ |------ |------------------- |
      Task | 14.9138 ms | 0.0000 ms |   1.00 | Baseline | 162,00 |     - |     - |         807.899,48 |
 ValueTask | 12.7492 ms | 0.0000 ms |   0.85 |   -14.5% |  10,00 |     - |     - |          71.935,35 |
