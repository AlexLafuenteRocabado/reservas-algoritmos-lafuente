Respueta a)
F1  O(n)  Un solo ciclo que hace n iteraciones con trabajo constante en cada una.
F2  O(n²)  Dos ciclos anidados que comparan todos los pares (i, j) con i < j, es decir n(n−1)/2 comparaciones.
F3  O(log n) k se divide a la mitad en cada vuelta, así que llega a 1 después de ≈ log₂ n iteraciones.
F4  O(n log n)  El ciclo externo hace n vueltas y en cada una el interno duplica k hasta llegar a n, o sea ≈ log₂ n iteraciones: n · log n.

b)
(i)   T(n) = 3 T(n/2) + n
a=3
b=2
d=1(n^1)
b^d=2^1=2
a>b corresponde a T(n)=O(nLogb^a) => O(nLog2^3)
(ii)  T(n) =   T(n/2) + n²
a=1
b=2
d=2(n^2)
b^d=2^2=4
a<b correcponde a T(n)=O(n^d) => O(n^2)
