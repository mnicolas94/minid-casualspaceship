using Deploy.Runtime;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;

namespace Editor.WebGLTemplateBuildsSelection
{
    public class WebglTemplatePreprocessor : IPreprocessBuildWithReport
    {
        public int callbackOrder { get; }
        
        public void OnPreprocessBuild(BuildReport report)
        {
            var templateVariable = Resources.Load<SerializableWebGLTemplate>("WebGLTemplateReference");
            Debug.Log("templateVariable.Value = " + templateVariable.Template);
            PlayerSettings.WebGL.template = templateVariable.Template;
        }
    }
}