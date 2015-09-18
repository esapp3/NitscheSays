using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour 
{

	private const string gameTypeName = "NitscheSays";
	private const string nameOfHostedGame = "UniqueGame";
	private HostData[] hosts;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	// Used to initialize server and register to master server
	private void StartServer() 
	{
		Network.InitializeServer (2, 25000, !Network.HavePublicAddress());
		MasterServer.RegisterHost (gameTypeName, nameOfHostedGame);
	}

	// Runs when the server successfully initializes
	void OnServerInitialized() 
	{
		Debug.Log ("Server has started!");
	}

	void OnGUI() 
	{
		if (!Network.isClient && !Network.isServer) {
			if (GUI.Button(new Rect(50, 50, 100, 75), 
			               "Start a Server") ) 
			{
				StartServer();
			}

			if (GUI.Button (new Rect(50, 250, 100, 75),
			                "Refresh Hosts") ) 
			{
				RefreshHostList();
			}
			if (hosts != null)
			{
				for( int i = 0; i < hosts.Length; i++)
				{
					if (GUI.Button(new Rect(250, 50, 100, 75), hosts[i].gameName))
				    {
						JoinHostedGame(hosts[i]);
					}
				}
			}
		}
	}

	private void RefreshHostList() 
	{
		MasterServer.RequestHostList(gameTypeName);
	}

	void OnMasterServerEvent(MasterServerEvent e)
	{
		if (e == MasterServerEvent.HostListReceived)
		{
			hosts = MasterServer.PollHostList();
		}
	}

	private void JoinHostedGame(HostData hostData) 
	{
		Network.Connect(hostData);
	}

	void OnConnectedToServer()
	{
		Debug.Log ("Connected to Server.");
	}


}
