using System.Collections;
using Coroutines;
using Coroutines.Abstractions;
using Tweens.Data;
using UnityEngine;

namespace Tweens
{
    public static class MoveTween
    {
        public static IEnumerator Move(this GameObject gameObject,
                Vector3 position,
                float time,
                float delay = 0,
                Curve curve = null)
        {
            var transform = gameObject.transform;

            return Sequence.Create(
                Delay.Create(delay),
                ProcessMoving(
                    transform,
                    position,
                    time,
                    curve));
        }

        private static IEnumerator ProcessMoving(
            Transform transform,
            Vector3 position,
            float time,
            Curve curve)
        {
            if (curve == null)
                curve = Curves.BackIn;

            var timeSpent = 0.0f;
            var start = transform.localPosition;
            var delta = position - start;
            while (timeSpent < time)
            {
                var shift = curve.Caclculate(timeSpent / time);
                var currentValue = start + delta * shift;
                transform.localPosition = currentValue;
                timeSpent += Time.deltaTime;
                yield return null;
            }
        }
    }
}