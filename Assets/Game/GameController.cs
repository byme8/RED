using System.Collections;
using Coroutines;
using Tweens;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject BulletTemplate;
    public float BulletSpawTime;
    public float BulletSpeed;

    public Vector3 BulletSpawScale;

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
        this.BulletRigibody.velocity = Vector3.zero;
        this.Bullet.transform.localPosition = Vector3.zero;
        this.Bullet.transform.localScale = Vector3.zero;
        this.Bullet.Enable();

        yield return Parallel.Create(
                    this.Bullet.Move(startPosition, this.BulletSpawTime, curve: Curves.BackOut),
                    this.Bullet.Scale(this.BulletSpawScale, this.BulletSpawTime, curve: Curves.BackOut));
        this.BulletRigibody.velocity = direction.normalized * this.BulletSpeed;
        yield return new WaitUntil(() => this.Bullet.transform.position.magnitude > 30);
        this.Bullet.Disable();
    }
}
