using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CobaObject : MonoBehaviour
{
    [SerializeField]
    public ObjectSO objectSO;

    private Image objectImage;

    private void Awake(){
        objectImage = GetComponent<Image>();
    }

    private void Start(){
        objectImage.sprite = objectSO.objectSprite;
        // objectImage.rectTransform.sizeDelta = new Vector2(objectSO.objectWidth, objectSO.objectHeight);
        objectImage.rectTransform.anchoredPosition = new Vector2(objectSO.objectX, objectSO.objectY);
    }
}
