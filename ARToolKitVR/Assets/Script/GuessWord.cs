using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class GuessWord : MonoBehaviour
{
    [SerializeField]
    Button[] buttons;

    [SerializeField]
    Text text;

    [SerializeField]
    GameLogic gameLogic;

    const string letters = "AZERTYUIOPQSDFGHJKLMWXCVBN";
    string lettersToPick = string.Empty;
    string lettersToShuffle = string.Empty;
    string wordToGuess = string.Empty;

    public void GenerateLetters(string word)
    {
        wordToGuess = word;

        text.text = string.Empty;

        lettersToShuffle = word;

        for (int i = word.Length; i < 21; i++)
        {
            lettersToShuffle += letters[UnityEngine.Random.Range(0, 26)];
        }

        System.Random num = new System.Random();
        lettersToPick = new string(lettersToShuffle.ToCharArray().
                OrderBy(s => (num.Next(2) % 2) == 0).ToArray());


        for(int i = 0; i < lettersToPick.Length; i++)
        {
            buttons[i].GetComponentInChildren<Text>().text = "" + lettersToPick[i];
        }
    }

    public void EnterLetter()
    {
        Button button = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
        text.text += button.GetComponentInChildren<Text>().text;
    }


    public void ValidateWord()
    {
        if(text.text == wordToGuess)
        {
            gameLogic.Win();
        }

        text.text = string.Empty;
    }

    public void GiveUp()
    {
        gameLogic.Lose();

        text.text = string.Empty;
    }

    public void DeleteLetter()
    {
        string tmpWord = text.text;
        tmpWord = tmpWord.Remove(tmpWord.Length - 1);
        text.text = tmpWord;
    }
}
