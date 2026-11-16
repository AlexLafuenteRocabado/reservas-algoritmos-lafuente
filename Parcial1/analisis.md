F1  O(n)  Un solo ciclo que hace n iteraciones con trabajo constante en cada una. |
F2  O(n²)  Dos ciclos anidados que comparan todos los pares (i, j) con i < j, es decir n(n−1)/2 comparaciones. |
F3  O(log n) k se divide a la mitad en cada vuelta, así que llega a 1 después de ≈ log₂ n iteraciones. |
F4  O(n log n)  El ciclo externo hace n vueltas y en cada una el interno duplica k hasta llegar a n, o sea ≈ log₂ n iteraciones: n · log n. |
