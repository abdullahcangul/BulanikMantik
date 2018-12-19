using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulanikMantik.Models
{
    public  class SicaklikDegerAralıklari
    {
        //Sıcaklık degerleri
        public static int CDminSicaklik=0;
        public static int CDmaxSicaklik=20;
        public static int DminSicaklik= 15;
        public static int DmaxSicaklık = 40;
        public static int OminSicaklik = 35;
        public static int OmaxSicaklik = 60;
        public static int YminSicaklik = 55;
        public static int YmaxSicaklık = 80;
        public static int CYminSicaklik = 75;
        public static int CYmaxSicaklık = 100;


        //Seviye ve Rezidans degerleri
        public static double CAminSeviye = 0;
        public static double CAmaxSeviye = 1;
        public static double AminSeviye = 0.5;
        public static double AmaxSeviye = 2;
        public static double OminSeviye = 1.5;
        public static double OmaxSeviye = 3.5;
        public static double CminSeviye = 3;
        public static double CmaxSeviye = 4.5;
        public static double ACminSeviye = 4;
        public static double ACmaxSeviye = 5;


        //Bulanik Kural Tabani
        //0=hareket yok,1=CA,2=A,3=O,4=A,5=AC
         int[,] KuralTabani = new int[,] { 
             {3,2,1,0,0},
             {4,3,1,1,0},
             {5,4,3,1,0},
             {5,4,4,2,0},
             {5,4,4,3,0}

         };


    }
    
}