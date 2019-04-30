using Artimech;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class guiGold : MonoBehaviour
{
    public aMechPlayerController m_PlayerController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Text text = GetComponent<Text>();
        text.text = "Gold: " + m_PlayerController.NumGold;
    }
}
