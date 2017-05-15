using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tweens;
using UnityEngine;

namespace RED.Entities
{
    public class Point : Entity
    {
        public bool Taken;

        public void Take()
        {
            this.Taken = true;
            this.StartCoroutine(this.Hide());
        }

        public override IEnumerator Hide()
        {
            yield return this.gameObject.Scale(Vector3.zero, this.HideTime, curve: Curves.CircularOut);
        }
    }
}
