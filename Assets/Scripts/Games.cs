
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Games : MonoBehaviour
{
    [SerializeField]
    private GameObject m_inventoryPanel;
    [SerializeField]
    private GameObject m_prefabInventoryWood;
    [SerializeField]
    private GameObject m_prefabInventoryFish;
    [SerializeField]
    private GameObject m_emptyItem;
    private GameObject m_newObject;
    [SerializeField]
    private Sprite m_WoodImage;
    private int m_woodInInvetory = 0;
    private int m_FishInInvetory = 0;
    [SerializeField]
    private SaveSystem m_dataSave;
    [SerializeField]
    private GameObject m_cutGameUI;
    [SerializeField]
    private GameObject m_fishingGameUI;
    [SerializeField]
    private GameObject m_WaterGamePoint;
    [SerializeField]
    private int m_woodGameDificulty = 5;
    [SerializeField]
    private GameObject m_echecTxt;
    [SerializeField]
    private float m_fichingDificulty = 0.05f;
    [SerializeField]
    private int m_inventorySize = 5;
    [SerializeField]
    private List<AudioClip> m_audioList = new List<AudioClip>();
    public event System.Action GetFish;
    public event System.Action GetWood;
    private void Start()
    {
        for (int i = 0; i < m_dataSave.loaddata().Item1; i++)
        {
            Destroy(m_emptyItem);
            m_newObject = Instantiate(m_prefabInventoryWood);
            m_newObject.transform.parent = m_inventoryPanel.transform;
            m_woodInInvetory += 1;
        }
        for (int i = 0; i < m_dataSave.loaddata().Item2 ; i++)
        {
            Destroy(m_emptyItem);
            m_newObject = Instantiate(m_prefabInventoryFish);
            m_newObject.transform.parent = m_inventoryPanel.transform;
            m_FishInInvetory += 1;
        }

    }
    public void setRemoveItem(bool IsWood )
    {
        if(IsWood)
        {
            m_woodInInvetory -= 1;
        }
        else
        {
            m_FishInInvetory -= 1;
        }
        m_dataSave.saveData(m_woodInInvetory, m_FishInInvetory);

    }
    private void Update()
    {

    }

    public int WoodGame(int woodPoint)
    {
        m_cutGameUI.SetActive(true);
        if (m_cutGameUI.transform.GetChild(0).gameObject.activeInHierarchy)
        {
            ///Debug.Log("tu doit apuyer sur D");
            if (Input.GetKeyDown(KeyCode.D))
            {
                m_cutGameUI.transform.GetChild(0).gameObject.GetComponent<Image>().color = Color.grey;
            }
            if (Input.GetKeyUp(KeyCode.D))
            {
                m_cutGameUI.transform.GetChild(0).gameObject.GetComponent<Image>().color = Color.white;
                Debug.Log("tu a apuyer sur D");
                m_cutGameUI.transform.GetChild(0).gameObject.SetActive(false);
                m_cutGameUI.transform.GetChild(Random.Range(0, m_cutGameUI.transform.childCount)).gameObject.SetActive(true);
                gameObject.GetComponent<AudioPool>().PlayMusicPool(m_audioList[0]);
                return woodPoint += 1;
            }
            if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.W))
            {
                
                return -2;
            }
        }
        if (m_cutGameUI.transform.GetChild(1).gameObject.activeInHierarchy)
        {
            ///Debug.Log("tu doit apuyer sur A");
            if (Input.GetKeyDown(KeyCode.A))
            {
                m_cutGameUI.transform.GetChild(1).gameObject.GetComponent<Image>().color = Color.grey;
            }
            if (Input.GetKeyUp(KeyCode.A))
            {
                m_cutGameUI.transform.GetChild(1).gameObject.GetComponent<Image>().color = Color.white;
                Debug.Log("tu a apuyer sur A");
                m_cutGameUI.transform.GetChild(1).gameObject.SetActive(false);
                m_cutGameUI.transform.GetChild(Random.Range(0, m_cutGameUI.transform.childCount)).gameObject.SetActive(true);
                gameObject.GetComponent<AudioPool>().PlayMusicPool(m_audioList[0]);
                return woodPoint += 1;
            }
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.W))
            {
                
                return -2;
            }
        }
        if (m_cutGameUI.transform.GetChild(2).gameObject.activeInHierarchy)
        {
            ///Debug.Log("tu doit apuyer sur W");
            if (Input.GetKeyDown(KeyCode.W))
            {
                m_cutGameUI.transform.GetChild(2).gameObject.GetComponent<Image>().color = Color.grey;
            }
            if (Input.GetKeyUp(KeyCode.W))
            {
                m_cutGameUI.transform.GetChild(2).gameObject.GetComponent<Image>().color = Color.white;
                Debug.Log("tu a apuyer sur D");
                m_cutGameUI.transform.GetChild(2).gameObject.SetActive(false);
                m_cutGameUI.transform.GetChild(Random.Range(0, m_cutGameUI.transform.childCount)).gameObject.SetActive(true);
                gameObject.GetComponent<AudioPool>().PlayMusicPool(m_audioList[0]);
                return woodPoint += 1;
            }
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
            {
                
                return -2;
            }
        }
        if (m_cutGameUI.transform.GetChild(3).gameObject.activeInHierarchy)
        {
            ///Debug.Log("tu doit apuyer sur S");
            if (Input.GetKeyDown(KeyCode.S))
            {
                m_cutGameUI.transform.GetChild(3).gameObject.GetComponent<Image>().color = Color.grey;
            }
            if (Input.GetKeyUp(KeyCode.S))
            {
                m_cutGameUI.transform.GetChild(3).gameObject.GetComponent<Image>().color = Color.white;
                Debug.Log("tu a apuyer sur D");
                m_cutGameUI.transform.GetChild(3).gameObject.SetActive(false);
                m_cutGameUI.transform.GetChild(Random.Range(0, m_cutGameUI.transform.childCount)).gameObject.SetActive(true);
                gameObject.GetComponent<AudioPool>().PlayMusicPool(m_audioList[0]);
                return woodPoint += 1;
                
            }
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.W))
            {
                
                return -2;
            }
        }
        if (woodPoint >= m_woodGameDificulty)
        {
            if (m_inventoryPanel.transform.childCount < m_inventorySize)
            {
                Destroy(m_emptyItem);
                GetWood?.Invoke();
                m_woodInInvetory += 1;
                m_dataSave.saveData(m_woodInInvetory, m_FishInInvetory);
            }
            return -1;
        }
        return woodPoint;


    }
    public void quitCutGame()
    {
        m_cutGameUI.SetActive(false);
       
    }
    public void QuitWaterGame()
    {
        m_WaterGamePoint.GetComponent<Image>().fillAmount = 0;
        m_fishingGameUI.GetComponent<Image>().fillAmount = 0;
        m_fishingGameUI.SetActive(false);
    }
    public void FishingButton()
    {
        m_WaterGamePoint.GetComponent<Image>().fillAmount += m_fichingDificulty;
        gameObject.GetComponent<AudioPool>().PlayMusicPool(m_audioList[1]);
    }
    public int WaterGame()
    {
        m_fishingGameUI.SetActive(true);
        m_fishingGameUI.GetComponent<Image>().fillAmount += 0.1f * Time.deltaTime;
       
        //Debug.Log("Passe dans WaterGame");
        if (m_fishingGameUI.GetComponent<Image>().fillAmount >= 1)
        {
            Debug.Log("perdu! WaterGame");
            m_fishingGameUI.GetComponent<Image>().fillAmount = 0;
            m_WaterGamePoint.GetComponent<Image>().fillAmount = 0;
            m_fishingGameUI.SetActive(false);
            return -1;
        }

        if (m_WaterGamePoint.GetComponent<Image>().fillAmount >= 1)
        {
            //Debug.Log("gagné! WaterGame" +  m_inventoryPanel.transform.childCount);
            gameObject.GetComponent<AudioPool>().PlayMusicPool(m_audioList[2]);
            if (m_inventoryPanel.transform.childCount < m_inventorySize)
            {

                //Debug.Log("sa crée un nouveux poisson dans l'inventaire" );
                Destroy(m_emptyItem);

                /////////yes mon event systeme fonctione! 
                GetFish?.Invoke();
                /////////////////////////////////////////////////////////


                //////////////////////////////////////////////////////////////////////////////n'a jamais fonctioné
                //Debug.Log("active l'event");
                //Dictionary<string, object> eventParams = new Dictionary<string, object>();
                //eventParams.Add("itemList", m_FishInInvetory);
                //EventManager.GetInstance().TriggerEvent(EEvents.On_Item_Added_To_Inventory, eventParams);
                //Debug.Log("l'event a marcher");/// sa jamais fonctioné 
                ///////////////////////////////////////////////////////////////////////////////

                m_FishInInvetory += 1;
            }
            m_dataSave.saveData(m_woodInInvetory, m_FishInInvetory);
            m_WaterGamePoint.GetComponent<Image>().fillAmount = 0;
            m_fishingGameUI.GetComponent<Image>().fillAmount = 0;
            m_fishingGameUI.SetActive(false);
            return 1;
        }

        return 0;
    }
    public IEnumerator echecTxt()
    {
        m_echecTxt.SetActive(true);
        yield return new WaitForSeconds(1);
        m_echecTxt.SetActive(false);
    }
}
