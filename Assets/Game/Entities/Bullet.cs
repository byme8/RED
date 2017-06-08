using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Coroutines;
using Tweens;
using UnityEngine;

namespace RED.Entities
{
    public class Bullet : Entity
    {
        public Rigidbody2D Rigibody;
        public float BulletSpawTime;
        public float BulletSpeed;
        public Vector3 BulletSpawScale;

        private SoundsManager SoundsManager;


        private void Start()
        {
            this.SoundsManager = GameObject.FindObjectOfType<SoundsManager>();
        }

        public IEnumerator Launch(Vector3 startPosition, Vector3 direction)
        {
            this.Rigibody.velocity = Vector3.zero;
            this.transform.localPosition = Vector3.zero;
            this.transform.localScale = Vector3.zero;
            this.Rigibody.simulated = false;
            this.Enable();

            yield return Parallel.Create(
                        this.gameObject.Move(startPosition, this.BulletSpawTime, curve: Curves.CircularIn),
                        this.gameObject.Scale(this.BulletSpawScale, this.BulletSpawTime, curve: Curves.CircularIn));

            this.Rigibody.simulated = true;
            this.Rigibody.velocity = direction.normalized * this.BulletSpeed;
            yield return new WaitUntil(() => this.transform.position.magnitude > 30);
            this.Disable();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var point = collision.gameObject.GetComponent<Point>();
            if (point)
            {
                point.Take();
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            this.SoundsManager.PlayOnCollide();
        }
    }
}
