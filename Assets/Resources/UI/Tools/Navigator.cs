using System.Collections;
using REDBlend.Assets.Resources.UI;
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

        public static Navigator Instance
        {
            get;
            private set;
        }

    }
}
