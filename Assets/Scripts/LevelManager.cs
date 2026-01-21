using System.Diagnostics.CodeAnalysis;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
      public GameObject[] levels;
      public int lv = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            
    }
      private void OnCollisionEnter2D(Collision2D collision)
      {
            if(collision.gameObject.tag == "Flag")
            {
                  levels[lv].gameObject.SetActive(false);
                  lv++;
                  levels[lv].gameObject.SetActive(true);
            }
      }
}
