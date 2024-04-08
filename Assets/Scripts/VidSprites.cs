using UnityEngine;

public class SpriteVideoPlayer : MonoBehaviour
{
    public string spritesFolderPath; //= "Vid"; // Path to the folder within Resources
    public float framesPerSecond = 24.0f; // Playback speed
    public bool plaV;
    private string parentName;

    private Sprite[] sprites; // Array of sprites to play, loaded at runtime
    private SpriteRenderer spriteRenderer;
    private int currentSpriteIndex;
    private float timeSinceLastFrame;
    private float frameDuration; // Duration of each frame

    // Additional variables for slow motion
    public float slowMotionFactor = 1.0f; // Increase to slow down more, 1 is normal speed
    private float slowMotionTimer = 0f;
    //public Vector3 newSize;
    private Transform sRsize;
    public GameObject mainCamera; // The camera to check against. Assign this in the inspector or find it dynamically.
    public float maxDistance = 36.0f; // Maximum distance for the object to be considered "visible"
    //public GameObject targetComponent; // The target component that contains the bool to toggle. Assign this in the inspector.

    void Start()
    {
        mainCamera = GameObject.Find("GR3D Player");
        spriteRenderer = GetComponent<SpriteRenderer>();
        parentName = transform.parent.name;
        sRsize = GetComponent<Transform>();
        //sRsize.localScale = newSize;
        LoadSpritesFromFolder(spritesFolderPath);
        spriteRenderer.sprite = sprites[currentSpriteIndex];
        Resize();
        
    }

      void Resize()
    {
        static string RemoveSecondItem(string parentName)
        {
            string[] items = parentName.Split(new[] { ' ' }, System.StringSplitOptions.RemoveEmptyEntries);
            if (items.Length >= 2)
            {
                return items[0];
            }
            return parentName;
        }

        parentName = RemoveSecondItem(parentName);
        
        if (parentName == "BillboardModern")
        {
            BilMod();
        }
        if (parentName == "BillboardModern2")
        {
            BilMod2();
        }
        if (parentName == "BillboardModern3")
        {
            BilMod3();
        }
        if (parentName == "BillboardModern4")
        {
            BilMod4();
        }
        if (parentName == "BillboardModern5")
        {
            BilMod5();
        }
        if (parentName == "BillboardModern6")
        {
            BilMod6();
        }

        void BilMod()
    {
            if (spritesFolderPath == "Vid")
            {
                sRsize.localScale = new Vector3(.95f, 2.0f, 1.0f);
            }

            if (spritesFolderPath == "TrafficRev")
            {
                sRsize.localScale = new Vector3(.43f, .91f, 1.0f);
            }

            if (spritesFolderPath == "FireLong")
            {
                sRsize.localScale = new Vector3(.53f, 1.09f, 1.0f);
            }

            if (spritesFolderPath == "Kids3")
            {
                sRsize.localScale = new Vector3(.53f, 1.09f, 1.0f);
            }

            else
            {
                sRsize.localScale = new Vector3(.635f, 1.32f, 1.0f);
            }
        }
    }
    void BilMod2()
    {
        if (spritesFolderPath == "Vid")
        {
            sRsize.localScale = new Vector3(1.31f, 1.15f, 1.0f);
        }

        if (spritesFolderPath == "TrafficRev")
        {
            sRsize.localScale = new Vector3(.61f, .55f, 1.0f);
        }

        if (spritesFolderPath == "FireLong")
        {
            sRsize.localScale = new Vector3(.75f, .66f, 1.0f);
        }

        if (spritesFolderPath == "Kids3")
        {
            sRsize.localScale = new Vector3(.75f, .66f, 1.0f);
        }

        else
        {
            sRsize.localScale = new Vector3(.89f, .77f, 1.0f);
        }
    }
    void BilMod3()
    {
        if (spritesFolderPath == "DudeFire")
        {
            sRsize.localScale = new Vector3(1.15f, 1.34f, 1.0f);
        }
        else
        {
            sRsize.localScale = new Vector3(.56f, .65f, 1.0f);
        }
    }
    void BilMod4()
    {
        if (spritesFolderPath == "Vid")
        {
            sRsize.localScale = new Vector3(1.44f, 2.45f, 1.0f);
        }

        if (spritesFolderPath == "TrafficRev")
        {
            sRsize.localScale = new Vector3(.655f, 1.15f, 1.0f);
        }

        if (spritesFolderPath == "FireLong")
        {
            sRsize.localScale = new Vector3(.795f, 1.39f, 1.0f);
        }

        if (spritesFolderPath == "Kids3")
        {
            sRsize.localScale = new Vector3(.795f, 1.39f, 1.0f);
        }

        else
        {
            sRsize.localScale = new Vector3(.96f, 1.63f, 1.0f);
        }
    }

    void BilMod5()
    {
        if (spritesFolderPath == "DudeFire")
        {
            sRsize.localScale = new Vector3(.68f, 1.64f, 1.0f);
        }

        else
        {
            sRsize.localScale = new Vector3(.3f, .77f, 1.0f);
        }
    }
    void BilMod6()
    {
        if (spritesFolderPath == "Vid")
        {
            sRsize.localScale = new Vector3(1.29f, 1.4f, 1.0f);
        }

        if (spritesFolderPath == "TrafficRev")
        {
            sRsize.localScale = new Vector3(.585f, .66f, 1.0f);
        }

        if (spritesFolderPath == "FireLong")
        {
            sRsize.localScale = new Vector3(.71f, .79f, 1.0f);
        }

        if (spritesFolderPath == "Kids3")
        {
            sRsize.localScale = new Vector3(.71f, .79f, 1.0f);
        }

        else
        {
            sRsize.localScale = new Vector3(.86f, .93f, 1.0f);
        }
    }
    void LoadSpritesFromFolder(string path)
    {
        // Load all sprites from the specified folder within Resources
        sprites = Resources.LoadAll<Sprite>(path);
      
    }

    void ToggleVisibilityBasedOnCamera()
    {
        // Calculate the distance from the object to the camera
        float distance = UnityEngine.Vector3.Distance(transform.position, mainCamera.transform.position);
        // Check if the object is within the maximum distance
        if (distance <= maxDistance)
        {
            // Calculate the vector from the camera to the object
            UnityEngine.Vector3 directionToObject = transform.position - mainCamera.transform.position;

            // Calculate the angle between the camera's forward direction and the direction to the object
            float angle = UnityEngine.Vector3.Angle(mainCamera.transform.forward, directionToObject);

            // If the angle is small enough (e.g., within 45 degrees), consider the camera as facing the object
            if (angle <= 180.0f)
            {
                // The camera is facing the object and it's within the specified distance
                plaV = true;
            }
            else
            {
                // The camera is not facing the object
                plaV = false;
            }
        }
        else
        {
            // The object is too far from the camera
            plaV = false;
        }
    }

    void Update()
    {
        frameDuration = 1 / framesPerSecond;
        if (plaV == true)
        {

            if (sprites == null || sprites.Length == 0) return; // Exit if no sprites loaded

            timeSinceLastFrame += Time.deltaTime;
            slowMotionTimer += Time.deltaTime;

            if (slowMotionTimer >= (frameDuration * slowMotionFactor))
            {
                if (timeSinceLastFrame >= frameDuration)
                {
                    // Update sprite
                    spriteRenderer.sprite = sprites[currentSpriteIndex];

                    // Move to the next sprite, looping back to the start if necessary
                    currentSpriteIndex = (currentSpriteIndex + 1) % sprites.Length;

                    // Reset timers
                    timeSinceLastFrame = 0f;
                    slowMotionTimer = 0f;
                }
            }

        }

        ToggleVisibilityBasedOnCamera();
      
    }
}
