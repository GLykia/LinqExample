using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace LinqExample
{
    public class Personel
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        private double Maas { get; set; }
        public const string dosya_yolu= @"C:\Users\emreu\source\repos\LinqExample\LinqExample\Personeller.txt";
        public List<Personel> personels = new List<Personel>();
        public double MAAS
        {
            get { return Maas; }
            set { Maas = value; }
        }

        public void Oku()
        {
            personels.Clear();
            int satir = File.ReadAllLines(dosya_yolu).Length;
            string[] satirdizi;
            
            satirdizi = File.ReadAllLines(dosya_yolu);
            FileStream fs = new FileStream(dosya_yolu, FileMode.OpenOrCreate);
            using (StreamReader streader= new StreamReader(fs))
            {
                string[] degerdizi;
                for (int i = 0; i < satir; i++)
                {
                    if (satirdizi[i] != null)
                    {
                        degerdizi = satirdizi[i].Split('-');
                        personels.Add(new Personel
                        {
                            Ad = degerdizi[0],
                            Soyad = degerdizi[1],
                            MAAS = double.Parse(degerdizi[2])
                        });
                    }
                }
            }
        }
        public void KayitEkle()
        {
            Oku();
            Personel yperson = new Personel();
            Console.Write("Personel adını giriniz: ");
            yperson.Ad = Console.ReadLine();
            Console.Write("Personel soyadını giriniz: ");
            yperson.Soyad = Console.ReadLine();
            Console.Write("Personelin Maaşını giriniz: ");
            yperson.MAAS = int.Parse(Console.ReadLine());
            personels.Add(yperson);
            Yaz();
        }
        public void Yaz()
        {
            int satir = File.ReadAllLines(dosya_yolu).Length+1;

            FileStream fs = new FileStream(dosya_yolu, FileMode.Open);
            using (StreamWriter stream = new StreamWriter(fs))
            {
                for (int i = 0; i < satir; i++)
                {
                    stream.Write(personels[i].Ad + "-");
                    stream.Write(personels[i].Soyad + "-");
                    stream.Write(personels[i].MAAS);
                    stream.WriteLine("");
                }
            }
        }
        public void Ara(string ad)
        {
            var sorgu = personels.Where(x => x.Ad.ToLower().Contains(ad) | x.Soyad.ToLower().Contains(ad));
            foreach (var item in sorgu)
            {
                Console.WriteLine($"{item.Ad + " "+ item.Soyad} bulundu.");
            }
        }
        public void Ara(double maas)
        {
            var sorgu = personels.Where(x => x.Maas==maas);
            foreach (var item in sorgu)
            {
                Console.WriteLine($"{item.Ad + " " + item.Soyad} bulundu.");
            }
        }
    }
}
