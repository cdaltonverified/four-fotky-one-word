using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChangeLanguage : MonoBehaviour
{
    public Sprite English;
    public Sprite Russian;
    private void OnEnable()
    {
        if (!Application.isPlaying) return;
        LanguageChange();
    }
    public void LanguageChange() 
    {
        switch(PlayerPrefs.GetInt(Constants.Language, 1))
        {
            case 0:
                GetComponent<Image>().sprite = Russian;
                break;
            case 1:
                GetComponent<Image>().sprite = English;
                break;
            default:
                break;
        } 
               
         

        
        
    
    }
}
