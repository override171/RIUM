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
                  collobj.SetActive(false);
                  Invoke("Dest", 3f);
            }
      }
      void Dest()
      {
            CancelInvoke();
            tutotext[uiNum].SetActive(false);
            uiNum++;
      }
}
