using UnityEngine;

public class Platform : MonoBehaviour
{
      public float speed;
      public bool isOn = false;
      public bool wallhit = true;
      SpriteRenderer spder;
      Rigidbody2D rigid;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spder = GetComponent<SpriteRenderer>();
            rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
            if (isOn)
            {
                  rigid.AddForce(Vector2.right * Time.deltaTime * speed);
            }
            else
            {
                  rigid.linearVelocity= Vector2.zero;
            }
      }
      private void OnTriggerEnter2D(Collider2D collision)
      {
            Debug.Log(collision.gameObject.layer);
            if (collision.gameObject.layer == 13)
            {
                  Debug.Log("contact");//layer override on
                  isOn = false;
                  speed = speed * -1;
            }
      }
      private void OnTriggerStay2D(Collider2D collision)
      {
            if(collision.gameObject.layer == 13)
            {
                  wallhit = true;
            }
      }
      private void OnTriggerExit2D(Collider2D collision)
      {
            if (collision.gameObject.layer == 13)
            {
                  wallhit = false;
            }
      }
}
