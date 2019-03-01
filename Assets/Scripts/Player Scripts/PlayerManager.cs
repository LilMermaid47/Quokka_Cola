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

    float jetpackPercentage;
    float healthPercentage;
    float jetpackMaxScale = 4;
    float healthMaxScale = 4;

    PlayerMovementv2 playerMovementScr;

    void Start()
    {
        playerMovementScr = GetComponent<PlayerMovementv2>();
    }

    void Update()
    {
        jetpackPercentage = playerMovementScr.jetpackFuel / playerMovementScr.jetpackCapacity;
        if (jetpackPercentage > 1)
        {
            jetpackPercentage = 1;
        }
        jetpackBar.localScale = new Vector3(jetpackPercentage * jetpackMaxScale, jetpackBar.localScale.y, jetpackBar.localScale.z);

        healthPercentage = playerMovementScr.jetpackFuel / playerMovementScr.jetpackCapacity; // To Fix
        if (healthPercentage > 1)
        {
            healthPercentage = 1;
        }
        healthBar.localScale = new Vector3(healthPercentage * healthMaxScale, healthBar.localScale.y, healthBar.localScale.z);
    }
}
