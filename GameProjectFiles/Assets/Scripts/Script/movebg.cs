using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movebg : MonoBehaviour
{
    private void Start()
    {
       Vector3 size=Camera.main.ViewportToWorldPoint(Vector3.one);
       size.z = 0;
       transform.localScale = size * 2;
        StartCoroutine(move());
    }
  
    IEnumerator move()
   {
      Material mat = GetComponent<Renderer>().material;
          float offst = 0;
      while (true)
      {
          mat.mainTextureOffset = new Vector2(offst, 0);
          offst += 0.1f*Time.deltaTime;
      yield return new WaitForEndOfFrame();
      }
   }
}
