using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{   
    public static PlayerHealthController instance;
    
    public int currentHealth, maxHealth;
    
    public float invincibleLength;
    private float invincibleCounter;
    private SpriteRenderer theSR;

    private void Awake(){
        instance =this;
    }
    void Start()
    {
        currentHealth=maxHealth; 
        theSR= GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (invincibleCounter>0){
            invincibleCounter-=Time.deltaTime;
            if(invincibleCounter<= 0){
                theSR.color=new Color(theSR.color.r, theSR.color.g, theSR.color.b, 1f);
            }
        }
    }
    public void DealDamage(){
        if(invincibleCounter<=0){

            currentHealth--;
            if(currentHealth<=0){
                currentHealth=0;
                //gameObject.SetActive(false);
                LevelManager.instance.RespawnPlayer();
            }
            else{
                invincibleCounter= invincibleLength;
                theSR.color=new Color(theSR.color.r, theSR.color.g, theSR.color.b,.5f);

                Player.instance.Knockback();
            }
            uiController.instance.UpdateHeathDisplay();
        }
       

    }
    public void HealPlayer(){
        currentHealth++;
        if(currentHealth>maxHealth){
            currentHealth=maxHealth;
        }
        uiController.instance.UpdateHeathDisplay();
    }

}
