using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="CL")]
public class Levels : ScriptableObject
{
    public int LevelNumber;
    public int levelNum;
    public string correctkeyword;
    public List<Sprite> _LevelImages;   
}
