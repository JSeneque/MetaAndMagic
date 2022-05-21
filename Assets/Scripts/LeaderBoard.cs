using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class LeaderBoard : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void updateLeaderboard(string wallet_address, string timestamp, string score);

    string _walletAddress;
    string _timestamp;
    string _score;

    public void SendToJS()
    {
        _walletAddress = SessionData.Instance._walletAddress;
        _timestamp = SessionData.Instance._timestampUtc.ToString();
        _score = SessionData.Instance._score.ToString();

        updateLeaderboard(_walletAddress, _timestamp, _score);
    }
}
