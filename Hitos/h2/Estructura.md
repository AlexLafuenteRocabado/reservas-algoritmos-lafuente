H2 – Estructura elegida para mi caso (registro de equipos / venta de laptops)
Elección
Estructura principal:** `Dictionary<string, Equipo>` con el código del equipo como clave (tabla hash).
Estructura de apoyo para orden y rangos: `SortedSet<(decimal Precio, string Codigo)>` (árbol balanceado). Uso el par (precio, código) porque dos laptops pueden tener el mismo precio y un SortedSet no admite duplicados.
Costo O de cada operación (n = equipos registrados)

| Operación | Lista (ingenua) | Dictionary (hash) | SortedSet (árbol) |

| Buscar un equipo por código (la que más hago) | O(n) | O(1 promedio | O(log n) |
| Insertar un equipo que ingresa | O(1) al final, pero O(n) si reviso duplicados | O(1 promedio | O(log n) |
| Borrar un equipo vendido | O(n) | O(1 promedio | O(log n) |
| El más barato / el siguiente en precio | O(n) | O(n) | O(log n) |
| Equipos en un rango de precio | O(n) | O(n) | O(log n + k) (k = cuántos caen en el rango) |
| Recorrer todos ordenados por precio | O(n log n) (hay que ordenar) | O(n log n) | O(n (inorden) |

Por qué esta elección
1. Lo que más hago es buscar por código (consultar, vender, dar de baja). Con lista cada búsqueda recorre todo; con hash es directa. Por eso el Dictionary es la estructura principal.
2. Hash **no sirve** para "el más barato", rangos ni recorrido en orden: no guarda orden. Para eso uso el árbol, que mantiene el orden y cuesta O(log n) por estar balanceado (SortedSet en C#).
3. El costo de usar las dos: más memoria y que cada insertar/borrar se hace en las dos estructuras (sigue siendo barato: O(1) + O(log n)).
4. Honestidad sobre mi escala: hoy son unos 40–50 equipos, donde cualquier estructura responde al instante. La elección importa si el negocio crece (cientos o miles de equipos), y eso es lo que mido en medicion.m`.
