using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Custom_Event;
using Event = Custom_Event.Event;
public class PhoneObj : ShiftingObject {
    [SerializeField] AudioClip Ringing;
    AudioSource m_audio;

    public override void OnCreate(){
        Long_Range_Event tempEvent = new Long_Range_Event(BaseInfo.priority, gameObject);
		Service.eventManager.FireEvent(tempEvent);
        m_audio = GetComponentInChildren<AudioSource>();
    }
	public void Ring(){
        m_audio = GetComponentInChildren<AudioSource>();
        setPriority(20);
        setRange(50);
        m_audio.clip = Ringing;
        m_audio.loop = true;
        m_audio.Play();
    }
}
