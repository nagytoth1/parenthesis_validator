using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CheckParenthesis
{
    static class Zarojelezes
    {
		private static readonly Regex nyitoZarojelRegex = new Regex(pattern: @"[{([]");
		private static readonly Regex csukoZarojelRegex = new Regex(pattern: @"[})\]]");
		private static readonly Stack<char> verem = new Stack<char>();
		private static Match zarojelTalalat;

		/// <summary>
		/// Eldönti egy kifejezésről, hogy annak zárójelezése helyes-e.
		/// </summary>
		/// <param name="kifejezes">A vizsgált kifejezés</param>
		/// <returns>true, amennyiben a kifejezés zárójelezése helyes. <br></br> 
		/// Ekkor minden egyes megtalált nyitó zárójelhez találunk egy vele megegyező típusú berekesztő zárójelet.
		/// false, amennyiben a vizsgált kifejezés ennek a feltételnek nem tesz eleget.</returns>
		public static bool HelyesE(string kifejezes)
		{
			//bejárjuk a paraméterben kapott kifejezést
			for (int i = 0; i < kifejezes.Length; i++)
			{
				//ha a karakter egy nyitó zárójel, tegyük a verembe
				zarojelTalalat = nyitoZarojelRegex.Match(
					kifejezes[i].ToString());
				
				// ekvivalens ezzel a megoldással: if (kifejezes[i] == '{' || kifejezes[i] == '(' || kifejezes[i] == '[')
				if (zarojelTalalat.Success)
					verem.Push(kifejezes[i]);
				// ha a karakter csukó zárójel, akkor vegyük ki a veremből a legutoljára betett nyitó zárójelet, vessük össze a kettőt, hogy egy párnak számít-e

				zarojelTalalat = csukoZarojelRegex.Match(
					kifejezes[i].ToString());
				// ekvivalens ezzel a megoldással: if (kifejezes[i] == '}' || kifejezes[i] == ')' || kifejezes[i] == ']')
				if (zarojelTalalat.Success) //ha csukó zárójelet találok
				{
					//Stack tetejéről kiszedjük az elemet, ha nem alkot egy zárójelpárt a kifejezés elemével, akkor hibás a zárójelezés
					//Nem megfelelő a zárójelezés, amennyiben
						//1. Ha találunk egy csukó zárójelet pár nélkül
						//2. Nem megfelelő típusú a két zárójel, rossz zárójellel zártuk be a nyitó zárójelet. pl. olyan kifejezéseknél, mint {(}), ekkor a zárójelek száma ugyan stimmel, típusuk nem megfelelően követik egymást, a helyes sorrend "{()}" lenne
					if (verem.Count == 0 || 
						!zarojelpartAlkot(verem.Pop(), kifejezes[i]))
						return false;
					//Megjegyzés: Érdemes a verem.Count == 0 feltételt előbb vizsgálni, mivel amennyiben valóban üres a verem, a verem.Pop()-nak nem szabad lefutnia, mivel hibát okozna
					//A shortcut/rövidzár-kiértékelés miatt nem fog a verem.Pop() lefutni, amennyiben verem.Count == 0
				}
			}
			//ha maradt még valami a veremben, akkor maradt nyitó zárójel csukó zárójel nélkül
			return verem.Count == 0; //ha a verem üres, igazzal térünk vissza (helyes a zárójelezés)
		}
		/// <summary>
		/// Megvizsgálja két karakterről, hogy zárójelpárt alkotnak-e.
		/// </summary>
		/// <param name="k1">Összehasonlításban részt vevő első karakter</param>
		/// <param name="k2">Összehasonlításban részt vevő második karakter</param>
		/// <returns>true, amennyiben első karakter nyitó a második karakter berekesztő/csukó zárójel. </returns>
		private static bool zarojelpartAlkot(char k1, char k2)
		{
			return
				(k1 == '(' && k2 == ')') ||
				(k1 == '{' && k2 == '}') ||
				(k1 == '[' && k2 == ']');
		}
	}
}
