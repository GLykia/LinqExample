using System;


namespace LinqExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Personel personel = new Personel();
            personel.KayitEkle();
            Console.WriteLine("Ad soyada göre arama");
            string arama = Console.ReadLine();
            personel.Ara(arama);
            Console.WriteLine("Maasa göre arama");
            double aramamaas = double.Parse(Console.ReadLine());
            personel.Ara(aramamaas);
        }
    }
}
