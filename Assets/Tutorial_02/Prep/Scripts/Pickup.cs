using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour
{
	private enum State
	{
		Idle, Excited, Action
	}

	private Transform avatar;
	private State currentState;

	protected void Awake ()
	{
		avatar = transform.GetChild (0);
		currentState = State.Excited;
	}

	protected void Update ()
	{
		switch (currentState)
		{
		case State.Idle:
			avatar.position = 0.3f * Mathf.Sin(Time.time) * Vector3.up;
			avatar.eulerAngles = 20.0f * Time.time * Vector3.up;
			break;
		case State.Excited:
			avatar.position = 0.3f * Mathf.Abs (Mathf.Sin (4f * Time.time)) * Vector3.up;
			avatar.eulerAngles = 80.0f * Time.time * Vector3.up;
			break;
		case State.Action:
			break;
		}
	}

	private void SetState(State newState)
	{
		State oldState = currentState;
		currentState = newState;
	}
}
