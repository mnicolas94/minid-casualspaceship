using System;
using System.Collections.Generic;
using System.IO;
// using SaveSystem.Editor.OdinSerializerExtensions;
using UnityEditor;
using UnityEngine;

namespace DefaultNamespace
{
    public static class TestAot
    {
        // [MenuItem("Test/test aot")]
        // public static void Test()
        // {
        //     ScanProjectForSerializedTypes(out var types);
        //
        //     var filePath = Path.Combine(Application.dataPath, "types.txt");
        //     Debug.Log(types.Count);
        //     if (types.Count == 0)
        //         return;
        //     
        //     using (StreamWriter outputFile = new StreamWriter(filePath))
        //     {
        //         foreach (var type in types)
        //         {
        //             outputFile.WriteLine(type.Name);
        //             Debug.Log(type.Name);
        //         }
        //     }
        // }
        //
        // public static bool ScanProjectForSerializedTypes(out List<Type> serializedTypes, bool scanBuildScenes = true, bool scanAllAssetBundles = true, bool scanPreloadedAssets = true, bool scanResources = true, List<string> resourcesToScan = null, bool scanAddressables = true)
        // {
        //     using (var scanner = new AOTSupportScanner())
        //     {
        //         scanner.BeginScan();
        //
        //         if (!scanner.ScanSaveSystemAssets(showProgressBar: true))
        //         {
        //             Debug.Log("Project scan canceled while scanning assets in specified path.");
        //             serializedTypes = null;
        //             return false;
        //         }
        //         
        //         if (scanBuildScenes && !scanner.ScanBuildScenes(includeSceneDependencies: true, showProgressBar: true))
        //         {
        //             Debug.Log("Project scan canceled while scanning scenes and their dependencies.");
        //             serializedTypes = null;
        //             return false;
        //         }
        //         
        //         if (scanResources && !scanner.ScanAllResources(includeResourceDependencies: true, showProgressBar: true, resourcesPaths: resourcesToScan))
        //         {
        //             Debug.Log("Project scan canceled while scanning resources and their dependencies.");
        //             serializedTypes = null;
        //             return false;
        //         }
        //         
        //         if (scanAllAssetBundles && !scanner.ScanAllAssetBundles(showProgressBar: true))
        //         {
        //             Debug.Log("Project scan canceled while scanning asset bundles and their dependencies.");
        //             serializedTypes = null;
        //             return false;
        //         }
        //         
        //         if (scanPreloadedAssets && !scanner.ScanPreloadedAssets(showProgressBar: true))
        //         {
        //             Debug.Log("Project scan canceled while scanning preloaded assets and their dependencies.");
        //             serializedTypes = null;
        //             return false;
        //         }
        //         
        //         if (scanAddressables && !scanner.ScanAllAddressables(includeAssetDependencies: true, showProgressBar: true))
        //         {
        //             Debug.Log("Project scan canceled while scanning addressable assets and their dependencies.");
        //             serializedTypes = null;
        //             return false;
        //         }
        //
        //         serializedTypes = scanner.EndScan();
        //     }
        //     return true;
        // }
    }
}