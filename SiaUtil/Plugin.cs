using IPA;
using UnityEngine;
using UnityEngine.SceneManagement;
using IPALogger = IPA.Logging.Logger;
using SiaUtil.Visualizers;
using System.Linq;

namespace SiaUtil
{
    public class Plugin : IBeatSaberPlugin, IDisablablePlugin
    {
        public void Init(IPALogger logger)
        {
            Logger.log = logger;
        }

        public void OnApplicationStart()
        {
            
        }

        public void OnApplicationQuit()
        {
            
        }

        public void OnFixedUpdate()
        {

        }

        public void OnUpdate()
        {

        }

        public void OnActiveSceneChanged(Scene prevScene, Scene nextScene)
        {
            if (nextScene.name == "MenuCore")
            {
                var a = Resources.FindObjectsOfTypeAll<MainMenuViewController>().First();

                var pa = ProgressBar.Create(new Vector2(200, 25), new Vector3(0f, 3f, 3f), false);
                pa.Progress = .5f;
                pa.Color = Color.red;
            }
        }

        public void OnSceneLoaded(Scene scene, LoadSceneMode sceneMode)
        {
            
        }

        public void OnSceneUnloaded(Scene scene)
        {

        }

        private static Sprite _radial;
        public static Sprite RadialIcon()
        {
            if (_radial == null)
            {
                _radial = Utilities.LoadSpriteFromResources("SiaUtil.Assets.Circle.png");
                return _radial;
            }
            else
                return _radial;
        }

        public void OnEnable()
        {
            _ = RadialIcon();
        }

        public void OnDisable()
        {
            
        }
    }
}
