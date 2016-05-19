
BenchmarkDotNet=v0.9.6.0
OS=Microsoft Windows NT 6.3.9600.0
Processor=Intel(R) Core(TM) i7-4700MQ CPU @ 2.40GHz, ProcessorCount=8
Frequency=2338328 ticks, Resolution=427.6560 ns, Timer=TSC
HostCLR=DNX MS.NET 4.0.30319.42000, Arch=32-bit RELEASE [AttachedDebugger]
JitModules=clrjit-v4.6.1055.0
.NET Command Line Tools (1.0.0-beta-001603)

Runtime=Core  Platform=X64  Jit=RyuJit  

                                                 Method |     Median | Scaled |    Delta |    Gen 0 | Gen 1 | Gen 2 | Bytes Allocated/Op |
------------------------------------------------------- |----------- |------- |--------- |--------- |------ |------ |------------------- |
          Creating instance of Task via Task.FromResult | 11.6702 ns |   1.00 | Baseline | 1.699,00 |     - |     - |              13,44 |
   Creating instance of Value Task via constructor call |  2.8916 ns |   0.25 |   -75.2% |        - |     - |     - |               0,00 |
 Creating instance of Value Task via call to FromResult |  2.9689 ns |   0.25 |   -74.6% |        - |     - |     - |               0,00 |
