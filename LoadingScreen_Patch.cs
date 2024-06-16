using HarmonyLib;
using UnityEngine;
using UnityEngine.UI;

namespace CustomLoadingScreen.Patches
{
	[HarmonyPatch(typeof(LoadingScreen), "Fade")]
	public static class LoadingScreen_Patch
	{
		public static void Prefix(LoadingScreen __instance)
		{
			Main.ReplaceLoadingScreenImage(__instance);
		}
	}
}
