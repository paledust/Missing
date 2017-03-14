using System;
using System.Collections.Generic;
using UnityEngine;

public class EventManager {
	static private EventManager instance;
	static public EventManager Instance{
		get{
			if(instance == null)
			{
				instance = new EventManager();
			}
			return instance;
		}
	}

	private Dictionary<Type, Event.handler> registeredHandlers = new Dictionary<Type, Event.handler>();

	public void RegisterHandler<T>(Event.handler handler)
	{
		
	}
	public void UnregisterHandler<T>(Event.handler handler)
	{

	}
}
