using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Games : MonoBehaviour
{
    [SerializeField]
    private GameObject m_inventoryePanel;
    [SerializeField]
    private GameObject m_prefabInventoryWood;
    [SerializeField]
    private GameObject m_prefabInventoryFish;
    [SerializeField]
    private GameObject m_emptyItem;
    private GameObject m_newObject;
    [SerializeField]
    private Sprite m_WoodImage;
    private bool woodInInvetory = false;
    private bool FishInInvetory = false;
    [SerializeField]
    private SaveClass m_dataSave;
    private void Start()
    {
        
    }
    private void Update()
    {
        
    }
    public void WoodGame()
    {
        if(!woodInInvetory)
        {
            Destroy(m_emptyItem);
            m_newObject = Instantiate(m_prefabInventoryWood);
            m_newObject.transform.parent = m_inventoryePanel.transform;
            woodInInvetory = true;
        }
        
        

    }
    public void WaterGame()
    {
        if (!FishInInvetory)
        {
            Destroy(m_emptyItem);
            m_newObject = Instantiate(m_prefabInventoryFish);
            m_newObject.transform.parent = m_inventoryePanel.transform;
            FishInInvetory = true;
        }

    }
}
