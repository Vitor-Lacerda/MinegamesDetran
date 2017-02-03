using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class GameManager : MonoBehaviour {

	public List<Minigame> _minigames;
	List<Minigame> _minigamesPossiveisFase;
	public int _pontosPorMinigame = 100;
	public GUIManager _guiManager;
	public int _chancesTotais = 3;
	public int _minisPorFase = 3;
	public int _decrementoTempo = 1;
	public int _tempoMinimo = 2;

	int _pontuacaoAtual;
	int _chances;
	int _highscore;
	int _minisJogados;


	Minigame _miniGameAtual;

	// Use this for initialization
	void Start () {
		_minigamesPossiveisFase = new List<Minigame> ();
		Iniciar ();
	}

	public void Iniciar(){
		_pontuacaoAtual = 0;
		_chances = _chancesTotais;
		_guiManager.MostrarTelaGameOver (false);
		_guiManager.ResetarPontuação ();
		SortearMinigames ();
		ProximoMinigame ();
	}

	void SortearMinigames(){
		System.Random rng = new System.Random ();
		_minigamesPossiveisFase = _minigames.OrderBy (x => rng.Next ()).ToList();
	}

	public void TerminarMinigame(bool ganhou){
		StartCoroutine (RotinaFimMinigame (ganhou));
	}

	IEnumerator RotinaFimMinigame(bool ganhou){

		bool fim = false;
		_minisJogados++;
		_guiManager.MostrarTelaPontuacao (true);
		TiraMiniGame ();
		if (ganhou) {
			_pontuacaoAtual += _pontosPorMinigame;
			yield return StartCoroutine (_guiManager.RotinaPontuar (_pontuacaoAtual, _pontosPorMinigame));
		} else {
			yield return StartCoroutine(_guiManager.RotinaPerderChance(_chancesTotais - _chances));
			_chances -= 1;
			if (_chances == 0) {
				fim = true;
				_guiManager.MostrarTelaGameOver (true);
			}
		}

		_guiManager.MostrarTelaPontuacao(false);

		if (!fim) {
			if (_minisJogados == _minisPorFase) {
				if (Configs.TEMPOMINIGAME > _tempoMinimo) {
					yield return StartCoroutine (_guiManager.RotinaMaisRapido ());
					_minisJogados = 0;
					Configs.FASE++;
					Configs.TEMPOMINIGAME -= _decrementoTempo;
				}
				SortearMinigames ();
			}
			

			ProximoMinigame ();
		}

		yield return null;

	}


	void TiraMiniGame(){
		if (_miniGameAtual != null) {
			Destroy (_miniGameAtual.gameObject);
		}
	}

	void ProximoMinigame(){
		
		//Minigame mini = _minigames [_minigames.Count-1];
		if (_minigamesPossiveisFase.Count <= 0) {
			SortearMinigames ();
		}
		Minigame mini = _minigamesPossiveisFase[0];
		Minigame novoMini = Instantiate (mini) as Minigame;
		_miniGameAtual = novoMini;
		_minigamesPossiveisFase.RemoveAt (0);
	}


	public void SetTimeSlider(float fracao){
		_guiManager.SetTimeSlider (fracao);
	}
}
