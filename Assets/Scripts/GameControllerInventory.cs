using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerInventory : MonoBehaviour {

    [SerializeField]
    private CpuInventoryUi cpuInventoryUi = null;

    private PlayerInventory _playerInventory = null;
    
    void Awake() {
        _playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();
    }

    void Start() {
        cpuInventoryUi.gameObject.SetActive(false);
    }

    void Update() {
        if (cpuInventoryUi != null) {
            CpuInventory cpuInventory = cpuInventoryUi.GetCpuInventory();

            if (cpuInventory != null) { 
                Item cpuItem = cpuInventory.GetAttachedItem();
                Item playerItem = _playerInventory.GetAttachedItem();

                if (cpuItem != null && playerItem != null) { 
                    ItemGroup[] groupsCpu = cpuItem.GetGroups();
                    ItemGroup[] groupsPlayer = playerItem.GetGroups();

                    bool isTheSameGroup = false;
                    foreach (ItemGroup cpuGroup in groupsCpu) {
                        foreach (ItemGroup playerGroup in groupsPlayer) {
                            if (cpuGroup == playerGroup) {
                                isTheSameGroup = true;
                                break;
                            }
                        }
                        if (isTheSameGroup) break;
                    }

                    if (isTheSameGroup) {
                        //Item auxItem = cpuItem;

                        cpuInventoryUi.GetCpuInventory().SetItem(cpuItem, playerItem);
                        _playerInventory.SetItem(playerItem, cpuItem);
                    }
                }
            }
        }
    }

}