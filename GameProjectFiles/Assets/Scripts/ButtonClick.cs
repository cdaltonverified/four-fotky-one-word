using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour
{
   public States ClickState;
   private void OnEnable()
   {
      GetComponent<Button>().onClick.RemoveAllListeners();
      GetComponent<Button>().onClick.AddListener(OnClick);
      
   }

   void OnClick()
   {
        Debug.Log("Button Click Sounds");
        SoundManager.Instance.PlayOnshootSound(SoundManager.Instance.Click);
      
      CanvasManager.Instance.Gamestate = ClickState;
   }
}
