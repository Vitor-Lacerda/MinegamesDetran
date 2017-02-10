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

	public float _intervaloEnvioPontuacao = 30f;
	float _ultimoEnvioPontuacao;

	UserService _uService;

	int _pontuacaoAtual;
	int _chances;
	int _highscore;
	int _minisJogados;

	System.Random rng;


	Minigame _miniGameAtual;

	// Use this for initialization
	void Start () {
		_uService = GameObject.Find ("_Login").GetComponent<UserService> ();
		rng = new System.Random ();
		_minigamesPossiveisFase = new List<Minigame> ();
		Iniciar ();
		_ultimoEnvioPontuacao = Time.time;
	}

	public void Iniciar(){
		_pontuacaoAtual = 0;
		_chances = _chancesTotais;
		_guiManager.MostrarTelaGameOver (false,0,0);
		_guiManager.ResetarPontuação ();
		SortearMinigames ();
		ProximoMinigame ();
		Configs.FASE = 0;
		Configs.TEMPOMINIGAME = Configs.TEMPOMINIGAMEINICIAL;
		Carregar ();
	}

	void SortearMinigames(){
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
			Pontuar ();
			yield return StartCoroutine (_guiManager.RotinaPontuar (_pontuacaoAtual, _pontosPorMinigame));
		} else {
			yield return StartCoroutine(_guiManager.RotinaPerderChance(_chancesTotais - _chances));
			_chances -= 1;
			if (_chances == 0) {
				fim = true;
				_guiManager.MostrarTelaGameOver (true, _pontuacaoAtual, _highscore);
				EnviarPontuacao (false);
			}
		}

		_guiManager.MostrarTelaPontuacao(false);

		if (!fim) {
			if (_minisJogados == _minisPorFase + Configs.FASE) {
				if (Configs.TEMPOMINIGAME > _tempoMinimo) {
					yield return StartCoroutine (_guiManager.RotinaMaisRapido ());
					_minisJogados = 0;
					Configs.FASE++;
					Configs.TEMPOMINIGAME -= _decrementoTempo;
					SortearMinigames ();
				}
			}
			

			ProximoMinigame ();
		}

		yield return null;

	}

	void Pontuar(){
		_pontuacaoAtual += _pontosPorMinigame;
		if (_pontuacaoAtual > _highscore) {
			_highscore = _pontuacaoAtual;
			_uService.SetHighScore (_highscore);
			Salvar ();
		}
	}

	void Salvar(){
		PlayerPrefs.SetInt (Configs.PLAYERPREFSKEY + _uService.userEmail, _highscore);
	}

	void Carregar(){
		_highscore = PlayerPrefs.GetInt (Configs.PLAYERPREFSKEY + _uService.userEmail, 0);
	}

	public void EnviarPontuacao(bool checarTempo){
		if (checarTempo) {
			if (Time.time - _ultimoEnvioPontuacao < _intervaloEnvioPontuacao) {
				return;
			}
		}
		_uService.CallSendScore ();
		_ultimoEnvioPontuacao = Time.time;
	}

	void TiraMiniGame(){
		if (_miniGameAtual != null) {
			Destroy (_miniGameAtual.gameObject);
		}
	}

	void ProximoMinigame(){
		
		if (_minigamesPossiveisFase.Count <= 0) {
			SortearMinigames ();
		}
		//Minigame mini = _minigames [_minigames.Count-1];
		Minigame mini = _minigames[3];
		//Minigame mini = _minigamesPossiveisFase[0];
		Minigame novoMini = Instantiate (mini) as Minigame;
		_miniGameAtual = novoMini;
		_minigamesPossiveisFase.RemoveAt (0);
	}


	public void SetTimeSlider(float fracao){
		_guiManager.SetTimeSlider (fracao);
	}
}
