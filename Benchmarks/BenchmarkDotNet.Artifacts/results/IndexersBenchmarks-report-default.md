
BenchmarkDotNet-Dev=v0.9.6.0+
OS=Windows
Processor=?, ProcessorCount=8
Frequency=2338337 ticks, Resolution=427.6544 ns, Timer=TSC
HostCLR=CORE, Arch=64-bit RELEASE [RyuJIT]
JitModules=?
1.0.0-preview1-002702

Runtime=Core  Platform=X64  Jit=RyuJit  

       Method | Length |    Median |    StdDev | Scaled |    Delta |
------------- |------- |---------- |---------- |------- |--------- |
 **ArrayIndexer** |      **1** | **0.3122 ns** | **0.0000 ns** |   **1.00** | **Baseline** |
 SliceIndexer |      1 | 0.3720 ns | 0.0000 ns |   1.19 |    19.2% |
  ListIndexer |      1 | 1.0255 ns | 0.0000 ns |   3.28 |   228.5% |
 **ArrayIndexer** |     **10** | **0.3292 ns** | **0.0000 ns** |   **1.00** | **Baseline** |
 SliceIndexer |     10 | 0.3077 ns | 0.0000 ns |   0.93 |    -6.6% |
  ListIndexer |     10 | 0.9509 ns | 0.0000 ns |   2.89 |   188.8% |
 **ArrayIndexer** |    **100** | **0.3098 ns** | **0.0000 ns** |   **1.00** | **Baseline** |
 SliceIndexer |    100 | 0.2974 ns | 0.0000 ns |   0.96 |    -4.0% |
  ListIndexer |    100 | 0.8913 ns | 0.0000 ns |   2.88 |   187.7% |
 **ArrayIndexer** |   **1000** | **0.3258 ns** | **0.0000 ns** |   **1.00** | **Baseline** |
 SliceIndexer |   1000 | 0.3512 ns | 0.0000 ns |   1.08 |     7.8% |
  ListIndexer |   1000 | 0.9817 ns | 0.0000 ns |   3.01 |   201.3% |
