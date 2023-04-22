using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{
    public RectTransform[] spawnPoints;
    public GameObject Coins;
    void Start()
    {
        StartCoroutine(nameof(Spawn));
    }
    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(3);

        while (CanvasManager.Instance.Gamestate == States.GamePlayPanel)
        {
                int randomSpawnPoint = Random.Range(0, spawnPoints.Length);
           Instantiate(Coins, spawnPoints[randomSpawnPoint].position, Quaternion.identity);
                yield return new WaitForSeconds(2);
            
        }
        yield return new WaitUntil(() => CanvasManager.Instance.Gamestate != States.GamePlayPanel);
        StartCoroutine(nameof(Spawn));
    }
   
  
}