using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ManagerJoyStick : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler  
{
    private Image imgJoyBg;
    private Image imgJoy;
    private Vector2 posInput;
    // Start is called before the first frame update
    void Start()
    {
        imgJoyBg = GetComponent<Image>();
        imgJoy = transform.GetChild(0).GetComponent<Image>();
    }


    public void OnDrag(PointerEventData eventData) //prevent error from using IdragHandler
    {
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(imgJoyBg.rectTransform, eventData.position, eventData.pressEventCamera, out posInput)) // to checke if the image is draged
        {
            posInput.x = posInput.x / (imgJoyBg.rectTransform.sizeDelta.x);
            posInput.y = posInput.y / (imgJoyBg.rectTransform.sizeDelta.y);
            Debug.Log(posInput.x.ToString() + "/" + posInput.y.ToString());

            //normalize
            if(posInput.magnitude > 1.0f)
            {
                posInput = posInput.normalized;
            }

            //joystick move

            imgJoy.rectTransform.anchoredPosition = new Vector2(posInput.x * (imgJoyBg.rectTransform.sizeDelta.x/2), posInput.y * (imgJoyBg.rectTransform.sizeDelta.y/2));
        }

           //chage /number to chage how for joyim can go
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
        OnDrag(eventData);
       
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        posInput = Vector2.zero;
        imgJoy.rectTransform.anchoredPosition = Vector2.zero;
    }

    public float inputHorizontal()
    {
        if (posInput.x != 0)
            return posInput.x;
        else
            return Input.GetAxis("Horizontal");
    }

    public float inputVertical()
    {
        if (posInput.y != 0)
            return posInput.y;
        else
            return Input.GetAxis("Horizontal");
    }
}
