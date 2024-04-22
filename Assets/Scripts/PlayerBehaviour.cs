using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class PlayerBehaviour : MonoBehaviour
{
   
    [SerializeField]
    private Camera m_camera;
    private PlayerState m_CurrentState;
    private bool m_inJobField = false;
    private string m_jobName = "None";
    [SerializeField]
    private GameObject m_controleUiTextPressE;
    [SerializeField]
    private GameObject m_controleUiTextPressQ;
    [SerializeField]
    private GameObject m_eventSystem;
    private string m_curentAnimation;
    private int m_woodPoint = 0;
    private int m_waterPoint = 0;
    private bool m_gameStart = false;
    // Start is called before the first frame update
    void Start()
    {
        m_controleUiTextPressE.SetActive(false);
        m_CurrentState = new PlayerMoveState(this);
    }
    public void MoveForward(bool backDirection)
    {
        if(!backDirection)
        {
            //Debug.Log(gameObject.name);
            RaycastHit hit;
            Ray ray = m_camera.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2.5f));
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.name == "FishingPlace")
                {
                    gameObject.GetComponent<NavMeshAgent>().SetDestination(hit.point);
                    m_inJobField = true;
                    m_jobName = "Water";
                    m_controleUiTextPressE.SetActive(true);
                }
                else 
                {
                    if (hit.collider.gameObject.name == "Terrain")
                    {
                        gameObject.GetComponent<NavMeshAgent>().SetDestination(hit.point);

                        if (m_jobName == "Water")
                        {
                            m_inJobField = false;
                        }
                    }
                }
            }
        }
        else
        {
           // Debug.Log(gameObject.name);
            RaycastHit hit;
            Ray ray = m_camera.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 5f));
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.name == "Terrain")
                {
                    
                        gameObject.GetComponent<NavMeshAgent>().SetDestination(hit.point);

                    
                }
               
            }
        }
      

    }
    public void RotatePlayer(bool IsRightDirection)
    {
        if(IsRightDirection)
        {
            gameObject.transform.Rotate(new Vector3(0,1,0));
        }
        else
        {
            gameObject.transform.Rotate(new Vector3(0,-1,0));
        }
    }
    private void Update()
    {
        if(m_gameStart)
        {

            //// a chaque frame, il passe dans le jeux defini
            if (m_jobName == "tree")
            {
                if (m_woodPoint >= 0)
                {
                    m_woodPoint = m_eventSystem.GetComponent<Games>().WoodGame(m_woodPoint);
                    m_CurrentState = new CutWood(this);
                }
                else
                {
                    if (m_woodPoint == -2) { StartCoroutine(m_eventSystem.GetComponent<Games>().echecTxt()); }
                    m_woodPoint = 0;
                    exitJob();
                }
            }
            if (m_jobName == "Water")
            {
               
                if (m_waterPoint == 0)
                {
                   m_waterPoint = m_eventSystem.GetComponent<Games>().WaterGame();
                    m_CurrentState = new Fishing(this);
                }
                else
                {
                    if (m_waterPoint == -1) { StartCoroutine(m_eventSystem.GetComponent<Games>().echecTxt()); }
                    m_waterPoint = 0;
                    exitJob();
                }
            }



        }
        if (gameObject.GetComponent<NavMeshAgent>().remainingDistance<0.1f)
        {
            
                gameObject.GetComponent<Animator>().SetBool("Move", false);
            
            
        }
        m_CurrentState.Execute();
        if(m_inJobField)
        {
          
            
            if (Input.GetKeyDown(KeyCode.E))
            {
                m_gameStart = true;
            }
            
        }
        else
        {
            m_controleUiTextPressE.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        
        m_inJobField = true;
        if(other.gameObject.GetComponent<Tree>())
        {
            m_controleUiTextPressE.SetActive(true);
            m_jobName = "tree";
        }
       
    }
    private void OnTriggerExit(Collider other)
    {
        m_inJobField = false;
        
    }
    public void exitJob()
    { 
        
        m_CurrentState = new PlayerMoveState(this);
        m_inJobField = false;
        m_controleUiTextPressQ.SetActive(false);
        m_eventSystem.GetComponent<Games>().quitCutGame();
        m_eventSystem.GetComponent<Games>().QuitWaterGame();
        m_gameStart = false;
    }
    public void SetAnimation(string animation )
    {
        
            gameObject.GetComponent<Animator>().SetBool(m_curentAnimation, false);
            m_curentAnimation = animation;
            gameObject.GetComponent<Animator>().SetBool(m_curentAnimation, true);
        
        
    }
    public void UiNotify()
    {
       m_controleUiTextPressE.SetActive(false);
       m_controleUiTextPressQ.SetActive(true);
    }
}
