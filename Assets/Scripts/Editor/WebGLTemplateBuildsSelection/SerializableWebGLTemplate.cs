using UnityEngine;
using Utils.Attributes;

namespace Editor.WebGLTemplateBuildsSelection
{
    [CreateAssetMenu(fileName = "SerializableWebGLTemplate", menuName = "SerializableWebGLTemplate", order = 0)]
    public class SerializableWebGLTemplate : ScriptableObject
    {
        [SerializeField, Dropdown(nameof(GetTemplates))] private string _template;

        public string Template => _template;

        private DropdownList<string> GetTemplates()
        {
            var templates = new DropdownList<string>();
            
            templates.Add("Crazy2020", "PROJECT:Crazy_2020");
            templates.Add("Crazy5.6", "PROJECT:Crazy_5_6+");
            templates.Add("Default", "APPLICATION:Default");
            templates.Add("Minimal", "APPLICATION:Minimal");
            templates.Add("PWA", "APPLICATION:PWA");

            return templates;
        }
    }
}