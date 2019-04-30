using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Artimech;

public class uiBar : MonoBehaviour
{
    public Image m_Image;
    public GameObject m_BackgroundObj;
    public aMechPlayerController m_Player;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UpdateBar();
    }

    private void UpdateBar()
    {
 /*       float coef = simMgr.PlayerTurnTime / simMgr.SimTuning.m_PlayerTurnTimeLimit;

        if (simMgr.IsAtAIsTurn() || simMgr.IsAtAPlayersAfterTurn())
            m_BackgroundObj.SetActive(false);
        else
            m_BackgroundObj.SetActive(true);

        if (simMgr.IsAtReset())
            m_Image.fillAmount = 1.0f;
        else
            m_Image.fillAmount = coef; */


    }
}