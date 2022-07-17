using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkManagerCustom : NetworkManager
{
    public void StartHosting()
    {
        base.StartHost();

    }

    public void JoinGame()
    {

        NetworkManager.singleton.networkAddress = "1.55.74.17";
        NetworkManager.singleton.networkPort = int.Parse("5000");
        NetworkManager.singleton.StartClient();

    }
}
