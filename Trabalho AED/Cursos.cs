using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_AED
{
    internal class Cursos
    {
        private int cogigo;
        private string nomeCurso;
        private int quantVagas;
        private List<Candidato> listaSelecionados;
        private double notaCorte;
        public Cursos (int cogigo, string nomeCurso, int quantVagas)
        {
            this.cogigo = cogigo;
            this.nomeCurso = nomeCurso;
            this.quantVagas = quantVagas;
            listaSelecionados = new List<Candidato> (quantVagas-1);
        }

        public void AdicionarLista (Candidato candidatoSelecionado, Dictionary<int, Cursos> dicionario)
        {
            if (!Selecionado(candidatoSelecionado, dicionario)) 
            {
                if (listaSelecionados.Count < quantVagas) //Quando a lista ainda tem espaço
                {
                    listaSelecionados.Add(candidatoSelecionado);
                    OrdenarLista();
                }

                else //Quando a lista está cheia
                {
                    if (notaCorte < candidatoSelecionado.Media) //Média do candidato maior que a nota de corte
                    {
                        listaSelecionados[quantVagas - 1] = candidatoSelecionado;
                        OrdenarLista();
                    }
                    else if (notaCorte == candidatoSelecionado.Media) //Se a nota de corte e a média forem iguais
                    {
                        if (listaSelecionados[quantVagas - 1].NotaRedacao < candidatoSelecionado.NotaRedacao) //Desempate pela redação
                        {
                            listaSelecionados[quantVagas - 1] = candidatoSelecionado;
                        }
                        else if (listaSelecionados[quantVagas - 1].NotaRedacao == candidatoSelecionado.NotaRedacao)
                        {
                            if (listaSelecionados[quantVagas - 1].NotaMatematica < candidatoSelecionado.NotaMatematica) //Desempate pela nota de matemática
                            {
                                listaSelecionados[quantVagas - 1] = candidatoSelecionado;
                            }
                        }
                        OrdenarLista();
                    }
                    else //Se a média do candidato for maior que a nota de corte
                    {
                        for (int i = 0; i < quantVagas; i++) //Passa em toda a lista para conferir se a média é maior do que a de alguém selecionado
                        {
                            if (candidatoSelecionado.Media > listaSelecionados[i].Media) //Se for maior, tira o ultimo colocado e insere o candidato atual, na hora de ordenar vai ajeitar a ordem
                            {
                                listaSelecionados[quantVagas-1]= candidatoSelecionado;
                            }
                            else if (candidatoSelecionado.Media == listaSelecionados[i].Media)
                            {
                                if (listaSelecionados[i].NotaRedacao < candidatoSelecionado.NotaRedacao) //Desempate pela redação
                                {
                                    listaSelecionados[quantVagas-1] = candidatoSelecionado;
                                }
                                else if (listaSelecionados[quantVagas-1].NotaRedacao == candidatoSelecionado.NotaRedacao) //Desempate pela nota de matemática
                                {
                                    if (listaSelecionados[i].NotaMatematica < candidatoSelecionado.NotaMatematica)
                                    {
                                        listaSelecionados[quantVagas-1] = candidatoSelecionado;
                                    }
                                }
                            }
                        }
                        OrdenarLista();
                    }
                }
                notaCorte = listaSelecionados[listaSelecionados.Count - 1].Media; //Atualiza a nota de corte
            }
        }

        private bool Selecionado(Candidato cand, Dictionary<int, Cursos> dicionario) //Ver se o candidato já está em outra lista antes de adicionar em alguma
        {
            foreach (Cursos curso in dicionario.Values)
            {
                if (curso.ListaSelecionados.Contains(cand))
                {
                    return true;
                }
            }
            return false;
        }

        internal void OrdenarLista() //Uso do bolha
        {
            Candidato temp;
            for (int i = 0; i < listaSelecionados.Count - 1; i++)
            {
                for (int j = listaSelecionados.Count - 1; j > i; j--)
                {
                    if (listaSelecionados[j].Media > listaSelecionados[j - 1].Media) //Ordenado por media
                    {                       
                        temp = listaSelecionados[j];
                        listaSelecionados[j] = listaSelecionados[j - 1];
                        listaSelecionados[j - 1] = temp;
                    }
                    else if (listaSelecionados[j].Media == listaSelecionados[i].Media)
                    {
                        if (listaSelecionados[j].NotaRedacao > listaSelecionados[j - 1].NotaRedacao) //Ordenando por nota da redação
                        {
                            temp = listaSelecionados[j];
                            listaSelecionados[j] = listaSelecionados[j - 1];
                            listaSelecionados[j - 1] = temp;
                        }
                        else if (listaSelecionados[j].NotaRedacao == listaSelecionados[j - 1].NotaRedacao) //Ordenando pela nota de matemática
                        {                           
                            if (listaSelecionados[j].NotaMatematica > listaSelecionados[j - 1].NotaMatematica)
                            {
                                temp = listaSelecionados[j];
                                listaSelecionados[j] = listaSelecionados[j - 1];
                                listaSelecionados[j - 1] = temp;
                            }
                        }
                    }
                }
            }
        }


        public int Codigo
        {
            get { return cogigo; }
            set { cogigo = value; }
        }
        public string NomeCurso
        {
            get { return nomeCurso; }
            set { nomeCurso = value; }
        }
        public int QuantVagas
        {
            get { return quantVagas; }
            set { quantVagas = value; }
        }
        public List <Candidato> ListaSelecionados
        {
            get { return listaSelecionados; }
            set { listaSelecionados = value; }
        }
        public double NotaCorte
        {
            get { return notaCorte; }
            set { notaCorte = value; }
        }
        public override string ToString()
        {
            return $"Código: {cogigo}, Nome: {nomeCurso}, Quantidade de Vagas {quantVagas}, NotaCorte: {notaCorte.ToString("N2")}";
        }

    }
}
