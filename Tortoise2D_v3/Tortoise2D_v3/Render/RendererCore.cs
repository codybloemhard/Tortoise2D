using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL4;
using Tortoise2D_v3.Math;
using Tortoise2D_v3.Platform;

namespace Tortoise2D_v3.Render
{
    public class RendererCore
    {
        private int vertexBuffer, colorBuffer, textureBuffer, extraBuffer;
        private int vao;

        private int max = 0;
        private int size = 0;

        private int vertsC = 0;
        private int colsC = 0;
        private int texC = 0;

        private float[] vertices;
        private float[] colors;
        private float[] textures;

        private int MAX_VERTICES;
        private int MAX_COLORS;
        private int MAX_TEXTURES;

        public RendererCore(int size)
        {
            GL.GenVertexArrays(1,out vao);
            
            GL.GenBuffers(1, out vertexBuffer);
            GL.GenBuffers(1, out colorBuffer);
            GL.GenBuffers(1, out textureBuffer);
            //GL.GenBuffers(1, out extraBuffer);

            Debug.PrintEngine("Generated VertexBuffer: " + vertexBuffer);
            Debug.PrintEngine("Generated ColorBuffer: " + colorBuffer);
            Debug.PrintEngine("Generated TextureBuffer: " + textureBuffer);
            max = size;

            vertices = new float[max * 2 * 3 * 2];
            colors = new float[max * 2 * 3 * 4];
            textures = new float[max * 2 * 3 * 2];
            MAX_VERTICES = max * 2 * 3 * 2;
            MAX_COLORS = max * 2 * 3 * 4;
            MAX_TEXTURES = max * 2 * 3 * 2;
        }

        public void AddSprite( float x,  float y,  float w,  float h)
        {
            if(size < max)
            {
                vertices[vertsC + 0] = x;
                vertices[vertsC + 1] = y + 22;

                vertices[vertsC + 2] = x + w;
                vertices[vertsC + 3] = y + h + 22;

                vertices[vertsC + 4] = x;
                vertices[vertsC + 5] = y + h + 22;

                vertices[vertsC + 6] = x;
                vertices[vertsC + 7] = y + 22;

                vertices[vertsC + 8] = x + w;
                vertices[vertsC + 9] = y + 22;

                vertices[vertsC + 10] = x + w;
                vertices[vertsC + 11] = y + h + 22;

                colors[colsC + 0] = 1.0f;
                colors[colsC + 1] = 1.0f;
                colors[colsC + 2] = 1.0f;
                colors[colsC + 3] = 1.0f;

                colors[colsC + 4] = 1.0f;
                colors[colsC + 5] = 1.0f;
                colors[colsC + 6] = 1.0f;
                colors[colsC + 7] = 1.0f;

                colors[colsC + 8] = 1.0f;
                colors[colsC + 9] = 1.0f;
                colors[colsC + 10] = 1.0f;
                colors[colsC + 11] = 1.0f;

                colors[colsC + 12] = 1.0f;
                colors[colsC + 13] = 1.0f;
                colors[colsC + 14] = 1.0f;
                colors[colsC + 15] = 1.0f;

                colors[colsC + 16] = 1.0f;
                colors[colsC + 17] = 1.0f;
                colors[colsC + 18] = 1.0f;
                colors[colsC + 19] = 1.0f;

                colors[colsC + 20] = 1.0f;
                colors[colsC + 21] = 1.0f;
                colors[colsC + 22] = 1.0f;
                colors[colsC + 23] = 1.0f;

                textures[texC + 0] = 0.0f;
                textures[texC + 1] = 0.0f;

                textures[texC + 2] = 1.0f;
                textures[texC + 3] = 1.0f;

                textures[texC + 4] = 0.0f;
                textures[texC + 5] = 1.0f;
            
                textures[texC + 6] = 0.0f;
                textures[texC + 7] = 0.0f;

                textures[texC + 8] = 1.0f;
                textures[texC + 9] = 0.0f;

                textures[texC + 10] = 1.0f;
                textures[texC + 11] = 1.0f;

                size++;
                vertsC += 12;
                colsC += 24;
                texC += 12;
            }
        }

        public void AddSpriteRGBA(float x, float y, float w, float h, float r, float g, float b, float a)
        {
            if (size < max)
            {
                vertices[vertsC + 0] = x;
                vertices[vertsC + 1] = y + 22;

                vertices[vertsC + 2] = x + w;
                vertices[vertsC + 3] = y + h + 22;

                vertices[vertsC + 4] = x;
                vertices[vertsC + 5] = y + h + 22;
                
                vertices[vertsC + 6] = x;
                vertices[vertsC + 7] = y + 22;

                vertices[vertsC + 8] = x + w;
                vertices[vertsC + 9] = y + 22;

                vertices[vertsC + 10] = x + w;
                vertices[vertsC + 11] = y + h + 22;
                
                colors[colsC + 0] = r;
                colors[colsC + 1] = g;
                colors[colsC + 2] = b;
                colors[colsC + 3] = a;

                colors[colsC + 4] = r;
                colors[colsC + 5] = g;
                colors[colsC + 6] = b;
                colors[colsC + 7] = a;

                colors[colsC + 8] = r;
                colors[colsC + 9] = g;
                colors[colsC + 10] = b;
                colors[colsC + 11] = a;

                colors[colsC + 12] = r;
                colors[colsC + 13] = g;
                colors[colsC + 14] = b;
                colors[colsC + 15] = a;

                colors[colsC + 16] = r;
                colors[colsC + 17] = g;
                colors[colsC + 18] = b;
                colors[colsC + 19] = a;

                colors[colsC + 20] = r;
                colors[colsC + 21] = g;
                colors[colsC + 22] = b;
                colors[colsC + 23] = a;

                textures[texC + 0] = 0.0f;
                textures[texC + 1] = 0.0f;

                textures[texC + 2] = 1.0f;
                textures[texC + 3] = 1.0f;

                textures[texC + 4] = 0.0f;
                textures[texC + 5] = 1.0f;

                textures[texC + 6] = 0.0f;
                textures[texC + 7] = 0.0f;

                textures[texC + 8] = 1.0f;
                textures[texC + 9] = 0.0f;

                textures[texC + 10] = 1.0f;
                textures[texC + 11] = 1.0f;

                size++;
                vertsC += 12;
                texC += 12;
                colsC += 24;
            }
        }
        public void AddSpriteRGBA4(float x, float y, float w, float h, 
                                float r1, float g1, float b1, float a1,
                                float r2, float g2, float b2, float a2,
                                float r3, float g3, float b3, float a3,
                                float r4, float g4, float b4, float a4)
        {
            if (size < max)
            {
                vertices[vertsC + 0] = x;
                vertices[vertsC + 1] = y + 22;

                vertices[vertsC + 2] = x + w;
                vertices[vertsC + 3] = y + h + 22;

                vertices[vertsC + 4] = x;
                vertices[vertsC + 5] = y + h + 22;

                vertices[vertsC + 6] = x;
                vertices[vertsC + 7] = y + 22;

                vertices[vertsC + 8] = x + w;
                vertices[vertsC + 9] = y + 22;

                vertices[vertsC + 10] = x + w;
                vertices[vertsC + 11] = y + h + 22;

                colors[colsC + 0] = r1;
                colors[colsC + 1] = g1;
                colors[colsC + 2] = b1;
                colors[colsC + 3] = a1;

                colors[colsC + 4] = r2;
                colors[colsC + 5] = g2;
                colors[colsC + 6] = b2;
                colors[colsC + 7] = a2;

                colors[colsC + 8] = r3;
                colors[colsC + 9] = g3;
                colors[colsC + 10] = b3;
                colors[colsC + 11] = a3;

                colors[colsC + 12] = r1;
                colors[colsC + 13] = g1;
                colors[colsC + 14] = b1;
                colors[colsC + 15] = a1;

                colors[colsC + 16] = r4;
                colors[colsC + 17] = g4;
                colors[colsC + 18] = b4;
                colors[colsC + 19] = a4;

                colors[colsC + 20] = r2;
                colors[colsC + 21] = g2;
                colors[colsC + 22] = b2;
                colors[colsC + 23] = a2;

                textures[texC + 0] = 0.0f;
                textures[texC + 1] = 0.0f;

                textures[texC + 2] = 1.0f;
                textures[texC + 3] = 1.0f;

                textures[texC + 4] = 0.0f;
                textures[texC + 5] = 1.0f;

                textures[texC + 6] = 0.0f;
                textures[texC + 7] = 0.0f;

                textures[texC + 8] = 1.0f;
                textures[texC + 9] = 0.0f;

                textures[texC + 10] = 1.0f;
                textures[texC + 11] = 1.0f;

                colsC += 24;
                size++;
                vertsC += 12;
                texC += 12;
            }
        }

        public void AddSpriteUV(float x, float y, float w, float h,
                                            float u1, float v1, float u2, float v2)
        {
            if (size < max)
            {
                vertices[vertsC + 0] = x;
                vertices[vertsC + 1] = y + 22;

                vertices[vertsC + 2] = x + w;
                vertices[vertsC + 3] = y + h + 22;

                vertices[vertsC + 4] = x;
                vertices[vertsC + 5] = y + h + 22;

                vertices[vertsC + 6] = x;
                vertices[vertsC + 7] = y + 22;

                vertices[vertsC + 8] = x + w;
                vertices[vertsC + 9] = y + 22;

                vertices[vertsC + 10] = x + w;
                vertices[vertsC + 11] = y + h + 22;

                colors[colsC + 0] = 1;
                colors[colsC + 1] = 1;
                colors[colsC + 2] = 1;
                colors[colsC + 3] = 1;

                colors[colsC + 4] = 1;
                colors[colsC + 5] = 1;
                colors[colsC + 6] = 1;
                colors[colsC + 7] = 1;

                colors[colsC + 8] = 1;
                colors[colsC + 9] = 1;
                colors[colsC + 10] = 1;
                colors[colsC + 11] = 1;

                colors[colsC + 12] = 1;
                colors[colsC + 13] = 1;
                colors[colsC + 14] = 1;
                colors[colsC + 15] = 1;

                colors[colsC + 16] = 1;
                colors[colsC + 17] = 1;
                colors[colsC + 18] = 1;
                colors[colsC + 19] = 1;

                colors[colsC + 20] = 1;
                colors[colsC + 21] = 1;
                colors[colsC + 22] = 1;
                colors[colsC + 23] = 1;

                textures[texC + 0] = u1;
                textures[texC + 1] = v1;

                textures[texC + 2] = u2;
                textures[texC + 3] = v2;

                textures[texC + 4] = u1;
                textures[texC + 5] = v2;

                textures[texC + 6] = u1;
                textures[texC + 7] = v1;

                textures[texC + 8] = u2;
                textures[texC + 9] = v1;

                textures[texC + 10] = u2;
                textures[texC + 11] = v2;

                colsC += 24;
                size++;
                vertsC += 12;
                texC += 12;
            }
        }

        public void AddSpriteUVRGBA(float x, float y, float w, float h,
                                            float u1, float v1, float u2, float v2,
                                            float r, float g, float b, float a)
        {
            if (size < max)
            {
                vertices[vertsC + 0] = x;
                vertices[vertsC + 1] = y + 22;

                vertices[vertsC + 2] = x + w;
                vertices[vertsC + 3] = y + h + 22;

                vertices[vertsC + 4] = x;
                vertices[vertsC + 5] = y + h + 22;

                vertices[vertsC + 6] = x;
                vertices[vertsC + 7] = y + 22;

                vertices[vertsC + 8] = x + w;
                vertices[vertsC + 9] = y + 22;

                vertices[vertsC + 10] = x + w;
                vertices[vertsC + 11] = y + h + 22;

                colors[colsC + 0] = r;
                colors[colsC + 1] = g;
                colors[colsC + 2] = b;
                colors[colsC + 3] = a;

                colors[colsC + 4] = r;
                colors[colsC + 5] = g;
                colors[colsC + 6] = b;
                colors[colsC + 7] = a;

                colors[colsC + 8] = r;
                colors[colsC + 9] = g;
                colors[colsC + 10] = b;
                colors[colsC + 11] = a;

                colors[colsC + 12] = r;
                colors[colsC + 13] = g;
                colors[colsC + 14] = b;
                colors[colsC + 15] = a;

                colors[colsC + 16] = r;
                colors[colsC + 17] = g;
                colors[colsC + 18] = b;
                colors[colsC + 19] = a;

                colors[colsC + 20] = r;
                colors[colsC + 21] = g;
                colors[colsC + 22] = b;
                colors[colsC + 23] = a;

                textures[texC + 0] = u1;
                textures[texC + 1] = v1;

                textures[texC + 2] = u2;
                textures[texC + 3] = v2;

                textures[texC + 4] = u1;
                textures[texC + 5] = v2;

                textures[texC + 6] = u1;
                textures[texC + 7] = v1;

                textures[texC + 8] = u2;
                textures[texC + 9] = v1;

                textures[texC + 10] = u2;
                textures[texC + 11] = v2;

                colsC += 24;
                size++;
                vertsC += 12;
                texC += 12;
            }
        }
        public void AddPointsUV(float p0x, float p0y, float p1x, float p1y, float p2x, float p2y, float p3x, float p3y,
                                            float u1, float v1, float u2, float v2)
        {
            if (size < max)
            {
                vertices[vertsC + 0] = p0x;
                vertices[vertsC + 1] = p0y + 22;

                vertices[vertsC + 2] = p2x;
                vertices[vertsC + 3] = p2y + 22;

                vertices[vertsC + 4] = p3x;
                vertices[vertsC + 5] = p3y + 22;

                vertices[vertsC + 6] = p0x;
                vertices[vertsC + 7] = p0y + 22;

                vertices[vertsC + 8] = p1x;
                vertices[vertsC + 9] = p1y + 22;

                vertices[vertsC + 10] = p2x;
                vertices[vertsC + 11] = p2y + 22;

                colors[colsC + 0] = 1;
                colors[colsC + 1] = 1;
                colors[colsC + 2] = 1;
                colors[colsC + 3] = 1;

                colors[colsC + 4] = 1;
                colors[colsC + 5] = 1;
                colors[colsC + 6] = 1;
                colors[colsC + 7] = 1;

                colors[colsC + 8] = 1;
                colors[colsC + 9] = 1;
                colors[colsC + 10] = 1;
                colors[colsC + 11] = 1;

                colors[colsC + 12] = 1;
                colors[colsC + 13] = 1;
                colors[colsC + 14] = 1;
                colors[colsC + 15] = 1;

                colors[colsC + 16] = 1;
                colors[colsC + 17] = 1;
                colors[colsC + 18] = 1;
                colors[colsC + 19] = 1;

                colors[colsC + 20] = 1;
                colors[colsC + 21] = 1;
                colors[colsC + 22] = 1;
                colors[colsC + 23] = 1;

                textures[texC + 0] = u1;
                textures[texC + 1] = v1;

                textures[texC + 2] = u2;
                textures[texC + 3] = v2;

                textures[texC + 4] = u1;
                textures[texC + 5] = v2;

                textures[texC + 6] = u1;
                textures[texC + 7] = v1;

                textures[texC + 8] = u2;
                textures[texC + 9] = v1;

                textures[texC + 10] = u2;
                textures[texC + 11] = v2;

                colsC += 24;
                size++;
                vertsC += 12;
                texC += 12;
            }
        }
        public void AddPointsUVRGBA(float p0x, float p0y, float p1x, float p1y, float p2x, float p2y, float p3x, float p3y,
                                            float u1, float v1, float u2, float v2,
                                            float r, float g, float b, float a)
        {
            if (size < max)
            {
                vertices[vertsC + 0] = p0x;
                vertices[vertsC + 1] = p0y + 22;

                vertices[vertsC + 2] = p2x;
                vertices[vertsC + 3] = p2y + 22;

                vertices[vertsC + 4] = p3x;
                vertices[vertsC + 5] = p3y + 22;

                vertices[vertsC + 6] = p0x;
                vertices[vertsC + 7] = p0y + 22;

                vertices[vertsC + 8] = p1x;
                vertices[vertsC + 9] = p1y + 22;

                vertices[vertsC + 10] = p2x;
                vertices[vertsC + 11] = p2y + 22;

                colors[colsC + 0] = r;
                colors[colsC + 1] = g;
                colors[colsC + 2] = b;
                colors[colsC + 3] = a;

                colors[colsC + 4] = r;
                colors[colsC + 5] = g;
                colors[colsC + 6] = b;
                colors[colsC + 7] = a;

                colors[colsC + 8] = r;
                colors[colsC + 9] = g;
                colors[colsC + 10] = b;
                colors[colsC + 11] = a;

                colors[colsC + 12] = r;
                colors[colsC + 13] = g;
                colors[colsC + 14] = b;
                colors[colsC + 15] = a;

                colors[colsC + 16] = r;
                colors[colsC + 17] = g;
                colors[colsC + 18] = b;
                colors[colsC + 19] = a;

                colors[colsC + 20] = r;
                colors[colsC + 21] = g;
                colors[colsC + 22] = b;
                colors[colsC + 23] = a;

                textures[texC + 0] = u1;
                textures[texC + 1] = v1;

                textures[texC + 2] = u2;
                textures[texC + 3] = v2;

                textures[texC + 4] = u1;
                textures[texC + 5] = v2;

                textures[texC + 6] = u1;
                textures[texC + 7] = v1;

                textures[texC + 8] = u2;
                textures[texC + 9] = v1;

                textures[texC + 10] = u2;
                textures[texC + 11] = v2;

                colsC += 24;
                size++;
                vertsC += 12;
                texC += 12;
            }
        }

        public void SetData()
        {
            GL.BindVertexArray(vao);

            GL.BindBuffer(BufferTarget.ArrayBuffer, vertexBuffer);
            GL.BufferData<float>(BufferTarget.ArrayBuffer, (IntPtr)(size * 2 * 3 * 2 * sizeof(float)), vertices, BufferUsageHint.StaticDraw);

            GL.BindBuffer(BufferTarget.ArrayBuffer, colorBuffer);
            GL.BufferData<float>(BufferTarget.ArrayBuffer, (IntPtr)(size * 2 * 3 * 4 *  sizeof(float)), colors, BufferUsageHint.StaticDraw);

            GL.BindBuffer(BufferTarget.ArrayBuffer, textureBuffer);
            GL.BufferData<float>(BufferTarget.ArrayBuffer, (IntPtr)(size * 2 * 3 * 2 * sizeof(float)), textures, BufferUsageHint.StaticDraw);
        }

        public void ClearData()
        {
            size = 0;
            vertsC = 0;
            colsC = 0;
            texC = 0;
        }

        public void Render()
        {
            GL.BindVertexArray(vao);
            
            GL.BindBuffer(BufferTarget.ArrayBuffer, vertexBuffer);
            GL.VertexAttribPointer(0, 2,VertexAttribPointerType.Float, false, 0, 0);
           
            GL.BindBuffer(BufferTarget.ArrayBuffer, colorBuffer);
            GL.VertexAttribPointer(1, 4, VertexAttribPointerType.Float, false, 0, 0);

            GL.BindBuffer(BufferTarget.ArrayBuffer, textureBuffer);
            GL.VertexAttribPointer(2, 2, VertexAttribPointerType.Float, false, 0, 0);

            GL.EnableVertexAttribArray(0);
            GL.EnableVertexAttribArray(1);
            GL.EnableVertexAttribArray(2);
            
            GL.DrawArrays(PrimitiveType.Triangles,0,size * 2 * 3 * 2);
        }

        public void DebugRawData(int buffer, int start, int end)
        {
            if(buffer == 0)
            {
                for (int i = start; i < end; i++)
                {
                    Debug.PrintEngine("" + vertices[i]);
                }
            }
            if(buffer == 1)
            {
                for (int i = start; i < end; i++)
                {
                    Debug.PrintEngine("" + colors[i]);
                }
            }
        }
    }
}