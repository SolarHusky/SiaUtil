using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace SiaUtil.Visualizers
{
    public class WorldSpaceRadial : MonoBehaviour
    {
        private Image _radialImage;
        private GameObject _radial;

        public void Create()
        {
            Canvas canvas = gameObject.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.WorldSpace;
            CanvasScaler canvasScaler = gameObject.AddComponent<CanvasScaler>();
            canvasScaler.scaleFactor = 10.0f;
            canvasScaler.dynamicPixelsPerUnit = 10f;
            gameObject.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 1f);
            gameObject.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 1f);

            _radial = new GameObject();
            _radialImage = _radial.AddComponent<Image>();
            _radial.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 2f);
            _radial.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 2f);
            _radial.transform.localScale = new Vector3(4, 4, 4);
            _radial.transform.localPosition = Vector3.zero;

            _radialImage.sprite = Plugin.RadialIcon();
            _radialImage.type = Image.Type.Filled;
            _radialImage.fillMethod = Image.FillMethod.Radial360;
            _radialImage.fillOrigin = (int)Image.Origin360.Top;
            _radialImage.fillClockwise = true;
            _radialImage.transform.localEulerAngles = new Vector3(0f, 0f, 0f);

        }

    }
}
