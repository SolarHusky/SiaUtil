using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SiaUtil.Visualizers
{
    public class ProgressBar : MonoBehaviour
    {
        private Canvas _canvas;
        internal Image _loadingBackg;
        internal Image _loadingBar;

        private static readonly Vector3 Position = new Vector3(0, 0f, 0f);
        private static readonly Vector3 Rotation = new Vector3(0, 0, 0);
        private static readonly Vector3 Scale = new Vector3(0.01f, 0.01f, 0.01f);
        private static readonly Vector2 CanvasSize = new Vector2(100, 50);
        private static readonly Color BackgroundColor = new Color(0, 0, 0, 0.2f);

        public float Progress
        {
            get
            {
                return _loadingBar.fillAmount;
            }
            set
            {
                _loadingBar.fillAmount = value;
            }
        }

        public Color Color
        {
            get
            {
                return _loadingBar.color;
            }
            set => _loadingBar.color = value;
        }

        public float BackgroundOpacity
        {
            get => _loadingBackg.color.a;
            set => _loadingBackg.color = new Color(0, 0, 0, value);
        }


        /// <summary>
        /// Modified and easier version of the progress bar from SongCore
        /// </summary>
        /// <param name="size"></param>
        /// <param name="position"></param>
        /// <param name="glow"></param>
        /// <param name="parent"></param>
        /// <returns></returns>
        public static ProgressBar Create(Vector2 size, Vector3 position, bool glow = true, RectTransform parent = null)
        {
            var gameObject = new GameObject("Progress Bar");
            var probar = gameObject.AddComponent<ProgressBar>();

            gameObject.transform.position = Position;
            gameObject.transform.eulerAngles = Rotation;
            gameObject.transform.localScale = Scale;

            probar._canvas = gameObject.AddComponent<Canvas>();
            probar._canvas.renderMode = RenderMode.WorldSpace;
            probar._canvas.enabled = false;
            var rectTransform = probar._canvas.transform as RectTransform;
            rectTransform.sizeDelta = CanvasSize;

            probar._loadingBackg = new GameObject("Background").AddComponent<Image>();
            rectTransform = probar._loadingBackg.transform as RectTransform;
            rectTransform.SetParent(probar._canvas.transform, false);
            rectTransform.sizeDelta = size;
            probar._loadingBackg.color = BackgroundColor;

            probar._loadingBar = new GameObject("Loading Bar").AddComponent<Image>();
            rectTransform = probar._loadingBar.transform as RectTransform;
            rectTransform.SetParent(probar._canvas.transform, false);
            rectTransform.sizeDelta = size;
            var tex = Texture2D.whiteTexture;
            var sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), Vector2.one * 0.5f, 100, 1);
            probar._loadingBar.sprite = sprite;
            probar._loadingBar.type = Image.Type.Filled;
            probar._loadingBar.fillMethod = Image.FillMethod.Horizontal;
            probar._loadingBar.color = new Color(1, 1, 1, 0.5f);

            probar._loadingBar.enabled = true;
            probar._loadingBackg.enabled = true;
            probar._canvas.enabled = true;

            if (parent == null)
                gameObject.transform.position = position;

            if (glow == false)
                probar._loadingBar.material = Utilities.NoGlowMaterial;

            if (parent != null)
            {
                (gameObject.transform as RectTransform).anchorMin = new Vector2(0.5f, 0.5f);
                (gameObject.transform as RectTransform).anchorMax = new Vector2(0.5f, 0.5f);
                (gameObject.transform as RectTransform).anchoredPosition = new Vector2(0, 0);
                (gameObject.transform as RectTransform).sizeDelta = Vector2.one;
                gameObject.transform.parent = parent;
                gameObject.transform.localPosition = Vector2.zero;
            }

            return probar;
        }
    }
}
