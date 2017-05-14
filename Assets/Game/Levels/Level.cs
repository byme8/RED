using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Coroutines;
using RED.Entities;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RED.Levels
{
    public class Level
    {
        public readonly string Name;

        public Point[] Points
        {
            get;
            private set;
        }

        private LevelController levelController;
        
        public Level(string name)
        {
            this.Name = name;
        }

        public IEnumerator Load()
        {
            yield return SceneManager.LoadSceneAsync(this.Name, LoadSceneMode.Additive);
            this.levelController = GameObject.FindObjectOfType<LevelController>();
            this.Points = GameObject.FindObjectsOfType<Point>();
            yield return this.levelController.Show();

            this.Finished = Observable.FromCoroutine(() => this.levelController.Monitoring());
            this.Finished.Subscribe();
        }

        public IObservable<Unit> Finished
        {
            get;
            private set;
        }

        public IEnumerator Unload()
        {
            yield return this.levelController.Hide();
            yield return SceneManager.UnloadSceneAsync(this.Name);
        }
    }
}
