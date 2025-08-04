# Actividad 3 

## Sorteo de Chance

### Enunciado

Gen�rico compra un chance en el cual se juega eligiendo un n�mero de 4 d�gitos, que se compara con el n�mero resultado del sorteo semanal. Se apuesta \$1000, y el jugador gana seg�n el nivel de coincidencia con el n�mero ganador.

El plan de pagos es el siguiente:

| Coincidencia                        | Pago por cada \$1 apostado |
| ----------------------------------- | -------------------------- |
| 4 cifras en el orden exacto         | \$4500                     |
| 4 cifras en cualquier orden         | \$200                      |
| �ltimas 3 cifras en el orden exacto | \$400                      |
| �ltimas 2 cifras en el orden exacto | \$50                       |
| �ltima cifra igual                  | \$5                        |
| Ninguna coincidencia v�lida         | \$0                        |

---

### Soluci�n propuesta

Se cre� una clase llamada `Chance`, que encapsula toda la l�gica del juego. Esta clase incluye dos funciones:

* `DeterminarGanancia`: Eval�a las condiciones de coincidencia entre el n�mero apostado y el n�mero ganador, y calcula el valor del premio.
* `EsDesordenado`: Verifica si ambos n�meros contienen las mismas cifras pero en diferente orden.

---

### L�gica implementada

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

Llama a una funci�n que ordena ambas cadenas num�ricas y compara si tienen las mismas cifras, sin importar el orden.

```csharp
else if (apostado.Substring(1) == ganador.Substring(1))
```

Compara las �ltimas 3 cifras de ambos n�meros (posici�n 1 en adelante).

```csharp
else if (apostado.Substring(2) == ganador.Substring(2))
```

Compara las �ltimas 2 cifras (posici�n 2 en adelante).

```csharp
else if (apostado[3] == ganador[3])
```

Compara la �ltima cifra individual (posici�n 3).

```csharp
return ganancia;
```

Retorna el valor del premio o cero si no hubo coincidencia significativa.

---

### Entrada y salida del programa

El programa solicita al usuario:

```
Ingrese el n�mero apostado (4 cifras):
Ingrese el n�mero ganador (4 cifras):
```

Y devuelve:

* Si gana:

  ```
  �Felicidades! Ganaste $4000
  ```
* Si no gana:

  ```
  No ganaste esta vez. �Sigue intentando!
  ```

```csharp
using System; 
using System.Linq; // Permite usar m�todos como OrderBy para ordenar cadenas

class Chance
{
    static void Main()
    {
        // Solicita al usuario el n�mero apostado
        Console.Write("Valor apostado $1000 ahora ingrese el n�mero apostado (4 cifras): ");
        string apostado = Console.ReadLine();

        // Solicita al usuario el n�mero ganador
        Console.Write("Ingrese el n�mero ganador (4 cifras): ");
        string ganador = Console.ReadLine();

        // Calcula la ganancia llamando a la funci�n DeterminarGanancia
        int ganancia = DeterminarGanancia(apostado, ganador);

        // Muestra el resultado al usuario
        if (ganancia > 0)
        {
            Console.WriteLine($"�Felicidades! Ganaste ${ganancia}");
        }
        else
        {
            Console.WriteLine("No ganaste esta vez. �Sigue intentando!");
        }
    }

    // Funci�n que determina cu�nto gan� el jugador seg�n las reglas
    static int DeterminarGanancia(string apostado, string ganador)
    {
        int valorApuesta = 1000; // El jugador apuesta siempre $1000
        int ganancia = 0; // Variable para almacenar el valor ganado

        // Si el n�mero apostado es igual al n�mero ganador exacto
        if (apostado == ganador)
        {
            ganancia = valorApuesta * 4500;
        }
        // Si el n�mero tiene las mismas cifras pero en distinto orden
        else if (EsDesordenado(apostado, ganador))
        {
            ganancia = valorApuesta * 200;
        }
        // Si coinciden las �ltimas 3 cifras en orden exacto
        else if (apostado.Substring(1) == ganador.Substring(1))
        {
            ganancia = valorApuesta * 400;
        }
        // Si coinciden las �ltimas 2 cifras en orden exacto
        else if (apostado.Substring(2) == ganador.Substring(2))
        {
            ganancia = valorApuesta * 50;
        }
        // Si coinciden s�lo la �ltima cifra
        else if (apostado[3] == ganador[3])
        {
            ganancia = valorApuesta * 5;
        }

        // Retorna el valor ganado o 0 si no acert� nada
        return ganancia;
    }

    // Funci�n que determina si dos n�meros contienen las mismas cifras en distinto orden
    static bool EsDesordenado(string a, string b)
    {
        // Ordena ambos strings por sus caracteres y compara si son iguales
        return a.OrderBy(c => c).SequenceEqual(b.OrderBy(c => c));
    }
}
```