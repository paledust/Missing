using System;
using System.Collections.Generic;
using Custom_Event;
using Event = Custom_Event.Event;
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

	private Dictionary<Type, Event.Handler> registeredHandlers = new Dictionary<Type, Event.Handler>();

	public void RegisterHandler<T>(Event.Handler handler)
	{
		Type type = typeof(T);

		if(registeredHandlers.ContainsKey(type)){
			registeredHandlers[type] += handler;
		}
		else{
			registeredHandlers[type] = handler;
		}
	}
	public void UnregisterHandler<T>(Event.Handler handler)
	{
		Type type = typeof(T);
		Event.Handler eventhandlers;

		if(registeredHandlers.TryGetValue(type, out eventhandlers)){
			eventhandlers -= handler;
			if(eventhandlers == null){
				registeredHandlers.Remove(type);
			}
			else{
				registeredHandlers[type] = eventhandlers;
			}
		}
	}
	public void ClearList(){
		registeredHandlers.Clear();
	}
	public void FireEvent(Event e){
		Type type = e.GetType();
		Event.Handler eventhandlers;
		if(registeredHandlers.TryGetValue(type, out eventhandlers)){
			eventhandlers(e);
		}
	}
}
