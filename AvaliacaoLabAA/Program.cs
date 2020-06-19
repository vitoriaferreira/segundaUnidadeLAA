using System;
using System.Collections.Generic;
using System.Linq;

namespace AvaliacaoLabAA
{
    class Program
    {
        public static void Main(String[] args)
        {
            PrimeiraQuestao();
            Console.WriteLine("----------------------------------------");
            SegundaQuestao();
            Console.WriteLine("----------------------------------------");
            TerceiraQuestao();
            Console.ReadKey();
        }

        private static void TerceiraQuestao()
        {
            var grafo = ObterGrafo("file1.txt");
            var vertices = new List<int>();

            foreach (var linha in grafo)
            {
             vertices.Add(linha[0]);   
            }

            var matriz = new int[vertices.Count, vertices.Count];
            for (int i = 0; i < vertices.Count; i++)
            {
                for (int j = 0; j < vertices.Count; j++)
                {
                    if (grafo[i].Contains(grafo[j][0]) && i!=j)
                    {
                        matriz[i, j] = 1;
                    }
                    else
                    {
                        matriz[i, j] = 0;
                    }
                }
            }

            for (int i = 0; i < vertices.Count; i++)
            {
                for (int j = 0; j < vertices.Count; j++)
                {
                    Console.Write($"{matriz[i,j]} ");
                }
                Console.WriteLine();
            }

        }

        private static void PrimeiraQuestao()
        {
            //Letra A, carregando o grafo em memória
            var grafo = ObterGrafo("file1.txt");

            //Letras B, C e D, Imprimindo cada vértice, seus adjacentes e a quantidade deles na mesma linha
            ImprimirGrafo(grafo);

            //Letra E, Imprimindo complexidade
            ImprimirComplexidade(grafo);
        }

        private static void SegundaQuestao()
        {
            //Letra A, carregando grafo em memória
            var grafo = ObterGrafo("file2.txt");

            //Letra B e C, Imprimindo cada vértice e a quantidade deles na mesma linha
            ImprimirGrafoSemAdjacentes(grafo);

            CalcularArestas(grafo);
        }

        private static void CalcularArestas(List<int>[] grafo)
        {
            var arestas = 0;

            foreach (var linha in grafo)
            {
                for (int i = 0; i < linha.Count; i++)
                {
                    if (i != 0)
                    {
                        arestas++;
                    }
                }
            }
            //Para ficar com a mesma quantidade de quebras de linha do exemplo
            Console.WriteLine();
            if (arestas == 0)
            {
                Console.WriteLine("Este grafo é Nulo!");
            } 
            else
            {
                Console.WriteLine($"Este grafo possui {arestas} arestas");
            }
        }

        private static void ImprimirComplexidade(List<int>[] grafo)
        {
            int complexidade = 0;

            foreach (var linha in grafo)
            {
                foreach (var unused in linha)
                {
                    complexidade++;
                }   
            }

            Console.WriteLine($"A complexidade deste grafo é: {complexidade}");
        }

        private static List<int>[] ObterGrafo(string arquivo)
        {
            var linhas = System.IO.File.ReadAllLines(arquivo).ToList();

            int quantidadeLinhas = linhas.Count;

            var grafo = new List<int>[quantidadeLinhas];

            for (int i = 0; i < quantidadeLinhas; i++)
            {
                grafo[i] = new List<int>();
                var vertices = linhas[i].Split("\t").ToList();

                foreach (string t in vertices)
                {
                    grafo[i].Add(int.Parse(t));
                }
            }

            return grafo;
        }

        static void ImprimirGrafo(List<int>[] grafo)
        {
            for (int i = 0; i < grafo.Length; i++)
            {
                var linha = grafo[i];
                Console.Write($"{linha[0]}: ");
                
                for (int j = 1; j < linha.Count; j++)
                {
                    Console.Write($"{linha[j]} ");
                }
                Console.WriteLine($"(quantidade de vértices adjacentes: {linha.Count - 1})");
            }
        }
        
        static void ImprimirGrafoSemAdjacentes(List<int>[] grafo)
        {
            foreach (var linha in grafo)
            {
                Console.WriteLine($"{linha[0]}: (quantidade de vértices adjacentes: {linha.Count - 1})");
            }
        }
    }
}
