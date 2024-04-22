using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    [SerializeField]
    private Data m_classData = new Data();
    private string m_pathString = "/Data.json";

   public (int,int) loaddata()
   {
        m_classData = new Data();
        Debug.Log("regarde si le path exist");
        if (File.Exists(Application.persistentDataPath + m_pathString))
        {
            Debug.Log("Charge les donné de sauvegarde");
            string data = File.ReadAllText(Application.persistentDataPath + m_pathString);
            m_classData = JsonUtility.FromJson<Data>(data);
        }

        return (m_classData.m_wood, m_classData.m_Fish);
    }
    public void saveData(int wood,int fish)
    {
        Debug.Log("execute une savegarde");
        m_classData.m_wood = wood;
        m_classData.m_Fish = fish;
        string data = JsonUtility.ToJson(m_classData);
        System.IO.File.WriteAllText(Application.persistentDataPath + m_pathString, data);
    }
    
}
[System.Serializable]
internal class Data
{
    public int m_wood;
    public int m_Fish;
}