using System;

namespace Tortoise2D_v3.Platform
{
    public class LayerManager
    {
        private LookupStrInt textures;
        private LookupStrInt widths;
        private LookupStrInt heights;
        private int MaxLayers;
        private Layer _layer;

        public LayerManager(int max)
        {
            MaxLayers = max;
            textures = new LookupStrInt(max);
            widths = new LookupStrInt(max);
            heights = new LookupStrInt(max);
            _layer = new Layer();
            _layer.set(0,0,0);
        }

        public Layer GetLayer(string layer)
        {
            _layer.set(textures.GetEntry(layer), widths.GetEntry(layer), heights.GetEntry(layer));
            return _layer;
        }

        public void AddLayer(string name, Layer layer)
        {
            textures.AddEntry(name, layer.t);
            widths.AddEntry(name, layer.w);
            heights.AddEntry(name, layer.h);
        }

    }

    public struct Layer
    {
        public int t;
        public int w;
        public int h;

        public Layer(int t, int w, int h)
        {
            this.t = t;
            this.w = w;
            this.h = h;
        }

        public void set(int t, int w, int h)
        {
            this.t = t;
            this.w = w;
            this.h = h;
        }
    }
}
