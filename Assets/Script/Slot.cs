using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{

    private bool occupied;

    private AContainer container;

    public bool Occupied {
        get => occupied;
        set => occupied = value;
    }

    void Start()
    {
        occupied = false;
    }

    public void PutContainer(AContainer container) {
        this.container = container;
        this.container.transform.SetParent(gameObject.transform);
        this.container.transform.localPosition = Vector3.zero;
        occupied = true;
    }

    public AContainer GetContainer(GameObject go) {
        this.container.transform.SetParent(go.transform);
        occupied = false;
        return this.container;
    }

    public void ClearContainer() {
        this.container = null;
    }
}
