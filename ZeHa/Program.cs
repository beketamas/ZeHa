namespace ZeHa
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length % 2 == 0 || args.Length == 0 || args.Length == 1)
                Console.WriteLine("Nem megfelelő argumentum szám");

            else
            {
                int kozepso = Convert.ToInt32(Math.Floor((double)args.Length / 2));

                if (Convert.ToDouble(args[kozepso - 1]) < Convert.ToDouble(args[kozepso + 1]))
                   Console.WriteLine($"1. feladat: {Math.Pow(Convert.ToInt32(args[kozepso]),
                    Math.Floor(Convert.ToDouble(args[kozepso + 1]) / Convert.ToDouble(args[kozepso - 1])))}");

                else
                   Console.WriteLine($"1. feladat: {Math.Pow(Convert.ToInt32(args[kozepso]),
                    Math.Floor(Convert.ToDouble(args[kozepso - 1]) / Convert.ToDouble(args[kozepso + 1])))}");
            }

            List<string> list = File.ReadAllLines("szavak.txt").Select(x => x.ToLower()).ToList();
            List<char> maganhagnzok = ['a','e','i','o','u'];
            int count = 0;
            list.ForEach(x =>
            {
                int szamlalo = 0;
                for (int i = 0; i < x.Length; i++)
                {
                    if (maganhagnzok.Contains(x[i]))
                        szamlalo++;
                }
                if (szamlalo > 4)
                {
                    count++;
                    //Console.WriteLine(x);
                }

            });
            Console.WriteLine($"2. feladat: {count}");
            Random rnd = new Random();
            int[,] matrix = new int[3, 3];
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    matrix[i, j] = rnd.Next(55, 155);

            List<int> szam = [];
            int szamlalo = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(new string(' ',3 - matrix[i, j].ToString().Length)+ matrix[i, j]+" ");
                    if (i == 0 || j == 0 || i == matrix.GetLength(0) -1 || j == matrix.GetLength(1) - 1)
                    {
                        szam.Add(matrix[i,j]);
                        szamlalo++;
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine($"3. feladat: {String.Format("{0:0.00}", (double)szam.Sum() / (double)szamlalo).Replace(',','.')}");

            List<string> listaRGB = File.ReadLines("kep.txt").Select(x => x).ToList();
            List<string> kekitettLista = [];
            listaRGB.ForEach(x =>
            {
                if (int.Parse(x.Split(";")[2]) < 100 )
                    kekitettLista.Add($"{int.Parse(x.Split(";")[0])};{int.Parse(x.Split(";")[1])};{int.Parse(x.Split(";")[2])+20}");
            });
            File.WriteAllLines("kekitett.txt", kekitettLista.Select(x => x));
            Console.WriteLine("#Kész!");
        }
    }
}
