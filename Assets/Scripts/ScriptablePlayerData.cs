using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ScriptablePlayerData : ScriptableObject
{
    [SerializeField]
    private GameObject m_prefabWoodCut ;
    [SerializeField]
    private GameObject m_prefabMove;
}
