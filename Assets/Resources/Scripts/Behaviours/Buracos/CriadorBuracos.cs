using UnityEngine;
using System.Collections;

public class CriadorBuracos : CriadorPista {

	public CarroBuracos _carro;

	public override void CriarNovaPista(){
		GameObject novaPista = CriarOuAcharObjeto();
		novaPista.transform.parent = this.transform;
		novaPista.transform.localPosition = new Vector2 (_carro._posicoesFaixas[_carro._faixaAtual].position.x,  _yOffset);
		novaPista.SetActive (true);
	}

}
