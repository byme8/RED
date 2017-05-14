using System;
using System.Collections;
using System.Linq;
using Coroutines;
using RED.Entities;
using RED.Game.Entities;
using RED.Levels;
using Tweens;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using UserInput;

public class GameController : MonoBehaviour
{
    public GameObject BulletTemplate;
    private LevelsManager levelManager;
    private Bullet Bullet;

    private Level currentLevel;
    private int currentLevelIndex;

    private void Start()
    {
        this.Bullet = this.BulletTemplate.Clone().GetComponent<Bullet>();
        this.Bullet.Disable();
        this.levelManager = FindObjectOfType<LevelsManager>();
    }

    public IEnumerator Play(int level)
    {
        this.currentLevel = this.levelManager.Levels.Skip(level).First();
        this.currentLevelIndex = level;

        yield return this.currentLevel.Load();
        this.currentLevel.Finished.
            Delay(TimeSpan.FromSeconds(0.5)).
            Subscribe(_ => this.StartCoroutine(this.NextLevel()));
    }

    private IEnumerator NextLevel()
    {
        this.currentLevelIndex++;
        yield return this.currentLevel.Unload();
        yield return this.Play(this.currentLevelIndex);
    }

    public IEnumerator LanuchBullet(Vector3 startPosition, Vector3 direction)
    {
        yield return this.Bullet.Launch(startPosition, direction);        

        if (this.currentLevel.Points.All(o => o.Taken))
            this.NextLevel();
    }
}
