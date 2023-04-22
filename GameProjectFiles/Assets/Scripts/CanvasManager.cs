using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager Instance;
    public GameObject MainMenuPanel;
   // public GameObject SettingPanel;
    public GameObject GamePlayPanel;
    public GameObject WinPanel;
    public GameObject SpinPanel;
    public GameObject Particles;
    public List<GameObject> AllScreens;
   // public Transform POs;
    public TextMeshProUGUI _LevelcompleteText;
    [SerializeField]
    private States _Gamestate;
    public States Gamestate
    {
        get => _Gamestate;
        set
        {


            _Gamestate = value;
            TurnOffAll();
            switch (_Gamestate)
            {
                case States.MainMenuPanel:
                    MainMenuPanel.Show();
                    break;
                case States.GamePlayPanel:
                    GamePlayPanel.Show();
                    break;
                case States.WinPanel:
                    Session.Instance.CurrentLevel += 1;
                    PlayerPrefs.SetInt(Constants.SaveCurrentLevel, Session.Instance.CurrentLevel);
                    Particles.SetActive(true);
                    CheckLevel();
                    WinPanel.Show();
                    break;
                case States.SpinPanel:
                    SpinPanel.Show();
                    break;
            }

        }
    }
    private void Start()
    {
        if (Session.Instance.Replay)
        {
            Session.Instance.Replay = false;
           Gamestate = States.GamePlayPanel;
            return;
        }
        Gamestate = States.MainMenuPanel;

    }
    public void Replay() 
    {
        SoundManager.Instance.PlayOnshootSound(SoundManager.Instance.Click);
        Session.Instance.Loading = false;
        Session.Instance.Replay = true;
        Fade.Instance.LoadScene("Game");
    }
    [ContextMenu("Reload")]
    public void MainMenu() 
    {
        SoundManager.Instance.PlayOnshootSound(SoundManager.Instance.Click);
        Session.Instance.Loading = false;
        Fade.Instance.LoadScene("Game");
    }

    public void TurnOffAll()
    {
        AllScreens.ForEach(x =>
        {
            if (x.activeSelf)
            {
                x.Hide();
            }
        });
    }
    public void CheckLevel() {

        if (Session.Instance.CurrentLevel==50)
        {
            SoundManager.Instance.PlayOnshootSound(SoundManager.Instance.LevelCompleteAudio);
            _LevelcompleteText.text = "Level 1 is Completed";
        }
        else if (Session.Instance.CurrentLevel == 100)
        {
            SoundManager.Instance.PlayOnshootSound(SoundManager.Instance.LevelCompleteAudio);
            _LevelcompleteText.text = "Level 2 is Completed";
        }
        else if (Session.Instance.CurrentLevel == 150)
        {
            SoundManager.Instance.PlayOnshootSound(SoundManager.Instance.LevelCompleteAudio);
            _LevelcompleteText.text = "Level 3 is Completed";
        }
        else if (Session.Instance.CurrentLevel == 200)
        {
            SoundManager.Instance.PlayOnshootSound(SoundManager.Instance.LevelCompleteAudio);
            _LevelcompleteText.text = "Level 4 is Completed";
        }
        else if (Session.Instance.CurrentLevel == 250)
        {
            SoundManager.Instance.PlayOnshootSound(SoundManager.Instance.LevelCompleteAudio);
            _LevelcompleteText.text = "Congratulation!! All the level is Completed";
        }

    }
    public void Quit()
    {
        SoundManager.Instance.PlayOnshootSound(SoundManager.Instance.Click);
        Application.Quit();
        Handheld.Vibrate();
    }
    private void Awake()
    {
        Instance = this;
    }
    public void Next() {

        SoundManager.Instance.PlayOnshootSound(SoundManager.Instance.Click);
        if (Session.Instance.CurrentLevel > 199)
        {
            LevelData.Instance.Levels[4].Isopened = true;
        }
        else if (Session.Instance.CurrentLevel > 149)
        {
            LevelData.Instance.Levels[3].Isopened = true;
        }
        else if (Session.Instance.CurrentLevel > 99)
        {
            LevelData.Instance.Levels[2].Isopened = true;
        }
        else if (Session.Instance.CurrentLevel > 49)
        {
            LevelData.Instance.Levels[1].Isopened = true;
        }
        Session.Instance.Loading = false;
        Session.Instance.Replay = true;
        Fade.Instance.LoadScene("Game");
    }
}
public enum States
{
    MainMenuPanel, GamePlayPanel, WinPanel, SpinPanel
}






























