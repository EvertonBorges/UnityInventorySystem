using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CpuInventoryUi : MonoBehaviour {

    [SerializeField]
    private Button[] buttonsUi = null;

    private CpuInventory _cpuInventory = null;

    public void SetCpu(CpuInventory cpuInventory) {
        if (_cpuInventory != cpuInventory) { 
            HideActualCpuInventory();
            this.gameObject.SetActive(true);
            this._cpuInventory = cpuInventory;

            for (int i = 0; i < buttonsUi.Length; i++) {
                int position = i;

                Button button = buttonsUi[position];

                button.onClick.RemoveAllListeners();
                button.onClick.AddListener(delegate () {
                    _cpuInventory.Attach(position);
                });
            }
        }
    }

    public CpuInventory GetCpuInventory() {
        return this._cpuInventory;
    }

    public void HideActualCpuInventory() { 
        if (_cpuInventory != null) {
            _cpuInventory.HideIventory();
            _cpuInventory = null;
            this.gameObject.SetActive(false);
        }
    }

}
