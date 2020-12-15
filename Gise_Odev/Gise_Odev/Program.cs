using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gise_Odev
{
    

    class Program
    {
        static string Gise_number; //girilen gise değeri
        static string Cikis_number;//cikis yapılan gişe değeri
        static bool isThere = true; //girilen gise var mı
        static string Bridge_yes_no; //girilen E ve H değerini tutar 
        static bool Bridge_dont_use = false; //köprü kullanıldı mı
        static int girisIndex; //girilen gişe indexi
        static int cikisIndex; //çikilan gişe indexi


        static void  GirisYapilanGise(string Gise_number, string[] GiseName)
        {
            Console.Write("Giriş Yapılan Gişeyi Giriniz: ");
            Gise_number = Console.ReadLine();

            for (int i = 0; i < 10; i++)
            {
               if(Gise_number == GiseName[i] )
                {
                    isThere = false;
                    //Console.WriteLine("Doğru");
                    girisIndex = i + 1;
                    break; //Eğer hiç doğru yoksa bool çalişir ve tekrar fok çağrılır
                }
               
            }


            if (isThere == true)
            {
                Console.WriteLine("Gise ismini yanlış girdiniz!! \n");
                GirisYapilanGise(Gise_number, GiseName);
            }

        }

        static void CikisYapilanGise(string Cikis_number, string[] GiseName )
        {
            Console.Write("Cıkış Yapılan Gişeyi Giriniz: ");
            Cikis_number = Console.ReadLine();
            for (int i = 0; i < 10; i++)
            {
                if (Cikis_number == GiseName[i])
                {
                    isThere = false;
                    //Console.WriteLine("Doğru");
                    cikisIndex = i + 1;
                    break; //eğer hiç doğru yoksa bool çalişir ve tekrar fonksiyon çağrılır
                }
            }
            if (isThere == true)
            {
                Console.WriteLine("Gise ismini yanlış girdiniz!! \n");
                CikisYapilanGise(Cikis_number, GiseName);
            }

        }


        static void WereBrigdeUsed() //köprü kullanıldı mı fonksiyonu
        {

            Console.WriteLine("______________________________________");
            Console.Write("Köprü kullanıldı mı? (E/H) ");
            Bridge_yes_no = Console.ReadLine();

            if(Bridge_yes_no == "E" || Bridge_yes_no == "e")
            {
                Bridge_dont_use = true;
               // Console.WriteLine("girdi");
                
            }
            else if (Bridge_yes_no == "H" || Bridge_yes_no == "h")
            {
                Bridge_dont_use = false;
               // Console.WriteLine("girmedi!!");
                
            }
            else
            {
                Console.WriteLine("Yanlış harf girdiniz!!");
                WereBrigdeUsed();
            }

        }

        static void GiseleriYazdir(string[] GiseName)
        {
            Console.WriteLine("______________________________________");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("{0} - {1}", i + 1, GiseName[i]);
            }
        }

        static void UcretHesapla(string[] GiseName)
        {
            Console.WriteLine("______________________________________");
            int toplamUcret = girisIndex - cikisIndex;
            toplamUcret = 15 * (Math.Abs(toplamUcret));
            
            if(Bridge_dont_use == true)
            {
                toplamUcret += 8;
            }

            Console.WriteLine("Giriş Yapılan Gişe: "+ GiseName[girisIndex-1]);
            Console.WriteLine("Çıkış Yapılan Gişe: " + GiseName[cikisIndex-1]);
            Console.WriteLine("Toplam Ucret: {0} TL olarak belirlenmiştir.",toplamUcret);

            

        }
        static void Main(string[] args)
        {

            string[] GiseName = { "Abant", "Düzce","Batı Hereke","Batı İzmit","Babaeski","Ankara","Gerede","Kurtköy","Kaynaşlı","Mahmutbey" };
            

            Console.WriteLine("HGS ve OGS GEÇİŞ ÜCRETİ HESAPLAMA");
 
            
            GiseleriYazdir(GiseName);
            GirisYapilanGise(Gise_number, GiseName);
            isThere = true;

            GiseleriYazdir(GiseName);
            CikisYapilanGise(Cikis_number, GiseName);

            WereBrigdeUsed();//köprü kullanıldımı 

            UcretHesapla(GiseName);//ücret hesaplar
            
            

            Console.ReadKey();

        }
    }
}
