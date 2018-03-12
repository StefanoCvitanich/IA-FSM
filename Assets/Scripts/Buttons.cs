using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour {

	public GameObject agent;

	private agentsFSM stateMachine;

	// Use this for initialization
	void Start () {

		stateMachine = agent.GetComponent<agentsFSM> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void RedButtonClick()
	{
		stateMachine.setState (agentsFSM.Event.RedButtonPressed);
	}

	public void BlueButtonClick()
	{
		stateMachine.setState (agentsFSM.Event.BlueButtonPressed);
	}

	public void GreenButtonClick()
	{
		stateMachine.setState (agentsFSM.Event.GreenButtonPressed);
	}
}
