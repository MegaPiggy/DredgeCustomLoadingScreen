using CustomLoadingScreen.Patches;
using HarmonyLib;
using Steamworks;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using Winch.Core;

namespace CustomLoadingScreen
{
    public static class Main
	{
		public static Texture2D loadingTexture = Utils.GetTexture("LoadingScreen");
		public static Material loadingMaterial;

		public static void Initialize()
		{
			WinchCore.Log.Info("Loading custom loading screen texture");
			Object.DontDestroyOnLoad(loadingTexture);
			loadingMaterial = new Material(Shader.Find("UI/Default"));
			loadingMaterial.name = "CustomLoadingScreen";
			loadingMaterial.SetTexture("_MainTex", loadingTexture);
			Object.DontDestroyOnLoad(loadingMaterial);
			new Harmony("megapiggy.customloadingscreen").PatchAll(Assembly.GetExecutingAssembly());
		}

		public static void ReplaceLoadingScreenImage() => ReplaceLoadingScreenImage(GameManager.Instance.Loader.loadingScreen);
		public static void ReplaceLoadingScreenImage(LoadingScreen loadingScreen)
		{
			WinchCore.Log.Info("Replacing loading screen image with custom one");
			Image component = loadingScreen.loadingScreen.transform.Find("Container/Image").GetComponent<Image>();
			component.color = Color.white;
			component.material = Main.loadingMaterial;
		}
	}
}
