using System;
using Tortoise2D_v3.Platform;
/*
namespace Tortoise2D_v3.Render
{
    public class CAnimation : Component
    {
        private CTransform trans;
        private Texture t;
        private float ox = 0, oy = 0;
        private bool colors = false;
        private float r, g, b, a;

        private int framesx, framesy, count, maxcount, rate, i;

        public CAnimation(GameObject parent, CTransform trans, Texture t, int fx, int fy, int rate) : base(parent)
        {
            this.trans = trans;
            tortoiseID = 03;
            this.t = t;
            this.framesx = fx;
            this.framesy = fy;
            this.rate = rate;
            maxcount = fx * fy;
        }

        public void SetColor(float r, float g, float b, float a)
        {
            if(r == 1 && g == 1 && b == 1 && a == 1)
            {
                this.r = 1;
                this.g = 1;
                this.b = 1;
                this.a = 1;
                this.colors = false;
            }
            else
            {
                this.r = r;
                this.g = g;
                this.b = b;
                this.a = a;
                colors = true;
            }
        }

        public void SetFrameRate(int framerate)
        {
            rate = framerate;
        }

        public override void Update()
        {
            i++;
            if (i >= rate - 1)
            {
                count++;
                i = 0;
            }
            if (count >= maxcount)
            {
                count = 0;
            }

            float anim_u1 = (count % framesx) * (1f / framesx);
            float anim_v1 = (count / framesx) * (1f / framesy);

            float anim_u2 = anim_u1 + (1f / framesx);
            float anim_v2 = anim_v1 + (1f / framesy);

            float relativesizex = System.Math.Abs(t.u1 - t.u2);
            float relativesizey = System.Math.Abs(t.v1 - t.v2);

            float u1 = relativesizex * (anim_u1) + t.u1;
            float v1 = relativesizey * (anim_v1) + t.v1;
            float u2 = relativesizex * (anim_u2) + t.u1;
            float v2 = relativesizey * (anim_v2) + t.v1;

            if (!colors)
                References.renderer.AddSpriteUV(trans.pos.x + ox, trans.pos.y + oy, trans.w, trans.h,
                                                           u1, v1, u2, v2);
            else
                References.renderer.AddSpriteUVRGBA(trans.pos.x + ox, trans.pos.y + oy, trans.w, trans.h,
                                                                         u1, v1, u2, v2, r, g, b, a);
        }
    }
}
*/