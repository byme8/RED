using System;
using System.Collections;
using REDBlend.Assets.Resources.UI;
using REDBlend.Assets.UI.ViewModels.Core;
using UnityEngine;

namespace REDBlend.Assets.UI.Tools
{
    public class Navigator : MonoBehaviour
    {
        private NoesisGUIPanel UI;

        private IEnumerator Start()
        {
            yield return new WaitForEndOfFrame();
            Instance = this;
            this.UI = GameObject.FindObjectOfType<NoesisGUIPanel>();
            this.Navigate(Routes.Main);
        }

        public void Navigate(string url)
        {
            Debug.Log("Change view to: " + url);
            this.UI.Xaml = url;
            this.UI.ForceLoadXaml();
        }

        public void Navigate(string url, object data)
        {
            Debug.Log("Change view to: " + url);
            this.UI.Xaml = url;
            this.UI.ForceLoadXaml();
            var viewModelWithValue = this.UI.GetContent().DataContext as ViewModelValue;
            if (viewModelWithValue == null)
                throw new InvalidOperationException("If you navigate with data you should you ViewModel<TValue> as view model.");

            viewModelWithValue.Value = data;
        }

        public static Navigator Instance
        {
            get;
            private set;
        }

    }
}
