using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class GameUIController : NetworkBehaviour
{
    public Button joinButt;
    public void JoinGame()
    {
        NetworkManager.singleton.StartClient();
        joinButt.gameObject.SetActive(false);
    }

}
