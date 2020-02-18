using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUi : MonoBehaviour {

    [SerializeField]
    private Item item = null;

    private PlayerInventory _playerInventory = null;

    void Awake() {
        _playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();
    }

    public void GetItem() {
        _playerInventory.AddItem(item);
    }

}