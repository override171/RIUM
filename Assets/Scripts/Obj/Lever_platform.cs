using UnityEngine;

public class Lever_platform : MonoBehaviour
{
      public GameObject platform;
      GameObject plat;
      public float moveSp;
      bool canLever = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
            plat = GameObject.Find("Platform");
    }

    // Update is called once per frame
    void Update()
    {
        moveSp = plat.GetComponent<Platform>().speed;
            if (canLever)
            {
                  if (Input.GetKeyDown(KeyCode.Q))
                  {
                        plat.GetComponent<Platform>().isOn = true;
                        Debug.Log("Lever On");
                  }
            }
    }
      private void OnTriggerEnter2D(Collider2D collision)
      {
  
      }
      private void OnTriggerStay2D(Collider2D collision)
      {
            if (collision.gameObject.tag == "Player")
            {
                  canLever = true;
            }
            else
            {
                  canLever = false;
            }
      }
}
