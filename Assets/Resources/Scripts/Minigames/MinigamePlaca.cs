using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Linq;

[System.Serializable]
public struct Placa
{
	public Sprite sprite;
	public string resposta;
}

public class MinigamePlaca : Minigame {

	public List<Placa> _placas;
	public Image _imagemPlaca;
	public Text[] _textsBotoes;
	public GameObject _bloqueador;
	public GameObject _imagemVitoria;
	public GameObject _imagemDerrota;

	int _botaoCerto;

	void Start(){
		int indicePlaca = UnityEngine.Random.Range (0, _placas.Count);
		Placa novaPlaca = _placas[indicePlaca];
		_botaoCerto = UnityEngine.Random.Range (0, _textsBotoes.Length);
		_imagemPlaca.sprite = novaPlaca.sprite;

		System.Random rng = new System.Random ();
		//Pega 3 indices que sejam diferentes do indice da placa que esta sendo apresentada
		var outrasRespostas = Enumerable.Range (0, _placas.Count-1).Where (x => x != indicePlaca).ToList ();
		outrasRespostas = outrasRespostas.OrderBy (x => rng.Next ()).Take (3).ToList ();

		//Os botoes errados ficam com a resposta dos tres indices que peguei ali em cima
		//O botao certo fica com a resposta certa.
		for (int i = 0; i < _textsBotoes.Length; i++) {
			if (i != _botaoCerto) {
				_textsBotoes [i].text = _placas [outrasRespostas [0]].resposta;
				outrasRespostas.RemoveAt (0);
			} else {
				_textsBotoes [i].text = novaPlaca.resposta;
			}
		}
	}

	protected override IEnumerator RotinaInicial ()
	{
		yield return base.RotinaInicial ();
		_bloqueador.SetActive (false);
		yield return null;
	}

	public void EscolherResposta(int i){
		if (i == _botaoCerto) {
			Ganhar ();
		} else {
			Perder ();
		}
	}

	protected override void AcabarTempo ()
	{
		base.AcabarTempo ();
		Perder ();
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
		_imagemDerrota.SetActive (true);

		yield return new WaitForSeconds (0.5f);


		yield return base.RotinaDerrota ();
	}

}
