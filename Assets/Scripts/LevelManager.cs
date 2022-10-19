using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public float waitToRespawn;
    public int gemsCollected;

    private void Awake(){
        instance =this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RespawnPlayer(){
        StartCoroutine(RespawnCo());

    }
    IEnumerator RespawnCo(){
        Player.instance.gameObject.SetActive(false);

        yield return new WaitForSeconds(waitToRespawn);

        Player.instance.gameObject.SetActive(true);
        Player.instance.transform.position=CheckPointController.instance.spawnPoint;

        PlayerHealthController.instance.currentHealth=PlayerHealthController.instance.maxHealth;
        uiController.instance.UpdateHeathDisplay();
    }
}
