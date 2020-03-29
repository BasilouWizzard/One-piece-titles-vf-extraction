using System;
using System.IO;
using System.Text;

namespace extraction_des_titres
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"path to file";
            string[] liste = ExtraireTitres(path);
            liste = StripBetweenTags(liste);
            AfficherTableau(liste);

        }
        public static string[] ExtrairePhrase(string path)
        {

            StreamReader test = new StreamReader(path);
            string[] phrase = test.ReadLine().Split(" ");
            return phrase;
        }

        static void LireUnTxt(string path)
        {
            string[] readText = File.ReadAllLines(path, Encoding.UTF8);
            foreach (string s in readText)
            {
                Console.WriteLine(s);
            }
        }
        public static string[] ExtraireTitres(string path)
        {
            string[] listeEpisodes = new string[62];
            int i = 1;
            int a = 0;
            string[] readText = File.ReadAllLines(path);
            foreach (string s in readText)
            {
                a++;
                if ((" | NumeroEpisode = " + i == s) | (" | NumeroEpisode  = " + i == s))
                {
                    listeEpisodes[i] = i + readText[a].Replace((" | TitreFrançais  = "), " ");
                    //Console.WriteLine(i + readText[a].Replace((" | TitreFrançais  = "), " ") );
                    i++;
                }
            }
            return listeEpisodes;
        }

        public static void AfficherTableau(String[] tab)
        {
            for (int a = 0; a < tab.Length; a++)
            {
                Console.WriteLine(tab[a]);
            }
        }
        private static string[] StripBetweenTags(string[] liste)
        {
            for (int i = 1; i < liste.Length; i++)
            {
                // Find the closing tag.
                int lastLocation = liste[i].IndexOf("<");
                // Remove the tag.
                if (lastLocation >= 0)
                {
                    string remove = liste[i].Substring(lastLocation, 34);
                    liste[i] = liste[i].Replace(remove, "");

                }
            }
        return liste;
        }
    }
}
