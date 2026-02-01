using UnityEngine;

public class Shutter : MonoBehaviour
{
      public GameObject shutter;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
      private void OnTriggerStay2D(Collider2D collision)
      {
            if(collision.gameObject.tag == "NonG")
            {
                  shutter.SetActive(true);
            }
            else if(collision.gameObject.tag == "Default")
            {
                  shutter.SetActive(false);
            }
      }
}
