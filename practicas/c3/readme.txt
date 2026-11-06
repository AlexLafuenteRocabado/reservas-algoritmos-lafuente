
# Practica C3 - Tabla de mediciones

## 1. Objetivo

Analizar experimentalmente la complejidad temporal de un algoritmo de busqueda lineal mediante mediciones de tiempo.

## 2. Lenguaje utilizado

- C#
- .NET

## 3. Algoritmo utilizado

Se implemento un algoritmo de busqueda lineal que recorre los elementos de un arreglo hasta encontrar el valor buscado.

Para garantizar que se recorra todo el arreglo, se busca un elemento que no existe.

## 4. Protocolo de medicion

- Se realiza una ejecucion de calentamiento.
- Se ejecutan 5 corridas por cada tamaño.
- Se calcula el promedio de las 5 corridas.
- Se utilizan los tamaños n, 4n y 16n.
- Se mide el tiempo utilizando Stopwatch.

## 5. Tabla de resultados

| Tamaño | Promedio (ms) | Ratio |
|---|---|---|
| n = 1.000.000 | Pendiente | 1x |
| 4n = 4.000.000 | Pendiente | Pendiente |
| 16n = 16.000.000 | Pendiente | Pendiente |

## 6. Analisis

La busqueda lineal tiene una complejidad temporal O(n), debido a que debe recorrer los elementos del arreglo cuando el elemento buscado no existe.

Se espera que al multiplicar por cuatro la cantidad de elementos, el tiempo de ejecucion aumente aproximadamente cuatro veces.

## 7. Conclusion

Esta practica permite comprobar mediante mediciones reales como aumenta el tiempo de ejecucion de un algoritmo de busqueda lineal a medida que crece el tamaño de los datos.
