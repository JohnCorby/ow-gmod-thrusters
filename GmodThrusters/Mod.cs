using OWML.ModHelper;

namespace GmodThrusters;

public class Mod : ModBehaviour
{
	private void Start()
	{
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
