using UnityEngine;

public class Cow : MonoBehaviour
{
    private bool getMeat = false;
    public int meatToAdd = 1;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && getMeat == true &&
            Manager.instance.turn < 5)
        {
            Manager.instance.AddMeat(meatToAdd);
            Manager.instance.AddTurn(1);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            getMeat = true;
        }
    }
    
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            getMeat = false;
        }
    }
}