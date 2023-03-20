using UnityEngine;
using UnityEngine.InputSystem;

namespace GmodThrusters;

/// <summary>
/// raycasts so we can add thrusters
///
/// will probably steal from https://github.com/Vesper-Works/OuterWildsOnline/blob/master/OuterWildsOnline/MessageHandler.cs for placing
/// </summary>
public class ThrusterPlacer : MonoBehaviour
{
	private bool _placing;

	private void Update()
	{
		if (!OWInput.IsInputMode(InputMode.Character)) return;

		if (Keyboard.current[Key.G].wasPressedThisFrame)
		{
			_placing = !_placing;
		}
	}

	private void OnGUI()
	{
		if (!OWInput.IsInputMode(InputMode.Character)) return;

		GUILayout.Label($"placing: {_placing}");
	}
}
