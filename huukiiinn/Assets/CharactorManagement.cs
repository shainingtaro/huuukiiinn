using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "CharactorData", menuName = "Charactor")]
public class CharactorManagement : ScriptableObject
{
    public List<GameObject> CharaID = new List<GameObject>();
}