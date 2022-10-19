using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointController : MonoBehaviour
{
    // Start is called before the first frame update
    public static CheckPointController instance;
    public CheckPoint[] checkpoints;
    public Vector3 spawnPoint;
    void Awake()
    {
        instance =this;
    }


    private void Start() {

        checkpoints = FindObjectsOfType<CheckPoint>();
        spawnPoint =Player.instance.transform.position;
    }
    // Update is called once per frame


    public void DeactivateCheckpoints(){
        for(int i=0; i< checkpoints.Length;i++){
            checkpoints[i].ResetCheckpoints();
        }
    }


     public void SetSpawnPoint(Vector3  newSpawnPoint){
            spawnPoint = newSpawnPoint;
    }

}