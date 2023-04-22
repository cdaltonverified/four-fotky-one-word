using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager Instance;
    public GameObject MainMenuPanel;
   // public GameObject SettingPanel;
    public GameObject GamePlayPanel;
    public GameObject WinPanel;
    public GameObject SpinPanel;
    public List<GameObject> AllScreens;
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
                //case States.SettingPanel:
                //    SettingPanel.Show();
                //    break;
                case States.GamePlayPanel:
                    GamePlayPanel.Show();
                    break;
                case States.WinPanel:
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
        Session.Instance.Replay = true;
        Fade.Instance.LoadScene("Game");
    }
    [ContextMenu("Reload")]
    public void MainMenu() 
    {
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
    private void Awake()
    {
        Instance = this;
    }
    public void Next() {
        Session.Instance.CurrentLevel += 1;
        PlayerPrefs.SetInt(Constants.SaveCurrentLevel, Session.Instance.CurrentLevel);
        Session.Instance.Replay = true;
        Fade.Instance.LoadScene("Game");
    }
}
public enum States
{
    MainMenuPanel, GamePlayPanel, WinPanel, SpinPanel
}






























