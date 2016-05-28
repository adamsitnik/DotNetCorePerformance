
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
 **ArrayObjectEnumerator** |      **1** |    **22.4380 ns** | **0.0000 ns** |   **1.00** | **Baseline** |
 SliceObjectEnumerator |      1 |    57.8512 ns | 0.0000 ns |   2.58 |   157.8% |
  ListObjectEnumerator |      1 |    29.8903 ns | 0.0000 ns |   1.33 |    33.2% |
 **ArrayObjectEnumerator** |     **10** |    **87.3241 ns** | **0.0000 ns** |   **1.00** | **Baseline** |
 SliceObjectEnumerator |     10 |   125.2061 ns | 0.0000 ns |   1.43 |    43.4% |
  ListObjectEnumerator |     10 |   121.5998 ns | 0.0000 ns |   1.39 |    39.3% |
 **ArrayObjectEnumerator** |    **100** |   **734.2112 ns** | **0.0000 ns** |   **1.00** | **Baseline** |
 SliceObjectEnumerator |    100 |   752.4336 ns | 0.0000 ns |   1.02 |     2.5% |
  ListObjectEnumerator |    100 |   874.8460 ns | 0.0000 ns |   1.19 |    19.2% |
 **ArrayObjectEnumerator** |   **1000** | **7,501.3220 ns** | **0.0000 ns** |   **1.00** | **Baseline** |
 SliceObjectEnumerator |   1000 | 7,271.4748 ns | 0.0000 ns |   0.97 |    -3.1% |
  ListObjectEnumerator |   1000 | 8,339.2925 ns | 0.0000 ns |   1.11 |    11.2% |
|    13.5% |
