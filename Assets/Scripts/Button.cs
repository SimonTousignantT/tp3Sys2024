using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField]
    private GameObject m_inventory;
    [SerializeField]
    private GameObject m_empyCase;
    public void inventoryButton()
    {
        if(m_inventory.activeInHierarchy)
        {
            m_inventory.SetActive(false);
            if(m_empyCase != null)
            {
                m_empyCase.SetActive(false);
            }
           
        }
        else
        {
            m_inventory.SetActive(true);
            if (m_empyCase != null)
            {
                m_empyCase.SetActive(true);
            }
        }
    }
}
