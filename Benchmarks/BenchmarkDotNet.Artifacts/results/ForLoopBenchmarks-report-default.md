
BenchmarkDotNet-Dev=v0.9.6.0+
OS=Windows
Processor=?, ProcessorCount=8
Frequency=2338337 ticks, Resolution=427.6544 ns, Timer=TSC
HostCLR=CORE, Arch=64-bit RELEASE [RyuJIT]
JitModules=?
1.0.0-preview1-002702

Runtime=Core  Platform=X64  Jit=RyuJit  

       Method | Length |        Median |    StdDev | Scaled |    Delta |
------------- |------- |-------------- |---------- |------- |--------- |
 **ArrayForLoop** |      **1** |     **2.5802 ns** | **0.0000 ns** |   **1.00** | **Baseline** |
 SliceForLoop |      1 |     3.2276 ns | 0.0000 ns |   1.25 |    25.1% |
  ListForLoop |      1 |     4.3056 ns | 0.0000 ns |   1.67 |    66.9% |
 **ArrayForLoop** |     **10** |    **30.7843 ns** | **0.0000 ns** |   **1.00** | **Baseline** |
 SliceForLoop |     10 |    27.8531 ns | 0.0000 ns |   0.90 |    -9.5% |
  ListForLoop |     10 |    34.7659 ns | 0.0000 ns |   1.13 |    12.9% |
 **ArrayForLoop** |    **100** |   **305.8892 ns** | **0.0000 ns** |   **1.00** | **Baseline** |
 SliceForLoop |    100 |   261.3444 ns | 0.0000 ns |   0.85 |   -14.6% |
  ListForLoop |    100 |   350.3006 ns | 0.0000 ns |   1.15 |    14.5% |
 **ArrayForLoop** |   **1000** | **2,977.7594 ns** | **0.0000 ns** |   **1.00** | **Baseline** |
 SliceForLoop |   1000 | 2,537.7719 ns | 0.0000 ns |   0.85 |   -14.8% |
  ListForLoop |   1000 | 3,403.5769 ns | 0.0000 ns |   1.14 |    14.3% |
