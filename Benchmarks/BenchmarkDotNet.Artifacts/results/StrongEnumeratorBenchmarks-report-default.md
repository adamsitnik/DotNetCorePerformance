
BenchmarkDotNet-Dev=v0.9.6.0+
OS=Windows
Processor=?, ProcessorCount=8
Frequency=2338337 ticks, Resolution=427.6544 ns, Timer=TSC
HostCLR=CORE, Arch=64-bit RELEASE [RyuJIT]
JitModules=?
1.0.0-preview1-002702

Runtime=Core  Platform=X64  Jit=RyuJit  

                Method | Length |        Median |    StdDev | Scaled |    Delta |
---------------------- |------- |-------------- |---------- |------- |--------- |
 **ArrayStrongEnumerator** |      **1** |     **0.3165 ns** | **0.0000 ns** |   **1.00** | **Baseline** |
 SliceStrongEnumerator |      1 |     2.0746 ns | 0.0000 ns |   6.56 |   555.5% |
  ListStrongEnumerator |      1 |    18.0532 ns | 0.0000 ns |  57.05 | 5,604.6% |
 **ArrayStrongEnumerator** |     **10** |     **5.0330 ns** | **0.0000 ns** |   **1.00** | **Baseline** |
 SliceStrongEnumerator |     10 |     8.6140 ns | 0.0000 ns |   1.71 |    71.2% |
  ListStrongEnumerator |     10 |    39.2263 ns | 0.0000 ns |   7.79 |   679.4% |
 **ArrayStrongEnumerator** |    **100** |    **59.7021 ns** | **0.0000 ns** |   **1.00** | **Baseline** |
 SliceStrongEnumerator |    100 |    70.8085 ns | 0.0000 ns |   1.19 |    18.6% |
  ListStrongEnumerator |    100 |   297.4990 ns | 0.0000 ns |   4.98 |   398.3% |
 **ArrayStrongEnumerator** |   **1000** |   **485.2487 ns** | **0.0000 ns** |   **1.00** | **Baseline** |
 SliceStrongEnumerator |   1000 |   649.0315 ns | 0.0000 ns |   1.34 |    33.8% |
  ListStrongEnumerator |   1000 | 2,725.4515 ns | 0.0000 ns |   5.62 |   461.7% |
