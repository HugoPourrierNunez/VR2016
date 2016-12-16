using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
    [SerializeField]
    Animator animator;

    [SerializeField]
    GuessWord guessWord;

    [SerializeField]
    Text scores;

    string wordToGuess = string.Empty;

    int playerScore1 = 0;
    int playerScore2 = 0;
    int playerGuessing = 2;

    void Start()
    {
        animator.SetBool("startMenu", true);
    }

	public void ExitGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        animator.SetBool("startMenu", false);
        animator.SetBool("draw", true);
    }

    public void Draw()
    {
        animator.SetBool("draw", false);
        animator.SetBool("enterWord", true);
    }

    public void SetWordToGuess(string word)
    {
        wordToGuess = word;
    }

    public void Guess()
    {
        animator.SetBool("guess", false);
        animator.SetBool("guessWord", true);
    }

    public void GuessWord()
    {
        animator.SetBool("changePlayer", false);
        animator.SetBool("enterWord", true);

        guessWord.GenerateLetters(wordToGuess);
    }

    public void Win()
    {
        if(playerGuessing == 1)
        {
            playerScore1++;
        }
        else
        {
            playerScore2++;
        }
        animator.SetBool("guessWord", false);
        animator.SetBool("restartMenu", true);
        playerGuessing = (playerGuessing == 2) ? 1 : 2;

        scores.text = "Joueur 1 : " + playerScore1 + "\n" + "Joueur 2 : " + playerScore2;
    }

    public void Lose()
    {
        if (playerGuessing == 2)
        {
            playerScore1++;
        }
        else
        {
            playerScore2++;
        }
        animator.SetBool("guessWord", false);
        animator.SetBool("restartMenu", true);
        playerGuessing = (playerGuessing == 2) ? 1 : 2;

        scores.text = "Joueur 1 : " + playerScore1 + "\n" + "Joueur 2 : " + playerScore2;
    }

    public void RestartGame()
    {
        animator.SetBool("restartMenu", false);
        animator.SetBool("draw", true);
        DrawScript myDrawScript = new DrawScript();

        myDrawScript.ResetTexture();
    }
}
