using System;

namespace Tortoise2D_v3.Math
{
    public class Vector2
    {
        public float x, y;

        public Vector2()
        {
            x = y = 0;
        }
        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }
        public void Set(float x, float y)
        {
            this.x = x;
            this.y = y;
        }
        
        public bool GetEqual(Vector2 v)
        {
            if (v.x != x)
                return false;
            if (v.y != y)
                return false;
            return true;
        }

        public void Add(Vector2 v)
        {
            x += v.x;
            y += v.y;
        }
        public void Subtract(Vector2 v)
        {
            x -= v.x;
            y -= v.y;
        }
        public void Add(float x, float y)
        {
            this.x += x;
            this.y += y;
        }
        public void Subtract(float x, float y)
        {
            this.x -= x;
            this.y -= y;
        }
        public void MultiplyElements(Vector2 v)
        {
            x *= v.x;
            y *= v.y;
        }
        public void MultiplyElements(float x, float y)
        {
            x *= x;
            y *= y;
        }
        public void DivideElements(Vector2 v)
        {
            if (v.x != 0)
                x /= v.x;
            else
                x = 0;
            if (v.y != 0)
                y /= v.y;
            else
                y = 0;
        }
        public void DivideElements(float xx, float yy)
        {
            if (xx != 0)
                x /= xx;
            else
                x = 0;
            if (yy != 0)
                y /= yy;
            else
                y = 0;
        }

        public void MulScalar(float s)
        {
            x *= s;
            y *= s;
        }
        public void Normalize()
        {
            float mag = (float)System.Math.Sqrt(x * x + y * y);
            x /= mag;
            y /= mag;
        }
        public void NormalizeSafe()
        {
            float mag = (float)System.Math.Sqrt(x * x + y * y);
            if(x != 0)
                x /= mag;
            if(y != 0)
                y /= mag;
        }

        public Vector2 GetNormalized()
        {
            float mag = (float)System.Math.Sqrt(x * x + y * y);
            return new Vector2(x/mag,y/mag);
        }
        public float GetMagnitude()
        {
            return (float)System.Math.Sqrt(x * x + y * y);
        }
        public float GetSqrMagnitude()
        {
            return (float)(x * x + y * y);
        }

        public float DotProduct(Vector2 v)
        {
            return (x * v.x) + (y * v.y);
        }
        public float CrossProduct(Vector2 v)
        {
            return (x*v.y) - (y*v.x);
        }

        public void MulMatrix2(Matrix2 m)
        {
            float xx = x;
            float yy = y;

            x = (m.elements[0, 0] * xx) + (m.elements[0, 1] * yy);
            y = (m.elements[1, 0] * xx) + (m.elements[1, 1] * yy);
        }

        public static void Normalize(Vector2 a, out Vector2 b)
        {
            float mag = (float)System.Math.Sqrt(a.x * a.x + a.y * a.y);
            b =  new Vector2(a.x / mag, a.y / mag);
        }
    }
}
