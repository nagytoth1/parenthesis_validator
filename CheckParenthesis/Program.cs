using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CheckParenthesis
{
	public class Program
	{
		static void Main(string[] args)
		{
			string kifejezes;
			ConsoleKey c;
            Console.WriteLine("-------Zárójel-ellenőrző program-------");
			do
			{
                Console.Write("Kérek egy kifejezést: ");
				kifejezes = Console.ReadLine();
                Console.WriteLine(Zarojelezes.HelyesE(kifejezes) ? 
					"A kifejezés helyesen van zárójelezve" : 
					"A kifejezés helytelenül van zárójelezve");
                Console.WriteLine("Nyomj \'q\'-t a kilépéshez, bármi mást a folytatáshoz...");
				c = Console.ReadKey(true).Key;
			}while(c != ConsoleKey.Q);

            Console.WriteLine("Kilépés a programból...");
			Thread.Sleep(2000);
		}
	}
}
