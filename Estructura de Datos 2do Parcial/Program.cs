using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Random random = new Random(); // Generador de números aleatorios

        // Crear un conjunto ficticio de 500 ciudadanos con identificadores únicos (Ciudadano 1, Ciudadano 2, ..., Ciudadano 500)
        HashSet<string> ciudadanos = new HashSet<string>();
        for (int i = 1; i <= 500; i++)
        {
            ciudadanos.Add($"Ciudadano {i}");
        }

        // Crear un conjunto ficticio de 75 ciudadanos vacunados con Pfizer (seleccionados aleatoriamente)
        HashSet<string> vacunadosPfizer = new HashSet<string>();
        while (vacunadosPfizer.Count < 75)
        {
            int numeroAleatorio = random.Next(1, 501); // Número entre 1 y 500 (501 es excluyente)
            vacunadosPfizer.Add($"Ciudadano {numeroAleatorio}"); // Se agrega al conjunto
        }

        // Crear un conjunto ficticio de 75 ciudadanos vacunados con AstraZeneca (seleccionados aleatoriamente)
        HashSet<string> vacunadosAstrazeneca = new HashSet<string>();
        while (vacunadosAstrazeneca.Count < 75)
        {
            int numeroAleatorio = random.Next(1, 501); // Número entre 1 y 500
            vacunadosAstrazeneca.Add($"Ciudadano {numeroAleatorio}"); // Se agrega al conjunto
        }

        // Determinar los ciudadanos que NO se han vacunado (restar vacunados de la lista general)
        HashSet<string> noVacunados = new HashSet<string>(ciudadanos);
        noVacunados.ExceptWith(vacunadosPfizer);
        noVacunados.ExceptWith(vacunadosAstrazeneca);

        // Determinar los ciudadanos que han recibido ambas vacunas (intersección de Pfizer y AstraZeneca)
        HashSet<string> vacunadosAmbas = new HashSet<string>(vacunadosPfizer);
        vacunadosAmbas.IntersectWith(vacunadosAstrazeneca);

        // Determinar los ciudadanos que solo han recibido la vacuna de Pfizer (restar los que tienen ambas)
        HashSet<string> soloPfizer = new HashSet<string>(vacunadosPfizer);
        soloPfizer.ExceptWith(vacunadosAstrazeneca);

        // Determinar los ciudadanos que solo han recibido la vacuna de AstraZeneca (restar los que tienen ambas)
        HashSet<string> soloAstrazeneca = new HashSet<string>(vacunadosAstrazeneca);
        soloAstrazeneca.ExceptWith(vacunadosPfizer);

        // Imprimir todos los listados con sus respectivos totales
        ImprimirLista("Ciudadanos no vacunados:", noVacunados);
        ImprimirLista("Ciudadanos que han recibido ambas vacunas:", vacunadosAmbas);
        ImprimirLista("Ciudadanos que solo han recibido la vacuna de Pfizer:", soloPfizer);
        ImprimirLista("Ciudadanos que solo han recibido la vacuna de AstraZeneca:", soloAstrazeneca);
    }

    // Método para imprimir listados con títulos y cantidad total de ciudadanos
    static void ImprimirLista(string titulo, HashSet<string> lista)
    {
        Console.WriteLine($"\n{titulo} (Total: {lista.Count})");
        foreach (var ciudadano in lista)
        {
            Console.WriteLine(ciudadano);
        }
        Console.WriteLine($"Total: {lista.Count}\n"); // Imprimir el total al final del listado
    }
}

