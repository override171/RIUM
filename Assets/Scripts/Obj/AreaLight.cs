using UnityEngine;

public class AreaLight : MonoBehaviour
{
      public GameObject arealight;
      public GameObject area;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            if(area.tag == "NonG")
            {
                  arealight.SetActive(true);
            }
            else
            {
                  arealight.SetActive(false);
            }
    }
}
