using HarmonyLib;
using MelonLoader;
using UnityEngine;

[assembly: MelonInfo(typeof(CustomCostume.Core), "CustomCostume", "1.0.1", "Mira", null)]
[assembly: MelonGame("TEAMHORAY", "Sephiria")]

namespace CustomCostume
{
    public class Core : MelonMod
    {
        public override void OnInitializeMelon()
        {
            //LoggerInstance.Msg("Initialized.");
        }
        public override void OnLateInitializeMelon()
        {
            CustomCostumeDatabase.Initialize();
        }

        public static Sprite LoadSpritePath(string path)
        {
            if (!File.Exists(path))
            {
                Melon<Core>.Logger.Msg(path + " dose not exist!");
                return null;
            }

            byte[] fileData = File.ReadAllBytes(path);
            Texture2D tex = new Texture2D(2, 2, TextureFormat.ARGB32, false);
            tex.LoadImage(fileData);

            var sprite = Sprite.Create(
                tex,
                new Rect(0, 0, tex.width, tex.height),
                new Vector2(0.5f, 0.2f), 16
            );
            sprite.name = Path.GetFileNameWithoutExtension(path);
            sprite.texture.filterMode = FilterMode.Point;
            return sprite;
        }
        public static GameDataLoader GetGameDataLoader()
        {
            var instance = typeof(GameDataLoader);
            return (GameDataLoader)instance.GetField("instance", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic).GetValue(instance);
        }
        [HarmonyPatch(typeof(Resources), nameof(Resources.LoadAll), new Type[] { typeof(string), typeof(Type) })]
        class ResourcesLoadAllPatch
        {
            static void Postfix(string path, Type systemTypeInstance, ref UnityEngine.Object[] __result)
            {
                if (systemTypeInstance == typeof(CostumeEntity) && path == "Costume")
                {
                    var list = __result.ToList();

                    CustomCostumeDatabase.RegisterCostume(list);

                    __result = list.ToArray();
                }
                if (systemTypeInstance == typeof(CostumeSkinEntity) && path == "CostumeSkin")
                {
                    var list = __result.ToList();

                    CustomCostumeDatabase.RegisterCostumeSkin(list);

                    __result = list.ToArray();
                }
            }
        }
        [HarmonyPatch(typeof(GameDataLoader), "Awake")]
        public static class GameDataLoaderAwakePatch
        {
            static void Postfix(GameDataLoader __instance)
            {
                if (__instance == null || __instance != GetGameDataLoader())
                    return;
                //Melon<Core>.Logger.Msg("Mod GameData Loading...");
                //CustomCostumeDatabase.Initialize();
                CustomCostumeDatabase.LoadAllStartingItems(CostumeDatabase.GetAll());
            }
        }
    }
}