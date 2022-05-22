using UnityEngine;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using TMPro;

//Moralis
using MoralisWeb3ApiSdk;
using Moralis.WebGL;
using Moralis.WebGL.Platform.Objects;

#if UNITY_WEBGL
public class AppManager : MonoBehaviour
{
    public MoralisController moralisController;
    public GameObject authButton;
    public GameObject startButton;
    public TextMeshProUGUI walletAddressLabel;

    private async void Start()
    {
        if (moralisController != null)
        {
            await moralisController.Initialize();
        }
        else
        {
            Debug.LogError("MoralisController is null.");
            return;
        }


        if (SessionData.Instance.GetWalletReceived())
        {
            //startButton.SetActive(!MoralisInterface.IsLoggedIn());
            startButton.SetActive(true);
        }
        else
        {
            //authButton.SetActive(!MoralisInterface.IsLoggedIn());
            authButton.SetActive(true);
        } 
    }

    public async UniTask LoginWithWeb3()
    {
        string userAddr = "";
        
        if (!Web3GL.IsConnected())
        {
            userAddr = await MoralisInterface.SetupWeb3();
        }
        else
        {
            userAddr = Web3GL.Account();
        }

        if (string.IsNullOrWhiteSpace(userAddr))
        {
            Debug.LogError("Could not login or fetch account from web3.");
        }
        else
        {
            string address = Web3GL.Account().ToLower();
            string appId = MoralisInterface.GetClient().ApplicationId;
            long serverTime = 0;

            // Retrieve server time from Moralis Server for message signature
            Dictionary<string, object> serverTimeResponse = await MoralisInterface.GetClient().Cloud.RunAsync<Dictionary<string, object>>("getServerTime", new Dictionary<string, object>());

            if (serverTimeResponse == null || !serverTimeResponse.ContainsKey("dateTime") ||
                !long.TryParse(serverTimeResponse["dateTime"].ToString(), out serverTime))
            {
                Debug.Log("Failed to retrieve server time from Moralis Server!");
            }

            string signMessage = $"Meta & Magic Authentication\n\nId: {appId}:{serverTime}";

            string signature = await Web3GL.Sign(signMessage);

            Debug.Log($"Signature {signature} for {address} was returned.");

            // Create moralis auth data from message signing response.
            Dictionary<string, object> authData = new Dictionary<string, object> { { "id", address }, { "signature", signature }, { "data", signMessage } };

            Debug.Log("Logging in user.");

            // Attempt to login user.
            MoralisUser user = await MoralisInterface.LogInAsync(authData);

            if (user != null)
            {
                Debug.Log($"User {user.username} logged in successfully. ");
                
                authButton.SetActive(false);
                startButton.SetActive(true);
                walletAddressLabel.gameObject.SetActive(true);
                SessionData.Instance.SetWalletAddress(GetWalletAddress(user));

            }
            else
            {
                Debug.Log("User login failed.");
            }
        }
    }
    
    private string GetWalletAddress(MoralisUser user)
    {
        return user.ethAddress;
    }
    
    public async void HandleAuthButtonClick()
    {
        await LoginWithWeb3();
    }
}
#endif