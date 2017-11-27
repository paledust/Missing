using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class subwayTrigger : MonoBehaviour {
	float timer;
	[SerializeField] float T = 50.0f;
	[SerializeField] Animator m_anime;
	[SerializeField] AudioSource m_audio;
	// Use this for initialization
	void Start () {
		timer = T-5.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if(m_anime.GetCurrentAnimatorStateInfo(0).IsName("Train_Idl")){
			timer += Time.deltaTime;
			if(timer >= T){
				m_anime.SetTrigger("Arrive");
				m_audio.Play();
				timer = 0.0f;
			}
		}
		if(m_anime.GetCurrentAnimatorStateInfo(0).IsName("Train_Arrive")){
			timer += Time.deltaTime;
			if(timer >= m_anime.GetCurrentAnimatorClipInfo(0)[0].clip.length){
				m_anime.SetTrigger("Reset");
				timer = 0.0f;
			}
		}
	}
}
