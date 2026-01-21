using UnityEngine;
using UnityEngine.UI;

public class don : MonoBehaviour
{
      Rigidbody2D rigid;
      GameObject player;
      LayerMask mask = 12;
      Vector2 posvec;
      bool hiting = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
            player = GameObject.Find("Player");
            mask = LayerMask.GetMask("BD");
    }

    // Update is called once per frame
    void Update()
    {
            if(hiting == false)
            {
                  posvec = (player.transform.position - transform.position).normalized;
            }
        rigid.linearVelocity = posvec * 500 * Time.deltaTime;
            raycheck();
    }
      void raycheck()
      {
            Vector2 rayOrigin = (Vector2)transform.position + (Vector2)transform.up * 1f;
            Vector2 rayOriginD = (Vector2)transform.position + (Vector2)transform.up * -1f;
            Vector2 rayOriginR = (Vector2)transform.position + (Vector2)transform.right * 1f;
            Vector2 rayOriginL = (Vector2)transform.position + (Vector2)transform.right * -1f;
            Debug.DrawRay(rayOrigin, transform.up * 0.3f, Color.green);
            Debug.DrawRay(rayOriginD, transform.up* -1 * 0.3f, Color.green);
            Debug.DrawRay (rayOriginR, transform.right * 0.3f, Color.green);
            Debug.DrawRay(rayOriginL, transform.right * -1 * 0.3f, Color.green);
            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, transform.up, 0.5f, mask);
            RaycastHit2D hit2 = Physics2D.Raycast(rayOriginD, transform.up, 0.5f * -1, mask );
            RaycastHit2D hit3 = Physics2D.Raycast(rayOriginR, transform.right, 0.5f, mask);
            RaycastHit2D hit4 = Physics2D.Raycast(rayOriginL, transform.right, 0.5f * -1, mask);
            if (hit3 || hit4)
            {
                  posvec = Vector2.up;
                  hiting = true;
                  Debug.Log("left");
            }
            else if (hit || hit2)
            {
                  posvec = Vector2.right;
                  hiting = true;
            }
            else
            {
                  hiting = false;
            }
      }
}
