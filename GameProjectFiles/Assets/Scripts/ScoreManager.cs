using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{

    public static ScoreManager Instance;
    public List<TextMeshProUGUI> ScoreText;
    private void Awake()
    {
        Instance = this;
    }

    [SerializeField] private int _Score;
    public int Score
    {
        get => _Score;
        set
        {
            _Score = value;
            ScoreText.ForEach(x => x.text = _Score.ToString());
        }
    }
    private void OnDisable()
    {
        PlayerPrefs.SetInt("Coin",Score);
    }
    private void OnEnable()
    {
        Score = PlayerPrefs.GetInt("Coin",Score);
    }
}
