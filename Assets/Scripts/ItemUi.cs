using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ItemUi : MonoBehaviour {

    [SerializeField]
    private Item item = null;

    [SerializeField]
    private GameObject gameObjectToDestroy = null;

    private Image _image = null;
    private PlayerInventory _playerInventory = null;

    void Awake() {
        _playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();
        _image = GetComponent<Image>();
    }

    private void Start() {
        _image.sprite = item.GetImage();
    }

    public void GetItem() {
        _playerInventory.AddItem(item);
        Destroy(gameObjectToDestroy);
    }

}