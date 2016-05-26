
BenchmarkDotNet-Dev=v0.9.6.0+
OS=Microsoft Windows NT 6.2.9200.0
Processor=Intel(R) Core(TM) i7-4700MQ CPU 2.40GHz, ProcessorCount=8
Frequency=2338337 ticks, Resolution=427.6544 ns, Timer=TSC
HostCLR=MS.NET 4.0.30319.42000, Arch=64-bit RELEASE [RyuJIT]
JitModules=clrjit-v4.6.1055.0

Runtime=Core  Platform=X64  Jit=RyuJit  

                          Method |  Length |         Median | Scaled |    Delta |  Gen 0 | Gen 1 |     Gen 2 | Bytes Allocated/Op |
-------------------------------- |-------- |--------------- |------- |--------- |------- |------ |---------- |------------------- |
 **Allocating new array every time** |     **100** |     **12.8117 ns** |   **1.00** | **Baseline** |   **2,55** |     **-** |         **-** |              **21,67** |
     Renting array from the pool |     100 |     64.4245 ns |   5.03 |   402.9% |      - |     - |         - |               0,01 |
 **Allocating new array every time** |    **1000** |     **74.1064 ns** |   **1.00** | **Baseline** |  **22,24** |     **-** |         **-** |             **209,46** |
     Renting array from the pool |    1000 |     62.9374 ns |   0.85 |   -15.1% |      - |     - |         - |               0,01 |
 **Allocating new array every time** |   **10000** |    **656.8299 ns** |   **1.00** | **Baseline** | **217,71** |     **-** |         **-** |           **2.509,37** |
     Renting array from the pool |   10000 |     60.8015 ns |   0.09 |   -90.7% |      - |     - |         - |               0,01 |
 **Allocating new array every time** |  **100000** |  **3,032.0091 ns** |   **1.00** | **Baseline** |      **-** |     **-** |  **2.238,92** |          **19.057,09** |
     Renting array from the pool |  100000 |     63.0107 ns |   0.02 |   -97.9% |      - |     - |         - |               0,01 |
 **Allocating new array every time** | **1000000** | **14,356.6730 ns** |   **1.00** | **Baseline** |      **-** |     **-** | **16.368,00** |         **173.919,72** |
     Renting array from the pool | 1000000 |     60.3875 ns |   0.00 |   -99.6% |      - |     - |         - |               0,02 |
