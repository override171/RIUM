using UnityEngine;

public class Lever_platform : MonoBehaviour
{
      public GameObject platform;
      public GameObject lever;
      GameObject platformChecker;
      float degree = 30;
      bool platformcont = false;
      GameObject plat;
      public float moveSp;
      bool canLever = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
            plat = GameObject.Find("Platform");
            platformChecker = GameObject.Find("Platform");
    }

    // Update is called once per frame
    void Update()
    {
            platformcont = platformChecker.GetComponent<Platform>().wallhit;
        moveSp = plat.GetComponent<Platform>().speed;
            if (canLever)
            {
                  if (platformcont)
                  {
                        if (Input.GetKeyDown(KeyCode.Q))
                        {
                              if (platformcont)
                              {
                                    degree = -1 * degree;
                                    plat.GetComponent<Platform>().isOn = true;
                                    Debug.Log("Lever On");
                                    lever.transform.rotation = Quaternion.Euler(0, 0, degree);
                              }
                        }
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
