using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Minigame : MonoBehaviour {

	public string _titulo;
	public string _subTitulo;
	public Text _textTitulo;
	public Text _textSubtitulo;

	float _tempoTotal;
	float _tempoInicial;

	public bool _rodando{ get; set; }
	protected GameManager _gameManager;
	//protected GUIManager _guiManager;

	protected virtual void Awake(){
		_gameManager = GameObject.FindObjectOfType<GameManager> ();
//		_guiManager = GameObject.FindObjectOfType<GUIManager> ();
		_tempoTotal = Configs.TEMPOMINIGAME;
		_rodando = false;
		_gameManager.SetTimeSlider (1);
		StartCoroutine (RotinaInicial ());
	}

	protected virtual void Update(){

		if (!_rodando)
			return;

		_gameManager.SetTimeSlider (1 - ((Time.time - _tempoInicial) / _tempoTotal));

		if (Time.time - _tempoInicial >= _tempoTotal) {
			AcabarTempo ();
		}
	}

	protected virtual IEnumerator RotinaInicial(){
		_textTitulo.text = _titulo;
		_textSubtitulo.text = _subTitulo;

		_textTitulo.gameObject.SetActive (true);
		_textSubtitulo.gameObject.SetActive (true);


		yield return new WaitForSeconds (Configs.TEMPOESPERAPADRAO);

		_textTitulo.gameObject.SetActive (false);
		_textSubtitulo.gameObject.SetActive (false);

		_rodando = true;

		_tempoInicial = Time.time;

		yield return null;

	}


	public virtual void Ganhar(){
		Debug.Log ("Ganhou");
		_rodando = false;
		StartCoroutine (RotinaVitoria ());
	}

	protected virtual IEnumerator RotinaVitoria(){

		//_gameManager.ProximoMinigame ();
		_gameManager.TerminarMinigame(true);
		yield return null;
	}

	public virtual void Perder(){
		Debug.Log ("Perdeu");
		_rodando = false;
		//Vai ser perder vida depois
		StartCoroutine(RotinaDerrota());
	}

	protected virtual IEnumerator RotinaDerrota(){
		//_gameManager.ProximoMinigame ();
		_gameManager.TerminarMinigame(false);
		yield return null;
	}

	protected virtual void AcabarTempo(){
		
	}

}
