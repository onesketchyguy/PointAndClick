using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Utility.Tools
{
    public class SpriteProcessor : AssetPostprocessor
    {
        private void OnPostprocessTexture(Texture2D texture)
        {
            var spriteScales = new Dictionary<string, byte>();
            spriteScales.Add("64", 64);
            spriteScales.Add("32", 32);
            spriteScales.Add("12", 12);
            spriteScales.Add("8", 8);

            //Convert the asset directory to lowercase for easier reading.
            string lowerCaseAssetPath = assetPath.ToLower();

            foreach (var item in spriteScales)
            {
                //Find the sprites folder. If I can't find it it will return -1.
                bool isInSpritesDirectory = lowerCaseAssetPath.IndexOf($"/sprites/{item.Key}/") != -1;

                //Follow the sprite in the directory.
                if (isInSpritesDirectory)
                {
                    TextureImporter textureImporter = (TextureImporter)assetImporter;

                    textureImporter.textureCompression = TextureImporterCompression.Uncompressed;

                    textureImporter.textureType = TextureImporterType.Sprite;
                    textureImporter.filterMode = FilterMode.Point;
                    textureImporter.spritePixelsPerUnit = item.Value;
                }
            }
        }
    }
}