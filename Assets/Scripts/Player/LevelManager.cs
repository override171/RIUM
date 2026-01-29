using System.Diagnostics.CodeAnalysis;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
      GameObject player;
      public GameObject[] levels;
      public int lv = 0;
      int i = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
            player = GameObject.Find("Player");
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
                  player.GetComponent<Player_useG>().haveG = false;
                  levels[lv].gameObject.SetActive(false);
                  lv++;
                  levels[lv].gameObject.SetActive(true);
                  Vector3 pos = transform.position;
                  pos.z = -2;
                  pos.x = -5;
                  pos.y = -1;
                  transform.position = pos;
                  i = 0;
            }
      }
}
