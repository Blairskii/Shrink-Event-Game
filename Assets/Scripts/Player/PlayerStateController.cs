using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerStateController : MonoBehaviour
{
    public bool IsLarge { get; private set; } 

    [Header("Start State")] 
    [SerializeField] private bool startLarge = false; // Player Starts Small by default

    [Header("Scale")] //Player size values
    [SerializeField] private Vector3 smallScale = Vector3.one;
    [SerializeField] private Vector3 largeScale = new Vector3(2f, 2f, 1f);

    [Header("Events")] //Events set in inspector, called when player changes size
    public UnityEvent OnBecameSmall;
    public UnityEvent OnBecameLarge;

    private IPlayerSizeListener[] listeners; // listeners that implement IPlayerSizeListener

    private void Awake() // Cache listeners in the scene when the script starts
    {
        CacheListeners();
    }

    private void Start()
    {
        ApplyStartingState(); // Apply the starting state after caching listeners to ensure they receive the correct event
    }

    private void CacheListeners() // Finds all MonoBehaviours in the scene and checks if they use IPlayerSizeListener
    {
        MonoBehaviour[] allBehaviours = FindObjectsOfType<MonoBehaviour>(true);
        List<IPlayerSizeListener> foundListeners = new List<IPlayerSizeListener>();

        foreach (MonoBehaviour behaviour in allBehaviours) // Loop through all MonoBehaviours and check if they implement IPlayerSizeListener
        {
            if (behaviour is IPlayerSizeListener listener) // If it does, add it to the list of listeners
            {
                foundListeners.Add(listener); // Add the listener to the list
            }
        }

        listeners = foundListeners.ToArray(); // Convert the list to an array
    }

    private void ApplyStartingState() // Apply the starting state based on the startLarge variable
    {
        if (startLarge)
        {
            ForceLarge();// If startLarge is true, force the player to be large
        }
        else
        {
            ForceSmall(); // If startLarge is false, force the player to be small
        }
    }

    private void ForceSmall() // Force the player to be small without checking the current state, used for initialization and forced changes
    {
        IsLarge = false; // Set the state to small
        transform.localScale = smallScale; // Change the player's scale to the small scale

        foreach (IPlayerSizeListener listener in listeners)
        {
            listener.OnPlayerBecameSmall(); // Notify all listeners that the player has become small
        }

        OnBecameSmall.Invoke(); // Invoke the OnBecameSmall event 
    }

    private void ForceLarge() 
    {
        IsLarge = true;
        transform.localScale = largeScale; // Change the player's scale to the large scale

        foreach (IPlayerSizeListener listener in listeners) // Notify all listeners that the player has become large
        {
            listener.OnPlayerBecameLarge(); // Notify all listeners that the player has become large
        }

        OnBecameLarge.Invoke(); // Invoke the OnBecameLarge event
    }

    public void SetSmall()
    {
        if (!IsLarge)
            return;

        ForceSmall(); // If the player is already small, do nothing. Otherwise, force the player to be small
    }

    public void SetLarge()
    {
        if (IsLarge)
            return;

        ForceLarge(); // If the player is already large, do nothing. Otherwise, force the player to be large
    }

    public void ToggleSize()
    {
        if (IsLarge)
            SetSmall(); 
        else
            SetLarge(); // Toggle the player's size based on the current state
    }
}