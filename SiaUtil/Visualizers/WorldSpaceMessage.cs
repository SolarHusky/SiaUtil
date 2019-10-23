using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace SiaUtil.Visualizers
{
    public class WorldSpaceMessage : MonoBehaviour
    {
        Canvas _canvas;
        public TextMeshProUGUI _messagePrompt;

        public float Font
        {
            get => _messagePrompt.fontSize;
            set => _messagePrompt.fontSize = value;
        }

        public Color Color
        {
            get => _messagePrompt.color;
            set => _messagePrompt.color = value;
        }

        public string Text
        {
            get => _messagePrompt.text;
            set => _messagePrompt.text = value;
        }

        public static WorldSpaceMessage Create(string text, Vector3 position, float fontSize = 10f)
        {
            var wsmgo = new GameObject("SiaUtilWorldSpaceMessage");
            var wsm = wsmgo.AddComponent<WorldSpaceMessage>();
            wsmgo.transform.localScale = new Vector3(0.025f, 0.025f, 0.025f);
            wsm._canvas = wsmgo.AddComponent<Canvas>();
            wsm._canvas.renderMode = RenderMode.WorldSpace;
            wsm._canvas.enabled = false;
            var rectTransform = wsm._canvas.transform as RectTransform;
            rectTransform.sizeDelta = new Vector2(100, 50);

            wsm._messagePrompt = Utilities.CreateText(rectTransform, text, new Vector2(0, 10));
            rectTransform = wsm._messagePrompt.transform as RectTransform;
            rectTransform.SetParent(wsm._canvas.transform, false);
            rectTransform.sizeDelta = new Vector2(100, 20);
            wsm._messagePrompt.fontSize = fontSize;
            wsm._canvas.enabled = true;

            wsmgo.transform.position = position;
            return wsm;
        }
    }
}
