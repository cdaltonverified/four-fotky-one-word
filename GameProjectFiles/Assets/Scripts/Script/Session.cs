using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Session : Singletion<Session>
{
   public bool Replay;
   public int UnlockedCount;
    public int CurrentLevel;
    public int levelCount;
    public bool Loading=true;
   private void OnEnable()
   {
        int Value = PlayerPrefs.GetInt(Constants.SaveCurrentLevel, 0);
        Session.Instance.CurrentLevel = Value;

        UnlockedCount = PlayerPrefs.GetInt("UnLock", 1);
   }

   private void OnDisable()
   {
        PlayerPrefs.SetInt("UnLock", UnlockedCount);

   }

   private void OnApplicationPause(bool pauseStatus)
   {
       if (pauseStatus)
       {
           PlayerPrefs.SetInt("UnLock", UnlockedCount);
       }
       
   }
}
