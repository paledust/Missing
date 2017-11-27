using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DressColor : MonoBehaviour {
	[SerializeField] Color ClothColor;
	Renderer m_renderer;
	// Use this for initialization
	void Start () {
		m_renderer = GetComponent<Renderer>();
		m_renderer.material.color = ClothColor;
	}
}
