using System.Collections;
using System.Collections.Generic;
using Tweens;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject BulletTemplate;
    public float BulletSpawTime;
    public float BulletSpeed;

    private GameObject Bullet;
    private Rigidbody2D BulletRigibody;

    private void Start()
    {
        this.Bullet = this.BulletTemplate.Clone();
        this.Bullet.Disable();
        this.BulletRigibody = this.Bullet.GetComponent<Rigidbody2D>();
    }

    public IEnumerator LanuchBullet(Vector3 startPosition, Vector3 direction)
    {
        this.Bullet.Enable();
        yield return this.Bullet.Move(startPosition, this.BulletSpawTime);
        this.BulletRigibody.velocity = direction.normalized * this.BulletSpeed;
        yield return new WaitUntil(() => this.Bullet.transform.position.magnitude > 10);
        this.Bullet.transform.position = Vector3.zero;
        this.Bullet.Disable();
    }
}
