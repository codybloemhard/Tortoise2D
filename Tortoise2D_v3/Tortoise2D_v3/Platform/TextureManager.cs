using System;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections.Generic;

namespace Tortoise2D_v3.Platform
{
    using Render;
    using Platform;

    public class TextureManager
    {
        private Dictionary<string, int> rawTextures;
        private Texturebuilder builder;

        private List<Bitmap> rawSpr;
        private Texture[] texturesSpr;
        private LookupStrInt texturenamesSpr;
        private int counterSpr = 0;

        private List<Bitmap> rawGui;
        private Texture[] texturesGui;
        private LookupStrInt texturenamesGui;
        private int counterGui = 0;

        public TextureManager()
        {
            rawTextures = new Dictionary<string, int>();
            builder = new Texturebuilder();

            rawSpr = new List<Bitmap>();
            texturenamesSpr = new LookupStrInt(1000);
            rawGui= new List<Bitmap>();
            texturenamesGui = new LookupStrInt(1000);
        }

        public Texture GetSprite(string name)
        {
            return texturesSpr[texturenamesSpr.GetEntry(name)];
        }
        public Texture GetGUI(string name)
        {
            return texturesGui[texturenamesGui.GetEntry(name)];
        }
        public Texture GetGUI0()
        {
            return texturesGui[0];
        }

        public void AddSprite(string path, string name)
        {
            rawSpr.Add(new Bitmap(path));
            texturenamesSpr.AddEntry(name, counterSpr++);
        }
        public void AddGUI(string path, string name)
        {
            rawGui.Add(new Bitmap(path));
            texturenamesGui.AddEntry(name, counterGui++);
        }

        public void LoadSprites()
        {
            Bitmap[] images = rawSpr.ToArray();
            Bitmap atlas = builder.BuildSuperTexture(images, out texturesSpr);
            AddRawTexture("sprites", atlas);
            for (int i = 0; i < texturesSpr.Length; i++)
            {
                texturesSpr[i].texture = GetRawTexture("sprites");
                rawSpr[i].Dispose();
                images[i].Dispose();
            }
            rawSpr.Clear();
            GC.Collect(2);
        }
        public void LoadGUI()
        {
            Bitmap[] images = rawGui.ToArray();
            Bitmap atlas = builder.BuildSuperTexture(images, out texturesGui);
            AddRawTexture("gui", atlas);
            for (int i = 0; i < texturesGui.Length; i++)
            {
                texturesGui[i].texture = GetRawTexture("gui");
                rawGui[i].Dispose();
            }
            rawGui.Clear();
        }

        public int GetRawTexture(string textureKey)
        {
            return rawTextures[textureKey];
        }

        public void AddRawTexture(string path, string key)
        {
            int textureID = 0;
            GL.GenTextures(1, out textureID);
            GL.BindTexture(TextureTarget.Texture2D, textureID);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Nearest);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Nearest);
            Bitmap bitmap = new Bitmap(path);
            BitmapData data = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            {
                GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, data.Width, data.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);
            }
            bitmap.UnlockBits(data);
            GL.BindTexture(TextureTarget.Texture2D, 0);
            rawTextures.Add(key, textureID);
            Debug.PrintEngine("Generated texture: " + textureID + " (" + path + ")");
            //Console.WriteLine("Texture[" + path + "] succesful saved @ [" + key + "]");
        }

        public void AddRawTexture(string key, Bitmap img)
        {
            int textureID = 0;
            GL.GenTextures(1, out textureID);
            GL.BindTexture(TextureTarget.Texture2D, textureID);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Nearest);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Nearest);
            BitmapData data = img.LockBits(new Rectangle(0, 0, img.Width, img.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            {
                GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, data.Width, data.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);
            }
            img.UnlockBits(data);
            GL.BindTexture(TextureTarget.Texture2D, 0);
            rawTextures.Add(key, textureID);
            Debug.PrintEngine("Binded texture: " + textureID);
            //Console.WriteLine("Texture[" + path + "] succesful saved @ [" + key + "]");
        }

        public void OutTexture(string path, out int textureID)
        {
            GL.GenTextures(1, out textureID);
            GL.BindTexture(TextureTarget.Texture2D, textureID);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Nearest);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Nearest);
            Bitmap bitmap = new Bitmap(path);
            BitmapData data = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            {
                GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, data.Width, data.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);
            }
            bitmap.UnlockBits(data);
            GL.BindTexture(TextureTarget.Texture2D, 0);
        }
    }

}
