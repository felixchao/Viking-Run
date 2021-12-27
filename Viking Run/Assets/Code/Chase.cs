using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Chase : MonoBehaviour
{
   public GameObject Player;
   public float speed = 9.0f;
   private int index = 0;
   public Vector3[] rotation;
   public Vector3[] rot;
   public bool isrepeat = false;
   public bool isdead = false;
    // Start is called before the first frame update
    void Start()
    {
      rotation = new Vector3[] { Vector3.forward, Vector3.left, Vector3.back, Vector3.right };
      rot = new Vector3[] { new Vector3(0, 0, 0), new Vector3(0, -90, 0), new Vector3(0, -180, 0), new Vector3(0, -270, 0) };
    }

    // Update is called once per frame
    void Update()
    {
      if (isdead)
      {
         
         return;
      }
      if(Vector3.Distance(Player.transform.position,transform.position) >= 9)
      {
         speed = 16.0f;
      }
      else
      {
         speed = 9.0f;
      }
      transform.Translate(speed * Time.deltaTime *Vector3.forward);
  
   }

   private void OnTriggerEnter(Collider other)
   {
  
      if(other.gameObject.tag == "Player")
      {
         isdead = true;
      }
      if (other.gameObject.tag == "left" )
      {

         index++;
         if(index == 4)
         {
            index = 0;
         }
         transform.eulerAngles = rot[index];
         Destroy(other);
      }

      if (other.gameObject.tag == "right")
      {
         index--;
         if(index == -1)
         {
            index = 3;
         }
         transform.eulerAngles = rot[index];
         Destroy(other);
      }
      
   }

}
