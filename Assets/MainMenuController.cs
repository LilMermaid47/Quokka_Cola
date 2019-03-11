using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    [SerializeField]
    GameObject pnl_Main;
    [SerializeField]
    GameObject pnl_Options;
    [SerializeField]
    GameObject pnl_Exit;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClickPlayButton()
    {
    }
    public void OnClickOptionsButton()
    {
        pnl_Main.SetActive(false);
        pnl_Options.SetActive(true);
        pnl_Exit.SetActive(false);
    }
    public void OnClickExitButton()
    {
        pnl_Main.SetActive(false);
        pnl_Options.SetActive(false);
        pnl_Exit.SetActive(true);
    }
    public void OnClickReturn()
    {
        pnl_Main.SetActive(true);
        pnl_Options.SetActive(false);
        pnl_Exit.SetActive(false);
    }
}

// https://www.youtube.com/watch?v=MTCYhbfSAuA (<-- inspiration principale pour le projet) + (ctrl+a)+(ctrl+a)+(ctrl+c)