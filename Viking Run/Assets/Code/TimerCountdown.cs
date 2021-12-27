using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class TimerCountdown : MonoBehaviour
{
   public GameObject gameObject;
   public GameObject wolf;
   public TextMeshProUGUI textscore;
   public TextMeshProUGUI textDisplay;
   public int secondsleft = 3;
   public bool isgrounded = true;
   private void Start()
   {
      StartCoroutine(TimerTake());
     
   }

   private void Update()
   {
      if (isgrounded)
      {
         wolf.GetComponent<Transform>().position = new Vector3(0f, 0f, -6f);
         gameObject.GetComponent<Transform>().localPosition = new Vector3(0f, 0f, 0f);
         GetComponent<Score>().time = 0;
         textscore.text = "0";
      }
   }


   IEnumerator TimerTake()
   {
      
      while (secondsleft > 0)
      {
         
         textDisplay.text = secondsleft.ToString();
         yield return new WaitForSeconds(1);
        

         secondsleft--;
      }
      
      textDisplay.text = "Go!";
      isgrounded = false;

      yield return new WaitForSeconds(1);

      
      textDisplay.gameObject.SetActive(false);
      Destroy(textDisplay);
   }

   

}
