using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.SerializableAttribute]
public class InteObject_Handler {
	[SerializeField] int _Sensibility = -10;
	public int Sensibility{get{return _Sensibility;}}
	protected GameObject Context;
	protected List<InterestingObject> LongTerm_Objects = new List<InterestingObject>();
	public InterestingObject CurrentObject{get; private set;}
	public int CurrentPriority{get{
			if(CurrentObject != null)
				return CurrentObject.BaseInfo.priority;
			else
				return Sensibility;
		}
	}
	public InteObject_Handler(GameObject _context){
		Context = _context;
	}
	internal void Start(){
		CurrentObject = null;
	}
	internal void Update(){
		InterestingObject tempObject = null;

		for(int i = LongTerm_Objects.Count - 1; i >= 0; i--){
			if(ObjectCheck(LongTerm_Objects[i])){
				tempObject = LongTerm_Objects[i];
			}
		}

		if(tempObject != null)
			CurrentObject = tempObject;

		if(CurrentObject != null && (CurrentObject.BaseInfo.priority <= Sensibility || RangeToPlayer(CurrentObject) > CurrentObject.BaseInfo.AffectRange)){
			CurrentObject = null;
		}
	}
	private bool ObjectCheck(InterestingObject _objcet){
		if(CurrentObject != null)
			return _objcet.BaseInfo.priority >= CurrentPriority &&
					_objcet.BaseInfo.AffectRange >= RangeToPlayer(_objcet) &&
					RangeToPlayer(_objcet) < RangeToPlayer(CurrentObject);
		else
			return _objcet.BaseInfo.AffectRange >= RangeToPlayer(_objcet);
	}
	private float RangeToPlayer(InterestingObject _objcet){
		return (Context.transform.position - _objcet.transform.position).magnitude;
	}
	public InterestingObject Find(Predicate<InterestingObject> predicate){
		return LongTerm_Objects.Find(predicate);
	}
	public List<InterestingObject> FindAll(Predicate<InterestingObject> predicate){
		return LongTerm_Objects.FindAll(predicate);
	}
	public void Get_Short(InterestingObject _InterestingObject){
		CurrentObject = _InterestingObject;
	}
	public void Add_Long(InterestingObject _InterestingObject){
		LongTerm_Objects.Add(_InterestingObject);
	}
	public void Remove_Long(InterestingObject _InterestingObject){
		if(LongTerm_Objects.Contains(_InterestingObject)){
			LongTerm_Objects.Remove(_InterestingObject);
		}
	}
}
