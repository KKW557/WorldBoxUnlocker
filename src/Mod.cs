using NeoModLoader.api;
using UnityEngine.Scripting;

namespace Unlocker;

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
        _post("Unlock", "Achievements");
    }
    
    [Preserve]
    public static void ClearAllAchievements(bool value)
    {
        if (!value)
        {
            return;
        }
        GameProgress.instance.debugClearAllAchievements();
        _post("Clear", "Achievements");
    }
    
    [Preserve]
    public static void UnlockAllAssets(bool value)
    {
        if (!value)
        {
            return;
        }
        GameProgress.instance.debugUnlockAll();
        _post("Unlock", "Assets");
    }
    
    [Preserve]
    public static void ClearAllAssets(bool value)
    {
        if (!value)
        {
            return;
        }
        GameProgress.instance.debugClearAll();
        _post("Clear", "Assets");
    }

    private static void _post(string action, string target)
    {
        Mod.Instance.GetConfig()["Unlocker Config Unlocker"][$"Unlocker Config {action} All {target}"].SetValue(false, true);
        Mod.LogInfo($"{action}ed all {target}");
    }
}
