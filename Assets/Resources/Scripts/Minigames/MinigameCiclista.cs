using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MinigameCiclista : Minigame {

	[SerializeField]
	float _tempoMaximoPertoDemais = 1f;

	public float _distanciaMinima = 1.5f;

	public float _tempoPertoDemais{get;set;}

	public GameObject _imagemVitoria;
	public GameObject _imagemMulta;
	public Text _textoMulta;

	string _infracao = "Você tem que manter 1,5m de distância dos ciclistas.";

	public void ContarTempo(){
		_tempoPertoDemais += Time.deltaTime;
		if (_tempoPertoDemais >= _tempoMaximoPertoDemais) {
			Perder ();
		}
	}

	protected override void Update ()
	{
		base.Update ();
	}

	public void ResetarTempo(){
		_tempoPertoDemais = 0;
	}

	public void Perder(string s){
		_infracao = s;
		Perder ();
	}

	protected override void AcabarTempo ()
	{
		
		base.AcabarTempo ();
		Ganhar ();

	}

	protected override IEnumerator RotinaVitoria ()
	{

		_rodando = false;
		_imagemVitoria.SetActive (true);
		yield return new WaitForSeconds (0.5f);

		yield return base.RotinaVitoria ();
	}

	protected override IEnumerator RotinaDerrota ()
	{
		_rodando = false;
		_textoMulta.text = _infracao;
		_imagemMulta.SetActive (true);

		yield return new WaitForSeconds (0.5f);


		yield return base.RotinaDerrota ();
	}


}
