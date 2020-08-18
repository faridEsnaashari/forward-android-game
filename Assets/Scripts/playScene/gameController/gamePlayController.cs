using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gamePlayController : MonoBehaviour
{
    public static gamePlayController instance;
    public GameObject gameOverUI;
    public GameObject pauseMenuUI;
    public GameObject pauseButtonUI;

    public Text scoreUI;
    public Text coinUI;

    private void Start()
    {
        playerStatus ps = new playerStatus();
        // fileManager.savePlayerStatus(ps);
        instance = this;

        updateCoinUI(0);
        updateScoreUI(0);

        resetPlayerStatus();
    }
    private void resetPlayerStatus()
    {
        coin.instance.resetCoin();
        Score.instance.resetScore();
    }

    public void destroyBall()
    {
        GameObject ball = gameObjectCreator.instance.instantiatedElements[0];
        GameObject ballIllustrate = ball.GetComponent<getObjects>().getBallIllustrate();

        ball.GetComponent<moveForward>().speed = 0;
        Destroy(ballIllustrate);
    }
    public void showGameOverUI()
    {
        activeUI("gameOver");
    }
    public int getCoinAmount()
    {
        return int.Parse(coinUI.text);
    }
    public int getHighScore()
    {
        playerStatus ps = fileManager.loadPlayerStatus();
        if(ps.highScore < int.Parse(scoreUI.text))
        {
            return int.Parse(scoreUI.text);
        }
        else
        {
            return  ps.highScore;
        }
    }
    public void savePlayerStatus()
    {
        int coin = getCoinAmount();
        int highScore = getHighScore();

        playerStatus ps = fileManager.loadPlayerStatus();
        ps.coinAmount += coin;
        ps.highScore = highScore;
        Debug.Log(ps.highScore);

        fileManager.savePlayerStatus(ps);
    }
    public void activateBallGravity()
    {
        GameObject ball = gameObjectCreator.instance.instantiatedElements[0];
        GameObject ballIllustrate = ball.GetComponent<getObjects>().getBallIllustrate();

        ball.GetComponent<moveForward>().speed = 0;
        ballIllustrate.GetComponent<Rigidbody>().useGravity = true;
    }
    public void destroyPreviousPlain()
    {
        gameObjectCreator.instance.destroyPreviousPlain();
    }
    public void instantiateNextPlain()
    {
        gameObjectCreator.instance.instantiateNextPlain();
    }
    public void pauseTheGame()
    {
        GameObject ball = gameObjectCreator.instance.instantiatedElements[0];
        ball.GetComponent<moveForward>().speed = 0;
        activeUI("pauseMenu");
    }
    public void loadMainMenuScene()
    {
        SceneManager.LoadScene("mainMenu" , LoadSceneMode.Single);
    }
    public void loadPlayScene()
    {
        SceneManager.LoadScene("play" , LoadSceneMode.Single);
    }
    public void resumeTheGame()
    {
        GameObject ball = gameObjectCreator.instance.instantiatedElements[0];
        ball.GetComponent<moveForward>().speed = 1;
        activeUI("pauseButton");
    }
    private void activeUI(string UIToActive)
    {
        switch(UIToActive)
        {
            case "pauseMenu": 
                pauseMenuUI.SetActive(true);
                pauseButtonUI.SetActive(false);
                gameOverUI.SetActive(false);
                break;

            case "pauseButton": 
                pauseMenuUI.SetActive(false);
                pauseButtonUI.SetActive(true);
                gameOverUI.SetActive(false);
                break;

            case "gameOver": 
                pauseMenuUI.SetActive(false);
                pauseButtonUI.SetActive(false);
                gameOverUI.SetActive(true);
                break;
        }
    }
    public void updateScoreUI(int _score)
    {
        scoreUI.text = _score.ToString();
    }
    public void updateCoinUI(int _coin)
    {
        coinUI.text = _coin.ToString();
    }
}
