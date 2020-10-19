using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee_Damage : MonoBehaviour {
    public EnemyStats eStats;
    public float damage;
    public float waitTime, attackTime;
    private void Awake () {
        eStats = GetComponent<EnemyStats> ();
        eStats.damage = damage;
    }

    private void OnTriggerStay (Collider other) {
        if (other.tag == "Player") {
           if(attackTime <= waitTime){
               
            other.GetComponent<PlayerStats> ().TakeDamage (damage);
            attackTime = waitTime;
           }
           else
           waitTime -= Time.deltaTime;
        }
    }
}