using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkins : MonoBehaviour
{
    private SpriteRenderer playerSkin;

    private void Start()
    {
        //PlayerPrefs.DeleteAll();
        playerSkin = GetComponent<SpriteRenderer>();
        currentPlayerSkinID = PlayerPrefs.GetInt(SkinID);
    }

    [SerializeField] public Sprite defaultSkin;
    [SerializeField] public Sprite redSkin;
    [SerializeField] public Sprite YellowSkin;
    [SerializeField] public Sprite purpleSkin;
    [SerializeField] public Sprite orangeSkin;
    [SerializeField] public Sprite blueSkin;
    [SerializeField] public Sprite darkBlueSkin;

    public string SkinID = "skinID";
    public int currentPlayerSkinID;


    private void Update()
    {
        currentPlayerSkinID = PlayerPrefs.GetInt(SkinID);

        if (currentPlayerSkinID == 0)
        {
            playerSkin.sprite = defaultSkin;
        }
        if (currentPlayerSkinID == 1)
        {
            playerSkin.sprite = redSkin;
        }
        if (currentPlayerSkinID == 2)
        {
            playerSkin.sprite = YellowSkin;
        }
        if (currentPlayerSkinID == 3)
        {
            playerSkin.sprite = purpleSkin;
        }
        if (currentPlayerSkinID == 4)
        {
            playerSkin.sprite = orangeSkin;
        }
        if (currentPlayerSkinID == 5)
        {
            playerSkin.sprite = blueSkin;
        }
        if (currentPlayerSkinID == 6)
        {
            playerSkin.sprite = darkBlueSkin;
        }


    }
}
