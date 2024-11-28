using System;

namespace Trabalho_AED
{
    internal class Candidato
    {
        private string nome;
        private double notaRedacao;
        private double notaMatematica;
        private double notaLinguagens;
        private int codigoOp1;
        private int codigoOp2;
        private double media;

        public Candidato(string nome, double notaRedacao, double notaMatematica, double notaLinguagens, int codigoOp1, int codigoOp2)
        {
            this.nome = nome;
            this.notaRedacao = notaRedacao;
            this.notaMatematica = notaMatematica;
            this.notaLinguagens= notaLinguagens;
            this.codigoOp1 = codigoOp1;
            this.codigoOp2 = codigoOp2;
            media = (notaRedacao+notaMatematica+notaLinguagens)/3;
        }
               

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }
        public double NotaRedacao
        {
            get { return notaRedacao; }
            set { notaRedacao = value; }
        }
        public double NotaMatematica
        {
            get { return notaMatematica; }
            set { notaMatematica = value; }
        }
        public double NotaLinguagens
        {
            get { return notaLinguagens; }
            set { notaLinguagens = value; }
        }
        public int CodigoOp1
        {
            get { return codigoOp1; }
            set { codigoOp1 = value; }
        }
        public int CodigoOp2
        {
            get { return codigoOp2; }
            set { codigoOp2 = value; }
        }
        public double Media
        {
            get { return media; }
            set { media = value; }
        }      

        public override string ToString()
        {
            return $"{nome} {media.ToString("N2")} {notaRedacao} {notaMatematica} {notaLinguagens}";
        }
    }
}
