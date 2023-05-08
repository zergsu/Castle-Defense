using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] int towerPrice = 25;
    public bool CreateTower(Tower tower, Vector3 position) {
        Bank bank = FindObjectOfType<Bank>();
        if(bank == null) { return false; }

        if(bank.CurrentBalance >= towerPrice) {
            bank.Withdraw(towerPrice);
            Instantiate(tower.gameObject, position, Quaternion.identity);
            return true;
        }

        return false;
    }
}
