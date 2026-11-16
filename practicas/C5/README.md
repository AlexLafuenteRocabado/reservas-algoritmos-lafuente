C5 - Torneo de algoritmos de ordenamiento

Objetivo
Comparar el rendimiento de tres algoritmos de ordenamiento: Burbuja, MergeSort y QuickSort, utilizando diferentes cantidades de datos.

Protocolo de medición
- Se utilizaron cantidades de 1.000, 5.000 y 10.000 elementos.
- Los tres algoritmos recibieron los mismos datos en cada prueba.
- Se realizó un calentamiento antes de medir.
- Se ejecutaron tres repeticiones por algoritmo y cantidad de datos.
- Se calculó el promedio de los tiempos obtenidos.
- Los tiempos se expresan en milisegundos.

Tabla de resultados

| Cantidad de datos | Burbuja (ms) | MergeSort (ms) | QuickSort (ms) |
|     1.000         | 2,2417 ms    | 0,3130 ms      | 0,1863 ms |
|     5.000         | 67,7936 ms   | 0,9263 ms      | 0,5303 ms |
|     10.000        | 292,4719 ms  | 1,7159 ms      | 1,1689 ms |

Conclusiones

El algoritmo cuadrático fue el más lento y empeoró muy rápido: al pasar de 5.000 a 10.000 datos su tiempo se multiplicó por 4,3 (de 67,8 a 292,5 ms), lo esperado en O(n²). En cambio, MergeSort y QuickSort casi solo duplicaron su tiempo (1,85 y 2,2 veces), como corresponde a O(n log n). Con 10.000 datos, MergeSort fue unas 170 veces más rápido que el cuadrático y QuickSort unas 250 veces.
