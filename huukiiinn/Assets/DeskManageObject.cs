using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DeskData", menuName = "Desk")]
public class DeskManageObject : ScriptableObject
{
    public List<GameObject> Deskprefabs = new List<GameObject>();
}
