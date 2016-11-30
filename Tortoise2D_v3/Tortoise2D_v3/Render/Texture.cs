using System;

namespace Tortoise2D_v3.Render
{
    public struct Texture
    {
        public int texture;
        public float u1, v1, u2, v2;

        public Texture(int texture, float u1, float v1, float u2, float v2)
        {
            this.texture = texture;
            this.u1 = u1;
            this.v1 = v1;
            this.u2 = u2;
            this.v2 = v2;
        }
    }
}