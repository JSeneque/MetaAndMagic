using System;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class SessionData : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void updateLeaderboard(string wallet_address, string timestamp, string score);

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
    public DateTime _timestampUtc;

    [SerializeField] GameObject _walletSubmitText;

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
        _timestampUtc = DateTime.UtcNow;
    }

    public void SetEndTime()
    {
        _endTime = Time.time;
        _gameCompleted = true;
        _score -= (int)(_endTime - _startTime);
        if (_score < 0) _score = 100;
        SendToLeaderboard();
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

    private void SendToLeaderboard()
    {
#if UNITY_WEBGL
        updateLeaderboard(_walletAddress, _timestampUtc.ToString(), _score.ToString());
#endif

#if UNITY_EDITOR
        Debug.Log("Wallet Address: " + _walletAddress + " Timestamp " + _timestampUtc.ToString() + " Score: " + _score.ToString());
#endif
    }

}
