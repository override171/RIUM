using System.Collections;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using UnityEngine.InputSystem;

public class LevelManager : MonoBehaviour
{
      GameObject player;
      public AudioClip swichsoud;
      public AudioClip noise;
      public AudioClip EndingBGM;
      AudioSource audioSource;
      public AudioSource ending;
      public AudioSource switchs;
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
            else
            {
                         audioSource.Stop();
            }
            if (lv == 5)
            {
                  if(ending.isPlaying == false)
                  {
                        ending.PlayOneShot(EndingBGM);
                  }
                  player.GetComponent<Player>().isfloat = false;
                  Invoke("moveoff", 5f);
                  Invoke("fade", 15f);
                  StartCoroutine(endingbgm());
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
             switchs.PlayOneShot(swichsoud);
             bgm = false;
            Fade.SetActive(true);
            Invoke("switchoff", 2f);
      }
      void switchoff()
      {
            switchs.enabled = false;
      }
      private void OnCollisionEnter2D(Collision2D collision)
      {
            if(collision.gameObject.tag == "Flag")
            {
                  i++;
                  Invoke("LvUp", 0f);
            }
      }
      IEnumerator endingbgm()
      {
            float t = 0f;
            while (t < 5f)
            {
                  t += Time.deltaTime;
                  ending.volume = Mathf.Lerp(0f, 0.4f, t / 5);
                  yield return null;
            }

            ending.volume = 0.4f;
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
