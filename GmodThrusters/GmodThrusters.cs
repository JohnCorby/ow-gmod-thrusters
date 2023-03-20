using OWML.Common;
using OWML.ModHelper;

namespace GmodThrusters;

public class GmodThrusters : ModBehaviour
{
	private void Awake()
	{
		// You won't be able to access OWML's mod helper in Awake.
		// So you probably don't want to do anything here.
		// Use Start() instead.
	}

	private void Start()
	{
		// Starting here, you'll have access to OWML's mod helper.
		ModHelper.Console.WriteLine($"My mod {nameof(GmodThrusters)} is loaded!", MessageType.Success);


		// Example of accessing game code.
		LoadManager.OnCompleteSceneLoad += (scene, loadScene) =>
		{
			if (loadScene is not (OWScene.SolarSystem or OWScene.EyeOfTheUniverse)) return;
			ModHelper.Events.Unity.FireOnNextUpdate(() =>
			{
				Locator.GetPlayerBody().gameObject.AddComponent<ThrusterPlacer>();
			});
		};
	}
}
