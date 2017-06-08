using System.Collections;
using System.Collections.Generic;
using RED.Game.Saving;
using UnityEngine;
using UniRx;
using System.Linq;

public class SoundsManager : MonoBehaviour
{
    public AudioSource MusicPlayer;

    public AudioClip[] Notes;
    public AudioClip Music;

    private int noteIndex = 0;
    private AudioClip[] notesToPlay;

    private void Awake()
    {
        this.MusicPlayer.clip = this.Music;

        GameSettings.Instance.Music.Subscribe(music =>
        {
            if (music)
                this.MusicPlayer.Play();
            else
                this.MusicPlayer.Stop();
        });

        this.notesToPlay = this.Notes.Union(this.Notes.Reverse()).ToArray();
    }

    public void PlayOnCollide()
    {
        if (!GameSettings.Instance.Sounds.Value)
            return;

        if (this.noteIndex == this.notesToPlay.Length)
            this.noteIndex = 0;

        AudioSource.PlayClipAtPoint(this.Notes[this.noteIndex++], Camera.main.transform.position);
    }

}
