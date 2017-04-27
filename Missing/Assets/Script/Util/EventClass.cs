using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Event {
	public delegate void Handler(Event e);
}

public class Att_Event:Event{
	public readonly GameObject context;
	public readonly int priority;
	public readonly float AffectRange;
	public Att_Event(int _priority = 0, float _affectRange = 5.0f, GameObject _context = null){
		priority = _priority;
		AffectRange = _affectRange;
		context = _context;
	}
}
public class Fall_Event: Att_Event{
	public Fall_Event(int _priority = 0, float _affectRange = 5.0f, GameObject _context = null): 
		base(_priority, _affectRange, _context){}
}
public class Shift_Event: Att_Event{
	public Shift_Event(int _priority = 0, float _affectRange = 5.0f, GameObject _context = null): 
		base(_priority, _affectRange, _context){}
}

[System.SerializableAttribute]
public struct BaseEventInfo{
	public int priority;
	public float AffectRange;
}