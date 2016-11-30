using System;

namespace Tortoise2D_v3.Math
{
    public class Matrix2
    {
        public float[,] elements;

        public Matrix2()
        {
            elements = new float[2,2];
        }

        public void SetAll(float a)
        {
            elements[0, 0] = a;
            elements[0, 1] = a;
            elements[1, 0] = a;
            elements[1, 1] = a;
        }
        public void SetRandom(float min, float max)
        {
            elements[0, 0] = (MathHelper.random() % (max - min)) + min;
            elements[0, 1] = (MathHelper.random() % (max - min)) + min;
            elements[1, 0] = (MathHelper.random() % (max - min)) + min;
            elements[1, 1] = (MathHelper.random() % (max - min)) + min;
        }
        public void SetRotation(float rad)
        {
            float cos = MathHelper.cos(rad);
            float sin = MathHelper.sin(rad);

            elements[0, 0] = cos;
            elements[0, 1] = -sin;
            elements[1, 1] = cos;
            elements[1, 0] = sin;
        }
        public void SetScale(float sx, float sy)
        {
            elements[0, 0] = sx;
            elements[0, 1] = 0;
            elements[1, 1] = sy;
            elements[1, 0] = 0;
        }
        public void SetScale(float s)
        {
            elements[0, 0] = s;
            elements[0, 1] = 0;
            elements[1, 1] = s;
            elements[1, 0] = 0;
        }
        public void SetShear(float x, float y)
        {
            elements[0, 0] = 1;
            elements[0, 1] = x;
            elements[1, 1] = 1;
            elements[1, 0] = y;
        }

        public bool IsEqual(Matrix2 other)
        {
            if (elements[0, 0] != other.elements[0, 0])
                return false;
            if (elements[0, 1] != other.elements[0, 1])
                return false;
            if (elements[1, 0] != other.elements[1, 0])
                return false;
            if (elements[1, 1] != other.elements[1, 1])
                return false;
            return true;
        }
        public void AddMatrix2(Matrix2 other)
        {
            elements[0, 0] += other.elements[0, 0];
            elements[0, 1] += other.elements[0, 1];
            elements[1, 0] += other.elements[1, 0];
            elements[0, 1] += other.elements[1, 1];
        }
        public void SubtractMatrix2(Matrix2 other)
        {
            elements[0, 0] -= other.elements[0, 0];
            elements[0, 1] -= other.elements[0, 1];
            elements[1, 0] -= other.elements[1, 0];
            elements[0, 1] -= other.elements[1, 1];
        }
        public void MulScalar(float s)
        {
            elements[0, 0] *= s;
            elements[0, 1] *= s;
            elements[1, 0] *= s;
            elements[0, 1] *= s;
        }
        public void MulMatrix2(Matrix2 other)
        {
            Matrix2 temp = new Matrix2();

            temp.elements[0, 0] = (elements[0, 0] * other.elements[0, 0]) + (elements[1, 0] * other.elements[0, 1]);
            temp.elements[1, 0] = (elements[0, 0] * other.elements[0, 1]) + (elements[1, 0] * other.elements[1, 1]);
            temp.elements[0, 1] = (elements[0, 1] * other.elements[0, 0]) + (elements[1, 1] * other.elements[0, 1]);
            temp.elements[1, 1] = (elements[0, 1] * other.elements[1, 0]) + (elements[1, 1] * other.elements[1, 1]);

            elements = temp.elements;
        }

        public void PrintMatrix2()
        {
            Console.WriteLine("    | " + elements[0, 0] + " , " + elements[0, 1] + " | ");
            Console.WriteLine("    | " + elements[1, 0] + " , " + elements[1, 1] + " | \n");
        }
    }
}