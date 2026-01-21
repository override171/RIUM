using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
      Rigidbody2D rigid;
      public GameObject hitobj;
      LayerMask mask = 8;
      public GameObject hit;
      public float moveSpeed;
      public bool isfloat = false;
      bool canmove = true;
      bool ishitarea = false;
      float h;
      // please work
      float v;
      // Start is called once before the first execution of Update after the MonoBehaviour is created
      void Start()
      {
          rigid = GetComponent<Rigidbody2D>();
            mask = ~LayerMask.GetMask("Player", "Default");
      }

      void Update()
      {
            Vector2 rayOrigin = (Vector2)transform.position + (Vector2)transform.up * 0.8f;
            Debug.DrawRay(rayOrigin, transform.up * 0.3f, Color.green);
            RaycastHit2D hit2 = Physics2D.Raycast(rayOrigin, transform.up, 0.5f, mask);
            if(hit2.collider != null)
            {
                  hitobj = hit2.collider.gameObject;
                  ishitarea = true;
            }

            if (  hit == null || hit.tag != "NonG" || hit == null)
            {
                  isfloat = false;
            }
            else if (hit.tag == "NonG")
            {
                  isfloat = true;
            }

            if (canmove)
            {
                  h = Input.GetAxisRaw("Horizontal");
                  v = Input.GetAxisRaw("Vertical");
            }
            else
            {
                  if(h > 0)
                  {
                        h = 1;
                  }
                  else if(h < 0)
                  {
                        h = -1;
                  }
                  v = -1;
            }
      }

      void FixedUpdate()
      {
            move();
      }
      void move()
      {
             if (isfloat == true)
             {
                  rigid.linearVelocity = new Vector2(h * moveSpeed, v * moveSpeed);
                  if(h < 0)
                  {
                        transform.rotation = Quaternion.Euler(0f, 0f, 90f);
                  }
                  else if(h > 0)
                  {
                        transform.rotation = Quaternion.Euler(0f, 0f, -90f);
                  }
                  if(v >0)
                  {
                        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                  }
                  else if(v < 0)
                  {
                        transform.rotation = Quaternion.Euler(0f, 0f, 180f);
                  }
             }
            else if(isfloat == false)
             {
                  //Debug.Log("out");
                  transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                  rigid.linearVelocity = new Vector2(h * moveSpeed, rigid.linearVelocityY);
             }
      }
      private void OnTriggerEnter2D(Collider2D collision)
      {
            if (collision.gameObject.tag != "Ground")
            {
                  hit = collision.gameObject;
            }
      }
      private void OnTriggerExit2D(Collider2D collision)
      {
            //hit = null;
            if (collision.gameObject.tag == "NonG")
            {
                  isfloat = false;
                  Debug.Log("isfloat false");
            }
      }
      private void OnTriggerStay2D(Collider2D collision)
      {
            if (collision.gameObject.tag != "Ground")
            {
                  hit = collision.gameObject;
            }
            if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "NonG")
            {
                  canmove = true;
            }
            else
            {
                  canmove = false;
            }
      }
}
