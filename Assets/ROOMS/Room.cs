﻿using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour {
    public GameObject[] bottomRooms;
    public GameObject[] topRooms;
    public GameObject[] rightRooms;
    public GameObject[] leftRooms;
    public int minAllowedSpawn, maxAllowedSpawn;
    public float waitTime;
    public List<GameObject> roomsList = new List<GameObject> ();

    public bool bossSpawn, treasureSpawn;
    GameObject bossRoom;
    GameObject treasureRoom;
    public Transform bossSpawnPoint, treasureSpawnPoint;

    private void Update () {

        if (waitTime <= 0 && bossSpawn == false || waitTime <= 0 && treasureSpawn == false) {
            for (int i = 0; i < roomsList.Count; i++) {
                if (i == roomsList.Count - 1) {
                    Transform b = Instantiate (bossSpawnPoint, roomsList[i].transform.position, Quaternion.identity);
                    b.transform.parent = roomsList[i].transform;
                    Vector3 middlePos = roomsList[i].GetComponent<Collider> ().bounds.center;
                    b.transform.position = new Vector3 (middlePos.x, middlePos.y + 1.5f, middlePos.z);
                    roomsList[i].gameObject.transform.name = "Boss Room";
                    bossRoom = roomsList[i].gameObject;
                    bossRoom.tag = "BossRoom";
                    bossSpawn = true;
                }
                if (i == roomsList.Count - 3) {
                    Transform s = Instantiate (treasureSpawnPoint, roomsList[i].transform.position, Quaternion.identity);
                    s.transform.parent = roomsList[i].transform;
                    Vector3 middlePos = roomsList[i].GetComponent<Collider> ().bounds.center;
                    s.transform.position = new Vector3 (middlePos.x, middlePos.y + .5f, middlePos.z);
                    roomsList[i].gameObject.transform.name = "Treasure Room";
                    treasureRoom = roomsList[i].gameObject;
                    treasureRoom.tag = "TreasureRoom";
                    treasureSpawn = true;

                }

            }
            
        } else
            waitTime -= Time.deltaTime;
    }

}