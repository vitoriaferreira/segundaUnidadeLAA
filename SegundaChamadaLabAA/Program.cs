using System;
using System.Collections.Generic;
using System.Linq;

namespace SegundaChamadaLabAA
{
    class Program
    {
        static void Main(string[] args)
        {
            var listaOriginal = new List<int>() { 2, 6, 8, 1, 18, 25, 7, 3, 52, 68, 9, 1 };
            var listaBubbleSort = BubbleSort(listaOriginal); //Melhor caso:n, pior caso:n² 
            var listaCocktailSort = cocktailSort(listaOriginal); //Melhor caso:n, pior caso:n² 
            var listaQuickSort = quickSort(listaOriginal); //Melhor caso:n*log(n), pior caso:n² 

            ImprimirLista("lista não ordenada", listaOriginal);
            ImprimirLista("BubbleSort: Melhor caso:n, pior caso:n²", listaBubbleSort);
            ImprimirLista("CocktailSort: Melhor caso:n, pior caso:n²", listaCocktailSort);
            ImprimirLista("QuickSort: Melhor caso:n*log(n), pior caso:n²", listaQuickSort);
        }


        private static List<int> BubbleSort(List<int> listaEntrada)
        {
            var lista = new List<int>(listaEntrada);
            int tamanho = lista.Count;

            for (int i = tamanho - 1; i >= 1; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (lista[j] > lista[j + 1])
                    {
                        int aux = lista[j];
                        lista[j] = lista[j + 1];
                        lista[j + 1] = aux;
                    }
                }
            }
            return lista;
        }

        private static List<int> cocktailSort(List<int> listaEntrada)
        {
            var lista = new List<int>(listaEntrada);
            int tamanho = lista.Count;
            int inicio = 0;
            int fim = tamanho - 1;
            int swap = 0;
            while (swap == 0 && inicio < fim)
            {
                swap = 1;
                int aux;
                for (int i = inicio; i < fim; i++)
                {
                    if (lista[i] > lista[i + 1])
                    {
                        aux = lista[i];
                        lista[i] = lista[i + 1];
                        lista[i + 1] = aux;
                        swap = 0;
                    }
                }

                fim--;

                for (int i = fim; i > inicio; i--)
                {
                    if (lista[i] < lista[i - 1])
                    {
                        aux = lista[i];
                        lista[i] = lista[i - 1];
                        lista[i - 1] = aux;
                        swap = 0;
                    }
                }

                inicio++;
            }

            return lista;
        }

        private static List<int> quickSort(List<int> listaEntrada)
        {
            var lista = new List<int>(listaEntrada);

            quickSort(lista, 0, lista.Count - 1);

            return lista;
        }

        private static void quickSort(List<int> lista, int inicio, int fim)
        {
            if (inicio < fim)
            {
                int p = lista[inicio];
                int i = inicio + 1;
                int f = fim;

                while (i <= f)
                {
                    if (lista[i] <= p)
                    {
                        i++;
                    }
                    else if (p < lista[f])
                    {
                        f--;
                    }
                    else
                    {
                        int troca = lista[i];
                        lista[i] = lista[f];
                        lista[f] = troca;
                        i++;
                        f--;
                    }
                }

                lista[inicio] = lista[f];
                lista[f] = p;

                quickSort(lista, inicio, f - 1);
                quickSort(lista, f + 1, fim);
            }
        }


        private static void ImprimirLista(string descricao, List<int> lista)
        {
            Console.WriteLine($"{descricao}");
            Console.WriteLine(string.Join(", ", lista.Select(item => item.ToString()).ToList()));
            Console.WriteLine();
        }
	}
}
