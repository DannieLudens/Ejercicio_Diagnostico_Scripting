# Ejercicio 2

## Conversi�n de segundos a formato HH:MM:SS

El objetivo del ejercicio es crear una funci�n que reciba un n�mero entero de segundos y retorne una cadena (`string`) que represente ese tiempo en formato `HH:MM:SS`. No se permite utilizar la clase `DateTime`, por lo tanto, el manejo del tiempo se realiza mediante divisiones y m�dulos.

### L�gica aplicada:
- **1 hora = 3600 segundos**
- **1 minuto = 60 segundos**
- Para convertir los segundos:
  - Se divide el total entre 3600 para obtener las horas.
  - Luego se obtiene el residuo y se divide entre 60 para obtener los minutos.
  - Finalmente, se obtiene el residuo final como los segundos restantes.
- Los valores se formatean con dos d�gitos usando `:D2` para asegurar que siempre tengan el formato `HH:MM:SS`.

### Ejemplo:
Si se ingresa `3661`, el programa imprimir�:

Formato HH:MM:SS: 01:01:01


Tambi�n valida que la entrada sea un n�mero entero positivo antes de hacer la conversi�n.

```csharp
using System; // Importa funcionalidades b�sicas como entrada/salida por consola

class Program 
{
    static void Main() 
    {
        Console.Write("Ingrese la cantidad de segundos: "); // Pide al usuario que escriba un n�mero entero de segundos
        string entrada = Console.ReadLine(); // Lee lo que el usuario escribi�
 
        int segundos; // Variable donde se guardar� el n�mero convertido

        if (int.TryParse(entrada, out segundos) && segundos >= 0)
        {
            // Si se pudo convertir y el n�mero es mayor o igual a cero
            string resultado = ConvertirASegundosFormato(segundos); // Llama a la funci�n para obtener el formato HH:MM:SS
            Console.WriteLine("Formato HH:MM:SS:  " + resultado); // Imprime el resultado en consola
        }
        else
        {
            Console.WriteLine("Por favor, ingrese un n�mero entero no negativo."); 
        }
    }

    // Esta funci�n convierte los segundos a formato HH:MM:SS
    static string ConvertirASegundosFormato(int totalSegundos)
    {
        int horas = totalSegundos / 3600; // 1 hora tiene 3600 segundos
        int minutos = (totalSegundos % 3600) / 60; // El residuo de horas se convierte a minutos (60 segundos por minuto)
        int segundos = totalSegundos % 60; // Lo que queda despu�s de horas y minutos son los segundos
        
        // Formatea los n�meros con dos d�gitos (04:07:09)
        return $"{horas:D2}:{minutos:D2}:{segundos:D2}"; 
        
    }
}

```