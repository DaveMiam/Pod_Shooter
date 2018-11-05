using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour,Damagable {
    playerLife playerLife;
    // Use this for initialization

public void DealDamage(int damage)
    {
        playerLife.TakeDamage(damage);
    }

    void Start () {
        playerLife = GetComponent<playerLife>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
