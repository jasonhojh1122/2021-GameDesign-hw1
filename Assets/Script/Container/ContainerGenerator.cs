using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerGenerator : MonoBehaviour {

    [SerializeField] private float interval;
    [SerializeField] private Conveyor conveyor;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private List<Container> containers;

    private List<string> containerTypes;

    private List<float> CDF;

    private Dictionary<string, Container> containerDict;

    void Start()
    {
        containerTypes = new List<string>();
        CDF = new List<float>();
        containerDict = new Dictionary<string, Container>();
        for (int i = 0; i < containers.Count; i++) {
            containerTypes.Add(containers[i].GetContainerType());
            containerDict.Add(containers[i].GetContainerType(), containers[i]);
            CDF.Add(containers[i].GetSelectedWeight());
            if (i > 0) {
                CDF[i] += CDF[i-1];
            }
        }
        for (int i = 0; i < containers.Count; i++) {
            CDF[i] /= CDF[containers.Count-1];
        }

        StartCoroutine(Generator());
    }

    private IEnumerator Generator() {
        yield return new WaitForSeconds(interval/2);
        while (true) {
            if (!conveyor.IsFull()) {
                var con = GenerateContainer();
                conveyor.Store(con);
            }
            // yield return null;
            yield return new WaitForSeconds(interval);
        }
    }

    private Container GenerateContainer() {
        float rand = UnityEngine.Random.Range(0.0f, 1.0f);
        int res = CDF.BinarySearch(rand);
        if (res < 0) {
            res = ~res;
        }
        return Instantiate(containers[res], spawnPoint.position, Quaternion.identity);
    }

    public string GenerateContainerType() {
        float rand = UnityEngine.Random.Range(0.0f, 1.0f);
        int res = CDF.BinarySearch(rand);
        if (res < 0) {
            res = ~res;
        }
        return containerTypes[res];
    }

    public Container GetContainer(string type) {
        return containerDict[type];
    }

}
