using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audiosound : MonoBehaviour
{
   GameObject gamebutton;
   private void Awake()
   {
      transform.gameObject.SetActive(true);
      DontDestroyOnLoad(transform.gameObject);
   }

   public void Stop()
   {
      transform.gameObject.SetActive(false);
   }
}
