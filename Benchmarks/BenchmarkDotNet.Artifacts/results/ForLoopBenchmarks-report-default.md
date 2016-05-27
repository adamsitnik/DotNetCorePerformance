
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
 **ArrayForLoop** |      **1** |     **0.7080 ns** | **0.0000 ns** |   **1.00** | **Baseline** |
 SliceForLoop |      1 |     0.7402 ns | 0.0000 ns |   1.05 |     4.5% |
  ListForLoop |      1 |     2.8866 ns | 0.0000 ns |   4.08 |   307.7% |
 **ArrayForLoop** |     **10** |     **5.7671 ns** | **0.0000 ns** |   **1.00** | **Baseline** |
 SliceForLoop |     10 |     8.6025 ns | 0.0000 ns |   1.49 |    49.2% |
  ListForLoop |     10 |    14.8918 ns | 0.0000 ns |   2.58 |   158.2% |
 **ArrayForLoop** |    **100** |    **79.0418 ns** | **0.0000 ns** |   **1.00** | **Baseline** |
 SliceForLoop |    100 |    95.8191 ns | 0.0000 ns |   1.21 |    21.2% |
  ListForLoop |    100 |   145.4398 ns | 0.0000 ns |   1.84 |    84.0% |
 **ArrayForLoop** |   **1000** |   **697.2406 ns** | **0.0000 ns** |   **1.00** | **Baseline** |
 SliceForLoop |   1000 |   870.4886 ns | 0.0000 ns |   1.25 |    24.8% |
  ListForLoop |   1000 | 1,367.0733 ns | 0.0000 ns |   1.96 |    96.1% |
