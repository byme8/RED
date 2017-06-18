using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Coroutines;
using Tweens;
using UniRx;
using UnityEngine;

namespace RED.UI.Core
{
    public class Navigator : MonoBehaviour
    {
        public static Navigator Instance;

        public Page StartPage;
        public Page GamePage;
        public Page SettingsPage;
        public Page CategoriesPage;
        public Page FeedbackPage;
        public Page AboutPage;

        public Navigator()
        {
            Instance = this;
        }

        private void Start()
        {
            this.CurrentPage.OnNext(this.StartPage);
        }

        public readonly BehaviorSubject<Page> CurrentPage
            = new BehaviorSubject<Page>(null);

        private bool Navigating;

        public IEnumerator Navigate(Page page)
        {
            if (this.Navigating)
                yield break;

            this.Navigating = true;

            yield return new[] { this.CurrentPage.Value.Hide(), page.Show(0.2f) }.AsParallel();
            this.CurrentPage.OnNext(page);

            this.Navigating = false;
        }
    }
}
