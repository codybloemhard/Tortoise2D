using System;

namespace Tortoise2D_v3.Math
{
    public class MathHelper
    {
        static Random r = new Random();

        public static float RAD_DEG = 57.2957795f;
        public static float DEG_RAD = 0.01745329f;
        /*
        public static bool RayBoxIntersection(CColliderAABB b, float px, float py, float qx, float qy)
        {
            double tx1 = (b.x - px) / (qx - px);
            double tx2 = (b.x + b.w - px) / 1 / (qx - px);

            double tmin = System.Math.Min(tx1, tx2);
            double tmax = System.Math.Max(tx1, tx2);

            double ty1 = (b.y - py) / (qy - py);
            double ty2 = (b.y + b.h - py) / (qy - py);

            tmin = System.Math.Max(tmin, System.Math.Min(ty1, ty2));
            tmax = System.Math.Min(tmax, System.Math.Max(ty1, ty2));

            return tmax >= tmin && tmax >= 0;
        }

        public static bool RayBoxIntersection(CColliderAABB b, float px, float py, float qx, float qy, ref float ix, ref float iy)
        {
            double tx1 = (b.x - px) / (qx - px);
            double tx2 = (b.x + b.w - px) / 1 / (qx - px);

            double tmin = System.Math.Min(tx1, tx2);
            double tmax = System.Math.Max(tx1, tx2);

            double ty1 = (b.y - py) / (qy - py);
            double ty2 = (b.y + b.h - py) / (qy - py);

            tmin = System.Math.Max(tmin, System.Math.Min(ty1, ty2));
            tmax = System.Math.Min(tmax, System.Math.Max(ty1, ty2));

            ix = (float)tmin * (qx - px) + px;
            iy = (float)tmin * (qy - py) + py;

            return tmax >= tmin && tmax >= 0;
        }
        */
        public static float clamp(float value, float min, float max)
        {
            return System.Math.Max(min, System.Math.Min(max, value));
        }
        public static void clamp(ref float value, ref float min, ref float max, out float returner)
        {
            returner = System.Math.Max(min, System.Math.Min(max, value));
        }
        public static float sin(float n)
        {
            return (float)System.Math.Sin(n);
        }
        public static float cos(float n)
        {
            return (float)System.Math.Cos(n);
        }
        public static float tan(float n)
        {
            return (float)System.Math.Tan(n);
        }
        public static float asin(float n)
        {
            return (float)System.Math.Asin(n);
        }
        public static float acos(float n)
        {
            return (float)System.Math.Acos(n);
        }
        public static float atan(float n)
        {
            return (float)System.Math.Atan(n);
        }

        public static float random()
        {
            return (float)r.NextDouble();
        }
    }
}
