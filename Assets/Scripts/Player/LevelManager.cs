using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using UnityEngine.InputSystem;

public class LevelManager : MonoBehaviour
{
      GameObject player;
      public AudioClip swichsoud;
      public AudioClip noise;
      AudioSource audioSource;
      public bool moveOff = false;
      bool bgm = true;
      public GameObject[] levels;
      public GameObject Fade;
      public Animator anim;
      public Rigidbody2D rb;
      public int lv = 0;
      int i = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
            player = GameObject.Find("Player");
            anim = GetComponent<Animator>();
            audioSource = gameObject.AddComponent<AudioSource>();
      }

    // Update is called once per frame
    void Update()
    {
            if (bgm)
            {
                  if(!audioSource.isPlaying)
                  {
                        audioSource.PlayOneShot(noise);
                  }
            }
            if(lv == 5)
            {
                  Invoke("moveoff", 5f);
                  Invoke("fade", 12f);
            }
    }
      void moveoff()
      {
            rb.bodyType = RigidbodyType2D.Static;
            anim.SetBool("isWalk", false);
            moveOff = true;
      }
      void fade()
      {
            CancelInvoke("fade");
             audioSource.PlayOneShot(swichsoud);
             bgm = false;
            Fade.SetActive(true);
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
