using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class BlockSlicerGameLogic : MonoBehaviour
{
    public XRRayInteractor[] XRRayInteractors;
    public GameObject[] sabers;
    public Canvas SplashScreen, ScoreBoard, EndGameCanvas;
    public TMP_Text GameScoreText, EndGameScoreText, WinLoseText; 
    public GameObject Level;
    public AudioClip Music;
    public void StartGame()
    {
        foreach(XRRayInteractor xRRay in XRRayInteractors)
        {
            xRRay.enabled = false;
        }
        foreach (GameObject saber in sabers)
        {
            saber.SetActive(true);
        }
        SplashScreen.gameObject.SetActive(false);
        ScoreBoard.gameObject.SetActive(true);
        Level.SetActive(true);
        StartCoroutine("YieldEndOfLevel");
        GetComponent<AudioSource>().PlayOneShot(Music);
    }
    IEnumerator YieldEndOfLevel()
    {
        yield return new WaitForSeconds(Music.length + 1.0f);
        if(Level.activeInHierarchy)
        {
            FinishedSong();
        }
    }
    public void GameOver()
    {
        LevelComplete(false);
    }
    public void FinishedSong()
    {
        LevelComplete(true);
    }
    void LevelComplete(bool didWin)
    {
        foreach (XRRayInteractor xRRay in XRRayInteractors)
        {
            xRRay.enabled = true;
        }
        foreach (GameObject saber in sabers)
        {
            saber.SetActive(false);
        }
        Level.SetActive(false);
        EndGameCanvas.gameObject.SetActive(true);
        WinLoseText.text = didWin ? "You Win!" : "You Lose!";
        ScoreBoard.gameObject.SetActive(false);
        EndGameScoreText.text = GameScoreText.text;
    }
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
