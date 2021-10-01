using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour, ISlot
{

    private Container container;

    Animator anim;

    void Start() {
        container = null;
        anim = GetComponent<Animator>();
        anim.Play("Rest");
    }

    public bool Store(Container container) {
        if (this.container != null) return false;
        this.container = container;
        this.container.transform.SetParent(gameObject.transform);
        this.container.transform.localPosition = Vector3.zero;
        return true;
    }

    public void Retrive(Container container) {
        this.container = null;
    }

    public void Touch() {
        anim.Play("Slot");
    }
}
