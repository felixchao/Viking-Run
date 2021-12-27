using System.Collections;
using System.Collections.Generic;
using static System.Math;
using UnityEngine;

public class TileManager : MonoBehaviour
{

   public float[] vectorsx;
   public float[] vectorsz;
   public GameObject[] tilePrefabs;
   public float[] rot;
   // Start is called before the first frame update
   private Transform playerTransform;
   private float spawnz = -3.0f;
   private float spawnx = 0f;
   private float tileLength = 2.62f;
   public int amnTilesOnScreen = 20;
   public float safeZone = 10f;
   private int lastPrefabIndex;
   public bool repeat = false;
   public bool isleft = false;
   public bool isright = false;
   public int countleft = 0;
   public int countright = 0;
   private int index = 0;
   public GameObject rock;
   public GameObject cubeleft;
   public GameObject cuberight;
   private List<GameObject> activeTiles;
    void Start()
    {

      rot = new float[] { 0.0f, -90.0f, -180.0f, -270.0f };
      vectorsz = new float[] { 1 * tileLength, 0,-1 * tileLength, 0};
      vectorsx = new float[] { 0,1 * tileLength, 0,-1 * tileLength };
      activeTiles = new List<GameObject>();
      playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
      for(int i = 0; i < amnTilesOnScreen; i++)
      {
         SpawnTile(0);

      }
     
    }

    // Update is called once per frame
    void Update()
    {
      if(playerTransform.position.y <= -5)
      {
         return;
      }
        if(Vector3.Distance(playerTransform.position,activeTiles[0].GetComponent<Transform>().position) > 5 && playerTransform.position.y < 3)
      {
         SpawnTile();
         DeleteTile();
      }
    }

   private void SpawnTile(int prefabIndex = -1)
   {
      GameObject go;
      int rd1 = 0;
      if (prefabIndex == -1)
      {
         int rd = RandomPrefabIndex();
         rd1 = rd;
         go = Instantiate(tilePrefabs[rd]) as GameObject;
         if (rd == 0)
         {
            int r = Random.RandomRange(0, 10);
            int rk = Random.RandomRange(0, 10);
            if (r >= 4)
            {
               GameObject coin = go.transform.GetChild(3).gameObject;
               Destroy(coin);
            }
            if(rk <= 1 && r >= 4)
            {
               GameObject obstacle = Instantiate(rock,rock.transform.position,rock.transform.rotation);
               obstacle.transform.SetParent(go.transform);
               obstacle.transform.localPosition = new Vector3(0, 0, 0);
            }
         }
      }
      else
      {
         go = Instantiate(tilePrefabs[prefabIndex]) as GameObject;
         int r = Random.RandomRange(0, 10);
         if (r >= 4)
         {
            GameObject coin = go.transform.GetChild(3).gameObject;
            Destroy(coin);
         }
      }

      
      go.transform.SetParent(transform);
      go.transform.position = Vector3.forward * spawnz + Vector3.left * spawnx;
      go.transform.Rotate(0f,rot[index], 0f);
      activeTiles.Add(go);

      if(rd1 == 1)
      {
         GameObject wall = Instantiate(cubeleft, go.transform.position , cubeleft.transform.rotation);
         wall.transform.Rotate(0f, rot[index], 0f);
      }
      else if(rd1 == 3)
      {
         GameObject wall = Instantiate(cuberight, go.transform.position , cuberight.transform.rotation);
         wall.transform.Rotate(0f, rot[index], 0f);
      }

      if (isleft)
      {
         index++;
         if (index == 4)
         {
            index = 0;
         }
         spawnx += vectorsx[index];
         spawnz += vectorsz[index];

         isleft = false;
         countleft++;
      }
      else if (isright)
      {
         index--;
         if(index == -1)
         {
            index = 3;
         }
         spawnx += vectorsx[index];
         spawnz += vectorsz[index];

         isright = false;
         countright++;
      }
      else
      {
         if (index == 4)
         {
            index = 0;
         }
         spawnx += vectorsx[index];
         spawnz += vectorsz[index];
      }
      if (countleft != 0)
      {
         countleft++;
         if (countleft == 6)
         {
            countleft = 0;
         }
      }
      if(countright != 0)
      {
         countright++;
         if(countright == 6)
         {
            countright = 0;
         }
      }

    }
   private void DeleteTile()
   {
      Destroy(activeTiles[0]);
      activeTiles.RemoveAt(0);
   }

   private int RandomPrefabIndex()
   {
      if (repeat)
      {
         repeat = false;
         return 2;
      }
      if(tilePrefabs.Length <= 1)
      {
         return 0;
      }
      int randomIndex = lastPrefabIndex;
      while(randomIndex == lastPrefabIndex)
      {
         if ((countleft <= 5 && countleft > 0)||(countright <=5 &&countright > 0))
         {
            return 0;
         }
         else
         {
            randomIndex = Random.Range(0, tilePrefabs.Length);
         }
      }
      lastPrefabIndex = randomIndex;
      if(randomIndex == 2)
      {
         repeat = true;
      }else if(randomIndex == 1)
      {
         isleft = true;
      }else if(randomIndex == 3)
      {
         isright = true;
      }
      return randomIndex;
   }

}
