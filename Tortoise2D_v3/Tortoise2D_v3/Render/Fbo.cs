using System;
using OpenTK.Graphics.OpenGL;
using OpenTK;
using System.Drawing;
using Tortoise2D_v3.Platform;

namespace Tortoise2D_v3.Render
{
    public class Fbo
    {
        private int fbo = 0;
        private int width, height;
        private DrawBuffersEnum[] buffers = new DrawBuffersEnum[1] { (DrawBuffersEnum)FramebufferAttachment.ColorAttachment0 };

        public Fbo(int width, int height)
        {
            this.width = width;
            this.height = height;
            GL.GenFramebuffers(1, out fbo);
            GL.BindFramebuffer(FramebufferTarget.Framebuffer, fbo);

            GL.BindFramebuffer(FramebufferTarget.Framebuffer, 0);
        }
        
        public Layer GenFBOTexture(int w = -1, int h = -1)
        {
            if (w == -1) w = width;
            if (h == -1) h = height;
            int tex;
            GL.GenTextures(1, out tex);
            GL.BindTexture(TextureTarget.Texture2D, tex);
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, w, h, 0, PixelFormat.Rgba, PixelType.UnsignedByte, IntPtr.Zero);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Nearest);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMagFilter.Nearest);
            Debug.PrintEngine("Generated FBO Texture: " + tex + " (" + w + " , " + h + ")");
            Layer returner = new Layer();
            returner.set(tex, w, h);
            return returner;
        }

        public void Use(int texture)
        {
            GL.BindFramebuffer(FramebufferTarget.Framebuffer, fbo);
            GL.FramebufferTexture(FramebufferTarget.Framebuffer, FramebufferAttachment.ColorAttachment0, texture, 0);
            GL.DrawBuffers(1, buffers);
        }

        public void DeUse()
        {
            GL.BindFramebuffer(FramebufferTarget.Framebuffer, 0);
        }
    }
}
