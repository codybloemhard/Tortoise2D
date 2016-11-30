using System;
/*
using Tortoise2D_v3.Platform;

namespace Tortoise2D_v3.Render
{
    public class CRender : Component
    {
        private CTransform trans;
        private Texture t;
        private float ox = 0, oy = 0;
        private bool colors = false;
        private float r, g, b, a;
        private bool points = false;

        public CRender(GameObject parent, CTransform trans, Texture t, bool useMatrices = false) : base(parent)
        {
            this.trans = trans;
            tortoiseID = 02;
            this.t = t;
            points = useMatrices;
        }

        public CRender(GameObject parent, CTransform trans, Texture t, float r, float g, float b, float a, bool p = false) : base(parent)
        {
            this.trans = trans;
            this.r = r;
            this.g = g;
            this.b = b;
            this.a = a;
            tortoiseID = 02;
            this.t = t;
            points = p;
        }
        public CRender(GameObject parent, CTransform trans, Texture t, float offx, float offy, bool p = false) : base(parent)
        {
            this.trans = trans;
            ox = offx;
            oy = offy;
            tortoiseID = 02;
            this.t = t;
            points = p;
        }
        public CRender(GameObject parent, CTransform trans, Texture t, float offx, float offy,
                                                            float r, float g, float b, float a, bool p = false) : base(parent)
        {
            this.trans = trans;
            ox = offx;
            oy = offy;
            this.r = r;
            this.g = g;
            this.b = b;
            this.a = a;
            colors = true;
            tortoiseID = 02;
            this.t = t;
            points = p;
        }

        public void SetColor(float r, float g, float b, float a)
        {
            this.r = r;
            this.g = g;
            this.b = b;
            this.a = a;
        }

        public override void Update()
        {
            if (!points)
            {
                if (!colors)
                    References.renderer.AddSpriteUV(trans.pos.x + ox, trans.pos.y + oy, trans.w, trans.h,
                                                           t.u1, t.v1, t.u2, t.v2);
                else
                    References.renderer.AddSpriteUVRGBA(trans.pos.x + ox, trans.pos.y + oy, trans.w, trans.h,
                                                                             t.u1, t.v1, t.u2, t.v2, r, g, b, a);
            }
            else
            {
                if (!colors)
                    References.renderer.AddPointsUV(trans.GetPoint(0).x + trans.pos.x + ox, trans.GetPoint(0).y + trans.pos.y + oy,
                                                                trans.GetPoint(1).x + trans.pos.x + ox, trans.GetPoint(1).y + trans.pos.y + oy,
                                                                trans.GetPoint(2).x + trans.pos.x + ox, trans.GetPoint(2).y + trans.pos.y + oy,
                                                                trans.GetPoint(3).x + trans.pos.x + ox, trans.GetPoint(3).y + trans.pos.y + oy,
                                                           t.u1, t.v1, t.u2, t.v2);
                else
                    References.renderer.AddPointsUVRGBA(trans.GetPoint(0).x + trans.pos.x + ox, trans.GetPoint(0).y + trans.pos.y + oy,
                                                                trans.GetPoint(1).x + trans.pos.x + ox, trans.GetPoint(1).y + trans.pos.y + oy,
                                                                trans.GetPoint(2).x + trans.pos.x + ox, trans.GetPoint(2).y + trans.pos.y + oy,
                                                                trans.GetPoint(3).x + trans.pos.x + ox, trans.GetPoint(3).y + trans.pos.y + oy,
                                                                             t.u1, t.v1, t.u2, t.v2, r, g, b, a);
            }
        }

    }
}
*/