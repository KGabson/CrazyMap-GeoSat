using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Media;
//using MathNet.Numerics;

namespace WindowsPhoneGame2
{
    class GiveScore
    {
        // struc de donné pour Angles et dist, avec id, Point visé et valeur

       // Condition d'arret boucle.
       public int nb_ite = 0;
  
       // Stockage point connus.
       
        // les connus 
       public List<gps> gpslist;
        // les mesurés
       public List<gps> PointMesuré;

        // Les visé
       public List<Vise> AllVise;

        // resultat mesuré
       Matrice X1;
        // resultat calculé
       Matrice X;
       Matrice A;
       Matrice B;
       Matrice P;
       Matrice Tmp;
       Matrice N;
       double[] chideux = { 3.841, 5.991, 7.815, 9.488, 11.070, 12.592, 14.067, 15.507, 16.919, 18.307, 19.675, 21.026, 22.362, 23.685, 24.996, 26.296, 27.587, 28.869, 30.144, 31.410, 32.671, 33.924, 35.172, 36.415, 37.652, 38.885, 40.113, 41.337, 42.557}; // 1 --> 29 ou 0 --> 28
        //Region Constructor;
        public GiveScore(List<DragObj> ListDragObj, List<Vise> ListVise)
        {
            gpslist = new List<gps>();
            PointMesuré = new List<gps>();
            foreach (DragObj db in ListDragObj)
                    {
                        if (db.IsGps == true)
                        {
                            gpslist.Add(new gps(db.Position));
                        }
                        else
                        {
                            PointMesuré.Add(new gps(db.Position));
                        }
                    }
            AllVise = ListVise;
        }

        // Region Func calc
        public Matrice testfunct()
        {
               // X = new Matrice(PointMesuré.Count + gpslist.Count, PointMesuré.Count);

                //-----> Define Matrice A (envoyé les elem)
                
                A = DefineMatriceA(PointMesuré, AllVise);
               
                // -----> Define matrice colonne B;
                B = DefineMatriceB(AllVise);

                // -----> Define matrice Pondération P;
                P = DefineMatriceP(AllVise);

                // logique de calcul --> 
               X = Matrice.StupidMultiply(Matrice.StupidMultiply(Matrice.Transpose(A), P), A);
               N = X;
               suite_des_calcules(N);
               X =  X.Invert();// Multiplication
               X = Matrice.StupidMultiply(X, Matrice.Transpose(A));
               X = Matrice.StupidMultiply(X, P);
               X = Matrice.StupidMultiply(X, B);
               X1 = X;

               Tmp = Matrice.Add(X, -X1);
               return Tmp;
        }

        public void suite_des_calcules(Matrice N)
        {
            int DegreLiberte;
            double chideuxval;
            double a;
            double b;

            N = N.Invert();
            DegreLiberte = (AllVise.Count() * 2) - (PointMesuré.Count() * 2);
            chideuxval = chideux[DegreLiberte];
            a = Math.Sqrt(chideuxval) * chideuxval;
            b = Math.Sqrt(chideuxval) * chideuxval;
           
            // matrice diagonal + matrice triangulaire sup + matrice tirangulaire inf
            // On peut avoir le determinant ? 
            // a et b
        }

        public int givenbinconnu(List<DragObj> ListDragObj)
        {
            int ret = 0;

            foreach (DragObj db in ListDragObj)
            {
                if (db.IsGps == false)
                    ret += 1;
            }

            return ret;
        }

        public Matrice DefineMatriceA(List<gps> Observation, List<Vise> ListVise)
        {
            A = new Matrice(ListVise.Count * 2, Observation.Count);

            for (int i = 0; i < ListVise.Count * 2; i++)
            {
                for (int j = 0; j < Observation.Count; j+=2)
                {
                    B[i, j] = (ListVise[i].st1.Position.Y - Observation[j].Position.Y) / Return_Distance(ListVise[i].st1.Position.X, Observation[j].Position.X, ListVise[i].st1.Position.Y, Observation[j].Position.Y);
                    B[i, j + 1] = (ListVise[i].st1.Position.X - Observation[j].Position.X) / Return_Distance(ListVise[i].st1.Position.X, Observation[j].Position.X, ListVise[i].st1.Position.Y, Observation[j].Position.Y);
               //     B[i, j] = (ListVise[i].st2.Position.Y - Observation[j].Position.Y) / Return_Distance(ListVise[i].st2.Position.X, Observation[j].Position.X, ListVise[i].st2.Position.Y, Observation[j].Position.Y);
                //    B[i, j + 1] = (ListVise[i].st2.Position.X - Observation[j].Position.X) / Return_Distance(ListVise[i].st2.Position.X, Observation[j].Position.X, ListVise[i].st2.Position.Y, Observation[j].Position.Y);
                }
            }
            return A;
        }

        public Matrice DefineMatriceB(List<Vise> ListVise)
        {
            B = new Matrice(ListVise.Count * 2, 1);

            for (int i = 0; i < ListVise.Count * 2; i+=2)
            {
                if (i <= ListVise.Count)
                {
                    B[i, 1] = Return_Distance(ListVise[i].st1.Position.X, ListVise[i].st2.Position.X, ListVise[i].st1.Position.Y, ListVise[i].st2.Position.Y) -
                    Return_Distance(ListVise[i].st1.Position.X, ListVise[i].st2.Position.X, ListVise[i].st1.Position.Y, ListVise[i].st2.Position.Y);
                    B[i + 1, 1] = Return_Distance(ListVise[i].st2.Position.X, ListVise[i].st1.Position.X, ListVise[i].st2.Position.Y, ListVise[i].st1.Position.Y) -
                        Return_Distance(ListVise[i].st2.Position.X, ListVise[i].st1.Position.X, ListVise[i].st2.Position.Y, ListVise[i].st1.Position.Y);
                }
                else
                {
                    B[i, 1] = Return_Angles(ListVise[i].st1.Position.X, ListVise[i].st2.Position.X, ListVise[i].st1.Position.Y, ListVise[i].st2.Position.Y, 0) -
                    Return_Angles(ListVise[i].st1.Position.X, ListVise[i].st2.Position.X, ListVise[i].st1.Position.Y, ListVise[i].st2.Position.Y, 0);
                    B[i + 1, 1] = Return_Angles(ListVise[i].st2.Position.X, ListVise[i].st1.Position.X, ListVise[i].st2.Position.Y, ListVise[i].st1.Position.Y, 0) -
                        Return_Angles(ListVise[i].st2.Position.X, ListVise[i].st1.Position.X, ListVise[i].st2.Position.Y, ListVise[i].st1.Position.Y, 0 );
                }
                
            }
            return B;
        }

        public Matrice DefineMatriceP(List<Vise> ListVise)
        {
            P = new Matrice(ListVise.Count * 2, ListVise.Count * 2);

            for (int i = 0; i < ListVise.Count * 2; i++)
            {
                for (int j = 0; j < ListVise.Count * 2; j++)
                {
                    if (i == j)
                    {
                        if (i <= ListVise.Count)
                        {
                            P[i, j] = 1 / calc_preci_priori(B[i, 1]);
                        }
                        else
                        {
                            P[i, j] = 1 / calc_preci_priori_angle(B[i, 1]);
                        }
                    }
                    else
                        P[i, j] = 0;
                }
            }
            return (P);
        }

        public double calc_preci_priori(double val)
        {
            double ret;

            ret = Math.Sqrt(Math.Pow(0.002,2) + (Math.Pow(10, -6) * 0.001 * val));

            return ret;
        }

        public double calc_preci_priori_angle(double val)
        {
            double ret;

            ret = Math.Sqrt(Math.Pow(0.002, 2) + (Math.Pow(10, -6) * (1 * Math.Pow(10, -4)) * val));

            return ret;
        }

        public double Return_Distance(double x1, double x2, double y1, double y2)
        {
            Double D12;

            D12 = Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
            return D12;
        }

        public double Return_Angles(double x1, double x2, double y1, double y2, double G01)
        {
            double V12;

            V12 = (Math.Atan((x2 - x1) / (y2 - y1)) - G01);
            return V12;
        }
    }
}
