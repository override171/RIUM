using UnityEngine;

public class Platform : MonoBehaviour
{
      public float speed = 100;
      public bool isOn = false;
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
            if (collision != null)
            {
                  Debug.Log("contact");//layer override on
                  isOn = false;
                  speed = speed * -1;
                  return;
            }
      }
}
