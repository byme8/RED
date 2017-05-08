using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Coroutines.Abstractions;
using UnityEngine;

namespace Coroutines
{
    public static class Parallel
    {
        public static ICoroutine Create(params ICoroutine[] coroutines)
        {
            return CoroutinesFactory.StartSuperFastCoroutine(ProcessParallel(coroutines));
        }

        public static Coroutine Create(params IEnumerator[] coroutines)
        {
            return CoroutinesFactory.StartCoroutine(ProcessParallel(coroutines));
        }

        private static IEnumerator ProcessParallel(IEnumerator[] coroutines)
        {
            var list = coroutines.Select(o => CoroutinesFactory.StartCoroutine(o)).ToArray();
            foreach (var coroutine in list)
                yield return coroutine;
        }

        private static IEnumerator ProcessParallel(ICoroutine[] coroutines)
        {
            var coroutinesList = coroutines.ToList();
            while (coroutinesList.Any())
            {
                coroutinesList.RemoveAll(o => !o.MoveNext());
                yield return null;
            }
        }

        public static ICoroutine ParallelCoroutines(this IEnumerable<ICoroutine> coroutines)
        {
            return Create(coroutines.ToArray());
        }

        public static Coroutine ParallelCoroutines(this IEnumerable<IEnumerator> coroutines)
        {
            return Create(coroutines.ToArray());
        }
    }
}
