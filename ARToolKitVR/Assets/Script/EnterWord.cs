using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EnterWord : MonoBehaviour {

    [SerializeField]
    Text word;

    [SerializeField]
    Animator animator;

    [SerializeField]
    GameLogic gameLogic;

    [SerializeField]
    GuessWord guessWord;

    string tmpWord = string.Empty;

	public void EnterLetter()
    {
        if(tmpWord.Length == 10)
        {
            return;
        }

        Button button = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
        tmpWord += button.GetComponentInChildren<Text>().text;

        word.text = tmpWord;
    }

    public void ValidateWord()
    {
        animator.SetBool("enterWord", false);
        animator.SetBool("guessWord", true);

        gameLogic.SetWordToGuess(tmpWord);
        guessWord.GenerateLetters(tmpWord);

        tmpWord = string.Empty;
        word.text = tmpWord;
    }

    public void DeleteLetter()
    {
        tmpWord = tmpWord.Remove(tmpWord.Length - 1);
        word.text = tmpWord;
    }
}
