using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class BGMPlayer : MonoBehaviour
{
      public AudioSource[] bgmSource;
      GameObject player;
      int i = 0;
      // Start is called once before the first execution of Update after the MonoBehaviour is created
      void Start()
      {
            bgmSource[0].volume = 0f;
            bgmSource[1].volume = 0f;
            InvokeRepeating("PlayBGM", 5f, 60f);
            //PlayBGM();
            player = GameObject.Find("Player");
      }

    // Update is called once per frame
    void Update()
    {
            if (player.GetComponent<LevelManager>().lv == 5)
            {
                  bgmSource[0].Stop();
                  bgmSource[1].Stop();
                  return;
            }
    }
      IEnumerator FadeIn()
      {
            float t = 0f;
            while (t < 5f)
            {
                  t += Time.deltaTime;
                  bgmSource[i].volume = Mathf.Lerp(0f, 0.3f, t / 5);
                  yield return null;
            }

            bgmSource[i].volume = 0.3f;
            i++;
      }
      void PlayBGM()
      {
            CancelInvoke("PlayBGM");
            AudioSource src = bgmSource[i];
            src.volume = 0f;
            src.Play();
            StartCoroutine("FadeIn");

            if (i >= bgmSource.Length)
                  i = 0;
      }
}
