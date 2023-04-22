using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public List<Levels> Data;
    public List<Image> _Images;
    public char[] AnsString;
    public char[] CreatedString;
    public List<Sprite> Alphabets;
    public List<Image> _ClickButtons;
    public List<GameObject> AnswerImg;
    public List<GameObject> AnsImg;
    public Sprite _TP;
    private void OnEnable()
    {

      
        for (int i = 0; i < AnswerImg.Count; i++)
        {
            AnswerImg[i].SetActive(false);
        }
        
        int Value = PlayerPrefs.GetInt(Constants.SaveCurrentLevel, 0);
        Session.Instance.CurrentLevel = Value;
        Levels levels = Data[Session.Instance.CurrentLevel];
        for (int i = 0; i < _Images.Count; i++)
        {
            _Images[i].sprite = levels._LevelImages[i];
        }
        AnsString = levels.correctkeyword.ToCharArray();
        int C = AnsString.Length;
        for (int i = 0; i < C; i++)
        {
            AnswerImg[i].SetActive(true);
            AnsImg.Add(AnswerImg[i]);
        }
        CreatedString = ExpandAndShuffleString(levels.correctkeyword, 12).ToCharArray();
        for (int i = 0; i < CreatedString.Length; i++)
        {
            _ClickButtons[i].sprite = Alphabets.FirstOrDefault(x => x.name.ToLower() == CreatedString[i].ToString().ToLower());
        }

    }
    public string ExpandAndShuffleString(string inputString, int numAlphabets)
    {
        int numCharsToAdd = numAlphabets - inputString.Length;
        if (numCharsToAdd <= 0)
        {
            return inputString;
        }
        string randomChars = "";
        for (int i = 0; i < numCharsToAdd; i++)
        {
            randomChars += (char)UnityEngine.Random.Range(65, 91);
        }
        string expandedString = inputString + randomChars;
        char[] chars = expandedString.ToCharArray();
        for (int i = chars.Length - 1; i > 0; i--)
        {
            int j = UnityEngine.Random.Range(0, i + 1);
            char temp = chars[i];
            chars[i] = chars[j];
            chars[j] = temp;
        }
        expandedString = new string(chars);
        return expandedString;
    }
    public void OnClick(Image _Image)
    {
        for (int i = 0; i < AnsImg.Count; i++)
        {
            if (AnsImg[i].GetComponent<Image>().sprite.name == "TP")
            {
                AnsImg[i].GetComponent<Image>().sprite = _Image.sprite;
                Result();
                AnsImg[i].gameObject.name = _Image.gameObject.name;
                _Image.GetComponent<Image>().sprite = _TP;
                break;
            }
        }
    }
    public Sprite TPSprite;
    public void UndoImage(Image _image)
    {
        _ClickButtons[int.Parse(_image.gameObject.name)].GetComponent<Image>().sprite = _image.sprite;
        _image.GetComponent<Image>().sprite = TPSprite;
    }
    public void Result()
    {

        string S = "";
       
        for (int i = 0; i < AnsImg.Count; i++)
        {
            if (AnsString[i].ToString().ToLower() == AnsImg[i].GetComponent<Image>().sprite.name.ToLower())
            {
                AnsImg[i].GetComponent<Image>().color = Color.green;
            }
            else
            {
                AnsImg[i].GetComponent<Image>().color = Color.red;
               
            }
            S += AnsImg[i].GetComponent<Image>().sprite.name;

        }string s2 = "";
            Debug.Log(S);
        for (int i = 0; i < AnsString.Length; i++)
        {
            s2 += AnsString[i];
        }
        Debug.Log(AnsString.ToString().ToLower());
        if (S== s2.ToLower())
        {
          
            ScoreManager.Instance.Score += 25;
            CanvasManager.Instance.Gamestate = States.WinPanel;
        }

    }
}
