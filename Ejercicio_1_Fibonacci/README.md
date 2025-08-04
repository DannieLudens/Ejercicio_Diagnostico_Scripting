# Ejercicio 1

Comencemos con lo Inicial

```csharp
using System; // Importa funcionalidades b�sicas como entrada y salida por consola
using System.Collections.Generic; // Permite usar listas din�micas (List<int>)

```

Clase principal para ejecutar el programa
```csharp
class Program // Define la clase principal del programa
{
    static void Main() // M�todo que se ejecuta primero cuando corres el programa
    {
        Console.Write("Ingrese el n�mero de t�rminos de la serie Fibonacci: ");
        // Imprime un mensaje en consola para que el usuario escriba un n�mero

        string entrada = Console.ReadLine();
        // Captura el texto que el usuario escribe

        int n; // Declara la variable donde guardaremos el n�mero convertido

        if (int.TryParse(entrada, out n) && n > 0)
        {
            // Intenta convertir el texto a n�mero y verifica que sea mayor a 0

            Console.WriteLine($"N�meros primos en los primeros {n} t�rminos de Fibonacci:");
            // Imprime una cabecera para los resultados

            List<int> secuencia = Fibonacci.Generar(n);
            // Llama al m�todo de la clase Fibonacci para generar la secuencia

            foreach (int numero in secuencia)
            {
                // Recorre cada n�mero de la secuencia Fibonacci

                if (Primo.EsPrimo(numero))
                {
                    // Verifica si el n�mero actual es primo usando la clase Primo

                    Console.Write(numero + " ");
                    // Si es primo, lo imprime seguido de un espacio
                }
            }

            Console.WriteLine(); // Salto de l�nea al final para que se vea ordenado
        }
        else
        {
            // Si el usuario no ingres� un n�mero v�lido

            Console.WriteLine("Por favor, ingrese un n�mero entero positivo v�lido.");
            // Muestra mensaje de error
        }
    }
}

```

Clase Fibonacci para generar la serie de Fibonacci
```csharp
class Fibonacci // Clase que se encarga de generar la serie de Fibonacci
{
    public static List<int> Generar(int n)
    {
        // M�todo est�tico que devuelve una lista con los primeros n t�rminos

        List<int> secuencia = new List<int>();
        // Crea una lista vac�a para guardar los n�meros

        int a = 0, b = 1;
        // Inicializa los dos primeros t�rminos de Fibonacci

        for (int i = 0; i < n; i++)
        {
            // Repite el proceso n veces (desde 0 hasta n-1)

            if (i == 0)
                secuencia.Add(a); // Agrega el primer t�rmino (0)
            else if (i == 1)
                secuencia.Add(b); // Agrega el segundo t�rmino (1)
            else
            {
                int siguiente = a + b; // Suma los dos anteriores para obtener el nuevo t�rmino
                secuencia.Add(siguiente); // Agrega el nuevo n�mero a la lista
                a = b; // Actualiza los valores: el segundo se convierte en el primero
                b = siguiente; // Y el nuevo se convierte en el segundo
            }
        }

        return secuencia;
        // Devuelve la lista completa con los n t�rminos
    }
}

```

Clase Primo Para verificar si un n�mero es primo
```csharp
class Primo // Clase que se encarga de verificar si un n�mero es primo
{
    public static bool EsPrimo(int num)
    {
        // M�todo que recibe un n�mero entero y devuelve true si es primo

        if (num <= 1) return false;
        // 0 y 1 no son primos por definici�n

        if (num == 2) return true;
        // 2 es el �nico n�mero par que s� es primo

        if (num % 2 == 0) return false;
        // Todos los dem�s pares no son primos

        for (int i = 3; i <= Math.Sqrt(num); i += 2)
        {
            // Recorre los n�meros impares desde 3 hasta la ra�z cuadrada del n�mero
            // Esto es m�s eficiente que revisar hasta el n�mero completo

            if (num % i == 0)
                return false;
            // Si el n�mero es divisible por i, entonces no es primo
        }

        return true;
        // Si no se encontr� ning�n divisor, entonces es primo
    }
}
```