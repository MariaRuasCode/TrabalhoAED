using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_AED
{
    internal class Program
    {
        static void LerArquivo(out Dictionary <int, Cursos>dicionario, out Candidato[] vetCand )
        {
            string linha;
            string[] dados;
            int qntCurso, qntCandidatos;
            dicionario = new Dictionary<int, Cursos>();
            vetCand = new Candidato[0];
  
            try
            {
                StreamReader arq = new StreamReader("entrada.txt", Encoding.UTF8);
                linha = arq.ReadLine();
                dados=linha.Split(';');
                qntCurso=int.Parse(dados[0]);
                qntCandidatos=int.Parse(dados[1]);
                vetCand = new Candidato[qntCandidatos];
                for(int i =0; i<qntCurso; i++)
                {
                    linha = arq.ReadLine();
                    dados = linha.Split(';');
                    Cursos curso = new Cursos(int.Parse(dados[0]), dados[1], int.Parse(dados[2]));
                    dicionario.Add(int.Parse(dados[0]), curso);
                }
                for(int i=0; i<qntCandidatos; i++)
                {
                    linha= arq.ReadLine();
                    dados = linha.Split(';');
                    Candidato candidato = new Candidato(dados[0], double.Parse(dados[1]), double.Parse(dados[2]), double.Parse(dados[3]), int.Parse(dados[4]), int.Parse(dados[5]));

                    vetCand[i] = candidato;
                }
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }

        static void ListaSelecionados(Candidato[] vetCand, Dictionary<int, Cursos> dicionario)
        {

            foreach (int j in dicionario.Keys)
            {
                Cursos curso = dicionario[j];
                for (int i = 0; i < vetCand.Length; i++)
                {
                    if (vetCand[i].CodigoOp1 == curso.Codigo)
                    {
                        curso.AdicionarLista(vetCand[i], dicionario);
                    }
                }
            }

            foreach (int j in dicionario.Keys)
            {
                Cursos curso = dicionario[j];
                for (int i = 0; i < vetCand.Length; i++)
                {
                    if (vetCand[i].CodigoOp2 == curso.Codigo)
                    {
                        curso.AdicionarLista(vetCand[i], dicionario);
                    }
                }
                Console.WriteLine("\n" + curso.NomeCurso + " " + curso.NotaCorte);
                foreach (Candidato candidato in curso.ListaSelecionados)
                    Console.WriteLine(candidato);
                //Colocar a escrita do arquivo dentro do for/foreach
            }

        }

        static void Main(string[] args)
        {
            Candidato[] vetCand;
            Dictionary<int, Cursos> dicionario;

            LerArquivo(out dicionario, out vetCand);
           
            for(int i=0;i<vetCand.Length; i++)
            {
                Console.WriteLine(vetCand[i]);
            }
  
            ListaSelecionados(vetCand, dicionario);
            
            Console.ReadLine();
        }
    }
}
