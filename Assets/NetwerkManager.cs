using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.SceneManagement;

public class NetwerkManager : NetworkManager
{
    public Transform[] SpawnPointList;
    public int currSpawn;

    public override void Start()
    {
        currSpawn = 0;

        SceneManager.LoadSceneAsync((int)1, LoadSceneMode.Additive);
        // nothing in base.Start, no need to call
    }


    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        Transform start = SpawnPointList[currSpawn];
        GameObject player = Instantiate(playerPrefab, start.position, start.rotation);
        NetworkServer.AddPlayerForConnection(conn, player);
        currSpawn++;
        if (currSpawn > 3)
        {
            currSpawn = 0;
        }

    }

}
