using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class DeathMenu : MonoBehaviour
{
   public TextMeshProUGUI scoretext;
   public TextMeshProUGUI scoreboard;
   public Image backgroundImage;
   private bool isshowned = false;

   private float transition = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
      gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
      if (!isshowned)
      {
         return;
      }
      transition += Time.deltaTime;
      backgroundImage.color = Color.Lerp(new Color(0, 0, 0, 0), Color.black, transition);
    }

   public void ToggleEndMenu(float time, int score)
   {
      gameObject.SetActive(true);
      scoretext.text = ((int)time).ToString();
      scoreboard.text = score.ToString();
      isshowned = true;
   }

   public void Restart()
   {
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
   }

   public void ToMenu()
   {
      SceneManager.LoadScene("Menu");
   }
}
