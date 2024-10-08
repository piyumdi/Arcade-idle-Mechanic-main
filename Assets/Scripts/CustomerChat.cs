/*
using UnityEngine;

public class CustomerChat : MonoBehaviour
{
    public GameObject chatboxPrefab;  // Prefab for the empty chatbox
    public Transform chatboxPosition;  // Position above the customer's head where the chatbox should appear
    private GameObject activeChatbox;  // Store the active chatbox

    void Start()
    {
        // Spawn the chatbox when the customer needs to request food
        SpawnChatbox();
    }

    // Method to spawn the chatbox
    void SpawnChatbox()
    {
        // Instantiate the empty chatbox at the chatboxPosition
        activeChatbox = Instantiate(chatboxPrefab, chatboxPosition.position, Quaternion.identity);

        // Set it as a child of the chatboxPosition so it stays in the correct position
        activeChatbox.transform.SetParent(chatboxPosition);

        // Adjust the local position and scale if needed
        activeChatbox.transform.localPosition = Vector3.zero;
        activeChatbox.transform.localScale = Vector3.one;  // Adjust scale if necessary
    }

    // Method to remove the chatbox when the player delivers food
    public void RemoveChatbox()
    {
        if (activeChatbox != null)
        {
            Destroy(activeChatbox);
        }
    }
}
*/


using System.Collections.Generic;
using UnityEngine;

public class CustomerChat : MonoBehaviour
{
    public GameObject chatboxPrefab;  // Prefab for the chatbox
    public Transform chatboxPosition;  // Position above the customer's head where the chatbox should appear
    public GameObject foodOrderPlace;  // GameObject to display food in the chatbox
    public List<GameObject> foodPrefabs;  // List of food prefabs (Cake, Cupcake, Crepe)

    private GameObject activeChatbox;  // Store the active chatbox
    private GameObject displayedFood;  // The food being displayed in the chatbox
    private string requestedFoodTag;  // The tag of the requested food

    void Start()
    {
        // Spawn the chatbox when the customer needs to request food
        SpawnChatbox();
    }

    // Method to spawn the chatbox and randomly select a food order
    void SpawnChatbox()
    {
        // Instantiate the chatbox at the chatboxPosition
        activeChatbox = Instantiate(chatboxPrefab, chatboxPosition.position, Quaternion.identity);
        activeChatbox.transform.SetParent(chatboxPosition);
        activeChatbox.transform.localPosition = Vector3.zero;
        activeChatbox.transform.localScale = Vector3.one;

        // Randomly select a food item from the list and display it in the chatbox
        int randomIndex = Random.Range(0, foodPrefabs.Count);
        GameObject selectedFoodPrefab = foodPrefabs[randomIndex];

        // Instantiate the selected food item and set it in the food order place
        displayedFood = Instantiate(selectedFoodPrefab, foodOrderPlace.transform.position, Quaternion.identity);
        displayedFood.transform.SetParent(foodOrderPlace.transform);
        displayedFood.transform.localPosition = Vector3.zero;
        displayedFood.transform.localScale = Vector3.one;

        // Store the requested food tag for comparison
        requestedFoodTag = selectedFoodPrefab.tag;
    }

    // Method to remove the chatbox when the player delivers food
    public void RemoveChatbox()
    {
        if (activeChatbox != null)
        {
            Destroy(activeChatbox);
        }
    }

    // Method to get the requested food tag for comparison
    public string GetRequestedFoodTag()
    {
        return requestedFoodTag;
    }
}
