using UnityEngine;

namespace Infrastructure.Data
{
    [CreateAssetMenu(menuName = "Container Registries Data", fileName = "Container Registries Data")]
    public class ContainerRegistriesData : ScriptableObject
    {
        [HideInInspector] public string RegistriesJson;
    }
}