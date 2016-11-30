using System;
using Tortoise2D_v3.Platform;

namespace Tortoise2D_v3.Render
{
    public class Camera
    {
        private float x, y, zoomx, zoomy;
        private Tortoise2d game;

        public Camera(Tortoise2d game,float x, float y)
        {
            this.game = game;
            this.x = x;
            this.y = y;
            zoomx = 1;
            zoomy = 1;
        }

        public void SetPositionLeftTop(float x, float y)
        {
            this.x = x;
            this.y = y;
        }
        public void SetPositionCenter(float x, float y)
        {
            this.x = x - game.grid.GetCellsX()/2;
            this.y = y - game.grid.GetCellsY()/2;
        }
        public void SetZoom(float zx, float zy)
        {
            this.zoomx = zx;
            this.zoomy = zy;
        }

        public float GetX()
        {
            return x;
        }
        public float GetY()
        {
            return y;
        }
        public float[] GetRect()
        {
            return new float[] { x, y, game.grid.GetCellsX() * zoomx, game.grid.GetCellsY() * zoomy};
        }
        public float GetZoomX()
        {
            return zoomx;
        }
        public float GetZoomY()
        {
            return zoomy;
        }

        public float GetXPixels()
        {
            return game.grid.TranslateGridScreenX(x);
        }
        public float GetYPixels()
        {
            return game.grid.TranslateGridScreenY(y);
        }
    }
}
