﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterestingObject : MonoBehaviour {
	[SerializeField] private BaseObjectInfo _BaseInfo;
	public Vector3 TriggerPos{get; private set;}
	public BaseObjectInfo BaseInfo{get{return _BaseInfo;}}

	public void setPriority(int m_Priority = -10){_BaseInfo.priority = m_Priority;}
	public void setRange(float m_Range = 5.0f){_BaseInfo.AffectRange = m_Range;}
	public void setInfo(BaseObjectInfo baseInfo){_BaseInfo = baseInfo;}
}
