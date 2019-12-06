using IPA;
using UnityEngine;
using UnityEngine.SceneManagement;
using IPALogger = IPA.Logging.Logger;
using SiaUtil.Visualizers;
using System.Linq;
using SiaUtil.widePeepoHappy;

namespace SiaUtil
{
    public class Plugin : IBeatSaberPlugin, IDisablablePlugin
    {
        public void OnEnable()
        {
            _ = RadialIcon();
        }

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
                PersistentSingleton<MenuColorChanger>.instance.CanBeModified = true;
            else
                PersistentSingleton<MenuColorChanger>.instance.CanBeModified = false;
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

        public void OnDisable()
        {
            
        }
    }
}
