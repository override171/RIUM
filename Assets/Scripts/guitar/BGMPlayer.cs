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
            InvokeRepeating("PlayBGM", 5f, bgmSource[i].clip.length);
            //PlayBGM();
            player = GameObject.Find("Player");
      }

    // Update is called once per frame
    void Update()
    {
            if (player.GetComponent<LevelManager>().lv == 5)
            {
                  if (bgmSource[0].isPlaying)
                  {
                        StartCoroutine(FadeOut(bgmSource[0]));
                  }
                  else if (bgmSource[1].isPlaying)
                  {
                        StartCoroutine(FadeOut(bgmSource[1]));
                  }
            }
    }
      void PlayBGM()
      {
            if (i >= bgmSource.Length)
                  i = 0;

            Debug.Log("Play BGM index: " + i);

            AudioSource src = bgmSource[i];
            src.volume = 0f;
            src.Play();

            StartCoroutine(FadeIn(src));

            i++;
      }
      IEnumerator FadeOut(AudioSource src)
      {
            float t = 0f;
            while (t < 3f)
            {
                  t += Time.deltaTime;
                  src.volume = Mathf.Lerp(0.3f, 0f, t / 3f);
                  yield return null;
            }
            src.volume = 0f;
            bgmSource[0].enabled = false;
            bgmSource[1].enabled = false;
      }

      IEnumerator FadeIn(AudioSource src)
      {
            float t = 0f;
            while (t < 5f)
            {
                  t += Time.deltaTime;
                  src.volume = Mathf.Lerp(0f, 0.3f, t / 5f);
                  yield return null;
            }
            src.volume = 0.3f;
      }
}
