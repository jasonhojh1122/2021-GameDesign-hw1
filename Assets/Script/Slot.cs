using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour, ISlot
{

    private AContainer container;

    void Start() {
        container = null;
    }

    public bool Store(AContainer container) {
        if (this.container != null) return false;
        this.container = container;
        this.container.transform.SetParent(gameObject.transform);
        this.container.transform.localPosition = Vector3.zero;
        return true;
    }

    public AContainer Retrive(AContainer container) {
        AContainer tmp = this.container;
        this.container = null;
        return tmp;
    }
}
