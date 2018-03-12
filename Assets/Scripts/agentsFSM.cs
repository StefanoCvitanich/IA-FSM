using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class agentsFSM : MonoBehaviour {

	State[,] fsm;

	public int rowStates;

	public int colEvents;

	private State currentState;

	private Vector3 startPos;

	public enum State
	{
		Idle,

		UpAndDown,

		RightAndLeft,

		Null
	};

	public enum Event
	{
		RedButtonPressed,

		BlueButtonPressed,

		GreenButtonPressed
	};

	// Use this for initialization
	void Start () {

		fsm = new State[rowStates,colEvents];

		startPos = transform.position;

		currentState = State.RightAndLeft;

		setRelation (State.Idle, Event.RedButtonPressed, State.UpAndDown);
		setRelation (State.Idle, Event.BlueButtonPressed, State.RightAndLeft);
		setRelation (State.Idle, Event.GreenButtonPressed, State.Null);

		setRelation (State.UpAndDown, Event.RedButtonPressed, State.Null);
		setRelation (State.UpAndDown, Event.BlueButtonPressed, State.RightAndLeft);
		setRelation (State.UpAndDown, Event.GreenButtonPressed, State.Idle);

		setRelation (State.RightAndLeft, Event.RedButtonPressed, State.UpAndDown);
		setRelation (State.RightAndLeft, Event.BlueButtonPressed, State.Null);
		setRelation (State.RightAndLeft, Event.GreenButtonPressed, State.Idle);

	}
	
	// Update is called once per frame
	void Update () {

		if (currentState == State.UpAndDown)
			UpAndDownMovement ();
		else if (currentState == State.RightAndLeft)
			RightAndLeftMovement ();
		else if (currentState == State.Idle)
			movetoToStartPos ();
		else if (currentState == State.Null)
			Debug.Log ("Error. Estado nulo");
	}

	public void setState(Event evt)
	{
		if(fsm [(int)currentState, (int)evt] != State.Null)
		{
			currentState = fsm [(int)currentState, (int)evt];
		}
	}

	public void setRelation(State inpState, Event evt, State outState)
	{
			fsm [(int)inpState, (int)evt] = outState;
	}

	public State getState()
	{
		return currentState;
	}

	private void UpAndDownMovement()
	{
		float y = 3 * Mathf.Sin (Time.timeSinceLevelLoad) + startPos.y;

		transform.position = new Vector3(startPos.x, y, startPos.z);
	}

	private void RightAndLeftMovement()
	{
		float x = 3 * Mathf.Sin (Time.timeSinceLevelLoad) + startPos.x;

		transform.position = new Vector3(x, startPos.y, startPos.z);
	}

	private void movetoToStartPos()
	{
		transform.position = startPos;
	}
}
