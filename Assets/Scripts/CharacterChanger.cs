using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterChanger : MonoBehaviour
{
    GameObject gameObject;
    public Sprite m_Sprite;
    Image m_Image;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        gameObject = GameObject.Find("Chosen Character");
        m_Image = gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    { }

    public void updateChar() 
    {
        animator.SetBool("IsOpen", true);
        m_Image.sprite = m_Sprite;
        m_Image.color = new Color32(255, 255, 255, 255);
    }
}
