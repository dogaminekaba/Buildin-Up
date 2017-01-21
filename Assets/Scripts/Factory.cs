using UnityEngine;

public class Factory : MonoBehaviour {

    [SerializeField]
    private GameObject cubePrefab;
    [SerializeField]
    private GameObject rectPrefab;
    [SerializeField]
    private GameObject cylinderPrefab;

    public GameObject getCube(Vector3 position)
    {
        float cubeSize = Random.Range(0.1f, 0.2f);
        GameObject cube = Instantiate(cubePrefab, position, Quaternion.identity);
        cube.transform.localScale.Set(1, 1, 1);
        return cube;
    }


}
