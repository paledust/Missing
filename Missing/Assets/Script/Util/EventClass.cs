﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Event {
	public delegate void Handler(Event e);
}

public class Change_Event:Event{
	public readonly InterestingObject context;
	public readonly int priority;
	public readonly float AffectRange;
	public Change_Event(int _priority = 0, float _affectRange = 5.0f, InterestingObject _context = null){
		priority = _priority;
		AffectRange = _affectRange;
		context = _context;
	}
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
public struct BaseObjectInfo{
	public int priority;
	public float AffectRange;

	public BaseObjectInfo(int _priority = -10, float _affectRange = 0.0f){
		priority = _priority;
		AffectRange = _affectRange;
	}
}