﻿using IPA;
using UnityEngine;
using UnityEngine.SceneManagement;
using IPALogger = IPA.Logging.Logger;
using SiaUtil.Visualizers;
using System.Linq;
using SiaUtil.widePeepoHappy;
using System.Collections.Generic;
using System.Collections;

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
            if (nextScene.name == "MenuViewControllers")
                MenuColorChanger.instance.CanBeModified = true;
            else
                MenuColorChanger.instance.CanBeModified = false;
        }

        public void OnSceneLoaded(Scene scene, LoadSceneMode sceneMode)
        {
            if (scene.name == "MenuViewControllers")
            {
                //SharedCoroutineStarter.instance.StartCoroutine(Wait());
            }
        }

        IEnumerator Wait()
        {
            yield return new WaitForSeconds(3f);
            var vis = WorldSpaceMessage.Create("test", new Vector3(0f, 3f, 1f), 7f);
            yield return new WaitForSeconds(3f);
            vis.Color = Color.red;
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
