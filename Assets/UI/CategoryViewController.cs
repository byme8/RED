using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Coroutines;
using RED.Levels;
using RED.UI.Core;
using UnityEngine;
using UnityEngine.UI;

public class CategoryViewController : MonoBehaviour
{
    public GameObject LevelTemplate;

    public Text CategotyName;
    public Text CategotyDescription;
    public Transform Root;

    public Category Category;

    public IOrderedEnumerable<Level> Levels
    {
        get;
        set;
    }

    public void Start()
    {
        this.CategotyName.text = this.Category.Name;
        this.CategotyDescription.text = this.Category.Description;

        foreach (var level in this.Levels)
        {
            var levelView = this.LevelTemplate.Clone<LevelViewController>();
            levelView.Level = level;
            levelView.transform.SetParent(this.Root);
        }
    }

}
