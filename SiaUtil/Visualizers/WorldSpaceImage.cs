using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace SiaUtil.Visualizers
{
    public class WorldSpaceImage : MonoBehaviour
    {
        private Image _panel;
        private Canvas _imageCanvas;

        public float Opacity
        {
            get
            {
                return _panel.material.color.a;
            }
            set => _panel.material.color = new Color(1, 1, 1, value);
        }



        public static WorldSpaceImage Create()
        {
            var wsig = new GameObject("SiaUtil World Space Image");
            var wsi = wsig.AddComponent<WorldSpaceImage>();

            wsig.transform.position = new Vector3(0f, 0f, 0f);
            wsig.transform.eulerAngles = new Vector3(0f, 0f, 0f);
            wsig.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
            wsi._imageCanvas = wsig.AddComponent<Canvas>();
            wsi._imageCanvas.renderMode = RenderMode.WorldSpace;

            var rectTransform = wsi._imageCanvas.transform as RectTransform;
            rectTransform.sizeDelta = new Vector2(100, 50);

            wsi._panel = new GameObject("Image").AddComponent<Image>();
            wsi._panel.material = new Material(CustomUI.Utilities.UIUtilities.NoGlowMaterial);
            wsi._panel.rectTransform.SetParent(wsi._imageCanvas.transform, false);
            wsi._panel.rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
            wsi._panel.rectTransform.anchorMax = new Vector2(0.5f, 0.5f);
            wsi._panel.rectTransform.anchoredPosition = new Vector2(4.5f, 4.5f);
            wsi._panel.rectTransform.sizeDelta = new Vector2(15f, 15f);
            wsi._panel.rectTransform.position = new Vector3(0f, 0f, 0f);
            wsi._panel.sprite = CustomUI.Utilities.UIUtilities.BlankSprite;

            wsi._panel.material.color = new Color(1, 1, 1, 1);
            wsi._panel.material.renderQueue = 4000;

            return wsi;
        }

        public void EnableWorldSpaceImage(Sprite sprite)
        {
            _panel.sprite = sprite;
            _panel.sprite.texture.wrapMode = TextureWrapMode.Clamp;
        }

        public void DisableWorldSpaceImage()
        {
            _panel.sprite = CustomUI.Utilities.UIUtilities.BlankSprite;
        }

        public void DestroyImager()
        {

            Destroy(_panel);
            Destroy(_imageCanvas);
            Destroy(this);
        }
    }
}
