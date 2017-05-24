using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RED.Utils;
using UniRx;

namespace RED.Game.Saving
{
    public class GameSettings : Singletone<GameSettings>
    {
        public GameSettings()
        {
            this.Sounds = new ReactiveProperty<bool>();
            this.Music = new ReactiveProperty<bool>();
            this.FinishedLevels = new ReactiveCollection<int>();
        }

        public ReactiveProperty<bool> Sounds
        {
            get;
            private set;
        }

        public ReactiveProperty<bool> Music
        {
            get;
            private set;
        }

        public ReactiveCollection<int> FinishedLevels
        {
            get;
            set;
        }

        public GameState GetState()
        {
            return new GameState
            {
                IsSoundsEnabled = this.Sounds.Value,
                IsMusicEnabled = this.Music.Value,
                FinishedLevels = this.FinishedLevels.ToArray()
            };
        }

        public void SetState(GameState state)
        {
            this.Sounds.Value = state.IsSoundsEnabled;
            this.Music.Value = state.IsMusicEnabled;

            this.FinishedLevels.Clear();
            foreach (var level in state.FinishedLevels)
                this.FinishedLevels.Add(level);
        }
    }

    public class GameState
    {
        public bool IsSoundsEnabled
        {
            get;
            set;
        }

        public bool IsMusicEnabled
        {
            get;
            set;
        }

        public int[] FinishedLevels
        {
            get;
            set;
        }
    }
}
