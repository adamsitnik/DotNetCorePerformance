
BenchmarkDotNet=v0.9.6.0
OS=Microsoft Windows NT 6.3.9600.0
Processor=Intel(R) Core(TM) i7-4700MQ CPU @ 2.40GHz, ProcessorCount=8
Frequency=2338328 ticks, Resolution=427.6560 ns, Timer=TSC
HostCLR=DNX MS.NET 4.0.30319.42000, Arch=32-bit RELEASE [AttachedDebugger]
JitModules=clrjit-v4.6.1055.0
.NET Command Line Tools (1.0.0-beta-001603)

Runtime=Core  Platform=X64  Jit=RyuJit  

      Method | Count |          Median | Scaled |    Delta |    Gen 0 | Gen 1 | Gen 2 | Bytes Allocated/Op |
------------ |------ |---------------- |------- |--------- |--------- |------ |------ |------------------- |
        **Task** |     **0** |      **12.2028 ns** |   **1.00** | **Baseline** |     **0,08** |     **-** |     **-** |              **12,90** |
  Value Task |     0 |       1.1293 ns |   0.09 |   -90.7% |        - |     - |     - |               0,00 |
 Cached Task |     0 |       6.3427 ns |   0.52 |   -48.0% |        - |     - |     - |               0,00 |
        **Task** |    **10** |     **234.1733 ns** |   **1.00** | **Baseline** |     **1,98** |     **-** |     **-** |             **307,88** |
  Value Task |    10 |      20.0483 ns |   0.09 |   -91.4% |        - |     - |     - |               0,00 |
 Cached Task |    10 |     173.3850 ns |   0.74 |   -26.0% |     0,90 |     - |     - |             140,25 |
        **Task** |   **100** |   **2,236.2443 ns** |   **1.00** | **Baseline** |    **20,86** |     **-** |     **-** |           **3.241,42** |
  Value Task |   100 |     111.9440 ns |   0.05 |   -95.0% |        - |     - |     - |               0,01 |
 Cached Task |   100 |   1,714.6095 ns |   0.77 |   -23.3% |    10,37 |     - |     - |           1.612,77 |
        **Task** | **10000** | **221,396.7596 ns** |   **1.00** | **Baseline** | **2.078,00** |     **-** |     **-** |         **322.453,97** |
  Value Task | 10000 |   9,910.2309 ns |   0.04 |   -95.5% |        - |     - |     - |               0,62 |
 Cached Task | 10000 | 160,144.7476 ns |   0.72 |   -27.7% | 1.038,90 |     - |     - |         161.242,73 |
