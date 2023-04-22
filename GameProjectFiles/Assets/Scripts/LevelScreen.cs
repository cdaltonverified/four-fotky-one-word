using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelScreen : MonoBehaviour
{
    public static LevelScreen Instance;
    public Sprite LockSprite;
    public List<GameObject> LockOnlevel;
    public List<Sprite> LockOnlevelsp;
    private void Awake()
    {
        Instance = this;
    }
    private void OnEnable()
    {
     
        for (int i = 0; i < LevelData.Instance.Levels.Count; i++)
        {
            if(LevelData.Instance.Levels[i].Isopened)
            {
                LockOnlevel[i].GetComponent<Image>().sprite = LockOnlevelsp[i];
                LockOnlevel[i].GetComponent<Button>().interactable = true;
               
            }
            else
            {
                LockOnlevel[i].GetComponent<Image>().sprite = LockSprite;
                LockOnlevel[i].GetComponent<Button>().interactable = false;
            }
        }
    }
    public void LevelClick(int Index)
    {
        SoundManager.Instance.PlayOnshootSound(SoundManager.Instance.Click);
        if (Index == 0)
        {
            if (Session.Instance.CurrentLevel > 0 && Session.Instance.CurrentLevel < 50)
            {

            }
            else
            {
                Session.Instance.CurrentLevel = 0;

            }
        }
       
      else  if (Index == 1)
        {
            if (Session.Instance.CurrentLevel>49&&Session.Instance.CurrentLevel<100)
            {

            }
            else
            {
                Session.Instance.CurrentLevel = 50;
               
            }

        }
       else if (Index == 2)
        {
            if (Session.Instance.CurrentLevel > 99 && Session.Instance.CurrentLevel < 150)
            {

            }
            else
            {
                Session.Instance.CurrentLevel = 100;

            }
        }
      else  if (Index == 3)
        {
            if (Session.Instance.CurrentLevel > 149 && Session.Instance.CurrentLevel < 200)
            {

            }
            else
            {
                Session.Instance.CurrentLevel = 150;

            }
        }
      else  if (Index == 4)
        {
            if (Session.Instance.CurrentLevel > 199 && Session.Instance.CurrentLevel < 250)
            {

            }
            else
            {
                Session.Instance.CurrentLevel = 200;

            }
        }
        CanvasManager.Instance.Gamestate = States.GamePlayPanel;

    }
}
