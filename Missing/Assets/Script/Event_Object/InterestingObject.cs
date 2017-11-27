using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Custom_Event;

public class InterestingObject : MonoBehaviour {
	[SerializeField] protected BaseObjectInfo _BaseInfo;
	public BaseObjectInfo BaseInfo{get{return _BaseInfo;}}

	public virtual void OnCreate(){}
	public virtual void OnDestroy(){}
	public void setPriority(int m_Priority = -10){_BaseInfo.priority = m_Priority;}
	public void setRange(float m_Range = 5.0f){_BaseInfo.AffectRange = m_Range;}
	public void setInfo(BaseObjectInfo baseInfo){_BaseInfo = baseInfo;}
}
