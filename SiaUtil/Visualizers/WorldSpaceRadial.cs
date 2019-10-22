using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SiaUtil.Visualizers
{
    public class WorldSpaceRadial : MonoBehaviour
    {
        public string Text
        {
            get
            {
                return _text.text;
            }
            set
            {
                _text.text = value;
            }
        }

        public float Progress
        {
            get
            {
                return _radialImage.fillAmount;
            }
            set
            {
                _radialImage.fillAmount = value;
            }
        }

        private TextMeshProUGUI _text;
        private Image _radialImage;
        private GameObject _radial;

        public static WorldSpaceRadial Create(RectTransform parent = null, Sprite customRadialImage = null, bool radialGlow = true, bool clockWise = true, Image.Origin360 fillOrigin = Image.Origin360.Top)
        {
            Sprite spr;

            if (customRadialImage == null)
                spr = Plugin.RadialIcon();
            else
                spr = customRadialImage;

            var wsrg = new GameObject("SiaUtil World Space Radial");
            var wsg = wsrg.AddComponent<WorldSpaceRadial>();
            
            Canvas canvas = wsrg.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.WorldSpace;
            CanvasScaler canvasScaler = wsrg.AddComponent<CanvasScaler>();
            canvasScaler.scaleFactor = 10.0f;
            canvasScaler.dynamicPixelsPerUnit = 10f;
            _ = wsrg.AddComponent<GraphicRaycaster>();
            wsrg.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 1f);
            wsrg.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 1f);

            wsg._text = Utilities.CreateText(canvas.transform as RectTransform, "", Vector2.zero);
            wsg._text.alignment = TextAlignmentOptions.Center;
            wsg._text.transform.localScale *= .12f;
            wsg._text.fontSize = 2.5f;
            wsg._text.color = Color.white;
            wsg._text.lineSpacing = -25f;
            wsg._text.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 1f);
            wsg._text.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 1f);
            wsg._text.enableWordWrapping = false;
            wsg._text.transform.localPosition = new Vector3(0f, 0f, 0f);
            wsg.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
            wsg._text.text = "";

            wsg._radial = new GameObject();
            wsg._radialImage = wsg._radial.AddComponent<Image>();
            wsg._radial.transform.SetParent(wsg._text.transform);
            wsg._radial.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 2f);
            wsg._radial.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 2f);
            wsg._radial.transform.localScale = new Vector3(4, 4, 4);
            wsg._radial.transform.localPosition = Vector3.zero;

            wsg._radialImage.sprite = spr;
            if (radialGlow == false)
                wsg._radialImage.material = new Material(Utilities.NoGlowMaterial);
            wsg._radialImage.type = Image.Type.Filled;
            wsg._radialImage.fillMethod = Image.FillMethod.Radial360;
            wsg._radialImage.fillOrigin = (int)fillOrigin;
            wsg._radialImage.fillClockwise = clockWise;
            wsg._radialImage.transform.localEulerAngles = new Vector3(0f, 0f, 0f);

            wsg._radialImage.fillAmount = 0f;

            if (parent != null)
            {
                (wsrg.transform as RectTransform).anchorMin = new Vector2(0.5f, 0.5f);
                (wsrg.transform as RectTransform).anchorMax = new Vector2(0.5f, 0.5f);
                (wsrg.transform as RectTransform).anchoredPosition = new Vector2(0, 0);
                (wsrg.transform as RectTransform).sizeDelta = Vector2.one;
                wsrg.transform.parent = parent;
                wsg.transform.localPosition = Vector2.zero;
            }
            return wsg;
        }

    }
}
