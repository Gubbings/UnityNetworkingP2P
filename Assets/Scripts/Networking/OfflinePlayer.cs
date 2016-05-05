using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class OfflinePlayer : MonoBehaviour {

    public string serverIP = "localhost";
    public int serverPort = 7777;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void connectToServer() {
        Network.Connect(serverIP, serverPort);
    }
}
