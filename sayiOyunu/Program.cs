using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace sayiOyunu
{
    
    class Program
    {
        static void Main(string[] args)
        {
            // oyun bilgisi 
            Console.WriteLine("Bir kelime bir sayı oyununun bir sayı kısmına hoş geldiniz!");
            Console.WriteLine("Oyunun amacı siz tarafından elle girilen ya da rastgele verilen sayılarla sadece dört işlem kullanarak kullanıcının belirleyeceği sayıya yaklaşmak veya ulaşmaktır. ");
            Console.WriteLine("Öncelikle hangi sayının bulunacağını girmelisiniz, ardından da sayıların manuel ya da random gelmesi için M ya da R harfini kullanmalısınız.");
            Console.WriteLine("Eğer hedef sayıya tam ulaşılırsa 10 puan, ulaşılmazsa; hedef sayıdan uzaklaşılan her bir sayı için 1 puan kırılır.");
            Console.WriteLine("Bol şans!\n");

            // işimizi görecek olan değişken ve dizi tanımlamaları
            Random random = new Random();
            int[] oneDigitNums = new int[]  // tek haneli sayılar
            {
                0,1,2,3,4,5,6,7,8,9
            };

            int[] twoDigitTimesTen = new int[] // çift haneli ve 10'un katı olanlar
            {
                10,20,30,40,50,60,70,80,90
            };

            char[] operators = new char[]   // operatörler
            {
                '+','-','/','*'
            };
            
            List<int> listeyiDoldurmakIcinListe = new List<int>();  // oluşturulan sayıların tekrardan kullanılmak için atıldığı liste
            List<int> olusturulanSayilar = new List<int>();    // oluşturulan sayıların atılacağı liste

            int randomIndex;    // listeden random sayı seçmek için random indeks değişkeni
            int result = 0; // sonuç değişkeni
            int targetNumber;   // işlemlerle bulunacak olan sayı
            Console.Write("\nBulunmasını istediğiniz sayıyı girin : ");
            targetNumber = int.Parse(Console.ReadLine());   // kullanıcıdan hedef sayıyı alıyoruz

            char randomOrManual;    // random ya da manuel girişi sağlayacak olan değişken

            // kullanıcıdan random / manuel giriş için harf alıyoruz
            Console.Write("Sayılarınız random mu gelsin, yoksa elle mi? (R:Random / M: Manuel) ---> ");
            randomOrManual = Convert.ToChar(Console.ReadLine());

            // switch case , R basılırsa random M basılırsa manuel giriş sağlayacak
            switch(randomOrManual)
            {
                case 'R':
                    Console.Write("Olusturulan sayilar : ");

                    // 5 tek haneli sayı oluşturup diziye atıyoruz
                    for (int i = 0; i < 5; i++)
                    {
                        randomIndex = random.Next(0, oneDigitNums.Length);
                        Console.Write(oneDigitNums[randomIndex] + " ");
                        olusturulanSayilar.Add(oneDigitNums[randomIndex]);
                        listeyiDoldurmakIcinListe.Add(oneDigitNums[randomIndex]);
                    }

                    // 1 çift haneli sayı oluşturup diziye atıyoruz
                    for (int i = 0; i < 1; i++)
                    {
                        randomIndex = random.Next(0, twoDigitTimesTen.Length);
                        Console.Write(twoDigitTimesTen[randomIndex] + " ");
                        olusturulanSayilar.Add(twoDigitTimesTen[randomIndex]);
                        listeyiDoldurmakIcinListe.Add(twoDigitTimesTen[randomIndex]);
                    }

                    
                    NumberOperations.numberOperations(operators, targetNumber, olusturulanSayilar, listeyiDoldurmakIcinListe,ref result);
                    break;
                    
                case 'M':
                    Console.Write("Lütfen sayıları girin.. 5 adet tek haneli ve 1 adet 10'un katı olan çift haneli sayı girin.\n");
                    for (int i = 0; i < 6; i++)
                    {
                        Console.Write(i + 1 + ".sayiyi girin : ");
                        olusturulanSayilar.Add(Convert.ToInt32(Console.ReadLine()));
                        listeyiDoldurmakIcinListe.Add(olusturulanSayilar[i]);
                    }

                    Console.Write("Girdiğiniz sayılar : ");
                    for (int i = 0; i < olusturulanSayilar.Count; i++)
                        Console.Write(olusturulanSayilar[i] + " ");
                    
                    NumberOperations.numberOperations(operators, targetNumber, olusturulanSayilar, listeyiDoldurmakIcinListe,ref result);
                    break;                                
            }

            Console.Write(NumberOperations.scoringOperations(targetNumber, result) + " puan kazandınız...!");

            Console.ReadLine();
        }
    }
}

