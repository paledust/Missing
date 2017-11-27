using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnFriend : MonoBehaviour {
	[SerializeField] GameObject FriendPrefeb;
	[SerializeField] GameObject PassengerPrefeb;
	[SerializeField] Transform SpawnPoint;
	bool if_Friend;
	int i = 5;
	protected void Start(){
		i = 5;
		if_Friend = false;
	}
	// Use this for initialization
	public bool Is_Friend_On_This_Train(){
		i --;
		int a = Random.Range(0,i);
		if(a == 0 && !if_Friend){
			spawn_A_Friend();
			if_Friend = true;
			return true;
		}
		else{
			spawn_A_NPC();
			return false;
		}
			
	}
	protected void spawn_A_Friend(){
		Instantiate(FriendPrefeb, SpawnPoint.position, SpawnPoint.rotation);
	}
	protected void spawn_A_NPC(){
		Instantiate(PassengerPrefeb, SpawnPoint.position, SpawnPoint.rotation);
	}
}
