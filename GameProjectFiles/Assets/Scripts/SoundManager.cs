using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SoundManager : Singletion<SoundManager>
{
    public AudioSource Background;
    public AudioSource Effect;
    public AudioClip Click;
    public AudioClip Over;
    public AudioClip Win;
    public AudioClip RevertBtn;
    public AudioClip ClickAlphabet;
    private void OnEnable()
    {
        UpdateSound();

    }
    public void UpdateSound()
    {
        int status = PlayerPrefs.GetInt(Constants.Sound, 1);
        Background.enabled = Convert.ToBoolean(status);
        Effect.enabled = Convert.ToBoolean(status);
        //  Effect.mute = Convert.ToBoolean(Convert.ToInt16(!Convert.ToBoolean(status)));

    }

    public void PlayOnshootSound(AudioClip Clip_)
    {
     //   SoundManager.Instance.PlayOnshootSound(SoundManager.Instance.Click);
        Effect.PlayOneShot(Clip_);
    }

}
