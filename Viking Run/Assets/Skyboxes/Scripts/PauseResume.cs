using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PauseResume : MonoBehaviour
{
   public GameObject PauseScreen;
   public GameObject PauseButton;
   public GameObject Timer;
   public GameObject score;
   public GameObject scoreboard;
   public GameObject timescore;
   public GameObject timescoreboard;

   bool GamePaused;
    // Start is called before the first frame update
    void Start()
    {
      GamePaused = false;
    }

    // Update is called once per frame
    void Update()
    {
      if (GamePaused)
      {
         Time.timeScale = 0;
      }
      else
      {
         Time.timeScale = 1;
      }
    }

   public void Paused()
   {
      GamePaused = true;
      PauseScreen.SetActive(true);
      PauseButton.SetActive(false);
      Timer.SetActive(false);
      score.SetActive(false);
      scoreboard.SetActive(false);
      timescore.SetActive(false);
      timescoreboard.SetActive(false);
   }

   public void ResumeGame()
   {
      GamePaused = false;
      PauseScreen.SetActive(false);
      PauseButton.SetActive(true);
      Timer.SetActive(true);
      score.SetActive(true);
      scoreboard.SetActive(true);
      timescore.SetActive(true);
      timescoreboard.SetActive(true);
   }
}
