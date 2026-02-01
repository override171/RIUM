using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class CutDirector : MonoBehaviour
{
      public PlayableDirector director;
      public CinemachineCamera Vcam;
      GameObject flag;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

      }

    // Update is called once per frame
    void Update()
    {
            flag = GameObject.Find("Flag");
      }
      private void OnCollisionEnter2D(Collision2D collision)
      {
            if(collision.gameObject.tag == "cut")
            {
                  Vcam.transform.position = new Vector3(flag.transform.position.x, flag.transform.position.y, Vcam.transform.position.z);
                  director.Play();
                  collision.gameObject.SetActive(false);
            }
      }
}
