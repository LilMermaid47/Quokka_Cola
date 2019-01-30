using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Gere les mouvements du joueur 
/// marche + jetpack
/// </summary>
public class PlayerMovement : MonoBehaviour {

    public float limitRechargeJetpack = 100.0f;
    public float powerLeftJetpack = 100.0f;
    public float jetPackSpeed = 1000.0f;
    public float jumpForce = 200;
    public float movementSpeed = 25.0f;
    private bool touchGround = true;
    private bool jetpackJump=false;
    public Rigidbody rb;

    void FixedUpdate()
    {
        //Mouvement wasd
        rb.AddForce(Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime, 0, Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime, ForceMode.Impulse);

        //Detecte si le joueur appuis de nouveau sur espace pour activer le jetpack
        if (Input.GetButtonDown("Jump") && powerLeftJetpack > 0 && !touchGround)
        {
            jetpackJump = true;
        }
       //Ajoute une force en Y lorsque le joueur a appuyé une seconde fois sur espace, si il appuis sur espace et si il reste du power dans le jetpack
       //Retire du power du jetpack
        if (Input.GetButton("Jump") && jetpackJump && powerLeftJetpack > 0)
        {
            rb.AddForce(0, jetPackSpeed * Time.deltaTime, 0);
            powerLeftJetpack--;
        }

        if(Input.GetButton("Jump") && touchGround)
        {
            rb.AddForce(0, jumpForce, 0,ForceMode.Impulse);
        }

        if (touchGround == true && powerLeftJetpack<limitRechargeJetpack)
        powerLeftJetpack++;

        touchGround = false;
    }
    /// <summary>
    /// Détecter si il y a une collision
    /// </summary>
    /// <param name="collisionInfoEnter">Collision enter</param>
    private void OnCollisionStay(Collision collisionInfoEnter)
    {
        //Détecte si la collision est le SOL pour activer le saut et la recharge du jetpack
        if (collisionInfoEnter.collider.gameObject.tag == ("Ground"))
        {
            touchGround = true;
            jetpackJump = false;
        }
    }
    /// <summary>
    /// Détecte lorsque le personnage quitte une colision
    /// </summary>
    /// <param name="collisionInfoExit">Collision exit</param>
    private void OnCollisionExit(Collision collisionInfoExit)
    {
        //Détecte si la collision est le SOL pour désactiver la recharge du jetpack
        if (collisionInfoExit.collider.gameObject.tag == ("Ground")) { touchGround = false; }
    }
}
