using System;

namespace Tortoise2D_v3.Math
{
    public class Grid
    {
        private float cellsX, cellsY;
        private float sizeX, sizeY;
        private int ww, wh;

        public Grid(float cellsx, float cellsy, int windoww, int windowh)
        {
            ww = windoww;
            wh = windowh;
            this.cellsX = cellsx;
            this.cellsY = cellsy;
            sizeX = ww / cellsx;
            sizeY = wh / cellsy;
        }

        public float TranslateGridScreenX(float x)
        {
            return x * sizeX;
        }
        public float TranslateGridScreenY(float y)
        {
            return y * sizeY;
        }

        public float TranslateScreenGridX(float x)
        {
            return x / sizeX;
        }
        public float TranslateScreenGridY(float y)
        {
            return y / sizeY;
        }

        public float GetCellsX()
        {
            return cellsX;
        }
        public float GetCellsY()
        {
            return cellsY;
        }
        public float GetCellSizeX()
        {
            return sizeX;
        }
        public float GetCellSizeY()
        {
            return sizeY;
        }
    }
}
