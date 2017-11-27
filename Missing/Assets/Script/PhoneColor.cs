using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PhoneColor : MonoBehaviour {
	[SerializeField] Color phoneColor;
	Renderer m_renderer;
	// Use this for initialization
	void Start () {
		m_renderer = GetComponent<Renderer>();
		m_renderer.material.color = phoneColor;
	}
}
