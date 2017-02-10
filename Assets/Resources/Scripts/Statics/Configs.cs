using UnityEngine;
using System.Collections;
using System.Globalization;


public class Configs : MonoBehaviour {

	public static string PLAYERPREFSKEY = "Minigames";
	public static float TEMPOMINIGAMEINICIAL = 6f;
	public static float TEMPOMINIGAME = 6f;
	public static int FASE = 0;
	public static float TEMPOESPERAPADRAO = 1f;

	public static NumberFormatInfo nfi;

	void Awake(){
		nfi = new NumberFormatInfo ();
		nfi.NumberDecimalSeparator= ",";
		nfi.NumberGroupSeparator = ".";
		TEMPOMINIGAME = TEMPOMINIGAMEINICIAL;
	}



}
