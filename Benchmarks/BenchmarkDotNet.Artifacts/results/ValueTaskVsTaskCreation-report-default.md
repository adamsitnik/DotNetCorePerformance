
BenchmarkDotNet=v0.9.7.0
OS=Microsoft Windows NT 6.2.9200.0
Processor=Intel(R) Core(TM) i7-4700MQ CPU 2.40GHz, ProcessorCount=8
Frequency=2338327 ticks, Resolution=427.6562 ns, Timer=TSC
HostCLR=MS.NET 4.0.30319.42000, Arch=64-bit RELEASE [RyuJIT]
JitModules=clrjit-v4.6.1055.0

Runtime=Core  Platform=X64  Jit=RyuJit  

              Method |    Median |    StdDev | Scaled |    Delta |    Gen 0 | Gen 1 | Gen 2 | Bytes Allocated/Op |
-------------------- |---------- |---------- |------- |--------- |--------- |------ |------ |------------------- |
      TaskFromResult | 9.6268 ns | 0.1796 ns |   1.00 | Baseline | 9.793,00 |     - |     - |              31,43 |
       ValueTaskCtor | 1.6605 ns | 0.0567 ns |   0.17 |   -82.8% |        - |     - |     - |               0,00 |
 ValueTaskFromResult | 1.7420 ns | 0.1672 ns |   0.18 |   -81.9% |        - |     - |     - |               0,00 |
