using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace UserInput
{
    public class TouchInputProvider : IInputProvider
    {
        private Camera Camera;

        public TouchInputProvider()
        {
            this.Camera = GameObject.FindObjectOfType<Camera>();
        }

        public Vector3 Position
        {
            get;
            set;
        }

        public IEnumerator GetFirstPoint()
        {
            yield return new WaitUntil(() => Input.touches.Any(o => o.phase == TouchPhase.Began));
            this.Position = this.Camera.ScreenToWorldPoint(Input.touches.First(o => o.phase == TouchPhase.Began).position);
            Debug.LogError(this.Position);
        }

        public IEnumerator GetSecondPoint()
        {
            yield return new WaitUntil(() => Input.touches.Any(o => o.phase == TouchPhase.Ended));
            this.Position = this.Camera.ScreenToWorldPoint(Input.touches.First(o => o.phase == TouchPhase.Ended).position);
            Debug.LogError(this.Position);
        }
    }
}
