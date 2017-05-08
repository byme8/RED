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
    public float BulletSpawTime;
    public float BulletSpeed;
    public Vector3 BulletSpawScale;

    private Rigidbody2D BulletRigibody;
    private LevelsManager levelManager;
    private GameObject Bullet;
    private Level currentLevel;

    private void Start()
    {
        this.Bullet = this.BulletTemplate.Clone();
        this.Bullet.Disable();
        this.BulletRigibody = this.Bullet.GetComponent<Rigidbody2D>();
        this.levelManager = FindObjectOfType<LevelsManager>();
    }

    public IEnumerator Play(int level)
    {
        this.currentLevel = this.levelManager.Levels.Skip(level).First();

        yield return this.currentLevel.Load();
        this.currentLevel.Finished.
            Delay(TimeSpan.FromSeconds(0.5)).
            Subscribe(_ => this.StartCoroutine(this.NextLevel(level)));
    }

    private IEnumerator NextLevel(int currentLevel)
    {
        yield return this.currentLevel.Unload();
        yield return this.Play(currentLevel + 1);
    }

    public IEnumerator LanuchBullet(Vector3 startPosition, Vector3 direction)
    {
        this.BulletRigibody.velocity = Vector3.zero;
        this.Bullet.transform.localPosition = Vector3.zero;
        this.Bullet.transform.localScale = Vector3.zero;
        this.Bullet.Enable();

        yield return Parallel.Create(
                    this.Bullet.Move(startPosition, this.BulletSpawTime, curve: Curves.CircularIn),
                    this.Bullet.Scale(this.BulletSpawScale, this.BulletSpawTime, curve: Curves.CircularIn));

        this.BulletRigibody.velocity = direction.normalized * this.BulletSpeed;
        yield return new WaitUntil(() => this.Bullet.transform.position.magnitude > 30);
        this.Bullet.Disable();
    }
}
