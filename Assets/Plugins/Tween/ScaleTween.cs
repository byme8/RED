using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Coroutines;
using Coroutines.Abstractions;
using Tweens.Data;
using UnityEngine;

namespace Tweens
{
    public static class ScaleTween
    {
        public static ICoroutine Scale(this GameObject gameObject,
                Vector3 scale,
                float time,
                float delay = 0,
                Curve curve = null)
        {
            var transform = gameObject.transform;

            return Sequence.Create(
                Delay.Create(delay),
                CoroutinesFactory.StartSuperFastCoroutine(ProcessScaling(
                    transform,
                    scale,
                    time,
                    delay,
                    curve)));
        }

        private static IEnumerator ProcessScaling(
            Transform transform,
            Vector3 scale,
            float time,
            float delay,
            Curve curve)
        {
            if (curve == null)
                curve = Curves.BackIn;

            var timeSpent = 0.0f;
            var start = transform.localScale;
            var delta = scale - start;
            while (timeSpent < time)
            {
                var shift = curve.Caclculate(timeSpent / time);
                var currentValue = start + delta * shift;
                transform.localScale = currentValue;
                timeSpent += Time.deltaTime;
                yield return null;
            }
        }
    }
}
