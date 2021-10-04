using UnityEditor;
using UnityEngine.Rendering;

[InitializeOnLoad]
public static class ProjectInit
{
    static ProjectInit()
    {
        // --|----------------------------------------------------- Set scripting backend to IL2CPP
        if (PlayerSettings.GetScriptingBackend(BuildTargetGroup.Standalone) != ScriptingImplementation.IL2CPP)
            PlayerSettings.SetScriptingBackend(BuildTargetGroup.Standalone, ScriptingImplementation.IL2CPP);
        
        // --|------------------------------------------------------- Set scripting API to .Net 4.6
        if (PlayerSettings.GetApiCompatibilityLevel(BuildTargetGroup.Standalone) != ApiCompatibilityLevel.NET_Standard_2_0)
            PlayerSettings.SetApiCompatibilityLevel(BuildTargetGroup.Standalone, ApiCompatibilityLevel.NET_Standard_2_0);

        // --|---------------------- Disable the 'Use Default Graphics API option for Linux targets
        if (PlayerSettings.GetUseDefaultGraphicsAPIs(BuildTarget.StandaloneLinux64) == true)
            PlayerSettings.SetUseDefaultGraphicsAPIs(BuildTarget.StandaloneLinux64, false);

        // --|------------------------------------ Remove the OpenGL graphics API and set to Vulkan
        if (PlayerSettings.GetGraphicsAPIs(BuildTarget.StandaloneLinux64).Length > 1)
            PlayerSettings.SetGraphicsAPIs(BuildTarget.StandaloneLinux64, new[] {GraphicsDeviceType.Vulkan});

        // --|------ Enable the use of unsafe code, enable incremental GC, and disable auto-refresh
        if (!PlayerSettings.allowUnsafeCode) PlayerSettings.allowUnsafeCode = true;
        if (!PlayerSettings.gcIncremental) PlayerSettings.gcIncremental = true;
        if (EditorPrefs.GetBool("kAutoRefresh", true)) EditorPrefs.SetBool("kAutoRefresh", false);
    }
}
