using System;
using Tortoise2D_v3.Platform;
using Tortoise2D_v3.Math;

namespace Tortoise2D_v3.Render
{
    public class Renderable
    {
        private Texture texture;
        private Tortoise2d t;
        private float x, y, w, h, r;
        private Matrix2 matrix;
        private Vector2[] p;
        private bool useMatrix = false;

        public Renderable(Tortoise2d t, Texture texture)
        {
            this.t = t;
            this.texture = texture;
            p = new Vector2[4];
            for(int i = 0; i < 4; i++)
            {
                p[i] = new Vector2();
            }
        }

        public Renderable(Tortoise2d t, string textureName)
        {
            this.t = t;
            texture = t.textures.GetSprite(textureName);
            p = new Vector2[4];
            for (int i = 0; i < 4; i++)
            {
                p[i] = new Vector2();
            }
        }

        public void SetTransform(float x, float y, float w, float h)
        {
            bool flag = false;
            if (w != this.w || h != this.h)
                flag = true;
            this.x = x;
            this.y = y;
            this.w = w;
            this.h = h;
            if (flag)
            {
                SetVectorFromDimensions();
                SetRotation(r);
            }
        }

        private void SetVectorFromDimensions()
        {
            p[0].x = -w / 2;
            p[0].y = -h / 2;

            p[1].x = w / 2;
            p[1].y = -h / 2;

            p[2].x = w / 2;
            p[2].y = h / 2;

            p[3].x = -w / 2;
            p[3].y = h / 2;
        }

        public void SetRotation(float deg)
        {
            float prevr = r;
            r = deg * MathHelper.DEG_RAD;
            Matrix2 temp = References.matrix;
            temp.SetRotation(-prevr + r);
            p[0].MulMatrix2(temp);
            p[1].MulMatrix2(temp);
            p[2].MulMatrix2(temp);
            p[3].MulMatrix2(temp);
        }

        public void Rotate(float deg)
        {
            float turn = deg * MathHelper.DEG_RAD;
            r += turn;
            Matrix2 temp = References.matrix;
            temp.SetRotation(turn);
            p[0].MulMatrix2(temp);
            p[1].MulMatrix2(temp);
            p[2].MulMatrix2(temp);
            p[3].MulMatrix2(temp);
        }

        public void EnableMatrix(bool e)
        {
            useMatrix = e;
        }

        public void ApplyMatrix(Matrix2 m, bool saveMatrix)
        {
            p[0].MulMatrix2(m);
            p[1].MulMatrix2(m);
            p[2].MulMatrix2(m);
            p[3].MulMatrix2(m);
            if (saveMatrix)
                matrix = m;
        }

        public virtual void Render()
        {
            if(!useMatrix)
                t.renderer.AddSpriteUV(x, y, w, h, texture.u1, texture.v1, texture.u2, texture.v2);
            else
                t.renderer.AddPointsUV(p[0].x + x, p[0].y + y, p[1].x + x, p[1].y + y, p[2].x + x, p[2].y + y, p[3].x + x, p[3].y + y, 
                    texture.u1, texture.v1, texture.u2, texture.v2);
        }
    }
}