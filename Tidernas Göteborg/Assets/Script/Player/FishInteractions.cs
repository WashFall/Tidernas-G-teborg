using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FishInteractions : MonoBehaviour
{

    [SerializeField]
    GameObject myContainer;

    bool inFishPickUpArea = false;
    bool inFishDropOffArea = false;

    private InputController inputController;
    InputAction pickUp;

    FishPickUpContainer fishPickUpContainer;
    FishCarryingContainer fishCarryingContainer;
    void Start()
    {
        inputController = new InputController();
        inputController.Enable();
        pickUp = inputController.Actions.Use;
        pickUp.performed += PickUpFish;
        pickUp.performed += DropOffFish;

        fishCarryingContainer = myContainer.GetComponent<FishCarryingContainer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void PickUpFish(InputAction.CallbackContext callback)
    {
        if (inFishPickUpArea)
        {
            AddFishToMyContainer(GetFish());
        }
    }
    void AddFishToMyContainer(GameObject fish)
    {
        if (fish != null)
        {
            fishCarryingContainer.AddFish(fish);
        }
    }
    GameObject GetFish()
    {
        return fishPickUpContainer.GetFish();
    }
    void DropOffFish(InputAction.CallbackContext callback)
    {
        if (inFishDropOffArea)
        {
            fishCarryingContainer.DeliverFish();
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("FishPickUpArea"))
        {
            inFishPickUpArea=true;
            fishPickUpContainer = collision.gameObject.GetComponent<FishPickUpContainer>();
        }else if (collision.gameObject.CompareTag("FishDropOffArea"))
        {
            inFishDropOffArea=true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("FishPickUpArea"))
        {
            inFishPickUpArea = false;
        }
        else if (collision.gameObject.CompareTag("FishDropOffArea"))
        {
            inFishDropOffArea = false;
        }
    }
}
