using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using RED.Levels;
using UnityEngine;
using UnityEngine.UI;

public class CategoryViewController : MonoBehaviour
{
    public Text Text;
    public Category Category;

    public void Start()
    {
        this.Text.text = this.Category.Name;
    }
}
