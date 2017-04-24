using UnityEngine;

[CreateAssetMenuAttribute (menuName = "PrefebList") ]
public class PrefebDB : ScriptableObject {
	[SerializeField] GameObject _NPC;
	public GameObject NPC{get{return _NPC;}}
	[SerializeField] GameObject _Player;
	public GameObject Player{get{return _Player;}}
}
