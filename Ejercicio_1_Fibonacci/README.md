# Ejercicio 1

Comencemos con lo Inicial

```csharp
using System; // Importa funcionalidades básicas como entrada y salida por consola
using System.Collections.Generic; // Permite usar listas dinámicas (List<int>)

```

Clase principal para ejecutar el programa
```csharp
class Program // Clase principal del programa
{
    static void Main() 
    {
        Console.Write("Ingrese el número de términos de la serie Fibonacci: "); // Imprime un mensaje en consola para que el usuario escriba un número

        string entrada = Console.ReadLine(); // Captura el texto que el usuario escribe

        int n; // Declara la variable donde guardaremos el número convertido

        if (int.TryParse(entrada, out n) && n > 0) // Intenta convertir el texto a número y verifica que sea mayor a 0
        {
            Console.WriteLine($"Números primos en los primeros {n} términos de Fibonacci:"); // Imprime una cabecera para los resultados
            List<int> secuencia = Fibonacci.Generar(n); // Llama al método de la clase Fibonacci para generar la secuencia

            foreach (int numero in secuencia) // Recorre cada número de la secuencia Fibonacci
            {
                if (Primo.EsPrimo(numero)) // Verifica si el número actual es primo usando la clase Primo
                {
                  Console.Write(numero + " "); // Si es primo, lo imprime seguido de un espacio
                }
            }
            Console.WriteLine(); // Salto de línea al final para que se vea ordenado
        }
        else // Si el usuario no ingresó un número válido
        {
            Console.WriteLine("Por favor, ingrese un número entero positivo válido."); // Muestra mensaje de error
        }
    }
}

```

Clase Fibonacci para generar la serie de Fibonacci
```csharp
class Fibonacci // Clase que se encarga de generar la serie de Fibonacci
{
    public static List<int> Generar(int n) // Método estático que devuelve una lista con los primeros n términos
    {
        List<int> secuencia = new List<int>(); // Crea una lista vacía para guardar los números

        int a = 0, b = 1; // Inicializa los dos primeros términos de Fibonacci
        
        for (int i = 0; i < n; i++) // Repite el proceso n veces (desde 0 hasta n-1)
        {
            if (i == 0)
                secuencia.Add(a); // Agrega el primer término (0)
            else if (i == 1)
                secuencia.Add(b); // Agrega el segundo término (1)
            else
            {
                int siguiente = a + b; // Suma los dos anteriores para obtener el nuevo término
                secuencia.Add(siguiente); // Agrega el nuevo número a la lista
                a = b; // Actualiza los valores: el segundo se convierte en el primero
                b = siguiente; // Y el nuevo se convierte en el segundo
            }
        }
        return secuencia; // Devuelve la lista completa con los n términos
    }
}

```

Clase Primo Para verificar si un número es primo
```csharp
class Primo // Clase que se encarga de verificar si un número es primo
{
    public static bool EsPrimo(int num) // Método que recibe un número entero y devuelve true si es primo
    {
        if (num <= 1) return false; // 0 y 1 no son primos por definición
        if (num == 2) return true; // 2 es el único número par que sí es primo
        if (num % 2 == 0) return false; // Todos los demás pares no son primos
        
        // Recorre los números impares desde 3 hasta la raíz cuadrada del número
        // Esto es más eficiente que revisar hasta el número completo
        for (int i = 3; i <= Math.Sqrt(num); i += 2)
        {
            if (num % i == 0) // Si el número es divisible por i, entonces no es primo
                return false;
        }
        return true; // Si no se encontró ningún divisor, entonces es primo
    }
}
```
