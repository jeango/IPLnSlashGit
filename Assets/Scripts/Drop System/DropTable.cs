using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Drop Table")]
public class DropTable : ScriptableObject
{
    public List<Drop> drops = new List<Drop>();

    int totalWeight;

    private void OnEnable()
    {
        totalWeight = 0;
        foreach (var item in drops)
        {
            totalWeight += item.weight;
        }
    }

    public void SpawnDrop(Transform source)
    {
        int roll = Random.Range(1, totalWeight + 1);
        int cursor = 0;
        for (int i = 0; i < drops.Count; i++)
        {
            cursor += drops[i].weight;
            if (cursor >= roll)
            {
                if (drops[i].prefab != null)
                {
                    GameObject obj = Pooling.Acquire(drops[i].prefab);
                    obj.transform.position = source.position;
                    obj.transform.rotation = source.rotation;
                    break;
                }
            }
        }
    }
}
[System.Serializable]
public struct Drop
{
    public GameObject prefab;
    public int weight;
}
