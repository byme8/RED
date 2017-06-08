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

    public Text Text;
    public Category Category;

    public IOrderedEnumerable<Level> Levels
    {
        get;
        set;
    }

    public void Start()
    {
        this.Text.text = this.Category.Name;

        foreach (var level in this.Levels)
        {
            var levelView = this.LevelTemplate.Clone<LevelViewController>();
            levelView.Level = level;
            levelView.transform.SetParent(this.transform);
        }
    }

}
