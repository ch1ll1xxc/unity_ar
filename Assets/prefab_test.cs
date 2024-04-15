using System.Collections;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class prefab_test : MonoBehaviour
{
    public GameObject Prefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        Vector3 position = other.bounds.center + Vector3.up * other.bounds.extents.y * 10;
        Instantiate(Prefab, position, transform.rotation);
    }
}
