
using Unity.Cinemachine;
using UnityEngine;

public class CamTest : MonoBehaviour
{
      public CinemachineCamera cam;
      public GameObject player;
      CinemachinePositionComposer framing;

      void Start()
      {
            cam.TryGetComponent(out framing);
      }

      void Update()
      {
            transform.position = player.transform.position;
      }

      void SetScreenPos(float x, float y)
      {
            framing.Composition.ScreenPosition = Vector2.Lerp(framing.Composition.ScreenPosition, new Vector2(x, y), Time.deltaTime);
      }

      private void OnTriggerStay2D(Collider2D collision)
      {
            if (collision.gameObject.tag == "Camline")
            {
                  Debug.Log("enter");
                  SetScreenPos(0, -0.4f);
            }
      }
      private void OnTriggerExit2D(Collider2D collision)
      {
            if(collision.gameObject.tag == "Camline")
            {
                  SetScreenPos(0, 0);
            }
      }
}
