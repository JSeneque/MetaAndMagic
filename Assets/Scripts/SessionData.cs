using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class SessionData : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void updateLeaderboard(string wallet_address, string timestamp, string score, string verify_wallet, string verify_score, string verify_timestamp);

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
        string password = "metamagic";
        string hashWalletAddress = HashPassword(password, _walletAddress);
        string hashTimestamp = HashPassword(password, _timestampUtc.ToString());
        string hashScore = HashPassword(password, _score.ToString());

#if UNITY_WEBGL
        updateLeaderboard(_walletAddress.ToString(), _timestampUtc.ToString(), _score.ToString(), hashWalletAddress.ToString(), hashTimestamp.ToString(), hashScore.ToString());
#endif

#if UNITY_EDITOR
        Debug.Log("Wallet Address: " + _walletAddress + " Timestamp " + _timestampUtc.ToString() + " Score: " + _score.ToString());
        Debug.Log("Hash Timestamp " + hashTimestamp);

#endif
    }

    public static String HashPassword(string _password, string _string)
    {
        var key = Encoding.UTF8.GetBytes(_password);
        var sha512 = new HMACSHA512(key);
        var bytes = UTF8Encoding.UTF8.GetBytes(_string);
        var hash = sha512.ComputeHash(bytes);
        return ToHexStr(hash);
    }

    public static string ToHexStr(byte[] hash)
    {
        StringBuilder hex = new StringBuilder(hash.Length * 2);
        foreach (byte b in hash)
            hex.AppendFormat("{0:x2}", b);
        return hex.ToString();
    }
}


