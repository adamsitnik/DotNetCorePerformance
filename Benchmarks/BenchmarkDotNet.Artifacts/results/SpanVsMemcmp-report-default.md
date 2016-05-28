
BenchmarkDotNet-Dev=v0.9.6.0+
OS=Windows
Processor=?, ProcessorCount=8
Frequency=2338337 ticks, Resolution=427.6544 ns, Timer=TSC
HostCLR=CORE, Arch=64-bit RELEASE [RyuJIT]
JitModules=?
1.0.0-preview1-002702

Runtime=Core  Platform=X64  Jit=RyuJit  

             Method | ItemsCount |         Median |    StdDev | Scaled |    Delta |
------------------- |----------- |--------------- |---------- |------- |--------- |
             **MemCmp** |          **0** |      **8.4629 ns** | **0.0000 ns** |   **1.00** | **Baseline** |
 SliceSequenceEqual |          0 |     13.8191 ns | 0.0000 ns |   1.63 |    63.3% |
    SliceBlockEqual |          0 |     36.2417 ns | 0.0000 ns |   4.28 |   328.2% |
             **MemCmp** |          **1** |      **9.0026 ns** | **0.0000 ns** |   **1.00** | **Baseline** |
 SliceSequenceEqual |          1 |     14.5012 ns | 0.0000 ns |   1.61 |    61.1% |
    SliceBlockEqual |          1 |     47.2466 ns | 0.0000 ns |   5.25 |   424.8% |
             **MemCmp** |         **10** |     **10.9999 ns** | **0.0000 ns** |   **1.00** | **Baseline** |
 SliceSequenceEqual |         10 |     20.2351 ns | 0.0000 ns |   1.84 |    84.0% |
    SliceBlockEqual |         10 |     40.7803 ns | 0.0000 ns |   3.71 |   270.7% |
             **MemCmp** |        **100** |     **15.3966 ns** | **0.0000 ns** |   **1.00** | **Baseline** |
 SliceSequenceEqual |        100 |     67.2928 ns | 0.0000 ns |   4.37 |   337.1% |
    SliceBlockEqual |        100 |     60.2442 ns | 0.0000 ns |   3.91 |   291.3% |
             **MemCmp** |       **1000** |     **50.1913 ns** | **0.0000 ns** |   **1.00** | **Baseline** |
 SliceSequenceEqual |       1000 |    222.6113 ns | 0.0000 ns |   4.44 |   343.5% |
    SliceBlockEqual |       1000 |    104.4036 ns | 0.0000 ns |   2.08 |   108.0% |
             **MemCmp** |     **100000** |  **4,876.9602 ns** | **0.0000 ns** |   **1.00** | **Baseline** |
 SliceSequenceEqual |     100000 |  5,103.1075 ns | 0.0000 ns |   1.05 |     4.6% |
    SliceBlockEqual |     100000 |  5,171.9840 ns | 0.0000 ns |   1.06 |     6.0% |
             **MemCmp** |    **1000000** | **54,247.2658 ns** | **0.0000 ns** |   **1.00** | **Baseline** |
 SliceSequenceEqual |    1000000 | 55,423.8373 ns | 0.0000 ns |   1.02 |     2.2% |
    SliceBlockEqual |    1000000 | 54,865.8820 ns | 0.0000 ns |   1.01 |     1.1% |
