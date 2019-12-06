using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

namespace SiaUtil
{
    public class Utilities
    {
        public static class Extensions
        {
            //Andruzzzhka is literally the best
            private static Shader _customTextShader;
            public static Shader CustomTextShader
            {
                get
                {
                    if (_customTextShader == null)
                    {
                        AssetBundle assetBundle = AssetBundle.LoadFromStream(Assembly.GetCallingAssembly().GetManifestResourceStream("SiaUtil.Assets.Shader.asset"));
                        _customTextShader = assetBundle.LoadAsset<Shader>("Assets/TextMesh Pro/Resources/Shaders/TMP_SDF_ZeroAlphaWrite_ZWrite.shader");
                    }
                    return _customTextShader;
                }
            }
        }

        public class LoadScripts
        {
            public static IEnumerator LoadTextureCoroutine(string spritePath, Action<Texture2D> done)
            {
                Texture2D tex;


                using (UnityWebRequest www = UnityWebRequestTexture.GetTexture(spritePath))
                {
                    yield return www.SendWebRequest();
                    if (www.isHttpError || www.isNetworkError)
                    {
                        Logger.log.Error("Connection Error!");
                    }
                    else
                    {
                        tex = DownloadHandlerTexture.GetContent(www);
                        tex.wrapMode = TextureWrapMode.Clamp;
                        yield return new WaitForSeconds(.05f);
                        done?.Invoke(tex);
                    }
                }
                
                
            }
        }

        public static TextMeshProUGUI CreateText(RectTransform parent, string text, Vector2 anchoredPosition)
        {
            return CreateText(parent, text, anchoredPosition, new Vector2(60f, 10f));
        }

        public static TextMeshProUGUI CreateText(RectTransform parent, string text, Vector2 anchoredPosition, Vector2 sizeDelta)
        {
            GameObject gameObj = new GameObject("SiaUtilUIText");
            gameObj.SetActive(false);

            TextMeshProUGUI textMesh = gameObj.AddComponent<TextMeshProUGUI>();
            TMP_FontAsset font = UnityEngine.Object.Instantiate(Resources.FindObjectsOfTypeAll<TMP_FontAsset>().First(t => t.name == "Teko-Medium SDF No Glow"));
            textMesh.font = font;
            textMesh.rectTransform.SetParent(parent, false);
            textMesh.text = text;
            textMesh.fontSize = 4;
            textMesh.color = Color.white;

            textMesh.rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
            textMesh.rectTransform.anchorMax = new Vector2(0.5f, 0.5f);
            textMesh.rectTransform.sizeDelta = sizeDelta;
            textMesh.rectTransform.anchoredPosition = anchoredPosition;
            textMesh.material.shader = Extensions.CustomTextShader;

            gameObj.SetActive(true);
            return textMesh;
        }

        public static TextMeshPro CreateWorldText(Transform parent, string text = "TEXT")
        {
            GameObject textMeshGO = new GameObject("SiaUtilText");

            textMeshGO.SetActive(false);

            TextMeshPro textMesh = textMeshGO.AddComponent<TextMeshPro>();
            TMP_FontAsset font = UnityEngine.Object.Instantiate(Resources.FindObjectsOfTypeAll<TMP_FontAsset>().First(x => x.name == "Teko-Medium SDF No Glow"));
            textMesh.renderer.sharedMaterial = font.material;
            textMesh.fontSharedMaterial = font.material;
            textMesh.font = font;

            textMesh.transform.SetParent(parent, true);
            textMesh.text = text;
            textMesh.fontSize = 5f;
            textMesh.color = Color.white;
            textMesh.renderer.material.shader = Extensions.CustomTextShader;

            textMesh.gameObject.SetActive(true);

            return textMesh;
        }

        private static Material _noGlowMaterial = null;
        public static Material NoGlowMaterial
        {
            get
            {
                if (!_noGlowMaterial)
                    _noGlowMaterial = new Material(Resources.FindObjectsOfTypeAll<Material>().First(m => m.name == "UINoGlow"));
                return _noGlowMaterial;
            }
        }

        private static Sprite _blankSprite = null;
        public static Sprite BlankSprite
        {
            get
            {
                if (!_blankSprite)
                    _blankSprite = Sprite.Create(Texture2D.blackTexture, new Rect(), Vector2.zero);
                return _blankSprite;
            }
        }

        public static Sprite LoadSpriteFromResources(string resourcePath, float PixelsPerUnit = 100.0f)
        {
            return LoadSpriteRaw(GetResource(Assembly.GetCallingAssembly(), resourcePath), PixelsPerUnit);
        }

        public static Sprite LoadSpriteRaw(byte[] image, float PixelsPerUnit = 100.0f)
        {
            return LoadSpriteFromTexture(LoadTextureRaw(image), PixelsPerUnit);
        }

        public static byte[] GetResource(Assembly asm, string ResourceName)
        {
            System.IO.Stream stream = asm.GetManifestResourceStream(ResourceName);
            byte[] data = new byte[stream.Length];
            stream.Read(data, 0, (int)stream.Length);
            return data;
        }

        public static Sprite LoadSpriteFromTexture(Texture2D SpriteTexture, float PixelsPerUnit = 100.0f)
        {
            if (SpriteTexture)
                return Sprite.Create(SpriteTexture, new Rect(0, 0, SpriteTexture.width, SpriteTexture.height), new Vector2(0, 0), PixelsPerUnit);
            return null;
        }

        public static Texture2D LoadTextureRaw(byte[] file)
        {
            if (file.Count() > 0)
            {
                Texture2D Tex2D = new Texture2D(2, 2);
                if (Tex2D.LoadImage(file))
                    return Tex2D;
            }
            return null;
        }
    }
}
