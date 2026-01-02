using NeoModLoader.api;
using UnityEngine.Scripting;

namespace KKW557.WorldBox.Unlocker;

public class Mod : BasicMod<Mod>
{
    protected override void OnModLoad()
    {
        var mod = GetDeclaration();
        LogInfo("Author: " + mod.Author);
        LogInfo("Version: " + mod.Version);
    }

    [Preserve]
    public static void AlwaysDebugCallback(bool value)
    {
        DebugConfig.setOption(DebugOption.DebugButton, value);
    }
    
    [Preserve]
    public static void UnlockAllAchievements(bool value)
    {
        if (!value)
        {
            return;
        }
        GameProgress.instance.unlockAllAchievements();
        Action("Unlock", "Achievements");
    }
    
    [Preserve]
    public static void ClearAllAchievements(bool value)
    {
        if (!value)
        {
            return;
        }
        GameProgress.instance.debugClearAllAchievements();
        Action("Clear", "Achievements");
    }
    
    [Preserve]
    public static void UnlockAllAssets(bool value)
    {
        if (!value)
        {
            return;
        }
        GameProgress.instance.debugUnlockAll();
        Action("Unlock", "Assets");
    }
    
    [Preserve]
    public static void ClearAllAssets(bool value)
    {
        if (!value)
        {
            return;
        }
        GameProgress.instance.debugClearAll();
        Action("Clear", "Assets");
    }

    private static void Action(string action, string target)
    {
        Instance.GetConfig()["Unlocker Config Unlocker"][$"Unlocker Config {action} All {target}"].SetValue(false, true);
        LogInfo($"{action}ed all {target}");
    }
}
