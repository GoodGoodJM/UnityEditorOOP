using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace GGM.Editor.UI
{
    public static class BackgroundTextureHelper
    {
        private static Dictionary<Color, Texture2D> ColorTextureMap = new Dictionary<Color, Texture2D>();

        public static Texture2D GetColorTexture(Color color)
        {
            Texture2D texture;
            if (ColorTextureMap.ContainsKey(color))
                texture = ColorTextureMap[color];
            else
            {
                texture = MakeTex(32, 32, color);
                ColorTextureMap[color] = texture;
            }

            return texture;
        }

        //From: https://forum.unity3d.com/threads/giving-unitygui-elements-a-background-color.20510/#post-430604
        public static Texture2D MakeTex(int width, int height, Color color)
        {
            Color[] pix = new Color[width * height];

            for (int i = 0; i < pix.Length; i++)
                pix[i] = color;

            Texture2D result = new Texture2D(width, height);
            result.SetPixels(pix);
            result.Apply();

            return result;
        }
    }
}
