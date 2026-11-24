Alex Lafuente Rocabado

Mi proceso
Trabajo vendiendo laptops nuevas y seminuevas. Hoy no tenemos un sistema: todo el registro de equipos (qué hay, a qué precio, cuál se vendió) se anota a mano por escrito. 
Los jefes manejan unos 40 a 50 equipos y en el depósito hay más. 
Este repositorio recoge cómo fui usando lo que aprendí en la materia (Ingeniería de Sistemas) para pensar ese proceso con datos y estructuras en lugar de papel.

Cómo está organizado el repositorio

practicas/: prácticas de clase (C3, C4, C5, C6).
  - C5: torneo de ordenamientos (burbuja/inserción contra MergeSort/QuickSort) con tabla de tiempos e informe. A 10.000 datos medí unos 292 ms el cuadrático contra ~1,7 ms MergeSort y ~1,2 ms QuickSort.
  - C6: elección argumentada del algoritmo de ordenamiento para los datos de mi caso, apoyada en la evidencia de C5.
- Hitos/h2/: estructuras de datos para mi caso.
  - `Inventario.md`: datos de mi caso, operaciones que hago (buscar por código, insertar, borrar, el más barato, rango de precio, recorrer en orden) y cuáles hago más veces.
  - `Estructura.md`: elegí un diccionario (hash) por código para buscar/insertar/borrar y un árbol balanceado (`SortedSet`) por precio para el menor, los rangos y el orden, con el costo O de cada operación.
  - `Medicion.md`: el mismo problema con lista (ingenua) y diccionario (adecuada), cuatro tamaños que se duplican, con protocolo (calentar, repetir 3 veces, promediar), ruido y conclusión.
Cómo leer las mediciones
Cada tabla de medición declara el protocolo (corrida de calentamiento descartada y promedio de 3 repeticiones), indica el ruido y termina con una conclusión honesta.
Con mis 40–50 equipos reales casi cualquier estructura responde al instante; la elección importa si el registro crece.
