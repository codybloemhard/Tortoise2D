using System;
using OpenTK.Graphics.OpenGL;
using OpenTK;
using System.Drawing;
using Tortoise2D_v3.Platform;
using Tortoise2D_v3.Math;

namespace Tortoise2D_v3.Render
{
    public class Renderer
    {
        private RendererCore core;
        private TextureManager tm;
        private Tortoise2d game;

        private Shader shader_plain, shader_w_light, shader_o_light, shader_merge, shader_merge_effect;

        private int width, height;
        private int texture = 0;
        private float _1920scale, _1080scale;
        
        private Fbo fbo;
        private Grid grid;

        private System.Random rand = new Random();

        public Renderer(Tortoise2d gg, int w, int h, int sprites, int maxlights, TextureManager t, Grid g)
        {
            game = gg;
            tm = t;
            width = w;
            height = h;

            _1920scale = (float)w / 1920;
            _1080scale = (float)h / 1080;
            //if not replace your stone-age-gpu for a decent one!
            Shader.GetSupported();

            shader_plain = new Shader(Shader.RShaderFF("shaders/vertex_plain.glsl"), Shader.RShaderFF("shaders/frag_plain.glsl"));
            shader_w_light = new Shader(Shader.RShaderFF("shaders/vertex_plain.glsl"), Shader.RShaderFF("shaders/frag_with_light.glsl"));
            shader_o_light = new Shader(Shader.RShaderFF("shaders/vertex_plain.glsl"), Shader.RShaderFF("shaders/frag_only_light.glsl"));
            shader_merge = new Shader(Shader.RShaderFF("shaders/vertex_plain.glsl"), Shader.RShaderFF("shaders/frag_merge.glsl"));
            shader_merge_effect = new Shader(Shader.RShaderFF("shaders/vertex_plain.glsl"), Shader.RShaderFF("shaders/frag_merge_effect.glsl"));
            core = new RendererCore(sprites);
            fbo = new Fbo(width, height);
            this.grid = g;
        }
        //ok
        public void START()
        {
            //window matrix thinghy stuff ;)
            GL.Viewport(0, 0, width, height);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            OpenTK.Matrix4 perspective = OpenTK.Matrix4.CreateOrthographicOffCenter(0, width, height, 0, 0, 1);
            GL.LoadMatrix(ref perspective);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            //enable stuff
            GL.Enable(EnableCap.Blend);
            GL.Enable(EnableCap.Texture2D);
            GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
            //do real stuff
            GL.ClearColor(Color.FromArgb(0));
            GL.Clear(ClearBufferMask.ColorBufferBit);
        }
        //ok
        public void END(Tortoise2d m)
        {
            Shader.Bind(null);
            core.ClearData();
            //GL.Flush();
            //GL.Finish();
            m.SwapBuffers();
        }
        //ok
        public void Render_SceneToLayer(Layer layer, bool usecam = true)
        {
            core.SetData();
            fbo.Use(layer.t);

            if (usecam)
            {
                shader_plain.SetVariable("cam_pos", game.camera.GetXPixels(), game.camera.GetYPixels(), game.camera.GetZoomX(), game.camera.GetZoomY());
            }
            else
            {
                shader_plain.SetVariable("cam_pos", 0, 0, 1, 1);
            }
            shader_plain.SetVariable("screen_size_half", width / 2, height / 2);
            GL.Viewport(0, 0, layer.w, layer.h);

            Shader.Bind(shader_plain);

            GL.BindTexture(TextureTarget.Texture2D, texture);
            GL.Clear(ClearBufferMask.ColorBufferBit);
            core.Render();

            fbo.DeUse();
            GL.Viewport(0, 0, width, height);
        }
        //ok
        public void RenderLayer(Layer layer)
        {
            core.ClearData();
            core.AddSprite(0, 0, width, height);
            core.SetData();

            shader_merge.SetVariable("cam_pos", 1, 1, 1, 1);
            shader_merge.SetVariable("screen_size_half", width / 2, height / 2);

            Shader.Bind(shader_merge);

            GL.BlendFunc(BlendingFactorSrc.One, BlendingFactorDest.OneMinusSrcAlpha);

            BindTexture(layer.t);
            core.Render();
            core.ClearData();
        }
        //ok
        public void Render_MergeLayers(Layer[] scene_layer, Layer[] effect_layer)
        {
            core.ClearData();
            core.AddSprite(0, 0, width, height);
            core.SetData();

            shader_merge.SetVariable("cam_pos", 1, 1, 1, 1);
            shader_merge.SetVariable("screen_size_half", width / 2, height / 2);

            Shader.Bind(shader_merge);

            GL.BlendFunc(BlendingFactorSrc.One, BlendingFactorDest.OneMinusSrcAlpha);

            for(int i = 0; i < scene_layer.Length; i++)
            {
                BindTexture(scene_layer[i].t);
                core.Render();
            }

            core.ClearData();
            core.AddSprite(0, 0, width, height);
            core.SetData();

            shader_merge_effect.SetVariable("brightness", 1f);
            shader_merge_effect.SetVariable("screen_size_half", width / 2, height / 2);
            shader_merge_effect.SetVariable("cam_pos", 0, 0, 1, 1);
            Shader.Bind(shader_merge_effect);

            GL.BlendEquationSeparate(BlendEquationMode.FuncAdd, BlendEquationMode.FuncAdd);
            GL.BlendFuncSeparate(BlendingFactorSrc.DstColor, BlendingFactorDest.Zero, BlendingFactorSrc.DstAlpha, BlendingFactorDest.Zero);

            for (int i = 0; i < effect_layer.Length; i++)
            {
                BindTexture(effect_layer[i].t);
                core.Render();
            }
        }
        //ok
        public Layer GenLayer(int w = -1, int h = -1)
        { 
            return fbo.GenFBOTexture(w, h);
        }
        //ok
        public void NewLayer(bool clearGeo)
        {
            if (clearGeo) core.ClearData();
        }

        //oldschool stuff
        public void Render_Slow_Quad(int x, int y, int w, int h, float u1, float v1, float u2, float v2, Color c)
        {
            GL.Begin(PrimitiveType.Quads);
            GL.Color4(c);
            GL.TexCoord2(u1, v1); GL.Vertex2(x, y);
            GL.TexCoord2(u2, v1); GL.Vertex2(x + w, y);
            GL.TexCoord2(u2, v2); GL.Vertex2(x + w, y + h);
            GL.TexCoord2(u1, v2); GL.Vertex2(x, y + h);
            GL.End();
        }
        public void Render_Slow_Quad(int x, int y, int w, int h, Color c)
        {
            GL.Begin(PrimitiveType.Quads);
            GL.Color4(c);
            GL.TexCoord2(0.0f, 0.0f); GL.Vertex2(x, y);
            GL.TexCoord2(1.0f, 0.0f); GL.Vertex2(x + w, y);
            GL.TexCoord2(1.0f, 1.0f); GL.Vertex2(x + w, y + h);
            GL.TexCoord2(0.0f, 1.0f); GL.Vertex2(x, y + h);
            GL.End();
        }
        public void Render_Slow_Quad(int x, int y, int w, int h)
        {
            GL.Begin(PrimitiveType.Quads);
            GL.Color4(Color.White);
            GL.TexCoord2(0.0f, 0.0f); GL.Vertex2(x, y);
            GL.TexCoord2(1.0f, 0.0f); GL.Vertex2(x + w, y);
            GL.TexCoord2(1.0f, 1.0f); GL.Vertex2(x + w, y + h);
            GL.TexCoord2(0.0f, 1.0f); GL.Vertex2(x, y + h);
            GL.End();
        }

        //adders all ok
        public void AddSpriteTexture(Texture t,float x, float y, float w, float h)
        {
            core.AddSpriteUV(grid.TranslateGridScreenX(x), grid.TranslateGridScreenY(y)
                            , grid.TranslateGridScreenX(w), grid.TranslateGridScreenY(h), t.u1, t.v1, t.u2, t.v2);
        }
        public void AddSpriteTextureRGBA(Texture t, float x, float y, float w, float h, float r, float g, float b, float a)
        {
            core.AddSpriteUVRGBA(grid.TranslateGridScreenX(x), grid.TranslateGridScreenY(y)
                            , grid.TranslateGridScreenX(w), grid.TranslateGridScreenY(h), t.u1, t.v1, t.u2, t.v2, r, g, b, a);
        }

        public void AddSprite(float x, float y, float w, float h)
        {
            core.AddSprite(grid.TranslateGridScreenX(x), grid.TranslateGridScreenY(y)
                            ,grid.TranslateGridScreenX(w), grid.TranslateGridScreenY(h));
        }
        public void AddSpriteRGBA(float x, float y, float w, float h, float r, float g, float b, float a)
        {
            core.AddSpriteRGBA(grid.TranslateGridScreenX(x), grid.TranslateGridScreenY(y),
                grid.TranslateGridScreenX(w), grid.TranslateGridScreenY(h), r, g, b, a);
        }
        public void AddSpriteRGBA4(float x, float y, float w, float h,
                                float r1, float g1, float b1, float a1,
                                float r2, float g2, float b2, float a2,
                                float r3, float g3, float b3, float a3,
                                float r4, float g4, float b4, float a4)
        {
            core.AddSpriteRGBA4(grid.TranslateGridScreenX(x), grid.TranslateGridScreenY(y),
                            grid.TranslateGridScreenX(w), grid.TranslateGridScreenY(h),
                            r1, g1, b1, a1,
                            r1, g2, b2, a2,
                            r1, g3, b3, a3,
                            r1, g4, b4, a4);
        }

        public void AddSpriteUV(float x, float y, float w, float h, float u1, float v1, float u2, float v2)
        {
            core.AddSpriteUV(grid.TranslateGridScreenX(x), grid.TranslateGridScreenY(y),
                grid.TranslateGridScreenX(w), grid.TranslateGridScreenY(h),u1,v1,u2,v2);
        }
        public void AddSpriteUVRGBA(float x, float y, float w, float h,
                                                float u1, float v1, float u2, float v2,
                                                float r, float g, float b, float a)
        {
            core.AddSpriteUVRGBA(grid.TranslateGridScreenX(x), grid.TranslateGridScreenY(y),
                grid.TranslateGridScreenX(w), grid.TranslateGridScreenY(h),u1,v1,u2,v2,r,g,b,a);
        }
        public void AddPointsUV(float p0x, float p0y, float p1x, float p1y, float p2x, float p2y, float p3x, float p3y,
                                float u1, float v1, float u2, float v2)
        {
            core.AddPointsUV(grid.TranslateGridScreenX(p0x), grid.TranslateGridScreenY(p0y), grid.TranslateGridScreenX(p1x), grid.TranslateGridScreenY(p1y),
                                                        grid.TranslateGridScreenX(p2x), grid.TranslateGridScreenY(p2y),
                                                        grid.TranslateGridScreenX(p3x), grid.TranslateGridScreenY(p3y), u1, v1, u2, v2);
        }
        public void AddPointsUVRGBA(float p0x, float p0y, float p1x, float p1y, float p2x, float p2y, float p3x, float p3y,
                                float u1, float v1, float u2, float v2,
                                float r, float g, float b, float a)
        {
            core.AddPointsUVRGBA(grid.TranslateGridScreenX(p0x), grid.TranslateGridScreenY(p0y), grid.TranslateGridScreenX(p1x), grid.TranslateGridScreenY(p1y),
                                                        grid.TranslateGridScreenX(p2x), grid.TranslateGridScreenY(p2y),
                                                        grid.TranslateGridScreenX(p3x), grid.TranslateGridScreenY(p3y), u1, v1, u2, v2, r, g, b, a);
        }
        //helpers
        //ok
        public void BindTexture(int textureID)
        {
            GL.BindTexture(TextureTarget.Texture2D, textureID);
            texture = textureID;
        }
    }
}