using UnityEngine;

public class BGMPlayer : MonoBehaviour
{
      public AudioSource[] bgmSource;
      GameObject player;
      int i = 0;
      bool bgmplay = false;
      // Start is called once before the first execution of Update after the MonoBehaviour is created
      void Start()
    {

            InvokeRepeating("PlayBGM", 30f, 60f);
            player = GameObject.Find("Player");
      }

    // Update is called once per frame
    void Update()
    {
            if(player.GetComponent<LevelManager>().lv == 1)
            {
                  bgmplay = true;
            }
            if (player.GetComponent<LevelManager>().lv == 5)
            {
                  bgmSource[0].Stop();
                  bgmSource[1].Stop();
                  return;
            }
    }
      void PlayBGM()
      {
            if(bgmplay)
            {
                  bgmSource[i].Play();
                  i++;
                  if (i >= bgmSource.Length)
                  {
                        i = 0;
                  }
            }
      }
}
