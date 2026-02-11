
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class StartIN : MonoBehaviour
{
      public Image[] obs;
      public GameObject btn;
      public AudioSource aud;
      public float fadeDuration = 5f;

      private bool isFading = false;

      void Update()
      {
            if (Input.anyKeyDown && !isFading)
            {
                    aud.Play();
                  Invoke("Off", 0.3f);
                  btn.SetActive(false);
                  StartCoroutine(FadeIn());
            }
      }
      void Off()
      {
            aud.enabled = false;
      }

      IEnumerator FadeIn()
      {
            isFading = true;

            float t = 0f;

            while (t < fadeDuration)
            {
                  t += Time.deltaTime;
                  float alpha = Mathf.Clamp01(1f - (t / fadeDuration)); // 1 → 0

                  foreach (Image img in obs)
                  {
                        Color c = img.color;
                        c.a = alpha;
                        img.color = c;
                  }
                  yield return null;
            }

            // 완전히 투명하게 고정
            foreach (Image img in obs)
            {
                  Color c = img.color;
                  c.a = 0f;
                  img.color = c;
            }
      }
}
