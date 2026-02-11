using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
      int sp = 1;
      public BoxCollider2D[] box;
      Rigidbody2D rigid;
      Animator anim;
      public GameObject hitobj;
      LayerMask mask = 8;
      public GameObject hit;
      public int hitH = 0;
      Vector2 stPos;
      public float moveSpeed;
      public bool isfloat = false;
      public bool isEnd = false;
        float exx = 20f;
      float dxx = 25f;
      float maxx = 5f;

      bool canmove = true;
      bool ishitarea = false;
      float h;
      public float rotateSpeed;
      // please work
      float v;
      // Start is called once before the first execution of Update after the MonoBehaviour is created
      void Start()
      {
            rigid = GetComponent<Rigidbody2D>();
            mask = ~LayerMask.GetMask("Player", "Default");
            anim = GetComponent<Animator>();    
      }

      void Update()
      {
            isEnd = GameObject.Find("Player").GetComponent<LevelManager>().moveOff;
     
            if (isfloat)
            {
                  anim.SetBool("inNonG", true);
            }
            else
            {
                  anim.SetBool("inNonG", false);
            }
                  Vector2 rayOrigin = (Vector2)transform.position + (Vector2)transform.up * 1.2f;
            Debug.DrawRay(rayOrigin, transform.up * 0.3f, Color.green);
            RaycastHit2D hit2 = Physics2D.Raycast(rayOrigin, transform.up, 0.5f, mask);
            if(hit2.collider != null)
            {
                  if(hit2.collider.gameObject.GetComponent<lockdGArea>() != null)
                  {
                        hitobj = null;
                  }
                  else
                  {
                        hitobj = hit2.collider.gameObject;
                        ishitarea = true;
                  }
            }

            if (  hit == null || hit.tag != "NonG" || hit.tag == "Ground")
            {
                  rigid.gravityScale = 2;
                  isfloat = false;
            }
            else if (hit.tag == "NonG")
            {
                  rigid.gravityScale = 0;
                  isfloat = true;
            }
            if(!isEnd)
            {
                  if (canmove)
                  {
                        h = Input.GetAxisRaw("Horizontal");
                        v = Input.GetAxisRaw("Vertical");

                        if (h != 0 && isfloat == false)
                        {
                              transform.localScale = new Vector3(Mathf.Sign(h), 1, 1);
                              anim.SetBool("isWalk", true);
                              box[0].enabled = false;
                              box[1].enabled = true;
                        }
                        else
                        {
                              anim.SetBool("isWalk", false);
                              box[0].enabled = true;
                              box[1].enabled = false;
                        }
                  }
                  else
                  {
                        if (h > 0)
                        {
                              h = 0.8f;
                        }
                        else if (h < 0)
                        {
                              h = -0.8f;
                        }
                        v = -1;
                  }
            }
      }

         
          
      void FixedUpdate()
      {
            move();
            //Debug.Log(rotateSpeed);
      }
      void move()
      {
            if (!isEnd)
            {
                  // 1. 물속에 있을 때 (수영)
                  if (isfloat)
                  {
                        moveSpeed = 2.5f;
                        rigid.linearVelocity = new Vector2(h * moveSpeed, v * moveSpeed);

                        bool hasInput = h != 0 || v != 0;
                        anim.SetBool("isSwim", hasInput);

                        // 회전 목표 각도 설정
                        float targetZ = 0f; // 기본값 (입력이 없거나 위로 갈 때 0도)

                        // 입력에 따른 우선순위 로직 (원래 코드의 의도를 반영하여 정리)
                        if (v < 0)
                        {
                              targetZ = 180f; // 아래로 갈 때
                        }
                        else if (v > 0)
                        {
                              targetZ = 0f;   // 위로 갈 때
                        }
                        else if (h > 0)
                        {
                              targetZ = -90f; // 오른쪽으로 갈 때 (-90도)
                        }
                        else if (h < 0)
                        {
                              targetZ = 90f;  // 왼쪽으로 갈 때 (90도)
                        }
                        else
                        {
                              targetZ = 0f;   // 입력이 없을 때 원래대로 복귀
                        }

                        // 현재 각도에서 목표 각도로 부드럽게 회전 (360도 회전 문제 해결)
                        // MoveTowardsAngle은 0도와 360도 경계 문제를 자동으로 처리해줍니다.
                        float currentZ = transform.eulerAngles.z;
                        float nextZ = Mathf.MoveTowardsAngle(currentZ, targetZ, 410f * Time.deltaTime);

                        transform.rotation = Quaternion.Euler(0f, 0f, nextZ);
                  }

                  else
                  {
                        //moveSpeed = 5f;
                        if(h > 0)
                        {
                              sp = 1;
                              //StartCoroutine(speedUp());
                        }
                        else if(h < 0)
                        {
                              sp = -1;
                              //StartCoroutine(speedUp());
                        }

                        // Y축 속도는 유지해야 중력이 작용함 (rigid.linearVelocity.y 사용)


                        // 회전 초기화
                        float targersp = h * maxx;
                        float currentsp = rigid.linearVelocityX;
                        if(Mathf.Abs(h) > 0.01f)
                        {
                              currentsp = Mathf.MoveTowards(currentsp, targersp, exx * Time.fixedDeltaTime);
                        }
                        else
                        {
                              currentsp = Mathf.MoveTowards(currentsp, 0f, dxx * Time.fixedDeltaTime);
                        }
                        rigid.linearVelocity = new Vector2(currentsp, rigid.linearVelocity.y);
                        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                        anim.SetBool("isSwim", false);
                  }
            }
      }
      private void OnTriggerEnter2D(Collider2D collision)
      {
            hitH = 0;

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
            Collider2D[] col = Physics2D.OverlapCircleAll(transform.position, 5f);
            foreach (Collider2D col2 in col)
            {
                  if(col2.gameObject.tag == "Ground" || col2.gameObject.tag == "NonG")
                  {
                        canmove = true;
                  }
            }
            if (collision.gameObject.tag != "Ground")
            {
                  hit = collision.gameObject;
            }

            if (collision.gameObject.tag != "Ground")
            {
                  hit = collision.gameObject;
            }
      }
}
