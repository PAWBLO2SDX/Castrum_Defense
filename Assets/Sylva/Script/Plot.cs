using UnityEngine;

public class Plot : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject dimPrefab;
    [SerializeField] private GameObject levelManager;

    private GameObject tower;
    private GameObject dimmer;

    private void OnMouseEnter()
    {
        dimmer = Instantiate(dimPrefab, transform.position, Quaternion.identity);
    }

    private void OnMouseExit()
    {
        Destroy(dimmer);
    }

    private void OnMouseDown()
    {
        //this is gonna be where we check if the plot is purchased and such using the Money script. This will be a nightmare
    }
}
