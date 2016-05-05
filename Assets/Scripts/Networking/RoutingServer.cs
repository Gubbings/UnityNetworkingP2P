using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System.Collections.Generic;

public class RoutingServer : NetworkBehaviour {

    public int serverPort = 4444;
    public Queue<NetworkPlayer> players = new Queue<NetworkPlayer>();

    private int playerCount = 0;
    private int lastCount = 0;


    public GameObject playButton;
    private bool inQueue = false;

    // Use this for initialization
    void Start () {
      //  setupServer();
	}
	
	// Update is called once per frame
	void Update () {
        if (Network.isServer) {
            if (players.Count > lastCount) {
                lastCount++;
                Debug.Log("player queued");
            }
        }
	}

    private void setupServer() {
        NetworkServer.Listen(serverPort);
    }

    private void OnPlayerConnected(NetworkPlayer player) {
        playerCount++;
    }

    [Command]
    public void CmdPlay() {
        RoutingServer rs = this.GetComponent<RoutingServer>();
        rs.players.Enqueue(Network.player);

        inQueue = true;
        playButton.SetActive(false);

        Debug.Log(rs.players.ToArray().Length);
    }
}
