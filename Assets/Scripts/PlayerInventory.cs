using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour {

    [SerializeField]
    private Image[] itemsImages = null;

    [SerializeField]
    private Sprite emptyItemImage = null;

    private readonly List<Item> _items = new List<Item>();
    private int _positionAttached = -1;

    void Start() {
        
    }

    void Update() {
        
    }

    public void AddItem(Item item) {
        if (_items.Count < 5 && !_items.Contains(item)) {
            _items.Add(item);
            UpdateImages();
        }
    }

    public void Attach(int position) {
        Detach();

        if (_positionAttached != position && _items.Count > position) {
            Image itemImage = itemsImages[position];

            Image parentImage = itemImage.GetComponentsInParent<Image>()[1];
            _positionAttached = position;
            itemImage.transform.localScale = Vector3.one * 1.15f;

            Color itemImageColor = parentImage.color;
            itemImageColor.a = 1f;
            parentImage.color = itemImageColor;
        } else if (_positionAttached == position) {
            _positionAttached = -1;
        }
    }

    public void Detach() {
        foreach (Image item in itemsImages) {
            Image parentImage = item.GetComponentsInParent<Image>()[1];
            item.transform.localScale = Vector3.one;

            Color itemImageColor = parentImage.color;
            itemImageColor.a = 64f/256f;
            parentImage.color = itemImageColor;
        }
    }

    public void RemoveItem(int position) {
        if (_items.Count > position) {
            _items.RemoveAt(position);
        }
        UpdateImages();
    }

    public void UpdateImages() {
        foreach (Item item in _items) {
            Image itemImage = itemsImages[_items.IndexOf(item)];
            itemImage.sprite = item.GetImage();
            Color itemImageColor = itemImage.color;
            itemImageColor.a = 1f;
            itemImage.color = itemImageColor;
        }

        for (int i = _items.Count; i < 5; i++) {
            Image itemImage = itemsImages[i];
            itemImage.sprite = emptyItemImage;
            Color itemImageColor = itemImage.color;
            itemImageColor.a = 0f;
            itemImage.color = itemImageColor;
        }
    }

    public Item GetAttachedItem() {
        if (_positionAttached > -1) {
            return _items[_positionAttached];
        }
        return null;
    }

    public void SetItem(Item actualItem, Item newItem) {
        _items.Remove(actualItem);
        _items.Add(newItem);
        UpdateImages();

        _positionAttached = -1;
        Detach();
    }

}