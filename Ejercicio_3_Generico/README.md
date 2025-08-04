# Actividad 3 

## Sorteo de Chance

### Enunciado

Genérico compra un chance en el cual se juega eligiendo un número de 4 dígitos, que se compara con el número resultado del sorteo semanal. Se apuesta \$1000, y el jugador gana según el nivel de coincidencia con el número ganador.

El plan de pagos es el siguiente:

| Coincidencia                        | Pago por cada \$1 apostado |
| ----------------------------------- | -------------------------- |
| 4 cifras en el orden exacto         | \$4500                     |
| 4 cifras en cualquier orden         | \$200                      |
| Últimas 3 cifras en el orden exacto | \$400                      |
| Últimas 2 cifras en el orden exacto | \$50                       |
| Última cifra igual                  | \$5                        |
| Ninguna coincidencia válida         | \$0                        |

---

### Solución propuesta

Se creó una clase llamada `Chance`, que encapsula toda la lógica del juego. Esta clase incluye dos funciones:

* `DeterminarGanancia`: Evalúa las condiciones de coincidencia entre el número apostado y el número ganador, y calcula el valor del premio.
* `EsDesordenado`: Verifica si ambos números contienen las mismas cifras pero en diferente orden.

---

### Lógica implementada

```csharp
int valorApuesta = 1000;
```

Establece el valor fijo de la apuesta.

```csharp
if (apostado == ganador)
```

Verifica si las 4 cifras coinciden exactamente en el mismo orden.

```csharp
else if (EsDesordenado(apostado, ganador))
```

Llama a una función que ordena ambas cadenas numéricas y compara si tienen las mismas cifras, sin importar el orden.

```csharp
else if (apostado.Substring(1) == ganador.Substring(1))
```

Compara las últimas 3 cifras de ambos números (posición 1 en adelante).

```csharp
else if (apostado.Substring(2) == ganador.Substring(2))
```

Compara las últimas 2 cifras (posición 2 en adelante).

```csharp
else if (apostado[3] == ganador[3])
```

Compara la última cifra individual (posición 3).

```csharp
return ganancia;
```

Retorna el valor del premio o cero si no hubo coincidencia significativa.

---

### Entrada y salida del programa

El programa solicita al usuario:

```
Ingrese el número apostado (4 cifras):
Ingrese el número ganador (4 cifras):
```

Y devuelve:

* Si gana:

  ```
  ¡Felicidades! Ganaste $4000
  ```
* Si no gana:

  ```
  No ganaste esta vez. ¡Sigue intentando!
  ```

```csharp
using System; 
using System.Linq; // Permite usar métodos como OrderBy para ordenar cadenas

class Chance
{
    static void Main()
    {
        // Solicita al usuario el número apostado
        Console.Write("Valor apostado $1000 ahora ingrese el número apostado (4 cifras): ");
        string apostado = Console.ReadLine(); // Guarda el número apostado

        // Solicita al usuario el número ganador
        Console.Write("Ingrese el número ganador (4 cifras): ");
        string ganador = Console.ReadLine(); // Guarda el número ganador

        // Calcula la ganancia llamando a la función DeterminarGanancia
        int ganancia = DeterminarGanancia(apostado, ganador);

        // Muestra el resultado al usuario
        if (ganancia > 0)
        {
            Console.WriteLine($"¡Felicidades! Ganaste ${ganancia}");
        }
        else
        {
            Console.WriteLine("No ganaste esta vez. ¡Sigue intentando!");
        }
    }

    // Función que determina cuánto ganó el jugador según las reglas
    static int DeterminarGanancia(string apostado, string ganador)
    {
        int valorApuesta = 1000; // El jugador apuesta siempre $1000
        int ganancia = 0; // Acumulador del valor que puede ganar

        // Caso 1: Las 4 cifras coinciden exactamente en el mismo orden
        if (apostado == ganador)
        {
            ganancia = valorApuesta * 4500;
        }
        // Caso 2: Las 4 cifras son las mismas pero en diferente orden
        else if (EsDesordenado(apostado, ganador))
        {
            ganancia = valorApuesta * 200;
        }
        // Caso 3: Coinciden las últimas 3 cifras en el mismo orden
        else if (apostado.Substring(1) == ganador.Substring(1))
        {
            ganancia = valorApuesta * 400;
        }
        // Caso 4: Coinciden las últimas 2 cifras en el mismo orden
        else if (apostado.Substring(2) == ganador.Substring(2))
        {
            ganancia = valorApuesta * 50;
        }
        // Caso 5: Coincide solamente la última cifra
        else if (apostado[3] == ganador[3])
        {
            ganancia = valorApuesta * 5;
        }

        // Retorna el valor ganado o 0 si no acertó nada
        return ganancia;
    }

    // Función que determina si dos números contienen las mismas cifras en distinto orden
    static bool EsDesordenado(string a, string b)
    {
        // a.OrderBy(c => c): convierte la cadena 'a' en una colección de caracteres, y los ordena alfabéticamente
        // b.OrderBy(c => c): hace lo mismo con la cadena 'b'
        // SequenceEqual: compara si las dos secuencias ordenadas son iguales

        // Ejemplo: si a = "1234" y b = "4321", al ordenarlos ambos quedan como "1234", entonces son equivalentes aunque estén desordenados

        // Ordena ambos strings por sus caracteres y compara si son iguales
        return a.OrderBy(c => c).SequenceEqual(b.OrderBy(c => c));
    }
}
```
