using REDBlend.Assets.Resources.UI;
using REDBlend.Assets.UI.Tools;
using REDBlend.Assets.UI.ViewModels.Core;
using UnityEngine;

namespace REDBlend.Assets.UI.ViewModels
{
    public class MainViewModel : ViewModel
    {
        public MainViewModel()
        {
            this.Play = new Command(_ => Debug.Log("hello"));
            this.Settings = new Command(_ => Navigator.Instance.Navigate(Routes.Settings));
            this.Quit = new Command(_ => Application.Quit());
        }

        public Command Play
        {
            get;
            private set;
        }

        public Command Settings
        {
            get;
            private set;
        }

        public Command Quit
        {
            get;
            private set;
        }
    }
}
