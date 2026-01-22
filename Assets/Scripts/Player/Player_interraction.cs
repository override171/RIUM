using UnityEngine;

public class Player_interraction : MonoBehaviour
{
      bool haveKey = false;
      public GameObject Key;
      public GameObject[] door;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
      private void OnCollisionEnter2D(Collision2D collision)
      {
            if(collision.gameObject.tag == "Key")
            {
                  haveKey = true;
                  Key.SetActive(false);
            }
            if(collision.gameObject.tag == "Door" && haveKey)
            {
                  haveKey = false;
                  door[0].SetActive(false);
                  door[1].SetActive(false);
            }
      }
}
