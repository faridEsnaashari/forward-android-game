using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class getTotalCoinAndHighScore : MonoBehaviour
{
    public Text totalCoinUI;
    public Text highScoreUI;

    private void Start()
    {
        playerStatus ps = fileManager.loadPlayerStatus();
        int totalCoin = ps.coinAmount;
        int highScore = ps.highScore;

        totalCoinUI.text = totalCoin.ToString();
        highScoreUI.text = highScore.ToString();
    }
}
