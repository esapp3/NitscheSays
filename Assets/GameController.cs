using System;
using UnityEngine;
using System.Collections;
namespace SimonSaysGame
{

	public class GameController : ScriptableObject
	{
			GameObject simonSaysSpotlight;
			GameObject simonRedGameLight;
			GameObject simonBlueGameLight;
			GameObject simonYellowGameLight;
			GameObject simonGreenGameLight;
			GameObject texts;
			GameObject tsquare;
			GameObject facebook;
			Camera studentCamera;
			GameObject pinkEle;
			GameObject redScreen;
			GameObject greenScreen;
			GameObject yellowScreen;
			GameObject blueScreen;
			TextMesh teacherTextNumbers;
			TextMesh teacherNotifications;
			TextMesh studentNotifications;
			TextMesh success;
			TextMesh failure;
			sleep s;
			dream d;
			CameraSwitch switchScript;
			drift txts;
			drift t2;
			drift fb;
			ArrayList teacherSelections;
			ArrayList studentSelections;

			int teacherInputsRemaining;
			int studentInputsRemaining;
			int maxInputs;
			int roundNum;
			int roundWins;

			GameObject startCam;
			/*Erin
			Camera startCam;
			Camera endCam;

			GameObject snapeSound;
			GameObject peanutsSound;
			GameObject anyoneSound;
		
			Erin*/


			enum GameStates
			{
				START,
				NO_OBSTACLES,
				DISTRACTED,
				SLEEPY,
				DREAMING,
				WIN,
				LOSE
			};

			GameStates currentState;
			
			//Initialize any game values that need to be initialized

			public GameController() 
			{
			}

			internal void Init()
			{
				teacherInputsRemaining = 4;
				studentInputsRemaining = 5;
				maxInputs = 4;
				roundWins = 0;
				currentState = GameStates.START;
				ArrayList teacherPicks = new ArrayList();
				ArrayList studentPicks = new ArrayList();
				simonSaysSpotlight = GameObject.Find("SimonSaysLight");
				simonRedGameLight = GameObject.Find("SimonSaysLightRed");
				simonBlueGameLight = GameObject.Find("SimonSaysLightBlue");
				simonYellowGameLight = GameObject.Find("SimonSaysLightYellow");
				simonGreenGameLight = GameObject.Find("SimonSaysLightGreen");
				texts = GameObject.Find ("texts");
				tsquare = GameObject.Find ("tsquare");
				facebook = GameObject.Find ("facebook");
				studentCamera = GameObject.Find ("Student Camera").GetComponent<Camera>() as Camera;
				pinkEle = GameObject.Find ("PinkElephant");
				teacherTextNumbers = GameObject.Find("teacherInputsRemaining").GetComponent<TextMesh>();
				teacherNotifications = GameObject.Find("teacherNotifications").GetComponent<TextMesh>();
				studentNotifications = GameObject.Find("studentNotifications").GetComponent<TextMesh>();
				success = GameObject.Find("successNotification").GetComponent<TextMesh>();
				failure = GameObject.Find("failureNotification").GetComponent<TextMesh>();
				texts.SetActive(false);
				tsquare.SetActive(false);
				facebook.SetActive(false);
				s = studentCamera.GetComponent<sleep>();
				d = studentCamera.GetComponent<dream>();
				txts = texts.GetComponent<drift>();
				t2 = tsquare.GetComponent<drift>();
				fb = facebook.GetComponent<drift>();
				roundNum = 1;
				teacherSelections = new ArrayList();
				studentSelections = new ArrayList();
				redScreen = GameObject.Find("redScreen");
				redScreen.SetActive(false);
				greenScreen = GameObject.Find("greenScreen");
				greenScreen.SetActive(false);
				yellowScreen = GameObject.Find("yellowScreen");
				yellowScreen.SetActive(false);
				blueScreen = GameObject.Find("blueScreen");
				blueScreen.SetActive(false);
				//pinkEle.SetActive(false);

				startCam = GameObject.Find("StartCamera");
				switchScript = startCam.GetComponent<CameraSwitch>();

				/*Erin*/
				//startCam = GameObject.Find ("StartCamera").GetComponent<Camera>() as Camera;
				//endCam = GameObject.Find ("EndCamera").GetComponent<Camera>() as Camera;

				//snapeSound = GameObject.Find ("snapeSound");
				//peanutsSound = GameObject.Find ("peanutsSound");
				//anyoneSound = GameObject.Find ("anyoneSound");
				
				//startCam.enabled = true;
				//endCam.enabled = false;
				//studentCamera.enabled = false;
				//startCam.gameObject.camera.enabled = true;
				//endCam.gameObject.camera.enabled = false;
				//studentCamera.gameObject.camera.enabled = false;
				
				//snapeSound.gameObject.audio.enabled = false;
				//peanutsSound.gameObject.audio.enabled = false;
				//anyoneSound.gameObject.audio.enabled = true;
				/*Erin*/ 

			}

			internal void UpdateGame()
			{
				if(currentState == GameStates.START) 
				{
					if(Input.GetKeyUp(KeyCode.Space))
					{
						currentState = GameStates.NO_OBSTACLES;
						switchScript.switchMain();
						//startCam.enabled = false;
						//endCam.enabled = false;
						//studentCamera.enabled = true;
						return;
					}
				}
				else if(currentState == GameStates.NO_OBSTACLES) 
				{
					teacherRoundLogic();
					return;
				}

				else if(currentState == GameStates.DISTRACTED) 
				{
					teacherRoundLogic();
					return;
				}

				else if(currentState == GameStates.SLEEPY) 
				{
					teacherRoundLogic();
					return;
				}

				else if(currentState == GameStates.DREAMING) 
				{
					teacherRoundLogic ();
					return;
				}

				else if(currentState == GameStates.WIN) 
				{
					switchScript.switchWin();
				}

				else if(currentState == GameStates.LOSE) 
				{
					switchScript.switchEnd();
				}
			}

			internal void decrementTeacherSelections() 
			{
				if (teacherInputsRemaining > 0) 
				{
					teacherInputsRemaining--;
				}
			}

			/////////////////////////////
			//REACT TO TEACHER INPUT   //
			/////////////////////////////


			bool check_A_Pressed()
			{
				if (Input.GetKey(KeyCode.W)) 
				{
					return true;
				}
				return false;
			}
			bool check_A_Released()
			{
			if (Input.GetKeyUp(KeyCode.W))
				{
					return true;
				}
				return false;
			}
			bool check_B_Pressed()
			{
			if (Input.GetKey(KeyCode.A))
				{
					return true;
				}
				return false;
			}
			bool check_B_Released()
			{
			if (Input.GetKeyUp(KeyCode.A))
				{
					return true;
				}
				return false;
			}
			bool check_X_Pressed()
			{
			if (Input.GetKey(KeyCode.S))
				{
					return true;
				}
				return false;
			}
			bool check_X_Released()
			{
			if (Input.GetKeyUp(KeyCode.S))
				{
					return true;
				}
				return false;
			}
			bool check_Y_Pressed()
			{
			if (Input.GetKey(KeyCode.D))
				{
					return true;
				}
				return false;
			}
			bool check_Y_Released()
			{
			if (Input.GetKeyUp(KeyCode.D))
				{
					return true;
				}
				return false;
			}

			void checkTeacherInputs()
			{
				if(check_X_Pressed()) pressBlue ();
				if(check_X_Released()) releaseBlue ();
				if(check_Y_Pressed()) pressYellow ();
				if(check_Y_Released()) releaseYellow ();
				if(check_B_Pressed()) pressRed ();
				if(check_B_Released()) releaseRed ();
				if(check_A_Pressed()) pressGreen ();
				if(check_A_Released()) releaseGreen ();
			}
			//GREEN
			void pressRed()
			{
				simonRedGameLight.light.intensity = 1.5f;
			}

			void releaseRed()
			{
				simonRedGameLight.light.intensity = 0f;
				teacherSelections.Add ("RED");
				decrementTeacherSelections();
			}

			void pressGreen()
			{
				simonGreenGameLight.light.intensity = 1.5f;
				
			}
			
			void releaseGreen()
			{
				simonGreenGameLight.light.intensity = 0f;
				teacherSelections.Add("GREEN");
				decrementTeacherSelections();
			}

			void pressBlue()
			{
				simonBlueGameLight.light.intensity = 1.5f;
				
			}
			
			void releaseBlue()
			{
				simonBlueGameLight.light.intensity = 0f;
				teacherSelections.Add("BLUE");
				decrementTeacherSelections();
			}

			void pressYellow()
			{
				simonYellowGameLight.light.intensity = 1.5f;
				
			}
			
			void releaseYellow()
			{
				simonYellowGameLight.light.intensity = 0f;
				teacherSelections.Add ("YELLOW");
				decrementTeacherSelections();
			}
			
			void incrementRound()
			{
				if(currentState == GameStates.NO_OBSTACLES)
				{ 
					currentState = GameStates.DISTRACTED;
					texts.SetActive(true);
					tsquare.SetActive(true);
					facebook.SetActive(true);
					txts.scriptActive = true;
					t2.scriptActive = true;
					fb.scriptActive = true;
				}
				else if(currentState == GameStates.DISTRACTED)
				{
					currentState = GameStates.SLEEPY;
					
					s.scriptActive = true;
				}
				else if(currentState == GameStates.SLEEPY) 
				{ 
					switchScript.dreamSound();
					s.scriptActive = false;	

					currentState = GameStates.DREAMING;
					pinkEle.SetActive(true);
					
					d.scriptActive = true;
				}
				else if (currentState == GameStates.DREAMING)
				{
					if(roundWins >= 3)
					{
						currentState = GameStates.WIN;
					}
					else
					{
						currentState = GameStates.LOSE;
					}
				}

			}
			void resetRound() 
			{
				maxInputs = maxInputs + 2;
				teacherInputsRemaining = maxInputs;
				studentInputsRemaining = maxInputs+1;
				studentSelections = new ArrayList();
				teacherSelections = new ArrayList();
				teacherTextNumbers.text = "" + (studentInputsRemaining-1);
			}

			void pauseScripts()
			{
				d.scriptActive = false;
				s.scriptActive = false;
				t2.scriptActive = false;
				txts.scriptActive = false;
				fb.scriptActive = false;
				texts.rigidbody.useGravity = false;
			}
			
			void startScripts()
			{
				if(currentState == GameStates.DISTRACTED)
				{
					t2.scriptActive = true;
					fb.scriptActive = true;
					txts.scriptActive = true;
					texts.rigidbody.useGravity = true;
				}
				else if(currentState == GameStates.SLEEPY)
				{
					t2.scriptActive = true;
					fb.scriptActive = true;
					txts.scriptActive = true;
					s.scriptActive = true;
					texts.rigidbody.useGravity = true;
				}
				else if(currentState == GameStates.DREAMING)
				{
					t2.scriptActive = true;
					fb.scriptActive = true;
					txts.scriptActive = true;
					d.scriptActive = true;
					s.scriptActive = true;
					texts.rigidbody.useGravity = true;
				}
				
			}

			void displayRoundText()
			{
				studentNotifications.text = "Round " + roundNum + " Over! Press Any Button.";
			}
			
			void displaySuccess()
			{
				success.text = "Success!";
			}
			
			void displayFailure()
			{
				failure.text = "Failure...";
			}

			void clearRoundText()
			{
				studentNotifications.text = "";
				teacherNotifications.text = "";
				success.text = "";
				failure.text = "";
			}
			
			void teacherRoundLogic() 
			{
				
				if(teacherInputsRemaining > 0)
				{
					checkTeacherInputs();
				}
				else
				{
					studentPlay();
					if(studentInputsRemaining == 1)
					{
						pauseScripts();
						displayRoundText();
						int correct = 0;
						for(int i = 0; i < teacherSelections.Count; i++)
						{
							if(teacherSelections[i].Equals(studentSelections[i]))
							{
								correct++;
							}
						}
						if(correct == maxInputs)
						{
							roundWins++;
							displaySuccess();
						}
						else
						{
							displayFailure();
						}
					}
					if(studentInputsRemaining <= 0)
					{
						clearRoundText();
						resetRound();
						incrementRound();
						startScripts();
						roundNum++;
						return;
					}
					teacherNotifications.text = "Teacher Input for Round Complete";
				}
			}
			///////////////////////////
			//REACT TO STUDENT INPUT //
			///////////////////////////
		void studentPlay() {
			if (Input.GetKey(KeyCode.UpArrow)) {
				redScreen.SetActive(true);
			}
			if (Input.GetKeyUp(KeyCode.UpArrow)) {
				redScreen.SetActive(false);
				decrementStudentSelections();
				studentSelections.Add ("RED");
			}
			if (Input.GetKey(KeyCode.DownArrow)) {
				yellowScreen.SetActive(true);
			}
			if (Input.GetKeyUp(KeyCode.DownArrow)) {
				yellowScreen.SetActive(false);
				decrementStudentSelections();
				studentSelections.Add ("YELLOW");
			}
			if (Input.GetKey(KeyCode.LeftArrow)) {
				blueScreen.SetActive(true);
			}
			if (Input.GetKeyUp(KeyCode.LeftArrow)) {
				blueScreen.SetActive(false);
				decrementStudentSelections();
				studentSelections.Add ("BLUE");
			}
			if (Input.GetKey(KeyCode.RightArrow)) {
				greenScreen.SetActive(true);
			}
			if (Input.GetKeyUp(KeyCode.RightArrow)) {
				greenScreen.SetActive(false);
				decrementStudentSelections();
				studentSelections.Add ("GREEN");
			}
		}

		void decrementStudentSelections()
		{
			if (studentInputsRemaining > 0) 
			{
				studentInputsRemaining--;
				teacherTextNumbers.text = "" + (studentInputsRemaining-1);
			}
		}
	}
}


