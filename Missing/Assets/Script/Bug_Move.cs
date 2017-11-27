using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bug_Move : MonoBehaviour {
	Vector3 moveDirection;
	Rigidbody m_rigidBody;
	// Use this for initialization
	void Start () {
		m_rigidBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		m_rigidBody.velocity = moveDirection;
	}
}
