using UnityEngine;

public class Magnet : MonoBehaviour
{

    [SerializeField] private AudioClip hitSound;

    public SelectionIndicator indicator;

    public bool withContainer;

    public GameObject containerGO;
    public Container container;
    public SpriteRenderer spriteRenderer;
    public ISlot slot;

    private AudioSource audioSource;

    void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Container" && withContainer == false) {
            containerGO = other.gameObject;
            // container = other.gameObject.GetComponent<Container>();
            // spriteRenderer = container.GetComponent<SpriteRenderer>();
            indicator.Indicate(containerGO.transform);
        }
        if (other.gameObject.tag == "Slot") {
            Debug.Log(string.Format("Ender {0}", other.gameObject.name));
            slot = other.gameObject.GetComponent<ISlot>();
            slot.Touch();
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Container" && withContainer == false) {
            indicator.Indicate(other.gameObject.transform);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Container" && withContainer == false) {
            indicator.UnIndicate();
            containerGO = null;
        }
        if (other.gameObject.tag == "Slot") {
            slot = null;
        }
    }

    public bool IsOnContainer()
    {
        return containerGO != null;
    }

    public bool IsOnSlot()
    {
        return slot != null;
    }

    public void PickUp()
    {
        if (!IsOnSlot()) return;
        indicator.UnIndicate();
        container = containerGO.GetComponent<Container>();
        spriteRenderer = containerGO.GetComponent<SpriteRenderer>();
        containerGO.transform.SetParent(gameObject.transform);
        RaiseSortingOrder();
        slot.Retrive(container);
        withContainer = true;
    }

    public void PutDown()
    {
        if (IsOnSlot() && slot.Store(container)) {
            ReduceSortingOrder();
            container = null;
            spriteRenderer = null;
            withContainer = false;
            audioSource.PlayOneShot(hitSound, 0.6f);
        }
        else {
            indicator.Warn(containerGO.transform);
        }
    }

    public bool IsWithContainer()
    {
        return withContainer;
    }

    public void RaiseSortingOrder() {
        indicator.RaiseSortingOrder();
        spriteRenderer.sortingOrder = 10;
    }

    public void ReduceSortingOrder() {
        indicator.ReduceSortingOrder();
        spriteRenderer.sortingOrder = 1;
    }

}