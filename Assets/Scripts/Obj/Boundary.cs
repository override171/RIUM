using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
      Rigidbody2D rigid;
      BoxCollider2D box;
      GameObject check;
      public GameObject boundary;
      bool inG = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
            rigid = GetComponent<Rigidbody2D>();
            box = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
            check = GameObject.Find("Player").GetComponent<Player>().hit;
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                  //Debug.Log("remove");
                  box.excludeLayers = 1 << 3;
                  Invoke("rebuild", 0.5f);
            }
            //Debug.Log(check.tag);
      }
      void rebuild()
      {
            CancelInvoke();
            box.excludeLayers = 0;
      }
      private void OnCollisionEnter2D(Collision2D collision)
      {
            if(check != null)
            {
                  if (check.tag == "Default")
                  {
                        Debug.Log("remove");
                        box.excludeLayers = 1 << 3;
                        Invoke("rebuild", 0.8f);
                  }
            }
      }
      private void OnCollisionStay2D(Collision2D collision)
      {
                  if (check == null || check.tag == "Default")
                  {
                        box.excludeLayers = 1 << 3;
                        Invoke("rebuild", 2f);
                  }
            if (collision.gameObject.tag == "Player")
            {
                  inG = true;
            }
      }
      private void OnTriggerStay2D(Collider2D collision)
      {
            if(collision.gameObject.tag == "NonG")
            {
                  boundary.layer = 12;
            }
      }
      private void OnTriggerExit2D(Collider2D collision)
      {
                boundary.layer = 0;
      }
}
