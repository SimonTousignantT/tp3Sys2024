using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EventManager : MonoBehaviour
{
    [SerializeField]
    private GameObject m_inventoryPanel;
    [SerializeField]
    private GameObject m_prefabInventoryWood;
    [SerializeField]
    private GameObject m_prefabInventoryFish;
    [SerializeField] private Games subjectToObserve;
    private GameObject m_newObject;
    private void OnGetFish()
    {
        // any logic that responds to event goes here
        Debug.Log("GetFish");
        m_newObject = Instantiate(m_prefabInventoryFish);
        m_newObject.transform.parent = m_inventoryPanel.transform;
       
    }
    private void OnGetWood()
    {
        Debug.Log("GetWood");
        m_newObject = Instantiate(m_prefabInventoryWood);
        m_newObject.transform.parent = m_inventoryPanel.transform;
    }

  
    private void Awake()
    {
        if (subjectToObserve != null)
        {
            subjectToObserve.GetFish += OnGetFish;
            subjectToObserve.GetWood += OnGetWood; 
        }
    }

   
    
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    ///////////////////////////////////////////////////////////////////////////l'explication du prof ne fonctione pas il mes donc impossible de comprendre 
    //private static EventManager m_Instance;

    //private Dictionary<EEvents, Action<Dictionary<string, object>>> m_events;

    //private EventManager()
    //{
    //    m_events = new Dictionary<EEvents, Action<Dictionary<string, object>>>();
    //}

    //public static EventManager GetInstance()
    //{
    //    if(m_Instance == null)
    //    {
    //        m_Instance = new EventManager();
    //    }
    //    return m_Instance;
    //}

    //public void SubscribeTo(EEvents eventId , Action<Dictionary<string, object>> func)
    //{
    //    if(m_events[eventId] != null)
    //    {
    //        m_events[eventId] += func;
    //    }
    //    else
    //    {
    //        m_events.Add(eventId, func);
    //    }
    //}
    //public void UnSubscribeFrom(EEvents eventId, Action<Dictionary<string, object>> func)
    //{
    //    if (m_events[eventId] != null)
    //    {
    //        m_events[eventId] -= func;
    //    }
    //}
    //public void TriggerEvent(EEvents eventId, Dictionary<string, object> parameters)
    //{
    //    if (m_events[eventId] != null)
    //    {
    //        m_events[eventId].Invoke(parameters);
    //    }
    //}


}
//public enum EEvents
//{
//    On_Game_Win,
//    On_Item_Added_To_Inventory


//}
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////