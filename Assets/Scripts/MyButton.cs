using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MyButton : MonoBehaviour
{
    [SerializeField]
    private GameObject m_inventory;
    [SerializeField]
    private GameObject m_empyCase;
    [SerializeField]
    private GameObject m_optionMenu;
    [SerializeField]
    private SaveSystem m_data;
    [SerializeField]
    private GameObject m_finishButton;
    [SerializeField]
    private Animator m_player;

    private GameObject m_eventSystem;
    public void inventoryButton()
    {
        if (m_inventory.activeInHierarchy)
        {
            m_inventory.SetActive(false);
            if (m_empyCase != null)
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
    public void loadGame()
    {

        SceneManager.LoadScene("Game");
    }
    public void NewGame()
    {
        m_data.saveData(0, 0);
        loadGame();
    }
    public void ExitGame()
    {
        SceneManager.LoadScene("Menu");
    }
    public void DestroySelf(bool IsWood)
    {
        m_eventSystem = GameObject.Find("EventSystem");
        m_eventSystem.GetComponent<Games>().setRemoveItem(IsWood);
        Destroy(gameObject);
    }
    public void OptionMenu()
    {

        if (m_optionMenu.activeInHierarchy)
        {
            m_optionMenu.SetActive(false);
        }
        else
        {
            m_optionMenu.SetActive(true);

            if (m_data.loaddata().Item1 + m_data.loaddata().Item2 > 4)
            {
                m_finishButton.GetComponent<Image>().color = new Color(255, 255, 255, 225);
                m_finishButton.GetComponent<Button>().interactable = true;


            }
            else
            {
                m_finishButton.GetComponent<Image>().color = new Color(255, 255, 255, 35);
                m_finishButton.GetComponent<Button>().interactable = false;
            }

        }


    }
    private void Update()
    {

    }

    public void FinishButton()
    {
        Debug.Log(" Win Click ");
        m_player.SetTrigger("Victory");
        m_inventory.GetComponent<MyButton>().StartCoroutine(WinWaitAnimate());
        OptionMenu();
    }
    private IEnumerator WinWaitAnimate()
    {
        Debug.Log(" 2 sec wait ");
        yield return new WaitForSeconds(2);
        NewGame();
    }
}
