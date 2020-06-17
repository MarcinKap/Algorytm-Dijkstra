using System;
using System.IO;
namespace Dijkstra
{
    class Program
    {
        const int MAX_INT = Int32.MaxValue;//
        static void Main(string[] args)
        {
            String[] lines = File.ReadAllLines("graf.txt");// czytanie pliku
            String firstLine = lines[0]; // pobranie pierwszej lini
            String[] values = firstLine.Split(" ");//podzielenie pierwszej lini
            int v = Int32.Parse(values[0]); // wezel startowy
            int n = Int32.Parse(values[1]); // liczba wierzcholkow
            int m = Int32.Parse(values[2]); // liczba krawedzi
            bool[] QS = new bool[n]; // zbiory Q i S
            int[] d = new int[n]; // tablica kosztów dojścia
            int[] p = new int[n]; // tablica poprzedników
            int[] S = new int[n]; //stos
            Element[] graf = new Element[n]; // Tablica list sąsiedztwa
            int sptr = 0;//wskaźnik stosu
            //inicjacja zbiorów
            for (int i = 0; i < n; i++)
            {
                d[i] = MAX_INT;
                p[i] = -1;
                QS[i] = false;
                graf[i] = null;
            }
            //odczytujemy dane wejściowe
            for (int i = 1; i <= m; i++)
            {
                String line = lines[i];
                String[] elements = line.Split(" ");
                int x = Int32.Parse(elements[0]); // wierzcholek początkowy
                int y = Int32.Parse(elements[1]); // wierzchołek docelowy krawędzi
                int w = Int32.Parse(elements[2]); // waga krawędzi
                Element next = graf[x];
                Element el = new Element(y, w, next);
                graf[x] = el;
            }
            d[v] = 0; // koszt dojścia jest zerowy
            int u;
            int j;
            // wyznaczanie ścieżek
            for (int i = 0; i < n; i++)
            {

                //szukamy wierzchołka w Q o najmniejszym koszcie d
                for (j = 0; QS[j]; j++) ; // inkrementujemy j w zależności od ilości wierzchołków w Q
                for (u = j++; j < n; j++)
                {
                    if (!QS[j] && (d[j] < d[u]))
                    {
                        u = j;
                    }
                }
                //Znaleziony wierzchołek przenosimy do S
                QS[u] = true;
                //modyfikujemy sąsiadów u, którzy są w Q
                Element pw = graf[u];
                while (pw != null)
                {
                    if (!QS[pw.v] && (d[pw.v] > d[u] + pw.w))
                    {
                        d[pw.v] = d[u] + pw.w;  //przypisanie kosztów dojścia
                        p[pw.v] = u; // przypisanie poprzednika
                    }
                    pw = pw.next;
                }

            }
            for (int i = 0; i < n; i++)
            {
                String line = "";
                line = i + ":";
                for (j = i; j > -1; j = p[j]) S[sptr++] = j;
                while (sptr > 0)
                {
                    line = line + S[--sptr] + " ";
                }
                line = line + "$" + d[i];
                Console.WriteLine(line);
            }

        }
    }
}
