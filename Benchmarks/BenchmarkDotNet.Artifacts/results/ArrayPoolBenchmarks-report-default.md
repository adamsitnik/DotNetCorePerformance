
BenchmarkDotNet-Dev=v0.9.6.0+
OS=Microsoft Windows NT 6.2.9200.0
Processor=Intel(R) Core(TM) i7-4700MQ CPU 2.40GHz, ProcessorCount=8
Frequency=2338337 ticks, Resolution=427.6544 ns, Timer=TSC
HostCLR=MS.NET 4.0.30319.42000, Arch=64-bit RELEASE [RyuJIT]
JitModules=clrjit-v4.6.1055.0

Runtime=Core  Platform=X64  Jit=RyuJit  

                                     Method |     Bytes |          Median | Scaled |    Delta | Gen 0 | Gen 1 | Gen 2 | Bytes Allocated/Op |
------------------------------------------- |---------- |---------------- |------- |--------- |------ |------ |------ |------------------- |
                                 **new byte[]** |       **100** |      **12.6966 ns** |   **1.00** | **Baseline** |  **0,00** |     **-** |     **-** |              **24,76** |
                          stackalloc byte[] |       100 |       7.4999 ns |   0.59 |   -40.9% |     - |     - |     - |               0,00 |
                     Marshal.AllocHGlobal() |       100 |      80.4921 ns |   6.34 |   534.0% |     - |     - |     - |               0,01 |
              ArrayPool<byte>.Shared.Rent() |       100 |      62.5581 ns |   4.93 |   392.7% |     - |     - |     - |               0,01 |
                DedicatedManagedPool.Rent() |       100 |      54.5687 ns |   4.30 |   329.8% |     - |     - |     - |               0,01 |
 NativeBufferPool<byte>.Shared.RentBuffer() |       100 |     180.6577 ns |  14.23 | 1,322.9% |     - |     - |     - |               0,02 |
                                 **new byte[]** |      **1000** |      **73.4506 ns** |   **1.00** | **Baseline** |  **0,00** |     **-** |     **-** |             **219,43** |
                          stackalloc byte[] |      1000 |      42.1420 ns |   0.57 |   -42.6% |     - |     - |     - |               0,00 |
                     Marshal.AllocHGlobal() |      1000 |      90.5203 ns |   1.23 |    23.2% |     - |     - |     - |               0,01 |
              ArrayPool<byte>.Shared.Rent() |      1000 |      62.3357 ns |   0.85 |   -15.1% |     - |     - |     - |               0,01 |
                DedicatedManagedPool.Rent() |      1000 |      51.9526 ns |   0.71 |   -29.3% |     - |     - |     - |               0,01 |
 NativeBufferPool<byte>.Shared.RentBuffer() |      1000 |     192.3572 ns |   2.62 |   161.9% |     - |     - |     - |               0,02 |
                                 **new byte[]** |     **10000** |     **707.5994 ns** |   **1.00** | **Baseline** |  **0,00** |     **-** |     **-** |           **2.760,29** |
                          stackalloc byte[] |     10000 |     406.5966 ns |   0.57 |   -42.5% |     - |     - |     - |               0,07 |
                     Marshal.AllocHGlobal() |     10000 |      84.4814 ns |   0.12 |   -88.1% |     - |     - |     - |               0,01 |
              ArrayPool<byte>.Shared.Rent() |     10000 |      62.1106 ns |   0.09 |   -91.2% |     - |     - |     - |               0,01 |
                DedicatedManagedPool.Rent() |     10000 |      52.2557 ns |   0.07 |   -92.6% |     - |     - |     - |               0,01 |
 NativeBufferPool<byte>.Shared.RentBuffer() |     10000 |     183.7644 ns |   0.26 |   -74.0% |     - |     - |     - |               0,02 |
                                 **new byte[]** |    **100000** |   **2,983.1854 ns** |   **1.00** | **Baseline** |     **-** |     **-** |  **0,00** |          **19.057,09** |
                          stackalloc byte[] |    100000 |   4,514.6782 ns |   1.51 |    51.3% |     - |     - |     - |               0,49 |
                     Marshal.AllocHGlobal() |    100000 |     503.7766 ns |   0.17 |   -83.1% |     - |     - |     - |               0,07 |
              ArrayPool<byte>.Shared.Rent() |    100000 |      62.5194 ns |   0.02 |   -97.9% |     - |     - |     - |               0,01 |
                DedicatedManagedPool.Rent() |    100000 |      52.9031 ns |   0.02 |   -98.2% |     - |     - |     - |               0,04 |
 NativeBufferPool<byte>.Shared.RentBuffer() |    100000 |     191.0568 ns |   0.06 |   -93.6% |     - |     - |     - |               0,02 |
                                 **new byte[]** |   **1000000** |  **14,993.7955 ns** |   **1.00** | **Baseline** |     **-** |     **-** |  **0,00** |         **166.672,98** |
                          stackalloc byte[] |   1000000 |  53,041.4601 ns |   3.54 |   253.8% |     - |     - |     - |               6,76 |
                     Marshal.AllocHGlobal() |   1000000 |     212.0584 ns |   0.01 |   -98.6% |     - |     - |     - |               0,03 |
              ArrayPool<byte>.Shared.Rent() |   1000000 |      65.5598 ns |   0.00 |   -99.6% |     - |     - |     - |               0,02 |
                DedicatedManagedPool.Rent() |   1000000 |      55.5784 ns |   0.00 |   -99.6% |     - |     - |     - |               0,32 |
 NativeBufferPool<byte>.Shared.RentBuffer() |   1000000 |     185.8842 ns |   0.01 |   -98.8% |     - |     - |     - |               0,02 |
                                 **new byte[]** |  **10000000** |  **70,736.7553 ns** |   **1.00** | **Baseline** |     **-** |     **-** |  **0,00** |       **1.739.007,49** |
                          stackalloc byte[] |  10000000 |              NA |      ? |        ? |     - |     - |     - |    +nieskończoność |
                     Marshal.AllocHGlobal() |  10000000 |  19,674.5539 ns |   0.28 |   -72.2% |     - |     - |     - |               1,87 |
              ArrayPool<byte>.Shared.Rent() |  10000000 |  74,719.2342 ns |   1.06 |     5.6% |     - |     - |  0,00 |       1.595.962,16 |
                DedicatedManagedPool.Rent() |  10000000 |      52.3630 ns |   0.00 |   -99.9% |     - |     - |  0,00 |               4,77 |
 NativeBufferPool<byte>.Shared.RentBuffer() |  10000000 |  20,949.5820 ns |   0.30 |   -70.4% |     - |     - |     - |               1,95 |
                                 **new byte[]** | **100000000** | **279,106.2756 ns** |   **1.00** | **Baseline** |     **-** |     **-** |  **0,00** |      **19.041.896,16** |
                          stackalloc byte[] | 100000000 |              NA |      ? |        ? |     - |     - |     - |    +nieskończoność |
                     Marshal.AllocHGlobal() | 100000000 | 163,163.3960 ns |   0.58 |   -41.5% |     - |     - |     - |              13,65 |
              ArrayPool<byte>.Shared.Rent() | 100000000 | 968,548.5748 ns |   3.47 |   247.0% |     - |     - |  0,00 |      19.976.664,22 |
                DedicatedManagedPool.Rent() | 100000000 |      52.2718 ns |   0.00 |  -100.0% |     - |     - |  0,00 |              40,01 |
 NativeBufferPool<byte>.Shared.RentBuffer() | 100000000 | 164,873.0737 ns |   0.59 |   -40.9% |     - |     - |     - |              14,89 |

Benchmarks with issues:
  ArrayPoolBenchmarks_AllocateWithStackalloc_X64_Jit-RyuJit_Runtime-Core_WarmupCount1_TargetCount1_LaunchCount1_Bytes-10000000
  ArrayPoolBenchmarks_AllocateWithStackalloc_X64_Jit-RyuJit_Runtime-Core_WarmupCount1_TargetCount1_LaunchCount1_Bytes-100000000
