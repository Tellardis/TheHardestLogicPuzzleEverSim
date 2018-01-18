using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHardestLogicPuzzleEverSim
{
    class Program
    {
        public static Dictionary<bool, string> Dict;
        public static Dictionary<string, God> Gods;
        public static void PrepareDict()
        {
            var rand = new Random();
            string[] lang = new[] { "DA", "JA" };
            Reshuffle(lang);
            Dict = new Dictionary<bool, string>();
            var index = rand.Next(0, 1);
            Dict.Add(true, lang[index]);
            Dict.Add(false, index == 0 ? lang[1] : lang[0]);

            God[] gods = new God[3];
            gods = new God[] { new GodRandom(), new GodFalse(), new GodTrue() };
            Reshuffle(gods);
            Gods = new Dictionary<string, God>();
            Gods.Add("A", gods[0]);
            Gods.Add("B", gods[1]);
            Gods.Add("C", gods[2]);
        }

        static void Reshuffle<T>(T[] texts)
        {
            var rand = new Random();
            for (int t = 0; t < texts.Length; t++)
            {
                T tmp = texts[t];
                int r = rand.Next(t, texts.Length);
                texts[t] = texts[r];
                texts[r] = tmp;
            }
        }

        static void PrintSettings()
        {
            Console.WriteLine("Gods:");
            foreach (var item in Gods.Keys)
            {
                Console.WriteLine($"{item}: {Gods[item]}");
            }
            Console.WriteLine("Lang:");
            Console.WriteLine("true: " + Dict[true]);
            Console.WriteLine("false: " + Dict[false]);
        }

        static void Main(string[] args)
        {
            PrepareDict();
            Console.WriteLine("Введите число вопросов(3)");
            var qn = Console.ReadLine();
            int i1;
            int i;
            if (!int.TryParse(qn, out i1))
            {
                i1 = 3;
            }
            i = i1;
            while (i != 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Вопрос номер " + (i1+1 - i).ToString());
                Console.ForegroundColor = ConsoleColor.Gray;
                var q = new Question();
                Console.WriteLine("Что бы ты ответил (DA,JA)");
                Console.ForegroundColor = ConsoleColor.Magenta;
                var t = Console.ReadLine().ToUpper();
                Console.ForegroundColor = ConsoleColor.Gray;
                var ga = Dict.First(x => x.Value == t).Key;
                q.GodAnswer = ga;
                Console.WriteLine("Кто?(A,B,C)");
                Console.ForegroundColor = ConsoleColor.Magenta;
                q.Subject = Gods[Console.ReadLine().ToUpper()];
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("Кем является?");
                Console.WriteLine("1 - GodTrue");
                Console.WriteLine("2 - GodFalse");
                Console.WriteLine("3 - GodRandom");
                Console.ForegroundColor = ConsoleColor.Magenta;
                q.GodType = new Dictionary<int, string>() { { 1, "GodTrue" }, { 2, "GodFalse" }, { 3, "GodRandom" } }[int.Parse(Console.ReadLine())];
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(q + ", Правильно?");
                Console.ReadKey();
                Console.WriteLine();
                Console.WriteLine("Кому задаем вопрос?");
                Console.ForegroundColor = ConsoleColor.Magenta;
                var godto = Console.ReadLine().ToUpper();
                Console.ForegroundColor = ConsoleColor.Gray;
                var godToAsk = Gods[godto];
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"Бог {godto} отвеил: ");
                Console.Write(Dict[godToAsk.Reply(q)]);
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine();
                i--;
            }
            Console.WriteLine("Кто есть кто?");
            var temp = new Dictionary<int, string>() { { 1, "GodTrue" }, { 2, "GodFalse" }, { 3, "GodRandom" } };
            Console.WriteLine("1 - GodTrue");
            Console.WriteLine("2 - GodFalse");
            Console.WriteLine("3 - GodRandom");
            Console.Write("A: ");
            var a = temp[int.Parse(Console.ReadLine())];
            Console.Write("B: ");
            var b = temp[int.Parse(Console.ReadLine())];
            Console.Write("C: ");
            var c = temp[int.Parse(Console.ReadLine())];
            bool victory = a == Gods["A"].ToString() && b == Gods["B"].ToString() && c == Gods["C"].ToString();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(victory ? "Победа" : "Поражение");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Press enter to answ");
            Console.ReadLine();
            PrintSettings();
            Console.WriteLine("GameOver");
            Console.ReadLine();
        }
    }
}
