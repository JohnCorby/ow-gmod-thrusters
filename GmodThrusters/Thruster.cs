using UnityEngine;

namespace GmodThrusters;

/// <summary>
/// applies thrust to the attached body
/// </summary>
public class Thruster : MonoBehaviour
{
	private OWRigidbody _body;

	public float Thrust = 10;

	private void Awake()
	{
		_body = this.GetAttachedOWRigidbody();
	}

	private void FixedUpdate()
	{
		var force = transform.forward * Thrust;

		if (_body.RunningKinematicSimulation())
		{
			// _kinematicRigidbody.AddForceAtPosition does nothing
			_body._kinematicRigidbody.AddForce(force);
		}
		else
		{
			_body._rigidbody.AddForceAtPosition(force, transform.position);
		}
	}
}
