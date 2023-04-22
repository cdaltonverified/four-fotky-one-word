using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Fade : Singletion<Fade>
{
    public float TimeToFade;
    public Image FadeImage;
    public GameObject Parent;
    public TextMeshProUGUI LoadingText;
    public AnimationCurve FadeCurve;

    private void OnEnable()
    {
        FadeImage.DOFade(0, TimeToFade).SetEase(FadeCurve).OnStart(() =>
        {FadeImage.gameObject.SetActive(true);
            FadeImage.color=Color.black;
        }).OnComplete(() => {FadeImage.gameObject.SetActive(false); })
            ;
    }

    public bool isfaded;
    public void LoadScene(string scenename, bool IsLoadingText=true, float? Timetofade = null)
    {
        Parent.Show();
        StartCoroutine(LoadScene(scenename));
        if(IsLoadingText) LoadingText.gameObject.SetActive(true);
        FadeImage.DOFade(1, Timetofade ?? TimeToFade).OnStart(()=>{FadeImage.gameObject.SetActive(true);}).OnComplete(()=>
        {

            isfaded = true;


        });

    }
    
    
    IEnumerator LoadScene(string scenename)
    {
        yield return null;
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(scenename);
        asyncOperation.allowSceneActivation = false;
        while (!asyncOperation.isDone)
        {
            LoadingText.text =  (asyncOperation.progress * 100) + "%";
            if (asyncOperation.progress >= 0.9f)
            {
                yield return new WaitWhile(()=>!isfaded);

              
                Parent.Hide();
                FadeImage.DOFade(0, TimeToFade).SetEase(FadeCurve).OnComplete(() =>
                {
                    
                    
                    FadeImage.gameObject.SetActive(false);
                });
                isfaded = false;
                    asyncOperation.allowSceneActivation = true;
            }

            yield return null;
        }
    }
    
}
