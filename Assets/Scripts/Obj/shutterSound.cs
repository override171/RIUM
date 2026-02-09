using UnityEngine;

public class shutterSound : MonoBehaviour
{
      public AudioClip sound;
      AudioSource audioSource;
      bool played = false;    
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
            if (collision.gameObject.tag == "NonG" || collision.gameObject.tag == "Default")
            {
                  played = false;
            }
      }
      void OnTriggerExit2D(Collider2D collision)
      {
            if (collision.gameObject.tag == "NonG" || collision.gameObject.tag == "Default")
            {
                  played = false;
            }
      }
      private void OnTriggerStay2D(Collider2D collision)
      {
            if (collision.gameObject.tag == "NonG")
            {
                  if (!audioSource.isPlaying)
                  {
                        if (played == true) return;
                        audioSource.PlayOneShot(sound);
                  }
                  played = true;
            }
            else if (collision.gameObject.tag == "Default")
            {

            }
      }
}
