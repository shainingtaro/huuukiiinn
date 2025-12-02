using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DeskData", menuName = "MyGame/MyData")]
public class DeskManagement : ScriptableObject
{
    public List<GameObject> Deskprefabs = new List<GameObject>();
}
