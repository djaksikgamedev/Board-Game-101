using UnityEngine;

public class Tree : MonoBehaviour
{
    private bool getWood = false;
    public int woodToAdd = 1;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && getWood == true &&
            Manager.instance.turn < 5)
        {
            Manager.instance.AddWood(woodToAdd);
            Manager.instance.AddTurn(1);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            getWood = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            getWood = false;
        }
    }
}