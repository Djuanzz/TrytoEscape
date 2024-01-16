using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PovRoom : MonoBehaviour
{
    private Canvas canvas;
    public string roomFolderName = "Chillroom"; // Nama folder yang berisi gambar-gambar ruangan
    private Sprite[] roomSprites;
    private Image imageComponent;
    private int currentSpriteIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        canvas = FindObjectOfType<Canvas>();
        Transform bgTransform = canvas.transform.Find("background");
        imageComponent = bgTransform.GetComponent<Image>();

        // Mendapatkan semua sprite dalam folder "Room"
        roomSprites = Resources.LoadAll<Sprite>(roomFolderName);

        // Memeriksa apakah ada sprite yang dimuat
        if (roomSprites.Length > 0)
        {
            // Mengambil sprite pertama dari array dan menggantinya
            imageComponent.sprite = roomSprites[currentSpriteIndex];
            Debug.Log("Background sprite changed to: " + roomSprites[currentSpriteIndex].name);
        }
        else
        {
            Debug.LogError("No sprites found in the folder: " + roomFolderName);
        }
    }

    public void RightArrow()
    {
        // Pindah ke sprite berikutnya
        currentSpriteIndex = (currentSpriteIndex + 1) % roomSprites.Length;
        // Mengganti sprite dengan sprite berikutnya
        imageComponent.sprite = roomSprites[currentSpriteIndex];
        Debug.Log("Background sprite changed to: " + roomSprites[currentSpriteIndex].name);
    }

    public void LeftArrow()
    {
        // Pindah ke sprite sebelumnya
        currentSpriteIndex = (currentSpriteIndex - 1 + roomSprites.Length) % roomSprites.Length;
        // Mengganti sprite dengan sprite sebelumnya
        imageComponent.sprite = roomSprites[currentSpriteIndex];
        Debug.Log("Background sprite changed to: " + roomSprites[currentSpriteIndex].name);
    }

    // ... (metode lainnya)

    // Update is called once per frame
    void Update()
    {
        // Tambahkan kode update jika diperlukan
    }
}
