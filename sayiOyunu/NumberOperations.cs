using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sayiOyunu
{
    static class NumberOperations
    {

        // gerekli işlemlerin yapıldığı fonksiyon
        public static int numberOperations(char[] operators,int targetNumber,List<int> olusturulanSayilar,List<int> listeyiDoldurmakIcinListe,ref int result)
        {
            // sonuc bulundugunda islemleri yazdirabilmek icin gereken
            List<int> islemdeKullanilanSayilar = new List<int>();
            List<int> sonuclar = new List<int>();
            List<char> kullanilanOperatorler = new List<char>();
            Random random = new Random();
            int randomIndex;
            int operatorIndex = 0;
            int sonucIndex = 0;

            Console.WriteLine("\n");

            int ilkIslemIcinSecilenSayi;    // ilk işlem için seçilen sayı
            char _operator;    // operatör değişkeni
            int operatorRandom; // operatörün rastgele seçilmesi için oluşturulan değişken
           
            // hedef sayıya ulaşana kadar ya da +-9 fark kadar yakın olana kadar dönen bir döngü
            while (true)
            {
                // eğer ki liste boşaldıysa ve hedef sayıya ulaşılmadıysa listeyi tekrardan dolduruyoruz ve işlemlere aynen devam ediyoruz
                // hedef sayıya ulaşılmama durumunu aşağıda kontrol ediyoruz
                if (ListOperations.isEmpty(olusturulanSayilar))
                {
                    ListOperations.fillList(olusturulanSayilar, listeyiDoldurmakIcinListe);
                    kullanilanOperatorler.Clear();
                    islemdeKullanilanSayilar.Clear();
                    sonuclar.Clear();
                    operatorIndex = 0;
                    sonucIndex = 0;
                }

                // sıkıntı yaşamamak için sıfırlanan değişkenler
                result = 0;

                // burada ilk işlem için sayı seçiliyor ve listeye ekleniyor
                randomIndex = random.Next(0, olusturulanSayilar.Count);
                ilkIslemIcinSecilenSayi = olusturulanSayilar[randomIndex];
                islemdeKullanilanSayilar.Add(ilkIslemIcinSecilenSayi);
                // operatörün seçilmesi ve listeye ekleme kısmı
                operatorRandom = random.Next(0, operators.Length);
                _operator = operators[operatorRandom];
                kullanilanOperatorler.Add(_operator);
                // ilk seçilen sayının mevcut sayı dizisinden silinmesi
                olusturulanSayilar.Remove(ilkIslemIcinSecilenSayi);

                // operatör toplamaysa ve listedeki eleman sayısı 0 değilse işlemler
                if (_operator == '+' && olusturulanSayilar.Count != 0)
                {
                    // işlem için ikinci sayı belirleniyor 
                    randomIndex = random.Next(0, olusturulanSayilar.Count);
                    // burda işlemi gerçekleştiriyoruz
                    result = ilkIslemIcinSecilenSayi + olusturulanSayilar[randomIndex];
                    sonuclar.Add(result);   // sonucu sonuçlar listesine ekliyoruz
                    islemdeKullanilanSayilar.Add(olusturulanSayilar[randomIndex]);  // kullanılan ikinci sayıyı kullanılan sayılar listesine ekliyoruz

                    // eğer ki hedef sayıya ulaşılmışsa veya yaklaşılmışsa döngüden çıkılıyor
                    if (ListOperations.isTargetReached(targetNumber, result))
                    {
                        // hedef sayıya ulaşıldı ve burada hedef sayıya ulaşırken gerçekleşen 4 işlemler ekrana yazdırılıyor
                        for (int i = 0; i < islemdeKullanilanSayilar.Count - 1; i++)
                        {
                            if (kullanilanOperatorler[operatorIndex] == '-')
                                Console.WriteLine("|{0}  {1}  {2}|  =  {3}", islemdeKullanilanSayilar[i], kullanilanOperatorler[operatorIndex], islemdeKullanilanSayilar[i + 1], sonuclar[sonucIndex] + " \n");
                            else
                                Console.WriteLine("{0}  {1}  {2}  =  {3}", islemdeKullanilanSayilar[i], kullanilanOperatorler[operatorIndex], islemdeKullanilanSayilar[i + 1], sonuclar[sonucIndex] + " \n");
                            i++;
                            operatorIndex++;
                            sonucIndex++;
                        }
                        // hedefe ulaşıldı yazısı, kullanilan sayinin listeden silinmesi ve sonucun eklenmesi
                        if (targetNumber == result)
                            Console.WriteLine("\nHedefe ulaşıldı...!");
                        else
                            Console.WriteLine("\nHedefe ulaşıldı/yaklaşıldı...!");

                        olusturulanSayilar.Remove(olusturulanSayilar[randomIndex]);
                        olusturulanSayilar.Add(result);

                        break;
                    }

                    // eğer ki sonuç 0 değilse sonucu diziye atıyoruz ve kullandığımız ikinci sayıyı da diziden siliyoruz
                    else
                    {
                        olusturulanSayilar.Remove(olusturulanSayilar[randomIndex]);
                        olusturulanSayilar.Add(result);
                    }

                }

                // operatör toplamaysa ve listedeki eleman sayısı 0 değilse işlemler
                else if (_operator == '-' && olusturulanSayilar.Count != 0)
                {
                    // işlem için ikinci sayı belirleniyor 
                    randomIndex = random.Next(0, olusturulanSayilar.Count);
                    // burda işlemin mutlak değerini alıyoruz ki negatif bir değerle karşılaşmayalım
                    result = Math.Abs(ilkIslemIcinSecilenSayi - olusturulanSayilar[randomIndex]);
                    sonuclar.Add(result);   // sonucu sonuçlar listesine ekliyoruz
                    islemdeKullanilanSayilar.Add(olusturulanSayilar[randomIndex]);  // kullanılan ikinci sayıyı kullanılan sayılar listesine ekliyoruz

                    // eğer ki hedef sayıya ulaşılmışsa veya yaklaşılmışsa döngüden çıkılıyor
                    if (ListOperations.isTargetReached(targetNumber, result))
                    {
                        // hedef sayıya ulaşıldı ve burada hedef sayıya ulaşırken gerçekleşen 4 işlemler ekrana yazdırılıyor
                        for (int i = 0; i < islemdeKullanilanSayilar.Count - 1; i++)
                        {
                            if (kullanilanOperatorler[operatorIndex] == '-')
                                Console.WriteLine("|{0}  {1}  {2}|  =  {3}", islemdeKullanilanSayilar[i], kullanilanOperatorler[operatorIndex], islemdeKullanilanSayilar[i + 1], sonuclar[sonucIndex] + " \n");
                            else
                                Console.WriteLine("{0}  {1}  {2}  =  {3}", islemdeKullanilanSayilar[i], kullanilanOperatorler[operatorIndex], islemdeKullanilanSayilar[i + 1], sonuclar[sonucIndex] + " \n");
                            i++;
                            operatorIndex++;
                            sonucIndex++;
                        }
                        // hedefe ulaşıldı yazısı, kullanilan sayinin listeden silinmesi ve sonucun eklenmesi
                        if (targetNumber == result)
                            Console.WriteLine("\nHedefe ulaşıldı...!");
                        else
                            Console.WriteLine("\nHedefe ulaşıldı/yaklaşıldı...!");

                        olusturulanSayilar.Remove(olusturulanSayilar[randomIndex]);
                        olusturulanSayilar.Add(result);

                        break;
                    }

                    // eğer ki sonuç 0 değilse sonucu diziye atıyoruz ve kullandığımız ikinci sayıyı da diziden siliyoruz
                    else
                    {
                        olusturulanSayilar.Remove(olusturulanSayilar[randomIndex]);
                        olusturulanSayilar.Add(result);
                    }
                }

                // operatör toplamaysa ve listedeki eleman sayısı 0 değilse işlemler
                else if (_operator == '*' && olusturulanSayilar.Count != 0)
                {
                    // işlem için ikinci sayı belirleniyor 
                    randomIndex = random.Next(0, olusturulanSayilar.Count);
                    // burda işlemi gerçekleştiriyoruz
                    result = ilkIslemIcinSecilenSayi * olusturulanSayilar[randomIndex];
                    sonuclar.Add(result);   // sonucu sonuçlar listesine ekliyoruz
                    islemdeKullanilanSayilar.Add(olusturulanSayilar[randomIndex]);  // kullanılan ikinci sayıyı kullanılan sayılar listesine ekliyoruz

                    // eğer ki hedef sayıya ulaşılmışsa veya yaklaşılmışsa döngüden çıkılıyor
                    if (ListOperations.isTargetReached(targetNumber, result))
                    {
                        // hedef sayıya ulaşıldı ve burada hedef sayıya ulaşırken gerçekleşen 4 işlemler ekrana yazdırılıyor
                        for (int i = 0; i < islemdeKullanilanSayilar.Count - 1; i++)
                        {
                            if (kullanilanOperatorler[operatorIndex] == '-')
                                Console.WriteLine("|{0}  {1}  {2}|  =  {3}", islemdeKullanilanSayilar[i], kullanilanOperatorler[operatorIndex], islemdeKullanilanSayilar[i + 1], sonuclar[sonucIndex] + " \n");
                            else
                                Console.WriteLine("{0}  {1}  {2}  =  {3}", islemdeKullanilanSayilar[i], kullanilanOperatorler[operatorIndex], islemdeKullanilanSayilar[i + 1], sonuclar[sonucIndex] + " \n");
                            i++;
                            operatorIndex++;
                            sonucIndex++;
                        }
                        // hedefe ulaşıldı yazısı, kullanilan sayinin listeden silinmesi ve sonucun eklenmesi
                        if(targetNumber==result)
                            Console.WriteLine("\nHedefe ulaşıldı...!");
                        else
                            Console.WriteLine("\nHedefe ulaşıldı/yaklaşıldı...!");
                       
                        olusturulanSayilar.Remove(olusturulanSayilar[randomIndex]);
                        olusturulanSayilar.Add(result);

                        break;
                    }

                    // eğer ki sonuç 0 değilse sonucu diziye atıyoruz ve kullandığımız ikinci sayıyı da diziden siliyoruz
                    else
                    {
                        olusturulanSayilar.Remove(olusturulanSayilar[randomIndex]);
                        olusturulanSayilar.Add(result);
                    }
                }

                // operatör toplamaysa ve listedeki eleman sayısı 0 değilse işlemler
                else if (_operator == '/' && olusturulanSayilar.Count != 0)
                {
                    // işlem için ikinci sayı belirleniyor 
                    randomIndex = random.Next(0, olusturulanSayilar.Count);
                    // burda işlemi gerçekleştiriyoruz
                    // 0'a bölme durumundan kaçınmak için koyduğumuz şart
                    if (olusturulanSayilar[randomIndex] != 0)
                    {
                        result = ilkIslemIcinSecilenSayi / olusturulanSayilar[randomIndex];
                        sonuclar.Add(result);   // sonucu sonuçlar listesine ekliyoruz
                        islemdeKullanilanSayilar.Add(olusturulanSayilar[randomIndex]);  // kullanılan ikinci sayıyı kullanılan sayılar listesine ekliyoruz


                        // eğer ki hedef sayıya ulaşılmışsa veya yaklaşılmışsa döngüden çıkılıyor
                        if (ListOperations.isTargetReached(targetNumber, result))
                        {
                            // hedef sayıya ulaşıldı ve burada hedef sayıya ulaşırken gerçekleşen 4 işlemler ekrana yazdırılıyor
                            for (int i = 0; i < islemdeKullanilanSayilar.Count - 1; i++)
                            {
                                if (kullanilanOperatorler[operatorIndex] == '-')
                                    Console.WriteLine("|{0}  {1}  {2}|  =  {3}", islemdeKullanilanSayilar[i], kullanilanOperatorler[operatorIndex], islemdeKullanilanSayilar[i + 1], sonuclar[sonucIndex] + " \n");
                                else
                                    Console.WriteLine("{0}  {1}  {2}  =  {3}", islemdeKullanilanSayilar[i], kullanilanOperatorler[operatorIndex], islemdeKullanilanSayilar[i + 1], sonuclar[sonucIndex] + " \n");
                                i++;
                                operatorIndex++;
                                sonucIndex++;
                            }
                            // hedefe ulaşıldı yazısı, kullanilan sayinin listeden silinmesi ve sonucun eklenmesi
                            if (targetNumber == result)
                                Console.WriteLine("\nHedefe ulaşıldı...!");
                            else
                                Console.WriteLine("\nHedefe ulaşıldı/yaklaşıldı...!");
                            olusturulanSayilar.Remove(olusturulanSayilar[randomIndex]);
                            olusturulanSayilar.Add(result);

                            break;
                        }

                        // eğer ki sonuç 0 değilse sonucu diziye atıyoruz ve kullandığımız ikinci sayıyı da diziden siliyoruz
                        else
                        {
                            olusturulanSayilar.Remove(olusturulanSayilar[randomIndex]);
                            olusturulanSayilar.Add(result);
                        }
                    }
                    else
                        continue;
                }
            }
            return result;
        }


        // puanlamada kullanılan fonksiyon
        public static int scoringOperations(int targetNumber, int result)
        {
            int totalPoint = 0;

            // hedef sayıyla sonuç aynıysa eğer 10 puan, eğer aralarındaki fark 1'se bununla doğru orantılı olarak azalan puanlama sistemi
            if (result == targetNumber)
                totalPoint = 10;
            else if (Math.Abs(targetNumber - result) == 1)
                totalPoint = 9;
            else if (Math.Abs(targetNumber - result) == 2)
                totalPoint = 8;
            else if (Math.Abs(targetNumber - result) == 3)
                totalPoint = 7;
            else if (Math.Abs(targetNumber - result) == 4)
                totalPoint = 6;
            else if (Math.Abs(targetNumber - result) == 5)
                totalPoint = 5;
            else if (Math.Abs(targetNumber - result) == 6)
                totalPoint = 4;
            else if (Math.Abs(targetNumber - result) == 7)
                totalPoint = 3;
            else if (Math.Abs(targetNumber - result) == 8)
                totalPoint = 2;
            else if (Math.Abs(targetNumber - result) == 9)
                totalPoint = 1;
            else
                totalPoint = 0;

            return totalPoint;
        }
    }
}
