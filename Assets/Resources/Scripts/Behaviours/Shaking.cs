using UnityEngine;
using System.Collections;

public class Shaking : MonoBehaviour {

	public float _frequency;
	public float _amplitude;
	public Vector2 _multipliers;
	public Vector2 _centro;
	public bool _rodando;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (!_rodando) {
			return;
		}

		Vector2 temp = transform.localPosition;
		if(_multipliers.x != 0)
		temp.x =  _centro.x + _multipliers.x*_amplitude*Mathf.Sin (Mathf.PI*2*Time.time*_frequency);
		if(_multipliers.y != 0)
		temp.y = _centro.y + _multipliers.y*_amplitude*Mathf.Sin (Mathf.PI*2*Time.time*_frequency + Mathf.PI/2);

		transform.localPosition = temp;
	}
}
