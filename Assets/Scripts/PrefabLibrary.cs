using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class PrefabEntry
{
    public ComponentType type;
    public GameObject prefab;
}

[CreateAssetMenu(fileName = "PrefabLibrary", menuName = "Library/Prefabs")]
public class PrefabLibrary : ScriptableObject
{
    [SerializeField] private List<PrefabEntry> prefabEntries;

    private Dictionary<ComponentType, GameObject> prefabLookup;

    private void OnEnable()
    {
        prefabLookup = new Dictionary<ComponentType, GameObject>();
        foreach (var entry in prefabEntries)
        {
            if (!prefabLookup.ContainsKey(entry.type))
            {
                prefabLookup.Add(entry.type, entry.prefab);
            }
        }
    }

    public GameObject GetPrefabFromComponentType(ComponentType type)
    {
        return prefabLookup.TryGetValue(type, out var prefab) ? prefab : null;
    }

    public List<PrefabEntry> GetPrefabEntries() { return prefabEntries; }
}
