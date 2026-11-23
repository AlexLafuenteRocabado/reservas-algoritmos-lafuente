#H2 – Medición: estructura ingenua vs adecuada

Dado el registro de n equipos (código, marca, precio), atender 1.000 consultas "¿existe el equipo con este código?" (90% existen, 10% no).
Ingenua: lista con búsqueda lineal → O(n) por consulta.
Adecuada: diccionario (tabla hash) por código → O(1) promedio por consulta.
Protocolo
Una corrida de calentamiento descartada, luego 3 repeticiones y se promedian. 
Resultados
| n | Lista (ms) | x vs anterior | Diccionario (ms) | x vs anterior |
| 5.000 | 61,562 | - | 0,0454 | - |
| 10.000 | 162,990 | 2,65 | 0,0524 | 1,15 |
| 20.000 | 251,649 | 1,54 | 0,0535 | 1,02 |
| 40.000 | 502,356 | 2,00 | 0,0555 | 1,04 |

Conclusión
1. La lista tarda en promedio unas 2,1 veces más cada vez que duplico n (2,65; 1,54; 2,00), lo que coincide con O(n), que predice ×2.
2. El diccionario casi no cambia al duplicar n (entre ×1,02 y ×1,15), coherente con O(1). A 40.000 equipos la lista es unas 9.000 veces más lenta que el diccionario.
3. Ruido: las razones de la lista no son exactamente 2 (saltan de 2,65 a 1,54) y los tiempos del diccionario son de centésimas de milisegundo,
4. Mi caso real son unos 40–50 equipos: ahí la diferencia no se notaría. La estructura adecuada importa si el registro crece a miles.
