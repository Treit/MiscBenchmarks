# Rotating an array
|                 Method | Amount |      Mean |     Error |   StdDev |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------- |------- |----------:|----------:|---------:|-------:|------:|------:|----------:|
|  RotateLeftWithReverse |      1 |  45.24 ns |  23.48 ns | 1.287 ns | 0.0185 |     - |     - |      80 B |
|     RotateLeftWithCopy |      1 |  97.30 ns | 102.40 ns | 5.613 ns | 0.0371 |     - |     - |     160 B |
| RotateLeftWithJuggling |      1 |  69.55 ns |  11.26 ns | 0.617 ns | 0.0185 |     - |     - |      80 B |
|  RotateLeftWithReverse |      4 |  48.31 ns |  12.02 ns | 0.659 ns | 0.0185 |     - |     - |      80 B |
|     RotateLeftWithCopy |      4 |  97.07 ns |  56.84 ns | 3.115 ns | 0.0371 |     - |     - |     160 B |
| RotateLeftWithJuggling |      4 |  80.26 ns |  88.90 ns | 4.873 ns | 0.0185 |     - |     - |      80 B |
|  RotateLeftWithReverse |     16 |  51.15 ns |  19.84 ns | 1.088 ns | 0.0185 |     - |     - |      80 B |
|     RotateLeftWithCopy |     16 |  94.61 ns |  58.89 ns | 3.228 ns | 0.0371 |     - |     - |     160 B |
| RotateLeftWithJuggling |     16 | 103.14 ns |  39.28 ns | 2.153 ns | 0.0185 |     - |     - |      80 B |
|  RotateLeftWithReverse |     24 |  50.64 ns |  39.41 ns | 2.160 ns | 0.0185 |     - |     - |      80 B |
|     RotateLeftWithCopy |     24 | 100.10 ns |  50.65 ns | 2.776 ns | 0.0371 |     - |     - |     160 B |
| RotateLeftWithJuggling |     24 |  74.47 ns |  52.45 ns | 2.875 ns | 0.0185 |     - |     - |      80 B |


