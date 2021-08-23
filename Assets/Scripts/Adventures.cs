using UnityEngine;

public class Adventures : MonoBehaviour
{
    private bool getQuest = false;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && getQuest == true &&
            Manager.instance.turn < 5 && Manager.instance.warrior >= 1)
        {
            Manager.instance.AddTurn(1);
            Manager.instance.Quest();
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            getQuest = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            getQuest = false;
        }
    }
}