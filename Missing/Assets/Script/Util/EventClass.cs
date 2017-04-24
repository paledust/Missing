using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Event {
	public delegate void Handler(Event e);
}
