using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Coroutines;
using RED.Levels;
using RED.UI.Core;
using UnityEngine;

public class CategoriesViewController : MonoBehaviour
{
    public GameObject CategoryViewTemplate;
    public Transform Root;

    private void Start()
    {
        var levels = GameObject.FindObjectsOfType<Level>().GroupBy(o => o.Category);
        foreach (var item in levels.OrderBy(o => o.Key.Order))
        {
            var category = this.CategoryViewTemplate.Clone<CategoryViewController>();
            category.transform.SetParent(this.Root);
            category.Levels = item.OrderBy(o => o.Order);
            category.Category = item.Key;
        }
    }

    public void ToMainMenu()
    {
        Navigator.Instance.StartPage.Navigate().StartCoroutine();
    }
}
