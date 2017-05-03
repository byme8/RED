using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace RED.Utils
{
    public class GameObjectPool
    {
        private int Total;
        private GameObject[] Templates;
        private List<GameObject> pool;

        public GameObjectPool(int total, params GameObject[] templates)
        {
            this.Total = total;
            this.Templates = templates;

            this.pool = new List<GameObject>();
            foreach (var template in templates)
                this.pool.Add(GameObject.Instantiate<GameObject>(template));

            var count = this.pool.Count;
            for (int i = 0; i < total - count; i++)
            {
                this.pool.Add(templates.Random());
            }
        }

        public GameObject Next
        {
            get
            {
                return this.pool.Where(o => !o.activeSelf).Random();
            }
        }
    }
}
