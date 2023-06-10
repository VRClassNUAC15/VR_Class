using UnityEngine;
using TMPro;

public class ScoreKeeper : MonoBehaviour
{
    public TMP_Text scoreBoard;
    public TMP_Text livesLeftBoard;

    int score = 0;
    int pointsPerHit = 10;

    int livesLeft;

    public BlockSlicerGameLogic gameLogic;

    public void IncreaseScore()
    {
        score += pointsPerHit;
        scoreBoard.text = score.ToString();
    }
    public void DecreaseLives()
    {
        livesLeft--;
        if(livesLeft <= 0)
        {
            gameLogic.GameOver();
        }
        livesLeftBoard.text = livesLeft.ToString();
    }
}
