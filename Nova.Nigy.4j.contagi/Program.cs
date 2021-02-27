using System.Linq;
using Newtonsoft.Json;
using System.IO;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Nova.Nigy._4j.contagi
{
    class Program
    {
        static Stampa[] stampa = new Stampa[1100];
        static void Main(string[] args)
        { 
            using (var reader = new StreamReader("ContagiRimini.csv"))
            {
                int i = 0;
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    string[] values = line.Split(',');

                    stampa[i] = new Stampa(values[0], values[1], values[2]);
                    i++;

                }
            }
            string jsonToWrite = JsonConvert.SerializeObject(stampa, Formatting.Indented);

            using (StreamWriter writer = new StreamWriter("contagiRimini.json"))
            {
                writer.Write(jsonToWrite);

            }
        }
    }
    class Stampa
    {
        public string Giorno, progressivo, contagi;
        
        public Stampa(string giorno, string prog, string cont)
        {
            Giorno = giorno;
            progressivo = prog;
            contagi = cont;
        }
    }
}
