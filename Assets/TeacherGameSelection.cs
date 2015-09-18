using System;
using UnityEngine;

public class TeacherGameSelection : MonoBehaviour
{
		public enum SimonSaysColor 
		{ 
			GREEN, RED, BLUE, YELLOW
		};

		private SimonSaysColor color;
		public TeacherGameSelection (SimonSaysColor newColor) 
		{
			this.color = newColor;
		}

		public SimonSaysColor getColor()
		{
			return color;
		}
}


