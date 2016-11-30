using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tortoise2D_v3.Platform;

namespace Tortoise2D_v3.Render
{
    public class ParticleSystem
    {
        public bool doEmit = true;
        private Texture t;
        private Tortoise2d game;
        private int size, rate, count = 0;
        private Particle[] parts;
        private float x, y;
        private float minX, maxX, minY, maxY, minW, maxW, minH, maxH, minGW, maxGW, minGH, maxGH, minVX, maxVX, minVY, maxVY, minAX, maxAX, minAY, maxAY, minR, maxR, minG, maxG, minB, maxB, minA, maxA,
            minCR, maxCR, minCG, maxCG, minCB, maxCB, minCA, maxCA, minT, maxT;
        
        public ParticleSystem(Tortoise2d game, Texture t, int size)
        {
            this.size = size;
            this.game = game;
            this.t = t;

            parts = new Particle[size];
            for(int i = 0; i < parts.Length; i++)
            {
                parts[i] = new Particle(game, t, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0);
                parts[i].alive = false;
            }
        }
        public void SetSystem(float x, float y, int rate)
        {
            this.x = x;
            this.y = y;
            this.rate = rate;
        }

        public void SetPositions(float minX, float maxX, float minY, float maxY)
        {
            this.minX = minX;
            this.maxX = maxX;
            this.minY = minY;
            this.maxY = maxY;
        }

        public void SetSizes(float minW, float maxW, float minH, float maxH, float minGW, float maxGW, float minGH, float maxGH)
        {
            this.minW = minW;
            this.maxW = maxW;
            this.minH = minH;
            this.maxH = maxH;
            this.minGW = minGW;
            this.maxGW = maxGW;
            this.minGH = minGH;
            this.maxGH = maxGH;
        }
        public void SetSizes(float minWH, float maxWH, float minC, float maxC)
        {
            this.minW = minWH;
            this.maxW = minWH;
            this.minH = minWH;
            this.maxH = minWH;
            this.minGW = minC;
            this.maxGW = minC;
            this.minGH = minC;
            this.maxGH = minC;
        }

        public void SetSpeeds(float minVX, float maxVX, float minVY, float maxVY, float minAX, float maxAX, float minAY, float maxAY)
        {
            this.minVX = minVX;
            this.maxVX = maxVX;
            this.minVY = minVY;
            this.maxVY = maxVY;
            this.minAX = minAX;
            this.maxAX = maxAX;
            this.minAY = minAY;
            this.maxAY = maxAY;
        }

        public void SetColors(float minR, float maxR, float minG, float maxG, float minB, float maxB, float minA, float maxA,
            float minCR, float maxCR, float minCG, float maxCG, float minCB, float maxCB, float minCA, float maxCA)
        {
            this.minR = minR;
            this.maxR = maxR;
            this.minG = minG;
            this.maxG = maxG;
            this.minB = minB;
            this.maxB = maxB;
            this.minA = minA;
            this.maxA = maxA;
            this.minCR = minCR;
            this.maxCR = maxCR;
            this.minCG = minCG;
            this.maxCG = maxCG;
            this.minCB = minCB;
            this.maxCB = maxCB;
            this.minCA = minCA;
            this.maxCA = maxCA;
        }

        public void SetTimes(int minTicks, int maxTicks)
        {
            minT = minTicks;
            maxT = maxTicks;
        }

        public void Init()
        {
            for(int i = 0; i < parts.Length; i++)
            {
                init(i);
            }
        }

        private void init(int i)
        {
            float X = (float)game.random.NextDouble() * (maxX - minX) + minX + x;
            float Y = (float)game.random.NextDouble() * (maxY - minY) + minY + y;
            float W = (float)game.random.NextDouble() * (maxW - minW) + minW;
            float H = (float)game.random.NextDouble() * (maxH - minH) + minH;
            float GW = (float)game.random.NextDouble() * (maxGW - minGW) + minGW;
            float GH = (float)game.random.NextDouble() * (maxGH - minGH) + minGH;
            float VX = (float)game.random.NextDouble() * (maxVX - minVX) + minVX;
            float VY = (float)game.random.NextDouble() * (maxVY - minVY) + minVY;
            float AX = (float)game.random.NextDouble() * (maxAX - minAX) + minAX;
            float AY = (float)game.random.NextDouble() * (maxAY - minAY) + minAY;
            float R = (float)game.random.NextDouble() * (maxR - minR) + minR;
            float G = (float)game.random.NextDouble() * (maxG - minG) + minG;
            float B = (float)game.random.NextDouble() * (maxB - minB) + minB;
            float A = (float)game.random.NextDouble() * (maxA - minA) + minA;
            float CR = (float)game.random.NextDouble() * (maxCR - minCR) + minCR;
            float CG = (float)game.random.NextDouble() * (maxCG - minCG) + minCG;
            float CB = (float)game.random.NextDouble() * (maxCB - minCB) + minCB;
            float CA = (float)game.random.NextDouble() * (maxCA - minCA) + minCA;
            int T = (int)((float)game.random.NextDouble() * (maxT - minT) + minT);
            parts[i].x = X;
            parts[i].y = Y;
            parts[i].w = W;
            parts[i].h = H;
            parts[i].growx = GW;
            parts[i].growy = GH;
            parts[i].vx = VX;
            parts[i].vy = VY;
            parts[i].ax = AX;
            parts[i].ay = AY;
            parts[i].r = R;
            parts[i].g = G;
            parts[i].b = B;
            parts[i].a = A;
            parts[i].cr = CR;
            parts[i].cg = CG;
            parts[i].cb = CB;
            parts[i].ca = CA;
            parts[i].time = T;
            parts[i].tick = 0;
            parts[i].alive = true;
        }

        public void Update()
        {
            if(doEmit)
                emit();

            for (int i = 0; i < parts.Length; i++)
                parts[i].Update();
        }

        private void emit()
        {
            for (int i = 0; i < rate; i++)
            {
                init(count + i);
            }
            count += rate;

            if (count > size - rate * 2)
                count = 0;
        }

        public void emit(int newrate)
        {
            newrate = System.Math.Min(size - count - 10, newrate);
            for (int i = 0; i < newrate; i++)
            {
                init(count + i);
            }
            count += rate;

            if (count > size - newrate * 2)
                count = 0;
        }

        public void Render()
        {
            for (int i = 0; i < parts.Length; i++)
                parts[i].Render();
        }
    }
}
