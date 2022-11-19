using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FishInteractions : MonoBehaviour
{
    [SerializeField]
    float fishDropOffYOffset = 4;
    [SerializeField]
    GameObject myContainer;

    bool inFishPickUpArea = false;
    bool inFishDropOffArea = false;

    private InputController inputController;
    InputAction pickUp;

    FishPickUpContainer fishPickUpContainer;
    void Start()
    {
        inputController = new InputController();
        inputController.Enable();
        pickUp = inputController.Actions.Use;
        pickUp.performed += PickUpFish;
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
            fish.transform.position = new Vector3(myContainer.transform.position.x, myContainer.transform.position.y+ fishDropOffYOffset, myContainer.transform.position.z);
            myContainer.GetComponent<FishCarryingContainer>().AddFish(fish);
        }
    }
    GameObject GetFish()
    {
        return fishPickUpContainer.GetFish();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("FishPickUpArea"))
        {
            inFishPickUpArea=true;
            fishPickUpContainer = collision.gameObject.GetComponent<FishPickUpContainer>();
            Debug.Log("In fish area");
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("FishPickUpArea"))
        {
            inFishPickUpArea = false;
        }
    }
}
