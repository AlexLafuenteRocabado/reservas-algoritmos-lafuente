Alex Lafuente Rocababdo

EjecutarCarga registra los n pedidos y luego prepara los n. Generé los datos antes de medir y usé un receptor nuevo por corrida.
Hice un calentamiento y promedié tres corridas medidas con steady_clock, por método y tamaño.

| Pedidos | Ingenuo (ms) | Factor | Mejorado (ms) | Factor |

| 15.000 | 0.382         | —      | 8,016          | — |
| 30.000 | 1.551         | 4,051× | 17,529         | 2,19× |
| 60.000 | 6.147         | 3,963× | 44,066         | 2,51× |

El ingenuo casi cuadruplicó su tiempo al duplicar la carga, como se espera de O(n²). Su mayor promedio fue 6,147 segundos.  
El mejorado creció entre 2,19× y 2,51×, más cerca del patrón de O(n log n) que del cuadrático.  
El segundo salto del mejorado se alejó más del factor teórico. 
La variación puede venir del ruido de ejecución o de costos de memoria que el modelo asintótico no refleja.
Comprobé prioridad, desempate por llegada, conteo, consultas antes y después de preparar, y la devolución vacía.
