En mi trabajo vendemos laptops nuevas y seminuevas, y todo el registro de los equipos se hace a mano porque no tenemos un sistema. Los jefes manejan unos 40 a 50 equipos, más lo que hay en el depósito.

Elegí MergeSort. Con tan pocos equipos cualquier algoritmo sería rápido, pero MergeSort tiene ventajas que me sirven: es estable, o sea que si dos laptops cuestan lo mismo mantienen su orden anterior, y siempre rinde igual sin importar cómo estén los datos. Además es fácil de explicar: se divide la lista, se ordena cada mitad y se mezclan.

En la práctica C5 vi que con 10.000 datos el algoritmo cuadrático tardó 292 ms y MergeSort solo 1,7 ms, y que al crecer los datos el cuadrático empeora mucho más rápido. QuickSort fue un poco más rápido (1,2 ms), pero no es estable y en el peor caso puede volverse lento, así que no me convenció tanto.

En conclusión, hoy con 40 o 50 equipos no habría problema de velocidad, pero elijo MergeSort porque ordena bien, es confiable y me sirve si el inventario crece cuando se digitalice el registro.
