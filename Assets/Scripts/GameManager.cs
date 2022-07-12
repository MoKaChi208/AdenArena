using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GameManager : MonoBehaviour
{
    private const string PLAYER_ID_PREFIX = "Player";
    private static Dictionary<string, Player> players = new Dictionary<string, Player>();

    public static void RegisterPlayer(string _netID, Player _player)
    {
        string _playerID = "Player" + _netID;
        players.Add(_playerID, _player);
        _player.transform.name = _playerID;
    }

    public static void UnRegisterPlayer(string _playerID)
    {
        players.Remove(_playerID);
    }

    public static Player GetPlayer(string _playerID)
    {
        return players[_playerID];
    }

    private void OnGUI()
    {
        //GUILayout.BeginArea(new Rect(Vector2.zero, new Vector2(2, 2)));
        GUILayout.BeginArea(new Rect(200,200,200,500));

        GUILayout.BeginVertical();
        foreach (string _playerID in players.Keys)
        {
            GUILayout.Label(_playerID +"    "+players[_playerID].transform.name);
        }
        GUILayout.EndVertical();
        GUILayout.EndArea();
    }
}
