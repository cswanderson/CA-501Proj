using UnityEngine;

public class SpriteVideoPlayer : MonoBehaviour
{
    public string spritesFolderPath = "Vid"; // Path to the folder within Resources
    public float framesPerSecond = 24.0f; // Playback speed

    private Sprite[] sprites; // Array of sprites to play, loaded at runtime
    private SpriteRenderer spriteRenderer;
    private int currentSpriteIndex;
    private float timeSinceLastFrame;
    private float frameDuration; // Duration of each frame

    // Additional variables for slow motion
    public float slowMotionFactor = 1.0f; // Increase to slow down more, 1 is normal speed
    private float slowMotionTimer = 0f;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        LoadSpritesFromFolder(spritesFolderPath);
        frameDuration = 1 / framesPerSecond;
    }

    void LoadSpritesFromFolder(string path)
    {
        // Load all sprites from the specified folder within Resources
        sprites = Resources.LoadAll<Sprite>(path);
    }

    void Update()
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
}
