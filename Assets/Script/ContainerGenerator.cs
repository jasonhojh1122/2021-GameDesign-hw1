using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerGenerator : MonoBehaviour
{
    [SerializeField] private List<AContainer> container;

    public float interval;

    private IEnumerator coroutine;

    void Start()
    {
        StartCoroutine("Generator");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update");
        MoveContainer();
    }

    IEnumerator Generator() {
        while(true) {
            Generate();
            yield return new WaitForSeconds(interval);
        }
    }

    void Generate() {

    }

    void MoveContainer() {

    }
}
