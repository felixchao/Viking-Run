using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
   public Chase wolf;
   public DeathMenu deathMenu;
   public TextMeshProUGUI text;
   public TextMeshProUGUI scoretext;
   public Transform player;
   public float time = 0.0f;
   public int score = 0;
   public bool isdead = false;
   
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
      if (player.position.y <= -5||wolf.isdead)
      {
         deathMenu.ToggleEndMenu(time,score);
         return;
      }
      time += Time.deltaTime;
      text.text = ((int)time).ToString();
      score = int.Parse(scoretext.text);
   }


}
