using UnityEngine;

public class NPCManager : MonoBehaviour
{
    public GameObject npcPrefab;
    public NPCData[] npcDataList;

    public void SpawnNPC()
    {
        GameObject npc = Instantiate(npcPrefab);

        NPCData data =
            npcDataList[Random.Range(0, npcDataList.Length)];

        npc.GetComponent<NPCInitializer>()
           .Initialize(data);
    }
}
