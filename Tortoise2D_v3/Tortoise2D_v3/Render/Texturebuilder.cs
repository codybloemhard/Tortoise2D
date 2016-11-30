using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Tortoise2D_v3.Render
{
    public class Texturebuilder
    {
        private const int SIZE = 4096;
        private int c = 0;
        
        public Texturebuilder()
        {
        }

        public void SaveSuperTexture(Bitmap[] images)
        {
            int[] x, y;
            x = new int[images.Length];
            y = new int[images.Length];

            SortBitmapsBigToSmall(ref images);

            PlaceImages(images, ref x, ref y);

            packBitmaps(images, x, y);
        }

        public Bitmap BuildSuperTexture(Bitmap[] images, out Texture[] textures)
        {
            int[] x, y;
            x = new int[images.Length];
            y = new int[images.Length];
            Texture[] texs = new Texture[images.Length];

            //SortBitmapsBigToSmall(ref images);

            PlaceImages(images, ref x, ref y, ref texs);

            textures = texs;

            return returnPackedBitmaps(images, x, y);
        }

        private void PlaceImages(Bitmap[] images, ref int[] x, ref int[] y)
        {
            Node start = new Node();
            start.rect = new Rect(0, 0, SIZE, SIZE);

            for (int i = 0; i < images.Length; i++)
            {
                Node thisnode = start.Insert(new Rect(0, 0, images[i].Width, images[i].Height));
                if(thisnode != null)
                {
                    x[i] = thisnode.rect.x;
                    y[i] = thisnode.rect.y;
                }
            }
        }

        private void PlaceImages(Bitmap[] images, ref int[] x, ref int[] y, ref Texture[] texs)
        {
            Node start = new Node();
            start.rect = new Rect(0, 0, SIZE, SIZE);

            for (int i = 0; i < images.Length; i++)
            {
                Node thisnode = start.Insert(new Rect(0, 0, images[i].Width, images[i].Height));
                if (thisnode != null)
                {
                    x[i] = thisnode.rect.x;
                    y[i] = thisnode.rect.y;
                    texs[i].u1 = (float)x[i] / (float)SIZE;
                    texs[i].v1 = (float)y[i] / (float)SIZE;
                    texs[i].u2 = (float)(x[i] + thisnode.rect.w) / (float)SIZE;
                    texs[i].v2 = (float)(y[i] + thisnode.rect.h) / (float)SIZE;
                }
            }
        }

        private void SortBitmapsBigToSmall(ref Bitmap[] images)
        {
            List<Bitmap> rawlist = new List<Bitmap>();
            for (int i = 0; i < images.Length; i++)
            {
                rawlist.Add(images[i]);
            }
            List<Bitmap> orderd = rawlist.OrderBy(o => o.Height).ToList();
            for (int i = 0; i < images.Length; i++)
            {
                images[i] = orderd[images.Length - i - 1];
            }
        }

        private Bitmap packBitmaps(Bitmap[] images, int[] x, int[] y)
        {
            Bitmap final = new Bitmap(SIZE, SIZE);
            Graphics g = Graphics.FromImage(final);
            g.Clear(Color.FromArgb(0,0,0,0));

            for (int i = 0; i < images.Length; i++)
            {
                g.DrawImage(images[i], new Point(x[i], y[i]));
                images[i].Dispose();
            }
            g.Dispose();
            final.Save("assets/packed0.png", System.Drawing.Imaging.ImageFormat.Png);
            return final;
        }

        private Bitmap returnPackedBitmaps(Bitmap[] images, int[] x, int[] y)
        {
            Bitmap final = new Bitmap(SIZE, SIZE);
            Graphics g = Graphics.FromImage(final);
            g.Clear(Color.FromArgb(0, 0, 0, 0));

            for (int i = 0; i < images.Length; i++)
            {
                g.DrawImage(images[i], new Point(x[i], y[i]));
                images[i].Dispose();
            }
            g.Dispose();
            final.Save("assets/packed" + c + ".png", System.Drawing.Imaging.ImageFormat.Png);
            c++;
            return final;
        }
    }

    class Node
    {
        private Node l;
        private Node r;
        private bool filled;
        public Rect rect;

        public Node()
        {
            l = null;
            r = null;
            filled = false;
            this.rect = null;
        }

        public Node Insert(Rect other)
        {
            //check if has a child, if, then check left when null(nofit) check right
            //if r == null, return null under this node there is no place
            //when this a left child parent gets null and checks right or if this right child parent has no place
            if (l != null)
            {
                Node nodeLeft = l.Insert(other);
                if (nodeLeft != null)
                    return nodeLeft;
                return r.Insert(other);
            }

            //there is a rect here
            if (filled)
                return null;

            //this node is to small
            if (!other.FitsIn(this.rect))
                return null;

            //the img fits exact
            if (other.Compare(this.rect) == 0)
            {
                filled = true;
                return this;
            }

            //make two childs
            l = new Node();
            r = new Node();

            int diffWidth = rect.w - other.w;
            int diffHeight = rect.h - other.h;

            //split hor or ver
            if (diffWidth > diffHeight)
            {
                l.rect = new Rect(rect.x, rect.y, other.w, rect.h);
                r.rect = new Rect(rect.x + other.w, rect.y, rect.w - other.w, rect.h);
            }
            else
            {
                l.rect = new Rect(rect.x, rect.y, rect.w, other.h);
                r.rect = new Rect(rect.x, rect.y + other.h, rect.w, rect.h - other.h);
            }

            //fit img in leaf(left child, leaf == node where (l == null && r == null))
            return l.Insert(other);
        }
    }

    class Rect
    {
        public int x;
        public int y;
        public int w;
        public int h;

        public Rect(int x, int y, int w, int h)
        {
            this.x = x;
            this.y = y;
            this.w = w;
            this.h = h;
        }

        public bool FitsIn(Rect outer)
        {
            return (outer.w >= this.w && outer.h >= this.h);
        }

        public int Compare(Rect other)
        {
            if (this.w == other.w && this.h == other.h)
            {
                return 0;
            }

            int areaThis = this.w * this.h;
            int areaOther = other.w * other.h;
            int difference = areaThis - areaOther;
            if (difference >= 0)
            {
                return 1;
            }
            return -1;
        }
    }
}