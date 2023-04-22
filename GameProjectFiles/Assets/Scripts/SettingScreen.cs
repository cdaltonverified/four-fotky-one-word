using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class SettingScreen : MonoBehaviour
{
    public List<GameObject> Language;
    public List<Sprite> Buttons;
    public Image SoundSprite;
    public Image languageSprites;
    public Image VibrationSprites;
   
    private void OnEnable()
    {
        SoundSprite.sprite = Buttons[PlayerPrefs.GetInt(Constants.Sound, 1)];
        VibrationSprites.sprite = Buttons[PlayerPrefs.GetInt(Constants.Vibration, 1)];
        Language.ForEach(x => x.SetActive(false));
        Language[PlayerPrefs.GetInt(Constants.Language, 1)].SetActive(true);
    }

    public void ToggleSoound()
    {

        int status = PlayerPrefs.GetInt(Constants.Sound, 1);

        if (status == 1)
        {
            status = 0;
        }
        else
        {
            status = 1;
           
        }
        SoundSprite.sprite = Buttons[status];

        PlayerPrefs.SetInt(Constants.Sound,status);
        SoundManager.Instance.UpdateSound();
        SoundManager.Instance.PlayOnshootSound(SoundManager.Instance.Click);
       

    }
    public void ToggleLanguage(int a)
    {
        if (a == 1)
        {
            a = 1;
           Language[0].SetActive(false);
            Language[1].SetActive(true);
        }
        else
        {
            a = 0;
           Language[1].SetActive(false);
            Language[0].SetActive(true);
        }
        PlayerPrefs.SetInt(Constants.Language, a);
        var Change = FindObjectsOfType<ChangeLanguage>();
        Change.ToList().ForEach(x => x.LanguageChange());
        SoundManager.Instance.UpdateSound();
       SoundManager.Instance.PlayOnshootSound(SoundManager.Instance.Click);
    }
    public void ToggleVibration()
    {

        int status = PlayerPrefs.GetInt(Constants.Vibration, 1);

        if (status == 1)
        {
            status = 0;
        }
        else
        {
            status = 1;
        }
        VibrationSprites.sprite = Buttons[status];
        PlayerPrefs.SetInt(Constants.Vibration, status);
       SoundManager.Instance.PlayOnshootSound(SoundManager.Instance.Click);
    }

}
