P1.3 — Elegir
Datos: 300.000 números de historia clínica y 5.000 consultas.
Costo de cada opción
| Opción | Qué hace | Operaciones aprox. |
| 1 Recorre todo el listado en cada consulta | 5.000 × 300.000 = 1.500.000.000 |
| 2 Ordena una vez (n log n) y busca con búsqueda binaria | 5.500.000 + 91.000 ≈ 5.600.000 |
| 3 Ordena una vez (cuadrático) y busca con búsqueda binaria | 300.000² = 90.000.000.000 |
La opción 2 es muchísimo más barata que las otras dos.
Mi elección
Opción 2: ordenar una vez en la mañana con un algoritmo n log n y luego buscar con búsqueda binaria.
Como la memoria es limitada, el ordenamiento tiene que hacerse sobre el mismo listado, sin copiarlo (por ejemplo QuickSort). MergeSort no sirve aquí porque necesita un arreglo extra del mismo tamaño.
