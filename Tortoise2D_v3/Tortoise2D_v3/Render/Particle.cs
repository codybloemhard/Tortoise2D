using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tortoise2D_v3.Platform;

namespace Tortoise2D_v3.Render
{
    public class Particle
    {
        public Tortoise2d game;
        public Texture t;
        public float x, y;
        public float w, h;
        public float vx, vy, ax, ay;
        public float growx, growy;
        public float r, g, b, a;
        public float cr, cg, cb, ca;
        public int time, tick;
        public bool alive;

        public Particle(Tortoise2d game, Texture t, float x, float y, float w, float h, float vx, float vy, float ax, float ay,
            float growx, float growy, float r, float g, float b, float a, float cr, float cg, float cb, float ca, int time)
        {
            this.game = game;
            this.t = t;
            this.x = x;
            this.y = y;
            this.w = w;
            this.h = h;
            this.vx = vx;
            this.vy = vy;
            this.ax = ax;
            this.ay = ay;
            this.growx = growx;
            this.growy = growy;
            this.r = r;
            this.g = g;
            this.b = b;
            this.a = a;
            this.cr = cr;
            this.cg = cg;
            this.cb = cb;
            this.ca = ca;
            this.time = time;
            tick = 0;
            alive = true;
        }

        public void Update()
        {
            if (alive)
            {
                if (tick > time)
                    alive = false;
                x += vx;
                y += vy;
                vx *= ax;
                vy *= ay;
                w *= growx;
                h *= growy;
                r *= cr;
                g *= cg;
                b *= cb;
                a *= ca;
                tick++;
            }
        }

        public void Render()
        {
            if(alive)
                game.renderer.AddSpriteTextureRGBA(t, x, y, w, h, r, g, b, a);
        }
    }
}
