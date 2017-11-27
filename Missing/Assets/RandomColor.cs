using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColor : MonoBehaviour {
	Renderer m_renderer;
	// Use this for initialization
	void Start () {
		Color ClothColor = new Color(Random.Range(0.0f,1.0f),Random.Range(0.0f,1.0f),Random.Range(0.0f,1.0f),1.0f);
		m_renderer = GetComponent<Renderer>();
		m_renderer.material.color = ClothColor;
	}
}
