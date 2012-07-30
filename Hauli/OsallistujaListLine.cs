using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hauli
{
    public interface OsallistujaListLine
    {
        int Id { get; set; }
        int Nro { get; set; }
        string Sukunimi { get; set; }
        string Nimi { get; set; }
        int Kierros25 { get; set; }
        int Kierros50 { get; set; }
        int Kierros75 { get; set; }
        int Kierros100 { get; set; }
        int Kierros125 { get; set; }
        int KierrosRatkonta { get; set; }
        int FinaaliKierros { get; set; }
        int FinaaliRatkonta { get; set; }
        int Yht { get; set; }
    }

    public class Osallistuja : OsallistujaListLine
    {
        private int id;
        private int nro;
        private string sukunimi;
        private string nimi;
        private int kierros25;
        private int kierros50;
        private int kierros75;
        private int kierros100;
        private int kierros125;
        private int kierrosRatkonta;
        private int finaaliKierros;
        private int finaaliRatkonta;
        private int yht;
    
        public Osallistuja(int id, int nro, string sukunimi, string nimi, int kierros25, 
                           int kierros50, int kierros75, int kierros100, int kierros125, 
                           int kierrosRatkonta, int finaaliKierros, int finaaliRatkonta, int yht)
        {
            this.id = id;
            this.nro = nro;
            this.sukunimi = sukunimi;
            this.nimi = nimi;
            this.kierros25 = kierros25;
            this.kierros50 = kierros50;
            this.kierros75 = kierros75;
            this.kierros100 = kierros100;
            this.kierros125 = kierros125;
            this.kierrosRatkonta = kierrosRatkonta;
            this.finaaliKierros = finaaliKierros;
            this.finaaliRatkonta = finaaliRatkonta;
            this.yht = yht;
        }

        public Osallistuja(Osallistuja c)
        {
            this.id = c.id;
            this.nro = c.nro;
            this.sukunimi = c.sukunimi;
            this.nimi = c.nimi;
            this.kierros25 = c.kierros25;
            this.kierros50 = c.kierros50;
            this.kierros75 = c.kierros75;
            this.kierros100 = c.kierros100;
            this.kierros125 = c.kierros125;
            this.kierrosRatkonta = c.kierrosRatkonta;
            this.finaaliKierros = c.finaaliKierros;
            this.finaaliRatkonta = c.finaaliRatkonta;
            this.yht = c.yht;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public int Nro
        {
            get { return nro; }
            set { nro = value; }
        }

        public string Sukunimi
        {
            get { return sukunimi; }
            set { sukunimi = value; }
        }

        public string Nimi
        {
            get { return nimi; }
            set { nimi = value; }
        }

        public int Kierros25
        {
            get { return kierros25; }
            set { kierros25 = value; }
        }
        
        public int Kierros50
        {
            get { return kierros50; }
            set { kierros50 = value; }
        }
        
        public int Kierros75
        {
            get { return kierros75; }
            set { kierros75 = value; }
        }

        public int Kierros100
        {
            get { return kierros100; }
            set { kierros100 = value; }
        }

        public int Kierros125
        {
            get { return kierros125; }
            set { kierros125 = value; }
        }

        public int KierrosRatkonta
        {
            get { return kierrosRatkonta; }
            set { kierrosRatkonta = value; }
        }

        public int FinaaliKierros
        {
            get { return finaaliKierros; }
            set { finaaliKierros = value; }
        }

        public int FinaaliRatkonta
        {
            get { return finaaliRatkonta; }
            set { finaaliRatkonta = value; }
        }

        public int Yht
        {
            get { return yht; }
            set { yht = value; }
        }
    }
}
