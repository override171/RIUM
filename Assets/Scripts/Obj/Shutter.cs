using UnityEngine;

public class Shutter : MonoBehaviour
{
      public GameObject shutter;
      public AudioClip sound;
      AudioSource audioSource;
      // Start is called once before the first execution of Update after the MonoBehaviour is created
      void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
      }

    // Update is called once per frame
    void Update()
    {
        
    }
      void OnTriggerEnter2D(Collider2D collision)
      {
            if(collision.gameObject.tag == "NonG")
            {
                  audioSource.PlayOneShot(sound);
            }
            else if(collision.gameObject.tag == "Default")
            {
                  audioSource.PlayOneShot(sound);
            }
      }
      private void OnTriggerStay2D(Collider2D collision)
      {
            if(collision.gameObject.tag == "NonG")
            {
                  shutter.SetActive(true);
                  audioSource.PlayOneShot(sound);
            }
            else if(collision.gameObject.tag == "Default")
            {
                  shutter.SetActive(false);
            }
      }
}
