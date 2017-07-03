using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Crazy : NPC_FSM_Head {
	public InterestingObject Inte_Crazyness;
	protected override void Start(){
		base.Start();
		Inte_Crazyness = GetComponent<CrazyPeople>();
		fsm.TransitionTo<PENDING_CRAZY_State>();
	}
	public class CRAZY_State: NPC_State{

		public override void OnEnter(){
			ExitTime = Random.Range(3f,5f);
			timer = 0.0f;
			NPC_Crazy _context = Context as NPC_Crazy;

			_context.Inte_Crazyness.setPriority(10);
			Short_Range_Event tempEvent = new Short_Range_Event(_context.Inte_Crazyness.BaseInfo.priority, 
																	_context.Inte_Crazyness.BaseInfo.AffectRange, 
																	_context.gameObject);
			Service.eventManager.FireEvent(tempEvent);
		}
		public override void Update(){
			Context.transform.LookAt(Context.RANDOM_LOOK_POINT);
			timer += Time.deltaTime;
			if(timer > ExitTime){
				TransitionTo<PENDING_CRAZY_State>();
			}
		}
	}
	public class PENDING_CRAZY_State: NPC_State{
		public override void OnEnter(){
			timer = 0.0f;
			ExitTime = Random.Range(5f,10f);
			NPC_Crazy _context = Context as NPC_Crazy;

			_context.Inte_Crazyness.setPriority(-11);
			_context.LookTo(_context.transform.rotation * Vector3.forward + _context.transform.rotation * Vector3.down  * 10 + _context.transform.position);
		}
		public override void Update(){
			timer += Time.deltaTime;
			if(timer >= ExitTime){
				TransitionTo<CRAZY_State>();
			}
		}
	}
}
