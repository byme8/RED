using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Coroutines;
using RED.Levels;
using Tweens;
using Tweens.Data;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{

    public GameObject SettingsPage;
    public GameController GameController;

    private void Start()
    {
        this.GameController = FindObjectOfType<GameController>();
    }

    public void Play()
    {
        this.PlayCoroutine().StartCoroutine();
    }

    private IEnumerator PlayCoroutine()
    {
        yield return this.HidePage(this.gameObject);
        yield return this.GameController.Play(0);
    }

    public void Settings()
    {
        this.SwapPages(this.gameObject, this.SettingsPage).StartCoroutine();
    }

    private IEnumerator SwapPages(GameObject firstPage, GameObject secondPage)
    {
        yield return new[] { this.HidePage(firstPage), this.ShowPage(secondPage, 0.2f) }.AsParallel();
    }

    private IEnumerator HidePage(GameObject page)
    {
        yield return new[] {
                page.Scale(new Vector3(1.1f, 1.1f), 1, curve: Curves.CircularOut),
                page.GetComponentsInChildren<CanvasRenderer>().Select(o => o.Opacity(0, 1, curve: Curves.CircularOut)).AsParallel() }.
            AsParallel();

        page.Disable();
    }

    private IEnumerator ShowPage(GameObject page, float delay = 0)
    {
        var renders = page.GetComponentsInChildren<CanvasRenderer>();

        page.Enable();
        page.transform.localScale = new Vector3(0.9f, 0.9f);
        foreach (var render in renders)
            render.SetAlpha(0);

        yield return new[] {
                page.Scale(new Vector3(1f, 1f), 1, delay, Curves.CircularOut),
                renders.Select(o => o.Opacity(1, 1, delay, Curves.CircularOut)).AsParallel() }.
            AsParallel();
    }

    public void Quit()
    {
        Debug.Log("Quit");
    }
}
