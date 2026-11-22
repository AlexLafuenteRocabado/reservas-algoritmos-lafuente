Alex LafuenteRocabado  

Uso una cola de prioridad con la clave (plazo, orden de llegada) y un conjunto ordenado para buscar por nombre. Al registrar, agrego el pedido a ambos.
Al preparar, saco el primero de la cola y borro su nombre del conjunto. Si dos plazos coinciden, gana el menor número de llegada.

Operación	        Veces por jornada	  Estructura	                                            Costo O
Registrar	        120.000	            Heap por (plazo, llegada) + insertar nombre en HashSet	O(log n)
PrepararSiguiente	120.000            	Extraer mínimo del heap + quitar nombre del HashSet	    O(log n)
EstaPendiente	    40.000	            HashSet de nombres pendientes	                          O(1) promedio
Pendientes	      (las que sean)	    Contador (o Count del HashSet)	                        O(1)

m es la cantidad de pendientes en ese momento. Una inserción aislada en la cola puede costar O(m) si el vector interno necesita crecer.
Cuento cada comparación de nombres como una operación. Ambas soluciones usan O(m) de memoria.
Supuse una jornada de carga alta para estimar los costos. Llegan los 120.000 pedidos, luego se hacen las 40.000 consultas a lista llena y al final se preparan todos.
Lista simple. Buscar el mínimo en cada preparación suma 120.000 × 119.999 / 2 = 7.199.940.000 comparaciones.
Las consultas pueden sumar 40.000 × 120.000 = 4.800.000.000. Son aproximadamente 12.000 millones de comparaciones, más las inserciones y los desplazamientos al borrar.
Cola y conjunto. Hay 240.000 operaciones que tocan las dos estructuras y 40.000 que solo tocan el conjunto.
Usando 17 como escala de log₂(120.000), estimo (240.000 × 2 + 40.000) × 17 ≈ 8,84 millones de unidades de trabajo logarítmico.
Es una aproximación de escala. El costo exacto depende de la altura del árbol, del trabajo del montículo y de cuántos pedidos quedan pendientes.
Si normalmente hubiera apenas unos diez pedidos pendientes, usaría una lista simple.
Recorrer tan pocos elementos por preparación o consulta puede salir más barato que mantener las dos estructuras.
