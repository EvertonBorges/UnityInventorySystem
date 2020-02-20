using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoviment : MonoBehaviour {

    [SerializeField]
    private float speed = 0f;

    private CpuInventoryUi _cpuInventoryUi = null;

    void Awake() {
        _cpuInventoryUi = GameObject.FindGameObjectWithTag("NpcInventoryUi").GetComponent<CpuInventoryUi>();
    }

    void Update() {
        float vertical = Input.GetAxisRaw("Vertical");
        float horizontal = Input.GetAxisRaw("Horizontal");

        transform.position += (Vector3.up * vertical + Vector3.right * horizontal) * speed * Time.deltaTime;
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.CompareTag("Npc")) {
            CpuInventory cpuInventory = collision.GetComponent<CpuInventory>();
            cpuInventory.ShowInventory();
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("Npc")) {
            _cpuInventoryUi.HideActualCpuInventory();
        }
    }

}