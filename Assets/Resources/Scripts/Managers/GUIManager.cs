using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour {

	public RectTransform _timeSlider;
	Image _timeSliderImage;


	public GameObject _telaPontuacao;
	public Text _textoPontuacao;
	public Image[] _imagensChances;

	public GameObject _telaGameOver;
	public Text _textoScoreFinal;
	public Text _textoHighscore;

	public GameObject _telaMaisRapido;



	void Awake(){
		_timeSliderImage = _timeSlider.GetComponent<Image> ();

	}

	public void SetTimeSlider(float fracao){
		Vector2 temp = _timeSlider.localScale;
		temp.x= fracao;
		_timeSlider.localScale = temp;
		Color tempColor = _timeSliderImage.color;
		tempColor.g = fracao;
		tempColor.b = fracao;
		_timeSliderImage.color = tempColor;
	}

	public void MostrarTelaPontuacao(bool b){
		_telaPontuacao.SetActive(b);
	}

	public void MostrarTelaGameOver(bool b, int score, int highscore){
		_textoScoreFinal.text = score.ToString();
		_textoHighscore.text = highscore.ToString ();
		_telaGameOver.SetActive (b);
	}

	public void ResetarPontuação(){
		_textoPontuacao.text = "0";
		foreach (Image i in _imagensChances) {
			i.color = Color.white;
		}
	}

	public IEnumerator RotinaMaisRapido(){
		_telaMaisRapido.SetActive (true);

		yield return new WaitForSeconds (1f);

		_telaMaisRapido.SetActive (false);

	}

	public IEnumerator RotinaPontuar(int pontuacao, int incremento){
		int p = pontuacao - incremento;
		_textoPontuacao.text = p.ToString ();

		while (p < pontuacao) {
			p += 2;
			_textoPontuacao.text = p.ToString ();
			yield return null;
		}

		yield return new WaitForSeconds (1f);
	}

	public IEnumerator RotinaPerderChance(int chancesPerdidas){

		yield return new WaitForSeconds (1f);

		_imagensChances [chancesPerdidas].color = Color.red;


		yield return new WaitForSeconds(1f);

	}

}
