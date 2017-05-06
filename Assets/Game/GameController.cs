using System;
using System.Collections;
using System.Linq;
using Coroutines;
using RED.Entities;
using RED.Levels;
using Tweens;
using UnityEngine;
using UnityEngine.SceneManagement;
using UserInput;

public class GameController : MonoBehaviour
{
    public GameObject BulletTemplate;
    public float BulletSpawTime;
    public float BulletSpeed;

    public Vector3 BulletSpawScale;

    private GameObject Bullet;
    private Rigidbody2D BulletRigibody;
    private LevelsManager levelManager;
    private string currentLevel;
    private Entity[] entities;
    private UserInputController userInput;

    private void Start()
    {
        this.Bullet = this.BulletTemplate.Clone();
        this.Bullet.Disable();
        this.BulletRigibody = this.Bullet.GetComponent<Rigidbody2D>();
        this.levelManager = FindObjectOfType<LevelsManager>();
        this.userInput = FindObjectOfType<UserInputController>();
    }

    public IEnumerator Play()
    {
        yield return this.Cleanup();
        yield return this.LoadLevel();
        yield return this.PlayStartAnimation();
        this.userInput.StartHandeling();
    }

    private IEnumerator PlayStartAnimation()
    {
        yield return this.entities.Select(entity =>
        {
            var position = entity.gameObject.transform.localPosition;
            var scale = entity.gameObject.transform.localScale;

            entity.gameObject.transform.localPosition = Vector3.zero;
            entity.gameObject.transform.localScale = Vector3.zero;

            return Parallel.Create(entity.gameObject.Move(position, entity.SpawnTime, curve: Curves.BounceOut),
                                   entity.gameObject.Scale(scale, entity.SpawnTime, curve: Curves.BounceOut));
        }).ParallelCoroutines();
    }

    private IEnumerator LoadLevel()
    {
        this.currentLevel = this.levelManager.Levels.First();
        yield return SceneManager.LoadSceneAsync(this.currentLevel, LoadSceneMode.Additive);
        this.entities = FindObjectsOfType<Entity>();
    }

    private IEnumerator Cleanup()
    {
        if (this.currentLevel != null)
        {
            yield return this.entities.Select(o => Parallel.Create(o.gameObject.Move(Vector3.zero, o.SpawnTime, curve: Curves.CircularIn),
                                                                   o.gameObject.Scale(Vector3.zero, o.SpawnTime, curve: Curves.CircularIn))).ParallelCoroutines();

            SceneManager.UnloadSceneAsync(this.currentLevel);
        }
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
