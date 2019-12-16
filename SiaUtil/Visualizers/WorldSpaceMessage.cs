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
        public TextMeshPro _messagePrompt;

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
            wsmgo.transform.position = position;
            wsm._messagePrompt = Utilities.Extensions.CreateWorldText(wsmgo.transform, text);
            wsm._messagePrompt.fontSize = fontSize;

            return wsm;
        }
    }
}
