internal class Program
{
    static Random rnd = new Random();

    static void Main()
    {
        Console.Write("Ile zestawów wylosować? ");
        int n = int.Parse(Console.ReadLine());

        int[,] wyniki = new int[n, 6];
        int[] liczniki = new int[50]; // indeks od 1 do 49

        // Losowanie zestawów
        for (int i = 0; i < n; i++)
        {
            HashSet<int> zbior = new HashSet<int>();
            while (zbior.Count < 6)
            {
                int liczba = rnd.Next(1, 50);
                zbior.Add(liczba);
            }

            int j = 0;
            foreach (int liczba in zbior)
            {
                wyniki[i, j++] = liczba;
                liczniki[liczba]++;
            }
        }

        // Wyświetlenie wyników
        for (int i = 0; i < n; i++)
        {
            Console.Write("Losowanie " + (i + 1) + ": ");
            for (int j = 0; j < 6; j++)
                Console.Write(wyniki[i, j] + " ");
            Console.WriteLine();
        }

        // Statystyka
        Console.WriteLine("\nWystąpienia liczb:");
        for (int i = 1; i <= 49; i++)
        {
            if (liczniki[i] > 0)
                Console.WriteLine($"Liczba {i} -> {liczniki[i]}");
        }
    }
}