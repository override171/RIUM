using UnityEngine;

public class Player_useG : MonoBehaviour
{
      public bool inNong = false;
      public GameObject hitarea;
      GameObject hita;
      public bool haveG = false;
      public GameObject h;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
           h = GameObject.Find("Player");
    }

      // Update is called once per frame
      void Update()
      {
            hita = h.GetComponent<Player>().hitobj;
            //Debug.Log(hita.tag);
            //Debug.Log(haveG);
            use();
            if (hitarea == null || hitarea.tag != "NonG")
            {
                  inNong = false;
            }
            else if (hitarea.tag == "NonG") 
            {
                  inNong=true;
            }
    }
      void use()
      {
              if (Input.GetKeyDown(KeyCode.E))
              {
                  if(haveG == false)
                  {
                        if(hita.tag == "NonG")
                        {
                              //aaDebug.Log("whit washing");
                              hita.tag = "Default";
                              SpriteRenderer render = hita.GetComponent<SpriteRenderer>();
                              render.color = Color.white;
                              haveG = true;
                              return;
                        }
                  }
                  if (hita.tag == "Default")
                  {
                       if(haveG == true)
                       {
                              haveG = false;
                              hita.tag = "NonG";
                              SpriteRenderer render = hita.GetComponent<SpriteRenderer>();
                              render.color = Color.lightBlue;
                              Debug.Log("spit g");
                       }
                  }
              } 
      }
      private void OnTriggerEnter2D(Collider2D collision)
      {
            if(collision.gameObject.tag != "Ground")
            {
                  hitarea = collision.gameObject;
            }
      }
}
