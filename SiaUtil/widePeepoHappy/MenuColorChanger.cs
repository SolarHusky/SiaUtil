using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SiaUtil.widePeepoHappy
{
    public class MenuColorChanger : PersistentSingleton<MenuColorChanger>
    {
        public bool CanBeModified { get; internal set; } = false;

        public void SetColor(Color color)
        {
            if (CanBeModified)
            {
                UpdateLights(color);
            }
        }
        public void SetColorOvertime(Color color, float time)
        {
            StartCoroutine(ChangeColor(MenuLightsSO().CurrentColorForID(0), color, time));
        }

        private IEnumerator ChangeColor(Color oldColor, Color newColor, float time)
        {
            float toAdd = 0f;
            while (toAdd <= 1)
            {
                SetColor(Color.Lerp(oldColor, newColor, toAdd));
                toAdd += .01f / time;
                yield return new WaitForSeconds(.01f);
            }
        }

        public void RevertColors()
        {
            MenuLightsSO().SetColorsFromPreset(defaultPreset);
        }

        private MenuLightsPresetSO defaultPreset;

        private MenuLightsManager _mLSO;
        private MenuLightsManager MenuLightsSO()
        {
            if (_mLSO == null)
            {
                _mLSO = Resources.FindObjectsOfTypeAll<MenuLightsManager>().First();
                defaultPreset = Resources.FindObjectsOfTypeAll<MenuLightsPresetSO>().First();
                return _mLSO;
            }
            else
                return _mLSO;
        }

        private void UpdateLights(Color color)
        {
            var x = Resources.FindObjectsOfTypeAll<MenuLightsPresetSO>().First();
            if (x != null)
            {
                var ids = x.lightIdColorPairs;
                foreach (var light in ids)
                {
                    MenuLightsSO().SetColor(light.lightId, color);
                }
            }
        }
    }
}
