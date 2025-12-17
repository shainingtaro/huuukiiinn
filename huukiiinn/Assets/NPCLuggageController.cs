using UnityEngine;

public class NPCLuggageController : MonoBehaviour
{
    public Transform tableAAnchor;
    public Transform tableBAnchor;

    public void Setup(
        LuggageData[] tableA,
        LuggageData[] tableB
    )
    {
        SpawnLuggages(tableA, tableAAnchor);
        SpawnLuggages(tableB, tableBAnchor);
    }

    private void SpawnLuggages(
        LuggageData[] datas,
        Transform anchor
    )
    {
        foreach (var data in datas)
        {
            Instantiate(data.luggagePrefab, anchor);
        }
    }
}
