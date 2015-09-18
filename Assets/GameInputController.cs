using System;
using UnityEngine;
using System.Collections;
namespace SimonSaysGame
{
	public class GameInputController: MonoBehaviour
	{
		//Controller Values
		bool playerIndexSet = false;
		GameController gameInstance;
		ScriptableObject gameScript;

	

		//Use this for initialization
		void Start()
		{
			//KEYBOARD/CONTROLLER SWITCH
			gameScript = ScriptableObject.CreateInstance("GameController");
			gameInstance = (GameController)gameScript;
			gameInstance.Init();
		}

		//Update is called once per frame
		void Update()
		{
			gameInstance.UpdateGame();
		}
	}
}

