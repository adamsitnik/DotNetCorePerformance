
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
 **ArrayObjectEnumerator** |      **1** |    **23.0499 ns** | **0.0000 ns** |   **1.00** | **Baseline** |
 SliceObjectEnumerator |      1 |    57.9466 ns | 0.0000 ns |   2.51 |   151.4% |
  ListObjectEnumerator |      1 |    29.1351 ns | 0.0000 ns |   1.26 |    26.4% |
 **ArrayObjectEnumerator** |     **10** |    **84.3073 ns** | **0.0000 ns** |   **1.00** | **Baseline** |
 SliceObjectEnumerator |     10 |   108.3210 ns | 0.0000 ns |   1.28 |    28.5% |
  ListObjectEnumerator |     10 |   108.9271 ns | 0.0000 ns |   1.29 |    29.2% |
 **ArrayObjectEnumerator** |    **100** |   **823.8347 ns** | **0.0000 ns** |   **1.00** | **Baseline** |
 SliceObjectEnumerator |    100 |   618.1289 ns | 0.0000 ns |   0.75 |   -25.0% |
  ListObjectEnumerator |    100 |   747.3437 ns | 0.0000 ns |   0.91 |    -9.3% |
 **ArrayObjectEnumerator** |   **1000** | **6,804.6740 ns** | **0.0000 ns** |   **1.00** | **Baseline** |
 SliceObjectEnumerator |   1000 | 5,610.0041 ns | 0.0000 ns |   0.82 |   -17.6% |
  ListObjectEnumerator |   1000 | 6,992.8430 ns | 0.0000 ns |   1.03 |     2.8% |
