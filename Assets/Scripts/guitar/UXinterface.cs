using UnityEngine;

public class UXinterface : MonoBehaviour
{
      public GameObject[] tutotext;
      GameObject collobj;
      public int uiNum = 0;
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
            if (collision.gameObject.tag == "tuto")
            {
                  tutotext[uiNum].SetActive(true);
                  collobj = collision.gameObject;
                  Invoke("Dest", 2.3f);
            }
      }
      void Dest()
      {
            CancelInvoke();
            collobj.SetActive(false);
            tutotext[uiNum].SetActive(false);
            uiNum++;
      }
}
