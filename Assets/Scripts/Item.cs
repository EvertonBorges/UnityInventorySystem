using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

    [SerializeField]
    private Sprite image = null;

    [SerializeField]
    private ItemGroup[] groups = null;
    
    void Update() {
        
    }

    public Sprite GetImage() {
        return image;
    }

    public ItemGroup[] GetGroups() {
        return groups;
    }

}