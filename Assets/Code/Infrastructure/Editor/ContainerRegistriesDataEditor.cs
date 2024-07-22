using System.Linq;
using Infrastructure.Data;
using Infrastructure.Entry;
using Infrastructure.Extensions;
using Newtonsoft.Json;
using UnityEditor;
using UnityEngine;

namespace Infrastructure.Editor
{
    [CustomEditor(typeof(ContainerRegistriesData))]
    public class ContainerRegistriesDataEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            ContainerRegistriesData containerRegistriesData = (ContainerRegistriesData)target;
            RegistriesTypes types = JsonConvert.DeserializeObject<RegistriesTypes>(containerRegistriesData.RegistriesJson) ?? new RegistriesTypes();

            GUILayout.Label("Cached states count: " + (types.States?.Length ?? 0));
            GUILayout.Label("Cached services count: " + (types.Services?.Length ?? 0));
            if (GUILayout.Button("Cache") == false) return;

            types.States = TypeExtensions.GetAllStatesTypes().ToArray();
            types.Services = TypeExtensions.GetAllGlobalServiceTypes().ToArray();
            containerRegistriesData.RegistriesJson = JsonConvert.SerializeObject(types);

            EditorUtility.SetDirty(containerRegistriesData);
            serializedObject.ApplyModifiedProperties();
        }
    }
}