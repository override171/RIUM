using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;

public class ShapedArea : MonoBehaviour
{
      public GameObject[] areas;
      public SpriteRenderer[] spder;
      public string a = "Default";
      string a0;
      string a1;
      string a2;
      public string master = "Default";
      int i = 1;
      // Start is called once before the first execution of Update after the MonoBehaviour is created
      void Start()
      {
            a0 = areas[0].gameObject.tag;
            a1 = areas[1].gameObject.tag;
            a2 = areas[2].gameObject.tag;
      }

    // Update is called once per frame
    void Update()
    {
            Debug.Log(i);
            if(areas[0].gameObject.tag != a0)
            {
                  master = areas[0].gameObject.tag;
                  tagChange();
            }
            if(areas[1].gameObject.tag != a1)
            {
                  master = areas[1].gameObject.tag;
                  tagChange();
            }
            if(areas[2].gameObject.tag != a2)
            {
                  master = areas[2].gameObject.tag;
                  tagChange();
            }
    }
      void tagChange()
      {
            foreach(var area in areas)
            {
                  area.gameObject.tag = master;
            }
            if(master == "NonG")
            {
                  foreach(var sp in spder)
                  {
                        sp.color = Color.lightBlue;
                  }
            }
            else if(master == "Default")
            {
                  foreach (var sp in spder)
                  {
                        sp.color = Color.white;
                  }
            }
            a0 = master;
            a1 = master;
            a2 = master;
      }
}
