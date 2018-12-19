using BulanikMantik.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace BulanikMantik.Controllers
{
    public class SuIsıtmaController : Controller
    {

        public double Sicaklik = 10;
        public double seviye = 1.2;
        //son tablo degiskenleri
        double toplam1=0;
        double toplam2=0;

        //bulaniklastirma için kullanildi
        double[] sicaklikSonuc = new double[2] { -1, -1};
        int[] sicaklikSonucDurumu = new int[2] { -1, -1 };
        double[] seviyeSonuc = new double[2] { -1, -1 };
        int[] seviyeSonucDurumu = new int[2] { -1,-1 };
        //Bulaniklastirma
        double rezidans=0;
        double rezidans2=0;
        double rezidans3=0;
        double rezidans4=0;
        Double[] rezidansDegerleri = new Double[4];
        static List<String> rezidansAnlamDegerleri = new List<String>();

        //durulastirma 
        //Tablo degerleri
        double[] durulastirmaFonksiyoGelen =new double[8] { 0,0,0,0,0,0,0,0};
        int sayacdurulastirma = 0;
        //0=hareket yok,1=CA,2=A,3=O,4=A,5=AC
        int[,] rezidansIcinTablo = new int[,] {
             {3,2,1,0,0},
             {4,3,1,1,0},
             {5,4,3,1,0},
             {5,4,4,2,0},
             {5,4,4,3,0}};
        //sonuc
        double islemSonuc=0;
        //Grafik cizme
        GenelModel m = new GenelModel();
        static List<GrafikModel> grafikModel = new List<GrafikModel>();

        //Grafik Cizimi
        Chart chart = new Chart(600, 600, theme: ChartTheme.Yellow);
        public ActionResult ChartOlustur()
        {
            bool a=true, b=true, c=true, d=true, e = true;
            chart.AddTitle("Isı ayarlayıcı 2000");
            chart.AddLegend("x ve y degerleri");
            foreach (GrafikModel rezidans in grafikModel)
            {
                //Çok Kücük Ve Asırı çok  Arası grafik secildi
                if (rezidans.rezidansDurumu == "CokDüsük")
                {
                 
                    if (a == true)
                    {
                      chart.AddSeries(name: "CokDüsük", chartType: "Line",
                      xValue: new[] { 0, 0.5, rezidans.x1, 1 },
                      yValues: new[] { 1, 1, rezidans.y1, 0 });
                      a = false;
                    }
                    chart.AddSeries( chartType: "Line",
                     xValue: new[] {0, rezidans.x1 , rezidans.x1 },
                     yValues: new[] { rezidans.y1, rezidans.y1, 0 });




                }
                if (rezidans.rezidansDurumu == "Düsük")
                {
                    if(b == true)
                    {
                        chart.AddSeries(name: "Düsük", chartType: "Line",
                        xValue: new[] { 0.5, rezidans.x2, 1.25, rezidans.x1, 2 },
                         yValues: new[] { 0, rezidans.y1, 1,rezidans.y1, 0 });
                        b = false;
                    }
                    chart.AddSeries(chartType: "Line",
                     xValue: new[] { 0, rezidans.x1, rezidans.x1 },
                     yValues: new[] { rezidans.y1, 0 });

                    chart.AddSeries( chartType: "Line",
                    xValue: new[] { 0, rezidans.x2, rezidans.x2 },
                    yValues: new[] { rezidans.y1, rezidans.y1, 0 });
                }
                if (rezidans.rezidansDurumu == "Orta")
                {
                    if (c == true)
                    {
                        chart.AddSeries(name: "Orta", chartType: "Line",
                        xValue: new[] { 1.5, rezidans.x2, 2.5, rezidans.x1, 3.5 },
                        yValues: new[] { 0, rezidans.y1, 1, rezidans.y1, 0 });
                        c = false;
                    }

                    chart.AddSeries( chartType: "Line",
                    xValue: new[] { 0, rezidans.x1, rezidans.x1 },
                    yValues: new[] { rezidans.y1, rezidans.y1, 0 });

                    chart.AddSeries( chartType: "Line",
                    xValue: new[] { 0, rezidans.x2, rezidans.x2 },
                    yValues: new[] { rezidans.y1, rezidans.y1, 0 });
                }
                if (rezidans.rezidansDurumu == "Çok")
                {
                    if (d == true)
                    {
                        chart.AddSeries(name: "Çok", chartType: "Line",
                         xValue: new[] { 3, rezidans.x2, 3.75, rezidans.x1, 4.5 },
                         yValues: new[] { 0, rezidans.y1, 1, rezidans.y1, 0 });
                        d = false;
                    }


                    chart.AddSeries( chartType: "Line",
                    xValue: new[] { 0, rezidans.x1, rezidans.x1 },
                    yValues: new[] { rezidans.y1, rezidans.y1, 0 });

                    chart.AddSeries( chartType: "Line",
                    xValue: new[] { 0, rezidans.x2, rezidans.x2 },
                    yValues: new[] { rezidans.y1, rezidans.y1, 0 });
                }
                if (rezidans.rezidansDurumu == "AşırıÇok")
                {
                    if (e == true)
                    {
                        chart.AddSeries(name: "AşırıÇok", chartType: "Line",
                         xValue: new[] { 4,rezidans.x1, 4.5, 5 },
                         yValues: new[] { 0, rezidans.y1,1, 1 });
                        e = false;
                    }

                    chart.AddSeries( chartType: "Line",
                    xValue: new[] { 0, rezidans.x1, rezidans.x1 },
                    yValues: new[] { rezidans.y1, rezidans.y1, 0 });
                }
            }
            return View(chart);
        }

        public ActionResult Index()
        {

            ViewBag.sicaklikSonuc = sicaklikSonuc;
            ViewBag.sicaklikSonucDurumu = sicaklikSonucDurumu;
            ViewBag.seviyeSonuc = seviyeSonuc;
            ViewBag.seviyeSonucDurumu = seviyeSonucDurumu;

            return View();
        }
        [HttpPost]
        public ActionResult Index(double Sicaklik,double seviye,string tabloIlk)
        {
            if (tabloIlk != null)
            {
                grafikModel.Count();
                grafikModel.RemoveRange(0, grafikModel.Count());
            }
            
            //1 adım
            ViewBag.sicaklikSonuc = sicaklikSonuc;
            ViewBag.sicaklikSonucDurumu = sicaklikSonucDurumu;
            ViewBag.seviyeSonuc = seviyeSonuc;
            ViewBag.seviyeSonucDurumu = seviyeSonucDurumu;
            //2.adım
            ViewBag.rezidansDegerleri = rezidansDegerleri;


            this.Sicaklik = Sicaklik;
            this.seviye = seviye;
            bulaniklastir();
            bulanikCikarim();
            ViewBag.sonuc = islemSonuc;
            islemSonuc = 0;
            //rezidansAnlamDegerleri
            return View(grafikModel);
        }

        //Bulaniklastirma
        public void bulaniklastir()
        {
            int sayac = 0;
            double buyuk, orta, kucuk;
            //Sicaklik kontrol
            if (Sicaklik >= 0 && Sicaklik < 20)
            {
                if (Sicaklik >= 10 )
                {
                    sicaklikSonuc[sayac] = (20 - Sicaklik) / (20 - 10);
                }
                else
                {

                    sicaklikSonuc[sayac] = 1;
                }
                sicaklikSonucDurumu[sayac] = 0;
                sayac++;
            }
            if (Sicaklik >= 15 && Sicaklik < 40)
            {
                buyuk = 40; orta = 27.5; kucuk = 15;
                if (Sicaklik >= orta)
                {
                    sicaklikSonuc[sayac] = (buyuk - Sicaklik) / (buyuk - orta);
                }
                else
                {
                    sicaklikSonuc[sayac] = (Sicaklik - kucuk) / (orta - kucuk);
                }
                sicaklikSonucDurumu[sayac] = 1;
                sayac++;
            }
            if (Sicaklik >= 35 && Sicaklik < 60)
            {

                buyuk = 60; orta = 47.5; kucuk = 35;
                if (Sicaklik >= orta)
                {
                    sicaklikSonuc[sayac] = (buyuk - Sicaklik) / (buyuk - orta);
                }
                else
                {
                    sicaklikSonuc[sayac] = (Sicaklik - kucuk) / (orta - kucuk);
                }
                sicaklikSonucDurumu[sayac] = 2;
                sayac++;
            }
            if (Sicaklik >= 55 && Sicaklik < 80)
            {
                buyuk = 80; orta = 67.5; kucuk = 55;
                if (Sicaklik >= orta)
                {
                    sicaklikSonuc[sayac] = (buyuk - Sicaklik) / (buyuk - orta);
                }
                else
                {
                    sicaklikSonuc[sayac] = (Sicaklik - kucuk) / (orta - kucuk);
                }
                sicaklikSonucDurumu[sayac] = 3;
                sayac++;
            }
            if (Sicaklik >= 75 && Sicaklik < 100)
            {
                buyuk = 100; orta = 87.5; kucuk = 75;
                if (Sicaklik >= orta)
                {
                    sicaklikSonuc[sayac] = 1;
                }
                else
                {
                    sicaklikSonuc[sayac] = (Sicaklik - kucuk) / (orta - kucuk);
                }
                sicaklikSonucDurumu[sayac] = 4;
                sayac++;
            }
            //seviye kontrol
            sayac = 0;
            if (seviye >= 0 && seviye < 1)
            {
                buyuk = 1; orta = 0.5; kucuk = 0;
                if (seviye >= orta)
                {
                    seviyeSonuc[sayac] = (buyuk - seviye) / (buyuk - orta);
                }
                else
                {
                    seviyeSonuc[sayac] = 1;
                }
                seviyeSonucDurumu[sayac] = 0;
                sayac++;
            }
            if (seviye >= 0.5 && seviye < 2)
            {
                buyuk = 2; orta = 1.25; kucuk = 0.5;
                if (seviye >= orta)
                {
                    seviyeSonuc[sayac] = (buyuk - seviye) / (buyuk - orta);
                }
                else
                {
                    seviyeSonuc[sayac] = (seviye - kucuk) / (orta - kucuk);
                }
                seviyeSonucDurumu[sayac] = 1;
                sayac++;
            }
            if (seviye >= 1.5 && seviye < 3.5)
            {
                buyuk = 3.5; orta = 2.5; kucuk = 1.5;
                if (seviye >= orta)
                {
                    seviyeSonuc[sayac] = (buyuk - seviye) / (buyuk - orta);
                }
                else
                {
                    seviyeSonuc[sayac] = (seviye - kucuk) / (orta - kucuk);
                }
                seviyeSonucDurumu[sayac] = 2;
                sayac++;
            }
            if (seviye >= 3 && seviye < 4.5)
            {
                buyuk = 4.5; orta = 3.75; kucuk = 3;
                if (seviye >= orta)
                {
                    seviyeSonuc[sayac] = (buyuk - seviye) / (buyuk - orta);
                }
                else
                {
                    seviyeSonuc[sayac] = (seviye - kucuk) / (orta - kucuk);
                }
                seviyeSonucDurumu[sayac] = 3;
                sayac++;
            }
            if (seviye >= 4 && seviye < 5)
            {
                buyuk = 5; orta = 4.5; kucuk = 4;
                if (seviye >= orta)
                {
                    seviyeSonuc[sayac] = 1;
                }
                else
                {
                    seviyeSonuc[sayac] = (seviye - kucuk) / (orta - kucuk);
                }
                seviyeSonucDurumu[sayac] = 4;
                sayac++;
            }
        }
        //Bulanik Cikarim
        public void bulanikCikarim()
        {
           //2 Tane Siçaklik varmı
            if (sicaklikSonuc[1]!=-1)
            {
                //2 Tane Seviye varmı
                if (seviyeSonuc[1] != -1)
                {
                    //2 Sicaklik ve seviye bulundu
                    IkıSicaklikIkiSeviyeHesapla();
                }
                else
                {
                    //2 Sicaklik ve 1 seviye bulundu
                    IkisicaklikDortluhesapla();
                }
            }           
            else if(seviyeSonuc[1] != -1)
            {
                //1 Sicaklik ve 2 seviye bulundu
                IkiseviyeDortluhesapla();
                
            }
            else
            {
                //1 Sicaklik ve 1 seviye bulundu
                tekliHesapla();
            }

            rezidansDegerleri[0] = rezidans;
            rezidansDegerleri[1] = rezidans2;
            rezidansDegerleri[2] = rezidans3;
            rezidansDegerleri[3] = rezidans4;
        }
        // Bulanık Çıkarım tek sicaklik ve seviye 
        public void tekliHesapla()
        {
            //Seviye ve sıcaklıgı karsılastırır rezidansı bulur
            if (seviyeSonuc[0]>=sicaklikSonuc[0])
            {
                rezidans = sicaklikSonuc[0];

            }
            else
            {
                rezidans = seviyeSonuc[0];
            }
            // Sonuc bulan fonksiyon
            durulastirmaBul(rezidans, rezidansIcinTablo[seviyeSonucDurumu[0],sicaklikSonucDurumu[0]], 0);
            if (toplam1 == 0 && toplam2 == 0)
            {
                islemSonuc = 0;
            }
            else
            {
                islemSonuc = toplam1 / toplam2;
            }
        }
        //2 sicaklik 1 seviye
        public void IkisicaklikDortluhesapla()
        {
            if (seviyeSonuc[0] >= sicaklikSonuc[0])
            {
                rezidans = sicaklikSonuc[0];

            }
            else
            {
                rezidans = seviyeSonuc[0];
            }
            durulastirmaBul(rezidans, rezidansIcinTablo[seviyeSonucDurumu[0], sicaklikSonucDurumu[0]], 0);
            if (seviyeSonuc[0] >= sicaklikSonuc[1])
            {
                rezidans2 = sicaklikSonuc[1];

            }
            else
            {
                rezidans2 = seviyeSonuc[0];
            }
            durulastirmaBul(rezidans2, rezidansIcinTablo[seviyeSonucDurumu[0], sicaklikSonucDurumu[1]], 2);
            if (toplam1 == 0 && toplam2 == 0)
            {
                islemSonuc = 0;
            }
            else
            {
                islemSonuc = toplam1 / toplam2;
            }
        }
        //1 sicaklik 2 seviye
        public void IkiseviyeDortluhesapla()
        {
            if (seviyeSonuc[0] >= sicaklikSonuc[0])
            {
                rezidans = sicaklikSonuc[0];

            }
            else
            {
                rezidans = seviyeSonuc[0];
            }
            durulastirmaBul(rezidans, rezidansIcinTablo[seviyeSonucDurumu[0], sicaklikSonucDurumu[0]], 0);
            if (seviyeSonuc[0] >= sicaklikSonuc[1])
            {
                rezidans2 = sicaklikSonuc[1];

            }
            else
            {
                rezidans2 = seviyeSonuc[0];
            }
            durulastirmaBul(rezidans2, rezidansIcinTablo[seviyeSonucDurumu[1], sicaklikSonucDurumu[0]], 2);
            
            if (toplam1 == 0 && toplam2 == 0)
            {
                islemSonuc = 0;
            }
            else
            {
                islemSonuc = toplam1 / toplam2;
            }
        }
        //
        public void IkıSicaklikIkiSeviyeHesapla()
        {
            if (seviyeSonuc[0] >= sicaklikSonuc[0])
            {
                rezidans = sicaklikSonuc[0];

            }
            else
            {
                rezidans = seviyeSonuc[0];
            }
            durulastirmaBul(rezidans, rezidansIcinTablo[seviyeSonucDurumu[0], sicaklikSonucDurumu[0]], 0);
            if (seviyeSonuc[0] >= sicaklikSonuc[1])
            {
                rezidans2 = sicaklikSonuc[1];

            }
            else
            {
                rezidans2 = seviyeSonuc[0];
            }
            durulastirmaBul(rezidans2, rezidansIcinTablo[seviyeSonucDurumu[0], sicaklikSonucDurumu[1]], 2);
            if (seviyeSonuc[1] >= sicaklikSonuc[0])
            {
                rezidans3 = sicaklikSonuc[0];

            }
            else
            {
                rezidans3 = seviyeSonuc[1];
            }
            durulastirmaBul(rezidans3, rezidansIcinTablo[seviyeSonucDurumu[1], sicaklikSonucDurumu[0]], 4);
            if (seviyeSonuc[1] >= sicaklikSonuc[1])
            {
                rezidans4 = sicaklikSonuc[1];

            }
            else
            {
                rezidans4 = seviyeSonuc[1];
            }
            durulastirmaBul(rezidans4, rezidansIcinTablo[seviyeSonucDurumu[1], sicaklikSonucDurumu[1]], 6);

            if (toplam1 == 0 && toplam2 == 0)
            {
                islemSonuc = 0;
            }
            else
            {
                islemSonuc = toplam1 / toplam2;
            }
        }
        //durulastirma için
        public void durulastirmaBul(double rezidans,int durum,int sayac)
        {
            double buyuk, orta, kucuk,sonuc;
            if (durum == 0)
            {
                rezidansAnlamDegerleri.Add("Hareket Yok");
            }
            //Tabloyu bir yerden Kesecek sonuc bulup tablo için degerleri üretir
            if (durum==1)
            {
                buyuk = 1; orta = 0.5; kucuk = 0;

                double i = buyuk - (rezidans * (buyuk - orta));
                sonuc = i * rezidans;
                durulastirmaFonksiyoGelen[sayac] = sonuc;
                toplam1 = toplam1 + sonuc;
                toplam2 = toplam2 + rezidans;
                rezidansAnlamDegerleri.Add("CokDüsük");
                GrafikModel gm = new GrafikModel();
                
                gm.x1 = i;
                gm.y1 = rezidans;
                gm.rezidansDurumu ="CokDüsük";
                grafikModel.Add(gm);


            }
            if (durum==2)
            {
                buyuk = 2; orta = 1.25; kucuk = 0.5;
             
                    double i1 = buyuk - (rezidans * (buyuk - orta));
                    sonuc = i1 * rezidans;
                    durulastirmaFonksiyoGelen[sayac] = sonuc;
                    sayac++;
                    toplam1 = toplam1 + sonuc;
               
                   double i2 = (rezidans * (orta - kucuk)) + kucuk;
                    sonuc = i2 * rezidans;
                    durulastirmaFonksiyoGelen[sayac] = sonuc;
                    toplam1 = toplam1 + sonuc;
                    toplam2 = toplam2 + 2 * rezidans;

                rezidansAnlamDegerleri.Add("Düsük");

                GrafikModel gm = new GrafikModel();
                gm.x1 = i1;
                gm.x2 = i2;
                gm.y1 = rezidans;
                gm.rezidansDurumu = "Düsük";
                grafikModel.Add(gm);

            }
            if (durum==3)
            {
                buyuk = 3.5; orta = 2.5; kucuk = 1.5;
                
                double i1 = buyuk - (rezidans * (buyuk - orta));
                sonuc = i1 * rezidans;
                durulastirmaFonksiyoGelen[sayac] = sonuc;
                sayac++;
                toplam1 = toplam1 + sonuc;

                double i2 = (rezidans * (orta - kucuk)) + kucuk;
                sonuc = i2 * rezidans;
                durulastirmaFonksiyoGelen[sayac] = sonuc;
                toplam1 = toplam1 + sonuc;
                toplam2 = toplam2 + 2 * rezidans;
                rezidansAnlamDegerleri.Add("Orta");



                GrafikModel gm = new GrafikModel();
                gm.x1 = i1;
                gm.x2 = i2;
                gm.y1 = rezidans;
                gm.rezidansDurumu = "Orta";
                grafikModel.Add(gm);

            }
            if (durum==4)
            {
                buyuk = 4.5; orta = 3.75; kucuk = 3;
                
                double i1 = buyuk - (rezidans * (buyuk - orta));
                sonuc = i1 * rezidans;
                durulastirmaFonksiyoGelen[sayac] = sonuc;
                sayac++;
                toplam1 = toplam1 + sonuc;

                double i2 = (rezidans * (orta - kucuk)) + kucuk;
                sonuc = i2 * rezidans;
                durulastirmaFonksiyoGelen[sayac] = sonuc;
                toplam1 = toplam1 + sonuc;
                toplam2 = toplam2 + 2 * rezidans;
                rezidansAnlamDegerleri.Add("Çok");



                GrafikModel gm = new GrafikModel();
                gm.x1 = i1;
                gm.x2 = i2;
                gm.y1 = rezidans;
                gm.rezidansDurumu = "Çok";
                grafikModel.Add(gm);
            }
            if (durum==5)
            {
                buyuk = 5; orta = 4.5; kucuk = 4;

                double i = (rezidans * (orta - kucuk)) + kucuk;
                sonuc = i * rezidans;
                durulastirmaFonksiyoGelen[sayac] = sonuc;
                toplam1 = toplam1 + sonuc;
                toplam2 = toplam2 + rezidans;
               
                rezidansAnlamDegerleri.Add("AşırıÇok");



                GrafikModel gm = new GrafikModel();
                gm.x1 = i;
                gm.y1 = rezidans;
                gm.rezidansDurumu = "AşırıÇok";
                grafikModel.Add(gm);

            }
        }

    }
}