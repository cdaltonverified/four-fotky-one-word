using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Close : MonoBehaviour
{
   private void OnEnable()
   {
        if (Session.Instance.Loading == true)
        {
            gameObject.SetActive(true);
            Invoke("Off", 3f);
        }
        else
        {
            Off();
        }
   }
    void Off()
    {
        gameObject.SetActive(false);
    }
}
