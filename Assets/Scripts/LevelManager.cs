using System.Diagnostics.CodeAnalysis;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
      public GameObject[] levels;
      Vector2 stPos;
      public int lv = 0;
      int i = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
            stPos = new Vector2(-5, -1);
    }

    // Update is called once per frame
    void Update()
    {
            
    }
      private void OnCollisionEnter2D(Collision2D collision)
      {
            if(collision.gameObject.tag == "Flag")
            {
                  i++;
                  Invoke("LvUp", 0f);
            }
      }
      void LvUp()
      {
            CancelInvoke("LvUp");
            if(i > 1)
            {
                  return;
            }
            if (i == 1)
            {
                  levels[lv].gameObject.SetActive(false);
                  lv++;
                  levels[lv].gameObject.SetActive(true);
                  transform.position = stPos;
            }
      }
}
