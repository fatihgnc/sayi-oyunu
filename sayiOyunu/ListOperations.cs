using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sayiOyunu
{
    static class ListOperations
    {

        // dizinin dolu ya da boş olmasına göre true ya da false döndüren fonksiyon
        public static Boolean isEmpty(List<int> sayilar)
        {
            if (sayilar.Count == 0)
                return true;
            else
                return false;
        }
       
        // dizi eğer boşsa diziyi doldurmak için kullanılan fonksiyon
        public static List<int> fillList(List<int> doldurulacakListe,List<int> doluListe)
        {
            doldurulacakListe.Clear();

            for (int i = 0; i < doluListe.Count; i++)
                doldurulacakListe.Add(doluListe[i]);

            return doldurulacakListe;

        }

        // hedefe ulaşılma durumuna göre true ya da false döndüren fonksiyon
        public static Boolean isTargetReached(int hedefSayi,int sonuc)
        {
            if (sonuc == hedefSayi) // hedefe eşit olma durumu
                return true;
            else if (Math.Abs(sonuc - hedefSayi) < 10) // hedefle sonuç arasında +-9 fark olma durumu
                return true;
            else    // yanlış olma durumu
                return false;
        }
    }
}
