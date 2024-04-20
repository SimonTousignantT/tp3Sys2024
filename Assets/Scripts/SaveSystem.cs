using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    [SerializeField]
    private SaveClass m_classData = new SaveClass();
    private string m_pathString = "/Data.json";

   public void loaddata()
   {
        if (File.Exists(m_pathString))
        {
            string data = File.ReadAllText(m_pathString);
            m_classData = JsonUtility.FromJson<SaveClass>(data);
        }
    }
    public void saveData()
    {
        
       string data = JsonUtility.ToJson(m_classData);
        System.IO.File.WriteAllText(Application.persistentDataPath + m_pathString, data);
    }
}
