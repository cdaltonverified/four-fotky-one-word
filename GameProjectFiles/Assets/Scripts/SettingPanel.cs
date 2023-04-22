using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SettingPanel : MonoBehaviour
{
    public List<Sprite> ButtonsSound;
    //public List<Sprite> ButtonsMusic;
    //public List<Sprite> ButtonsVib;
    public Image SoundSprite;
    public Image MusicSprite;
    public Image VibrationSprites;
   
    private void OnEnable()
    {
      
      //  MusicSprite.sprite = ButtonsMusic[PlayerPrefs.GetInt(Constants.music, 1)];
        SoundSprite.sprite = ButtonsSound[PlayerPrefs.GetInt(Constants.Sound, 1)];
       // VibrationSprites.sprite = ButtonsVib[PlayerPrefs.GetInt(Constants.Vibration, 1)];
    }

    public void ToggleSoound()
    {
  
        int status = PlayerPrefs.GetInt(Constants.Sound,1);

        if (status == 1)
        {
            status = 0;
           
        }
        else
        {
            status = 1;
          

        }
        SoundSprite.sprite = ButtonsSound[status];
        SoundManager.Instance.PlayOnshootSound(SoundManager.Instance.Click);
        PlayerPrefs.SetInt(Constants.Sound,status);
       SoundManager.Instance.UpdateSound();

    }
    // public void ToggleMusic()
    //{
  
    //    int status = PlayerPrefs.GetInt(Constants.music,1);

    //    if (status == 1)
    //    {
    //        status = 0;
           
    //    }
    //    else
    //    {
    //        status = 1;
          

    //    }
    //    MusicSprite.sprite = ButtonsMusic[status];
    //    SoundManager.Instance.PlayOnshootSound(SoundManager.Instance.Click);
    //    PlayerPrefs.SetInt(Constants.music,status);
    //   SoundManager.Instance.UpdateSound();

    //}
   
    //public void ToggleVibration()
    //{

    //    int status = PlayerPrefs.GetInt(Constants.Vibration, 1);

    //    if (status == 1)
    //    {
    //        status = 0;


          
    //    }
    //    else
    //    {
    //        status = 1;
           

    //    }
    //    VibrationSprites.sprite = ButtonsVib[status];
    //   SoundManager.Instance.PlayOnshootSound(SoundManager.Instance.Click);
    //    PlayerPrefs.SetInt(Constants.Vibration, status);
    //}

}
