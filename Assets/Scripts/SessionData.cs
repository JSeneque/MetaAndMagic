using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SessionData : MonoBehaviour
{
    public static SessionData Instance;

    public string _walletAddress;
    public bool _walletCollected;
    public float _startTime;
    public float _endTime;
    public float _maxScore = 600000;
    public float _score;
    public Text _scoreText;
    public Text _address;
    public bool _gameCompleted;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(this.gameObject);

        _score = _maxScore;
     }

    public void SetWalletAddress(string address)
    {
        _walletAddress = address;
        _walletCollected = true;
    }

    public bool GetWalletReceived()
    {
        return _walletCollected;
    }

    public void SetStartTime()
    {
        _startTime = Time.time;
    }

    public void SetEndTime()
    {
         _endTime = Time.time;
        _gameCompleted = true;
        _score -= (int)(_endTime - _startTime);
        _scoreText.text = _score.ToString();
    }

    public void UpdateDebugUI()
    {
        //_address.text = "Wallet Address: " + _walletAddress.ToString();
    }

    public void ResetScore()
    {
        _score = _maxScore;
        _startTime = 0;
        _endTime = 0;
        _gameCompleted = false;
        //_scoreText.text = "0";
    }

}
