using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [Header("Player stats")]
    [SerializeField]
    float health = 100;
    [SerializeField]
    float maxHealth = 100;

    [Space]
    [Header("Links")]
    [SerializeField]
    RectTransform healthBar;
    [SerializeField]
    RectTransform jetpackBar;

    float jetpackFuel;

    float healthScale;
    float jetpackFuelScale;

    float frameClock;
    float currentJetpackBarScale;

    PlayerMovementv2 playerMovementScr;

    void Start()
    {
        playerMovementScr = GetComponent<PlayerMovementv2>();
        jetpackFuel = playerMovementScr.jetpackFuel;
        jetpackFuelScale = 4 / playerMovementScr.jetpackCapacity;
        healthScale = 4 / maxHealth;
        currentJetpackBarScale = 4;
    }

    void Update()
    {
        frameClock += 0.1f;
        if (frameClock > 1)
            frameClock = 0;
        if (frameClock == 0)
        {
            if (jetpackFuel != playerMovementScr.jetpackFuel)
            {
                jetpackFuel = playerMovementScr.jetpackFuel;
                currentJetpackBarScale = jetpackBar.localScale.x;
                Debug.Log("Loop");
            }
            //jetpackBar.localScale = new Vector3(jetpackFuelScale * jetpackFuel, jetpackBar.localScale.y, jetpackBar.localScale.z);
        }
        Debug.Log(currentJetpackBarScale + " Current jetpack scale");
        Debug.Log(jetpackFuelScale * jetpackFuel + " Scale to reach");
        jetpackBar.localScale = new Vector3(Mathf.Lerp(currentJetpackBarScale, jetpackFuelScale * jetpackFuel, frameClock), jetpackBar.localScale.y, jetpackBar.localScale.z);
    }
}
