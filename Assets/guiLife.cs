using Artimech;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class guiLife : MonoBehaviour
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
        text.text = "Life: " + (int) m_PlayerController.LifePercent + "%";
    }
}
