using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class ABoat : MonoBehaviour {

    [SerializeField] private List<BoatSlot> slots;
    [SerializeField] private float speed;
    [SerializeField] private int score;
    [SerializeField] private AudioClip hornSound;

    private Vector3 targetPos;

    private bool stopped;

    public int SlotNum {
        get => slots.Count;
    }

    private AudioSource audioSource;

    public abstract float GetWeight(float time);

    void Awake() {
        audioSource = GetComponent<AudioSource>();
    }

    void Start() {
        audioSource.PlayOneShot(hornSound, 0.6f);
    }

    protected virtual void Update() {
        if (!stopped)
            Move();
    }

    public void MoveTo(Vector3 pos) {
        stopped = false;
        this.targetPos = pos;
    }

    private void Move() {
        Vector3 newPos = gameObject.transform.position;
        newPos.x -= speed * Time.deltaTime;
        gameObject.transform.position = newPos;
        if (Mathf.Abs(targetPos.x - newPos.x) < 0.1f) {
            stopped = true;
        }
    }

    public bool IsSatisfy() {
        for (int i = 0; i < slots.Count; i++) {
            Container con = slots[i].GetContainer();
            if (con == null || con.GetContainerType() != slots[i].GetContainerType()) {
                return false;
            }
        }
        return true;
    }

    public bool IsStop() {
        return stopped;
    }

    public void SetSlotType(int id, Container container) {
        slots[id].SetType(container);
    }

    public void Leave() {
        Destroy(gameObject);
    }

    public int GetScore() {
        return score;
    }

}
