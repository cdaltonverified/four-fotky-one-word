using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class Level
{
  public bool Isopened;
}
public class LevelData : Singletion<LevelData>
{
  public List<Level> Levels;

  private void OnEnable()
  {
    if (ES3.KeyExists("Levels"))
    {
      Levels = ES3.Load("Levels") as List<Level>;
    }
  }

  private void OnDisable()
  {
    ES3.Save("Levels",Levels);
  }

  private void OnApplicationPause(bool pauseStatus)
  {
    if(!pauseStatus) return;
    ES3.Save("Levels",Levels);

  }
}
