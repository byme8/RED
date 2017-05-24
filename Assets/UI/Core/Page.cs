using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Coroutines;
using Tweens;
using UnityEngine;

namespace RED.UI.Core
{
    public class Page : MonoBehaviour
    {
        public IEnumerator Hide()
        {
            yield return new[] {
                this.gameObject.Scale(new Vector3(1.1f, 1.1f), 1, curve: Curves.CircularOut),
                this.gameObject.GetComponentsInChildren<CanvasRenderer>().Select(o => o.Opacity(0, 1, curve: Curves.CircularOut)).AsParallel() }.
                AsParallel();

            this.Disable();
        }

        public IEnumerator Show(float delay = 0)
        {
            var renders = this.GetComponentsInChildren<CanvasRenderer>();

            this.Enable();
            this.transform.localScale = new Vector3(0.9f, 0.9f);
            foreach (var render in renders)
                render.SetAlpha(0);

            yield return new[] {
                this.gameObject.Scale(new Vector3(1f, 1f), 1, delay, Curves.CircularOut),
                renders.Select(o => o.Opacity(1, 1, delay, Curves.CircularOut)).AsParallel() }.
                AsParallel();
        }
    }

    public static class PageExtentions
    {
        public static IEnumerator Navigate(this Page page)
        {
            yield return Navigator.Instance.Navigate(page);
        }
    }

}
