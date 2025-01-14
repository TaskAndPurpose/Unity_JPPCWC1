using UnityEngine;
using UnityEngine.SceneManagement;

public class Plane_MK1 : MonoBehaviour
{
    /// <summary>
    /// Variables
    /// </summary>
    [Header("Plane Settings")]
    public float forwardSpeed = 10f; // Constant forward movement speed
    public float tiltSpeed = 10f;    // Speed at which the plane tilts

    [Header("Camera Settings")]
    public Camera firstPersonCamera;
    public Camera thirdPersonCamera;

    private void Start()
    {
        // Ensure only one camera is active at start
        ActivateFirstPersonCamera();
    }
    
    /// <summary>
    /// Functions
    /// </summary>
    
    
 

    private void LinearEngine()
    {
        //constantly move forward
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);
    }
    
    
    private void HandleMovement()
    {
        //WS, tilt the nose of the plane rotation to climb or decend
        float verticalInput = Input.GetAxis("Vertical"); // Maps W and S to -1 to 1
        transform.Rotate(Vector3.right, -1*verticalInput * tiltSpeed * Time.deltaTime);
        
        
        
        // Tilt the plane based on A (left) and D (right) and ROTATE on the z
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.forward, -1*horizontalInput * tiltSpeed * Time.deltaTime);

    }

    private void HandleCameraSwitching()
    {
        // Switch to first-person camera with key 1
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ActivateFirstPersonCamera();
        }

        // Switch to third-person camera with key 2
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ActivateThirdPersonCamera();
        }
    }

    private void ActivateFirstPersonCamera()
    {
        if (firstPersonCamera != null && thirdPersonCamera != null)
        {
            firstPersonCamera.gameObject.SetActive(true);
            thirdPersonCamera.gameObject.SetActive(false);
        }
        else
        {
            Debug.LogError("Cameras not assigned in the Inspector!");
        }
    }

    private void ActivateThirdPersonCamera()
    {
        if (firstPersonCamera != null && thirdPersonCamera != null)
        {
            firstPersonCamera.gameObject.SetActive(false);
            thirdPersonCamera.gameObject.SetActive(true);
        }
        else
        {
            Debug.LogError("Cameras not assigned in the Inspector!");
        }
    }

    private void HandleLevelReset()
    {
        // Reset the level with the R key
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetCurrentLevel();
        }
    }

    private void ResetCurrentLevel()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }
    
    
    ///
    // MonoBehaviour 
    ///
    private void Update()
    {
      
        LinearEngine();
        HandleMovement();
        HandleCameraSwitching();
        HandleLevelReset();
    }
}
