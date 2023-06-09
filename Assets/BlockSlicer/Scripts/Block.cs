using UnityEngine;

public class Block : MonoBehaviour
{
    public enum BlockType
    {
        Left,
        Right,
        DontHit
    }
    public BlockType myBlockType = BlockType.Left;

    ScoreKeeper scoreKeeper;
    float speed = 0.01f;

    private void Start()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>().GetComponent<ScoreKeeper>();
    }
    void FixedUpdate()
    {
        transform.position -= Vector3.forward * speed;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(!other.name.Contains("Left") && !other.name.Contains("Left"))
        {
            return;
        }
        if(other.name.Contains("Left") && myBlockType == BlockType.Left)
        {
            scoreKeeper.IncreaseScore();
        }
        else if (other.name.Contains("Right") && myBlockType == BlockType.Right)
        {
            scoreKeeper.IncreaseScore();
        }
        else
        {
            scoreKeeper.DecreaseLives();
        }
    }
}
