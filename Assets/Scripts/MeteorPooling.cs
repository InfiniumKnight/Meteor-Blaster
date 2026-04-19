using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class  MeteorPoolEntry
{
    public MeteorType type;
    public GameObject prefab;
    public int initialSize = 5;
}

public enum MeteorType
{
    AsterBig1,
    AsterBig2,
    AsterBig3,
    AsterBig4,
    AsterHuge1,
    AsterHuge2,
    AsterHuge3,
    AsterMed1,
    AsterMed2,
    AsterMed3,
    AsterMed4,
    AsterMed5,
    AsterSmall1,
    AsterSmall2,
    AsterSmall3,
    AsterSmall4,
    AsterSmall5,
    AsterSmall6,
}

public class MeteorPooling : MonoBehaviour
{
    [SerializeField] private List<MeteorPoolEntry> entries;

    private Dictionary<MeteorType, List<GameObject>> poolDict = new();

    private void Awake()
    {
        foreach (var entry in entries)
        {
            var list = new List<GameObject>();

            for (int i = 0; i < entry.initialSize; i++)
            {
                var obj = Instantiate(entry.prefab, transform);
                obj.SetActive(false);
                list.Add(obj);
            }

            poolDict[entry.type] = list;
        }
    }

    public GameObject Spawn(MeteorType type, Vector2 position)
    {
        var list = poolDict[type];

        foreach (var obj in list)
        {
            if (!obj.activeInHierarchy)
            {
                obj.transform.position = position;
                obj.SetActive(true);
                return obj;
            }
        }

        var entry = entries.Find(e => e.type == type);

        if (entry == null)
        {
            Debug.LogError($"No prefab found for type {type}");
            return null;
        }

        var prefab = entry.prefab;
        var newObj = Instantiate(prefab, transform);

        newObj.transform.position = position;
        newObj.SetActive(true);

        list.Add(newObj);
        return newObj;
    }

    public void ResetAll()
    {
        foreach (var list in poolDict.Values)
        {
            foreach (var obj in list)
            {
                obj.SetActive(false);
            }
        }
    }
}
