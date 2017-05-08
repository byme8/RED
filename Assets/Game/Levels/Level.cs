using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RED.Levels
{
    public class Level
    {
        public readonly string Name;
        private LevelController levelController;

        public Level(string name)
        {
            this.Name = name;
        }

        public IEnumerator Load()
        {
            yield return SceneManager.LoadSceneAsync(this.Name, LoadSceneMode.Additive);
            this.levelController = GameObject.FindObjectOfType<LevelController>();

            yield return this.levelController.Show();
        }

        public IEnumerator Unload()
        {
            yield return this.levelController.Hide();
            yield return SceneManager.UnloadSceneAsync(this.Name);
        }
    }
}
