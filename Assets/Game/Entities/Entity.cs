using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Coroutines;
using Tweens;
using UniRx;
using UnityEngine;

namespace RED.Entities
{
    public class Entity : MonoBehaviour
    {
        public float SpawnDelay;
        public float SpawnTime;

        public float HideTime;

        public virtual IEnumerator Show()
        {
            this.Enable();
            var position = this.gameObject.transform.localPosition;
            var scale = this.gameObject.transform.localScale;

            this.gameObject.transform.localPosition = Vector3.zero;
            this.gameObject.transform.localScale = Vector3.zero;

            yield return Parallel.Create(this.gameObject.Move(position, this.SpawnTime, this.SpawnDelay, Curves.BounceOut),
                                   this.gameObject.Scale(scale, this.SpawnTime, this.SpawnDelay, Curves.BounceOut));
        }

        public virtual IEnumerator Hide()
        {
            yield return Parallel.Create(this.gameObject.Move(Vector3.zero, this.HideTime, curve: Curves.CircularOut),
                                   this.gameObject.Scale(Vector3.zero, this.HideTime, curve: Curves.CircularOut));
            this.Disable();
        }

    }
}
