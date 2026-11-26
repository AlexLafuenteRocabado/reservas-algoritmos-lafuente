H2 - Medición
Problema
Buscar un equipo por su código en el registro de equipos. 
Es la operación que más se repite en mi caso, y la resuelvo con dos estructuras:
Ingenua: List<Equipo>, recorriendo la lista hasta encontrar el código (O(n)).
Adecuada: Dictionary<string, Equipo>, tabla hash (O(1) promedio).
Código: Medicion.cs (lenguaje C#).

Protocolo
Tamaños que se duplican: 10.000, 20.000, 40.000 y 80.000 equipos.
Por cada tamaño se hacen 2.000 consultas de códigos que existen, elegidos al azar con semilla fija (siempre las mismas).
Se hace un calentamiento antes de medir y se miden 3 corridas, y se promedian.
Se verifica que las dos estructuras encuentren exactamente los mismos equipos antes de comparar tiempos.
Se mide con Stopwatch. Los tiempos cambian según la máquina y tienen algo de ruido, así que importa la tendencia.
Resultados
n        List (ms)    Dictionary (ms)   x
10000        100,29           0,2550   393
20000        165,40           0,2994   552
40000        350,64           0,2467   1421
80000        728,73           0,3038   2398
Conclusión
El diccionario fue muchísimo más rápido que la lista. Al duplicar los equipos, el tiempo de la lista casi se duplicaba también (100, 165, 350 y 729 ms), como se espera de O(n), mientras que el diccionario se mantuvo casi igual (alrededor de 0,25 a 0,30 ms), como corresponde a O(1). Con 80.000 equipos fue unas 2.400 veces más rápido.

Con los 40 o 50 equipos de hoy la diferencia no se notaría, pero elijo el diccionario porque buscar por código es mi operación más frecuente y no se vuelve más lenta si el registro crece.
