using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    public Text scoreBoard;
    public Text livesLeftBoard;

    int score = 0;
    int pointsPerHit = 10;

    int livesLeft;

    BlockSlicerGameLogic gameLogic;

    private void Start()
    {
        gameLogic = FindObjectOfType<BlockSlicerGameLogic>().GetComponent<BlockSlicerGameLogic>();
    }
    public void IncreaseScore()
    {
        score += pointsPerHit;
        scoreBoard.text = score.ToString();
    }
    public void DecreaseLives()
    {
        livesLeft--;
        if(livesLeft == 0)
        {
            gameLogic.GameOver();
        }
        livesLeftBoard.text = livesLeft.ToString();
    }
}
