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

namespace WindowsPhoneGame2
{
    static class Constants
    {
        public const double Pi = Math.PI;
        public const int  ScreenWidth = 800;
        public const int Screenheight = 480;
    }

    class GridMap
    {
        List<List<Cell>> MapArray= new List<List<Cell>>();

        public GridMap(List<Obstacle> ListObs)
        {
            for (int i = 0; i < 80; i++)
            {
                MapArray.Add(new List<Cell>());
                for (int j = 0; j < 48; j++)
                {
                    MapArray[i].Add(new Cell(i, j, 0));            
                }
            }
            
            // partie qui remplie la grille, de 1 pr obstacle.*

            // BACK HERE MERCREDI --> collision perfecter et chaque shape dans 
            //la classe Obstacle en fonction de l'ID pour avoir une belle shape for everybody


         //   for (int i = 0; i < ListObs.Count(); i++)
         //   {
           //     Fill_cell((int)(ListObs[i].VOb.X / 10), (int)(ListObs[i].VOb.Y /10), 1, ListObs[i].id);
         //   }
        }

        public void Add_Obs(int x, int y)
        {
            MapArray[x][y].Empty = 1;
        }

        public void Del_Obs(int x, int y)
        {
            MapArray[x][y].Empty = 0;
        }

        public Point PointforGrid(int x, int y)
        {
            return (new Point(x / 10, y / 10));
        }

        public bool Check_Tile(int x, int y)
        {
            if (MapArray[x][y].Empty == 0)
            {
                return (true);
            }
            return (false);
        }

        // recupere le type du graphiobject qui est dans la cell
        public void getType(GraphicObject obj)
        {
            if (obj is Tree)
            {
                Tree monArbre = obj as Tree;
            }
            else if (obj is Home)
            {
                Home Maison = obj as Home;
            }
            else if (obj is Buisson)
            {
                Buisson bush = obj as Buisson;
            }
            else if (obj is Road)
            {
                Road route = obj as Road;
            }
            else if (obj is Borne)
            {
                Borne jaune = obj as Borne;
            }
        }

        public void Fill_cell(int x, int y, int val, int id)
        {
            int gx = x;// / 10; // recup bien valeur entiere
            // gx = Math.Floor(gx);
            int gy = y;// / 10; 

            // id ====> quel objet c'est 
            if (gy < 0)
            {
                gy = 0;
            }
            if ((id == 0) || (id == 1) || (id == 13) || (id == 14))
            {
                fill_tree(gx, gy,id);
                // pointeur vers Obj("tree").
                // taille de l'image + Shape
            }
            else if (id == 3 || id == 9 || id == 10 || id == 11 || id == 12)
            {
                fill_home(gx, gy, id);
                // Home
            }
            else if (id == 2 || id == 7 || id == 8)
            {
                fill_buis(gx, gy, id);
                // Buiss
            }
            else if (id == 4 || id == 5 || id == 15 || id == 16)
            {
                fill_road(gx, gy, id);
                // Road
            }
            // gerer se cas particulier + colli + rota
        }

        public void fill_tree(int gx, int gy, int id)
        {
            MapArray[gx][gy].Empty = 1;
            for (int i = 1; i <= 15; i++)
            {
                MapArray[gx + i][gy].Empty = 1;
            }
            for (int j = 1; j <= 14; j++)
            {
                MapArray[gx][gy + j].Empty = 1;
            }
        }

        public void fill_home(int gx, int gy, int id)
        {
            MapArray[gx][gy].Empty = 1;
            for (int i = 1; i <= 18; i++)
            {
                MapArray[gx + i][gy].Empty = 1;
            }
            for (int j = 1; j <= 11; j++)
            {
                MapArray[gx][gy + j].Empty = 1;
            }
        }

        public void fill_buis(int gx, int gy, int id)
        {
            MapArray[gx][gy].Empty = 1;
        }

        public void fill_road(int gx, int gy, int id)
        {
            MapArray[gx][gy].Empty = 1;
        }
        //Graphics.Viewport.TitleSafeArea
    }

    class Cell
    {
        public int Hei;
        public int Wid;
        public int Empty; // etat de la tuile;
        public GraphicObject Pointeur = null;

        // Cast du type de l'obstacle à graphic obj
        // cast vers le type d'object que c'est type == class 

        // --> pointeur vers l'objet. Class au dessu ou en dessous. ou un type object avec tout les types.

        public Cell(int a, int b, int val)
        {
            Hei = a;
            Wid = b;
            Empty = val;
        }

        public Rectangle giveshape() // pour tester les intersection ? Ou alors retourner un rectangle en fonction de l'obje
        {
            return (new Rectangle(Hei, Wid, 10, 10)); // * 10
        }

        public void giveObject() // return un pointeur sur l'objet dans la cell.
        {
            
        }
    }
}
