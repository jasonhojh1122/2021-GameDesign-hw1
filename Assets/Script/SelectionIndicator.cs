using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionIndicator : MonoBehaviour
{

    [SerializeField] private Material indicatorMaterial;

    public List<SpriteRenderer> renderers;

    private void Start() {
        UnIndicate();
    }

    public void Indicate(Vector3 pos) {
        // indicatorMaterial.SetInt("Indicating", 1);
        Debug.Log("Indicated");
        foreach (var r in renderers) {
            r.material.SetFloat("_Indicate", 1f);
        }
        gameObject.transform.position = pos;
    }

    public void UnIndicate() {
        // indicatorMaterial.SetInt("Indicating", 0);
        Debug.Log("UnIndicated");
        foreach (var r in renderers) {
            r.material.SetFloat("_Indicate", 0f);
        }
    }

}
