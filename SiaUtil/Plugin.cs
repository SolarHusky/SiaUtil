using IPA;
using UnityEngine;
using UnityEngine.SceneManagement;
using IPALogger = IPA.Logging.Logger;
using SiaUtil.Visualizers;

namespace SiaUtil
{
    public class Plugin : IBeatSaberPlugin
    {
        public void Init(IPALogger logger)
        {
            Logger.log = logger;
        }

        public void OnApplicationStart()
        {
            _ = RadialIcon();
        }

        public void OnApplicationQuit()
        {
            Logger.log.Debug("OnApplicationQuit");
        }

        public void OnFixedUpdate()
        {

        }

        public void OnUpdate()
        {

        }

        public void OnActiveSceneChanged(Scene prevScene, Scene nextScene)
        {
            
        }

        public void OnSceneLoaded(Scene scene, LoadSceneMode sceneMode)
        {
            if (scene.name == "MenuCore")
            {
                var a = new GameObject();
                var b = a.AddComponent<WorldSpaceRadial>();
                b.Create();
                a.transform.position = new Vector3(0f, 5f, 5f);
            }
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
    }
}
