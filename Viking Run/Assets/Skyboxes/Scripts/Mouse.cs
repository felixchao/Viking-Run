using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      if (Input.GetMouseButtonDown(0))
      {
         Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
         RaycastHit raycastHit;
         if (Physics.Raycast(r, out raycastHit))
         {
            Destroy(raycastHit.collider.gameObject);
         }
      }
   }
}
