using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionIndicator : MonoBehaviour
{

    [SerializeField] private Material indicatorMaterial;
    public List<SpriteRenderer> renderers;
    private Transform targetTransform;

    private void Start() {
        UnIndicate();
    }

    private void Update() {
        if (targetTransform != null) {
            gameObject.transform.position = targetTransform.position;
        }
    }

    public void Indicate(Transform targetTransform) {
        foreach (var r in renderers) {
            r.material.SetFloat("_Indicate", 1f);
        }
        this.targetTransform = targetTransform;
    }

    public void UnIndicate() {
        foreach (var r in renderers) {
            r.material.SetFloat("_Indicate", 0f);
            r.material.SetFloat("_Warning", 0f);
        }
        targetTransform = null;
    }

    public void Warn(Transform targetTransform) {
        gameObject.transform.position = targetTransform.position;
        foreach (var r in renderers) {
            r.material.SetFloat("_Indicate", 1f);
            r.material.SetFloat("_Warning", 1f);
        }
        this.targetTransform = targetTransform;
        Invoke("UnIndicate", 0.1f);
    }

    public void RaiseSortingOrder() {
        foreach (var r in renderers) {
            r.sortingOrder = 5;
        }
    }

    public void ReduceSortingOrder() {
        foreach (var r in renderers) {
            r.sortingOrder = 0;
        }
    }

}
