using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Coroutines.Abstractions;

namespace Coroutines
{
    public static class Parallel
    {
        public static ICoroutine Create(params ICoroutine[] coroutines)
        {
            return CoroutinesFactory.StartSuperFastCoroutine(ProcessParallel(coroutines));
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
    }
}
