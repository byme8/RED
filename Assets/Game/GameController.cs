using System;
using System.Collections;
using System.Linq;
using Coroutines;
using RED.Coroutines;
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
    public Level CurrentLevel;
    public GameObject BulletTemplate;
    private LevelsManager levelManager;
    private Bullet Bullet;

    private int currentLevelIndex;
    private bool loadingInProgress;

    private void Start()
    {
        this.Bullet = this.BulletTemplate.Clone().GetComponent<Bullet>();
        this.Bullet.Disable();
        this.levelManager = FindObjectOfType<LevelsManager>();
    }

    public IEnumerator Play(int level)
    {
        if (this.loadingInProgress)
            yield break;

        this.loadingInProgress = true;

        if (this.CurrentLevel != null)
            yield return new[] { this.CurrentLevel.Unload(), this.Bullet.Hide() }.AsParallel();

        this.CurrentLevel = this.levelManager.Levels.Skip(level).First();
        this.currentLevelIndex = level;

        yield return this.CurrentLevel.Load();
        this.CurrentLevel.Finished.
            Delay(TimeSpan.FromSeconds(0.5)).
            Subscribe(_ => this.StartCoroutine(this.NextLevel()));

        this.loadingInProgress = false;
    }

    public IEnumerator Restart()
    {
        yield return this.Play(this.currentLevelIndex);
    }

    private IEnumerator NextLevel()
    {
        this.currentLevelIndex++;
        if (this.currentLevelIndex >= this.levelManager.Levels.Count())
            this.currentLevelIndex = 0;

        this.Bullet.Disable();
        yield return this.Play(this.currentLevelIndex);
    }

    public IEnumerator LanuchBullet(Vector3 startPosition, Vector3 direction)
    {
        yield return this.Bullet.Launch(startPosition, direction);

        if (this.CurrentLevel.Points.All(o => o.Taken))
            this.NextLevel();
    }
}
