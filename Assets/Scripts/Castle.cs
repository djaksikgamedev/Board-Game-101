using UnityEngine;

public class Castle : MonoBehaviour
{
    private bool getWarrior = false;
    public int warriorToAdd = 1;
    public int warriorCostMeat = 2;
    public int warriorCostwood = 1;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && getWarrior == true)
        {
            CheckIfCanBuy();
        }
    }

    public void CheckIfCanBuy()
    {
        if (Manager.instance.meat >= Manager.instance.costInMeat && 
            Manager.instance.wood >= Manager.instance.costInWood &&
            Manager.instance.turn < 5)
        {
            Manager.instance.AddWarrior(warriorToAdd);
            Manager.instance.AddTurn(1);
        }
        else Debug.Log("Brak funduszy."); 
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            getWarrior = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            getWarrior = false;
        }
    }
}