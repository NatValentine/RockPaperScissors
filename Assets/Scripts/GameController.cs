using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    bool player1Ready = false;
    bool player2Ready = false;

    GameObject player1Throw;
    GameObject player2Throw;

    int player1Score = 0;
    int player2Score = 0;

    public Text resultTxt;
    public Text scoreBoard;
    public GameObject nextRoundBtn;

    // Update is called once per frame
    void Update()
    {
        // If both players have made their choice, see who won.
        if (player1Ready && player2Ready)
        {
            Winner();
            nextRoundBtn.SetActive(true);
        }
    }

    public void Player1Choice (GameObject go)
    {
        player1Throw = go;
        player1Ready = true;
    }

    public void Player2Choice(GameObject go)
    {
        player2Throw = go;
        player2Ready = true;
    }

    void Winner()
    {
        // Show the players' choices
        player1Throw.SetActive(true);
        player2Throw.SetActive(true);

        // 3 scenarios, either player wins or it's a tie.
        if (player1Throw.GetComponent<Throw>().tiesWith == player2Throw)
        {
            resultTxt.text = "IT'S A TIE";
        }

        if (player1Throw.GetComponent<Throw>().winsAgainst == player2Throw)
        {
            resultTxt.text = "PLAYER 1 WINS";
            player1Score++;
        }

        if (player1Throw.GetComponent<Throw>().LosesTo == player2Throw)
        {
            resultTxt.text = "PLAYER 2 WINS";
            player2Score++;
        }

        // The players are no longer ready after making their moves.
        // Since I call this method from update, I need to make sure they only score once.
        player1Ready = false;
        player2Ready = false;

        // Update the scoreboard
        scoreBoard.text = player1Score.ToString() + " - " + player2Score.ToString();
    }

    public void NextRound()
    {
        // Reset the field
        player1Throw.SetActive(false);
        player2Throw.SetActive(false);

        resultTxt.text = "";

        nextRoundBtn.SetActive(false);
    }
}
