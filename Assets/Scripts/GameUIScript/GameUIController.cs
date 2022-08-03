using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class GameUIController: MonoBehaviour
{
    public Button joinButt;
    public InputField username;

    public void JoinGame()
    {
        NetworkManager.singleton.StartClient();
        joinButt.gameObject.SetActive(false);
        username.gameObject.SetActive(false);
        DBManager.username = username.text;
    }
}

