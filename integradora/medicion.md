Alex Lafuente Rocabado

I3 — Medición

1. Protocolo
- Lenguaje: C# (.NET ___), compilado en modo Release, máquina: ___ (CPU / RAM).
- Carga: `EjecutarCarga` (n paquetes al azar con semilla n, capacidad = un tercio del peso total).
- Por cada tamaño y por cada solución: 1 corrida de calentamiento (descartada) + 3 corridas medidas; se reporta el promedio.
- Se verificó que ambas soluciones devuelven la MISMA ganancia en cada tamaño.
 2. Ingenua vs mejorada

| n | Ingenua (ms) | vs fila anterior | Mejorada (ms) | vs fila anterior | misma ganancia |
|---|---|---|---|---|---|
| 18 | 40,569 | - | 0,102 | - | sí (511) |
| 20 | 175,604 | x4,33 | 0,153 | x1,51 | sí (520) |
| 22 | 746,754 | x4,25 | 0,231 | x1,51 | sí (743) |
| 24 | 3181,298 | x4,26 | 0,262 | x1,13 | sí (1040) |

Corridas individuales (para mostrar el ruido): ___

Conclusión
(Reescríbela con TUS números. Ideas para que sea honesta:)
- La ingenua se multiplica por ~___ cada +2, lo esperado es ~4 (porque 2^(n+2) = 4·2^n; con el factor n sale algo más, ~4,4). Coincide / no coincide porque ___.
- La mejorada crece mucho menos: su costo es O(n·C) y aquí C es un tercio del peso total, o sea C crece con n, así que el costo es casi cuadrático en n (≈ x1,2–1,3 por cada +2).
- Ruido: con tiempos muy chicos (menos de unos pocos ms) el reloj, el recolector de basura y otros procesos pesan tanto que los cocientes de la mejorada no son confiables; lo vi en que las 3 corridas variaron de ___ a ___ ms. Solo 3 corridas no alcanzan para afirmar diferencias finas.
- Aun con ese ruido, la diferencia entre las dos es de ___ órdenes de magnitud en n = ___, demasiado grande para ser ruido.

3. Mejorada con 1.000 paquetes y capacidad 10.000
Promedio de 3 corridas (tras calentamiento): ___ ms. (La tabla tiene 1.001 × 10.001 ≈ 10 millones de celdas.)

4. ¿Y si la capacidad fuera 1.000.000.000 de kg?
Mi solución cuesta O(n·C) en tiempo y en memoria, y C aparece como un VALOR, no como el tamaño de la entrada (el tamaño de C en bits es solo ~log₂ C ≈ 30). Por eso se llama pseudo-polinomial: es lineal en el valor de C pero exponencial en su tamaño en bits.
Con C = 10^9:
- Memoria: la tabla tendría (n+1)·(10^9+1) enteros; con n = 1.000 son ~10^12 celdas, ~4 TB. Ni una sola fila (~4 GB) es razonable, y en C# `new int[n+1, C+1]` lanzaría `OutOfMemoryException` antes de empezar.
- Tiempo: ~10^12 operaciones con n = 1.000, es decir, horas o días.
- Si C es mayor o igual que la suma de todos los pesos, se llevan todos los paquetes (O(n)).
- Hacer la tabla sobre la ganancia en vez de sobre los kg: dp[g] = mínimo peso para lograr ganancia g, con costo O(n · suma de ganancias), que es chico si las ganancias son pequeñas (aquí 10–99 Bs por paquete).
- Si n es pequeño (~40), "meet in the middle" en O(2^(n/2)) o ramificación y poda.
