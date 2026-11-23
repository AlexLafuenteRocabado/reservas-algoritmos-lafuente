Inventario de operaciones (caso: registro de equipos, venta de laptops)

Qué datos guarda el proceso
Cada equipo (laptop nueva o seminueva) tiene: código (único, identifica el equipo), marca/modelo, 
estado (nueva o seminueva), precio y si sigue disponible o ya se vendió. 
Hoy todo se anota a mano por escrito, sin sistema.

Cuántos
- Hoy: unos 40 a 50 equipos los que manejan los jefes, y en el depósito hay más sin cifra exacta.
- Peor mes (más ingresos de equipos / más stock): unos 60 equipos.

Operaciones que hago y con qué frecuencia

| Operación | En mi trabajo | Frecuencia |
|---|---|---|
| Buscar por clave | "¿Tenemos la laptop con este código? ¿cuánto cuesta, en qué estado está?" | La que más veces (varias veces al día) |
| Insertar | Ingresa un equipo nuevo o seminuevo al registro | Frecuente |
| Borrar | Se vende un equipo y sale del registro de disponibles | Frecuente (tantas como ventas) |
| El menor / el siguiente | "¿Cuál es la laptop más barata disponible?" y la siguiente | Algunas veces por semana |
| Un rango | "Laptops entre X y Y bolivianos" para un cliente con presupuesto | Frecuente al atender clientes |
| Recorrer en orden | Lista de todo el stock ordenada por precio (o por código) | Pocas veces (cierre / revisión) |

Qué estructura resuelve barato cada una y cuál sufre
| Operación | Barata con | Sufre con |
|---|---|---|
| Buscar por clave | Tabla hash (O(1) promedio) | Lista sin orden (O(n)) |
| Insertar | Tabla hash (O(1)); árbol balanceado (O(log n)) | Lista ordenada (hay que desplazar, O(n)) |
| Borrar | Tabla hash (O(1)); árbol (O(log n)) | Lista (O(n)) |
| El menor / el siguiente | Árbol balanceado (SortedSet, O(log n)) | Tabla hash y lista (O(n)) |
| Rango | Árbol balanceado (O(log n + k)) | Tabla hash (no guarda orden) y lista (O(n)) |
| Recorrer en orden | Árbol, recorrido inorden (O(n)) | Tabla hash y lista (hay que ordenar, O(n log n)) |

Conclusión del inventario:lo que más hago (buscar por código, insertar, borrar) lo resuelve bien una tabla hash; lo que necesita orden (el más barato, rangos de precio, listado ordenado) lo resuelve un árbol balanceado. Eso me lleva a combinar las dos en estructura.md.
