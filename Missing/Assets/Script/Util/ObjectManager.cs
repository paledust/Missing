using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EventType{
	Last_Event,
	Flash_Event,
	Deffered_Event
}

public class ObjectManager : Manager<InterestingObject> {
	[SerializeField] GameObject objectTemplate;
	public override InterestingObject Create(){
		var _object = GameObject.Instantiate(objectTemplate);
		var _interests = _object.AddComponent<InterestingObject>();
		ManagedObjects.Add(_interests);
		_interests.OnCreate();
		return _interests;
	}
	public override void Destroy(InterestingObject _object){
		ManagedObjects.Remove(_object);
		Destroy(_object);
	}

}
