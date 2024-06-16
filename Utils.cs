using System;
using System.IO;
using System.Reflection;
using UnityEngine;
using Winch.Core;

namespace CustomLoadingScreen
{
    public static class Utils
    {
        public static Texture2D GetTexture(string filename, TextureFormat format = TextureFormat.BC7)
		{
			string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Assets", filename + ".png");
			if (File.Exists(path))
            {
                byte[] data = File.ReadAllBytes(path);
                Texture2D tex = new Texture2D(4, 4, format, false);
                try
                {
                    tex.LoadImage(data);
                    return tex;
                }
                catch (UnityException ex)
                {
                    WinchCore.Log.Error(string.Format("Error on 'GetTexture' call. Texture cannot be loaded: {0}", (object)ex));
                }
            }
            else
                WinchCore.Log.Error("Error on 'GetTexture' call. File not found at: " + path);
            return (Texture2D)null;
        }

        public static Sprite GetSprite(string filename, TextureFormat format = TextureFormat.BC7)
        {
            Texture2D texture = Utils.GetTexture(filename, format);
            return Sprite.Create(texture, new Rect(0.0f, 0.0f, (float)texture.width, (float)texture.height), new Vector2(0.5f, 0.5f));
        }
    }
}
