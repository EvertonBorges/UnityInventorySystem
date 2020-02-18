using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CpuInventoryUi : MonoBehaviour {

    [SerializeField]
    private CpuInventory cpuInventory;

    public void SetCpu(CpuInventory cpuInventory) {
        this.cpuInventory = cpuInventory;
    }

    public CpuInventory GetCpuInventory() {
        return this.cpuInventory;
    }

}
