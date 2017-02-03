using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CarroMiniCiclista : MonoBehaviour {

	public float _velocidade = 1f;
	public Transform _ciclista;
	public Image _medidorDistancia;
	public Text _textDistancia;

	float _textWidthInicial;
	MinigameCiclista _minigame;
	float _distanciaInicial;



	// Use this for initialization
	void Start () {
		_minigame = this.transform.parent.GetComponent<MinigameCiclista> ();
		_distanciaInicial = Vector3.Distance (this.transform.position, _ciclista.position);
		_textWidthInicial = _textDistancia.rectTransform.sizeDelta.x;
		ConfiguraMedidor ();
		_velocidade += 0.5f * Configs.FASE;
	}
	
	// Update is called once per frame
	void Update () {

		if (!_minigame._rodando)
			return;

		if (Input.GetMouseButton (0) || Input.GetKey (KeyCode.Space)) {
			transform.position += Vector3.left * _velocidade * Time.deltaTime;
		} else {
			transform.position += Vector3.right * _velocidade * Time.deltaTime;
		}

		ConfiguraMedidor ();

		if (Vector3.Distance (this.transform.position, _ciclista.position) < _minigame._distanciaMinima) {
			_minigame.ContarTempo ();
			_medidorDistancia.color = Color.red;
		} else {
			_minigame.ResetarTempo ();
			_medidorDistancia.color = Color.white;
		}
	}

	void ConfiguraMedidor(){
		float distancia = Vector3.Distance (this.transform.position, _ciclista.position);

		//Posiciona o medidor
		Vector2 temp = _medidorDistancia.transform.localScale;
		temp.x = (distancia / _distanciaInicial);
		_medidorDistancia.transform.localScale = temp;
		_medidorDistancia.transform.position = Camera.main.WorldToScreenPoint (transform.position);

		//Posiciona o texto horizontalmente
		temp = _textDistancia.transform.position;
		temp.x = Camera.main.WorldToScreenPoint (transform.position).x;
		_textDistancia.transform.position = temp;

		//Muda o tamanho da caixa do texto pra ele acompanhar o carro
		temp = _textDistancia.rectTransform.sizeDelta;
		temp.x = (distancia / _distanciaInicial) * _textWidthInicial;
		_textDistancia.rectTransform.sizeDelta = temp;

		//Muda o texto mesmo
		//1,5 e porque precisa manter 1,5m do ciclista na vida real. Não é um numero magico
		float distanciaRealAtual = (distancia * 1.5f)/_minigame._distanciaMinima;
		_textDistancia.text = distanciaRealAtual.ToString ("F2", Configs.nfi) + "m";
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("Ciclista")) {
			_minigame.Perder ("Você tem que manter 1,5m de distância do ciclista.");
		}
		if (other.CompareTag ("Contramao")) {
			_minigame.Perder ("Você entrou na contramão!.");
		}
	}
}
