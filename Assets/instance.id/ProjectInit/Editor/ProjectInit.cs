using UnityEditor;
using UnityEngine.Rendering;

[InitializeOnLoad]
public static class ProjectInit
{
    static ProjectInit()
    {
        if (PlayerSettings.GetScriptingBackend(BuildTargetGroup.Standalone) != ScriptingImplementation.IL2CPP)
            PlayerSettings.SetScriptingBackend(BuildTargetGroup.Standalone, ScriptingImplementation.IL2CPP);
        
        if (PlayerSettings.GetApiCompatibilityLevel(BuildTargetGroup.Standalone) != ApiCompatibilityLevel.NET_4_6)
            PlayerSettings.SetApiCompatibilityLevel(BuildTargetGroup.Standalone, ApiCompatibilityLevel.NET_4_6);

        if (PlayerSettings.GetUseDefaultGraphicsAPIs(BuildTarget.StandaloneLinux64) == true)
            PlayerSettings.SetUseDefaultGraphicsAPIs(BuildTarget.StandaloneLinux64, false);

        if (PlayerSettings.GetGraphicsAPIs(BuildTarget.StandaloneLinux64).Length > 1)
            PlayerSettings.SetGraphicsAPIs(BuildTarget.StandaloneLinux64, new[] {GraphicsDeviceType.Vulkan});

        if (!PlayerSettings.allowUnsafeCode) PlayerSettings.allowUnsafeCode = true;
        if (!PlayerSettings.gcIncremental) PlayerSettings.gcIncremental = true;
        if (EditorPrefs.GetBool("kAutoRefresh", true)) EditorPrefs.SetBool("kAutoRefresh", false);
    }
}
