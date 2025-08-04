# Actividad 4 

## POO - Clases Abstractas y Herencia

### Enunciado

> Implemente lo siguiente:
>
> * Una clase abstracta `AbstractSample` con:
>
>   * Un atributo privado `message`.
>   * Un método abstracto `PrintMessage(string input)`.
>   * Un método virtual `InvertMessage(string input)` que invierte el texto.
> * Dos subclases:
>
>   * Una imprime el mensaje tal como está.
>   * La otra imprime el mensaje con las mayúsculas y minúsculas invertidas.
>   * Una de las clases sobrescribe `InvertMessage` para también invertir las mayúsculas y minúsculas.
> * Una clase `MessageManager` (implementada en `Program.cs`) que instancie ambas subclases y use sus métodos.

---

### Estructura del proyecto

Se organizaron las clases en archivos separados, pero pertenecen al mismo *namespace*:

* `AbstractSample.cs`: clase base abstracta.
* `SimplePrinter.cs`: subclase que imprime el mensaje original.
* `FancyPrinter.cs`: subclase que imprime el mensaje con cambio de mayúsculas/minúsculas.
* `Program.cs`: contiene `Main()`, instancia los objetos e invoca los métodos.

---

* **Clases abstractas**: se usó `AbstractSample` para definir una estructura base que deben seguir las subclases.
* **Métodos abstractos y virtuales**: se aplicaron para forzar la implementación y permitir sobreescritura, respectivamente.
* **Polimorfismo**: se utilizó al tratar las subclases como instancias de `AbstractSample` para invocar los métodos sobrescritos.
* **Herencia**: las clases `SimplePrinter` y `FancyPrinter` extienden de `AbstractSample`.

---

`AbstractSample.cs`

```csharp
namespace OOP_Recorderis_MessageApp
{
    // Clase abstracta que define la base para las subclases
    abstract class AbstractSample
    {
        private string message; // Campo privado para almacenar el mensaje

        // Constructor que asigna el valor del mensaje
        public AbstractSample(string message)
        {
            this.message = message;
        }

        // Método abstracto que obliga a las subclases a implementar cómo imprimir el mensaje
        public abstract void PrintMessage(string input);

        // Método virtual que puede ser sobrescrito por las subclases
        // Devuelve el mensaje invertido (ej: "Hola" → "aloH")
        public virtual string InvertMessage(string input)
        {
            char[] chars = input.ToCharArray(); // Convierte el string en arreglo de caracteres
            Array.Reverse(chars);               // Invierte el arreglo
            return new string(chars);           // Crea un nuevo string con los caracteres invertidos
        }

        // Método protegido para acceder al campo privado desde las subclases
        protected string GetMessage()
        {
            return message;
        }
    }
}
```

---

`SimplePrinter.cs`

```csharp
namespace OOP_Recorderis_MessageApp
{
    // Subclase que imprime el mensaje tal como está
    internal class SimplePrinter : AbstractSample
    {
        public SimplePrinter(string message) : base(message) { }

        public override void PrintMessage(string input)
        {
            Console.WriteLine("Mensaje original: " + input);
        }
    }
}
```

---

`FancyPrinter.cs`

```csharp
namespace OOP_Recorderis_MessageApp
{
    // Subclase que imprime el mensaje con mayúsculas y minúsculas invertidas
    internal class FancyPrinter : AbstractSample
    {
        public FancyPrinter(string message) : base(message) { }

        public override void PrintMessage(string input)
        {
            // Invierte mayúsculas y minúsculas del mensaje
            string result = string.Concat(input.Select(c =>
                char.IsLetter(c) ?
                    (char.IsUpper(c) ? char.ToLower(c) : char.ToUpper(c)) :
                    c
            ));

            Console.WriteLine("Mensaje con cambio de mayúsculas/minúsculas: " + result);
        }

        // Sobrescribe el método de inversión para también cambiar mayúsculas/minúsculas
        public override string InvertMessage(string input)
        {
            // Primero invierte el string
            char[] chars = input.ToCharArray();
            Array.Reverse(chars);

            // Luego cambia las mayúsculas/minúsculas
            string reversed = new string(chars);
            return string.Concat(reversed.Select(c =>
                char.IsLetter(c) ?
                    (char.IsUpper(c) ? char.ToLower(c) : char.ToUpper(c)) :
                    c
            ));
        }
    }
}
```

---

`Program.cs`

```csharp
using System;

namespace OOP_Recorderis_MessageApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Instancia de la subclase que imprime normal
            AbstractSample simplePrinter = new SimplePrinter("Hola Mundo");
            simplePrinter.PrintMessage("Hola Mundo");
            Console.WriteLine("Invertido: " + simplePrinter.InvertMessage("Hola Mundo"));

            Console.WriteLine(); // Separador

            // Instancia de la subclase que imprime con cambio de mayúsculas/minúsculas
            AbstractSample fancyPrinter = new FancyPrinter("Hola Mundo");
            fancyPrinter.PrintMessage("Hola Mundo");
            Console.WriteLine("Invertido y con cambio de mayúsculas/minúsculas: " +
                              fancyPrinter.InvertMessage("Hola Mundo"));
        }
    }
}
```

---

## Estructura de POO en el ejercicio

### 1. **Abstracción**

* Se define una clase abstracta `AbstractSample`, que representa una idea general de un “impresor de mensajes”.
* Esta clase define una interfaz común con un método abstracto `PrintMessage` y un método virtual `InvertMessage`, sin preocuparse por los detalles de implementación.
* **Ejemplo en el código:**

  ```csharp
  abstract class AbstractSample { ... }
  ```

### 2. **Encapsulamiento**

* El atributo `message` está **privado** y no se accede directamente desde fuera de la clase. Se accede de forma controlada mediante el método protegido `GetMessage()`.
* Esto protege el estado interno del objeto.
* **Ejemplo en el código:**

  ```csharp
  private string message;  // no se puede modificar desde fuera
  protected string GetMessage() { return message; }
  ```

### 3. **Herencia**

* Las clases `SimplePrinter` y `FancyPrinter` heredan de la clase `AbstractSample`.
* Esto permite reutilizar código y comportamiento común definido en la clase base.
* **Ejemplo en el código:**

  ```csharp
  internal class SimplePrinter : AbstractSample
  ```

### 4. **Polimorfismo**

* Se usan referencias del tipo base (`AbstractSample`) para almacenar instancias de subclases.
* Los métodos sobrescritos se comportan de forma diferente según la subclase.
* **Ejemplo en el código:**

  ```csharp
  AbstractSample simple = new SimplePrinter("Hola");
  simple.PrintMessage("Hola");  // llama al método específico de SimplePrinter
  ```

---

## Diagrama de Clases 

```text
                 +-------------------------+
                 |    AbstractSample       |  (Clase Abstracta)
                 +-------------------------+
                 | - message : string      |
                 +-------------------------+
                 | + PrintMessage(input)   | (abstract)
                 | + InvertMessage(input)  | (virtual)
                 | + GetMessage()          |
                 +-------------------------+
                         /\
                        /  \
                       /    \
      +----------------+   +----------------+
      | SimplePrinter  |   | FancyPrinter   |
      +----------------+   +----------------+
      | + PrintMessage |   | + PrintMessage |
      |                |   | + InvertMessage| (sobrescrito)
      +----------------+   +----------------+

```

