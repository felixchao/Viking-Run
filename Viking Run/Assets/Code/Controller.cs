using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Controller : MonoBehaviour
{
   public Chase wolf;
   public Vector3 MovingDirection;
   public float JumpingForce;
   public float Gravity = -20f;
   public TextMeshProUGUI score;
   private bool isdead = false;
   Rigidbody rb;
   Animator animator;
   

   [SerializeField] float movingspeed = 10f;
   [SerializeField] int onGround = 1; 
      bool run = false;
   

   // Start is called before the first frame update
   void Start()
    {
      animator = GetComponent<Animator>();
      rb = GetComponent<Rigidbody>();
      
    }

   // Update is called once per frame
   [SerializeField] Vector3[] nowVector = new Vector3[]{new Vector3(0f,-9f,0f),new Vector3(0f,9f,0f) };
   [SerializeField]int timer = 10;

   int now = 0; 
   void Update()
    {

      if(transform.position.y <= -5||wolf.isdead)
      {
         animator.SetBool("Die", true);
         return;
      }

      run = false;

   
      if (timer >= 10)
      {
         timer = 10;
  
      }
      else
      {
         transform.Rotate(nowVector[now]);
         timer++;
      }
      if (Input.GetKey(KeyCode.W))
      {
         transform.Translate(movingspeed * Time.deltaTime * Vector3.forward);
         run = true;
      }
      if (Input.GetKeyDown(KeyCode.A))
      {
         if(timer == 10)
         {
            now = 0;
            run = true;
            timer = 0;
         }
      }
       if (Input.GetKeyDown(KeyCode.D))
      {

         if (timer == 10)
         {
            now = 1;
            run = true;
            timer = 0;
         }
      }
      animator.SetBool("Run", run);

      
         if (Input.GetKeyDown(KeyCode.Space)&&onGround == 1)
         {
          
           rb.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
           onGround = 0;

      }
      
 
      
   }
   void OnCollisionEnter(Collision collision)
   {
      if (collision.gameObject.tag == "Ground")
      {
         onGround = 1;
      }
      if(collision.gameObject.tag == "Coin")
      {
         Destroy(collision.gameObject);
         score.text = (int.Parse(score.text) + 1).ToString();
      }

   }









}
