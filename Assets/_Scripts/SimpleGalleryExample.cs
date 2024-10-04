using UnityEngine;
using UnityEngine.UI;

public class SimpleGalleryExample : MonoBehaviour
{
    public RawImage displayImage;  // The UI element to display the selected image
    public RectTransform rawImageRectTransform;  // Reference to the RawImage's RectTransform

    // Method to open the gallery and pick an image
    public void PickImageFromGallery()
    {
        NativeGallery.Permission permission = NativeGallery.GetImageFromGallery((path) =>
        {
            if (path != null)
            {
                // Load the image into a Texture2D
                Texture2D texture = NativeGallery.LoadImageAtPath(path, maxSize: 1024);
                if (texture == null)
                {
                    Debug.LogError("Couldn't load texture from " + path);
                    return;
                }

                // Assign the texture to the RawImage
                displayImage.texture = texture;

                // Adjust the size of the RawImage to match the texture's aspect ratio
                AdjustImageSize(texture);
            }
        }, "Select an image", "image/*");

        if (permission == NativeGallery.Permission.Denied)
        {
            Debug.LogError("Gallery access permission denied!");
        }
    }

    // Adjust the RawImage's size to maintain the aspect ratio of the image
    void AdjustImageSize(Texture2D texture)
    {
        // Get the aspect ratio of the texture
        float textureAspectRatio = (float)texture.width / (float)texture.height;

        // Get the current size of the RawImage's RectTransform
        float currentWidth = rawImageRectTransform.sizeDelta.x;
        float currentHeight = rawImageRectTransform.sizeDelta.y;

        // Calculate the new size while maintaining the aspect ratio
        if (textureAspectRatio > 1) // Wide image (landscape)
        {
            float newHeight = currentWidth / textureAspectRatio;
            rawImageRectTransform.sizeDelta = new Vector2(currentWidth, newHeight);
        }
        else // Tall image (portrait)
        {
            float newWidth = currentHeight * textureAspectRatio;
            rawImageRectTransform.sizeDelta = new Vector2(newWidth, currentHeight);
        }
    }
}
