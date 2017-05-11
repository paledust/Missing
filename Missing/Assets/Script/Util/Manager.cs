using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Manager<T> where T: MonoBehaviour{
	protected readonly List<T> ManagedObjects = new List<T>();
	public abstract T Create();
	public abstract void Destroy(T o);
	public T Find(Predicate<T> predicate){
		return ManagedObjects.Find(predicate);
	}
	public List<T> FindAll(Predicate<T> predicate){
		return ManagedObjects.FindAll(predicate);
	}
}