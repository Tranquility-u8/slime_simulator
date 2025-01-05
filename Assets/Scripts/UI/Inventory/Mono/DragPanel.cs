using UnityEngine;
using UnityEngine.EventSystems;

public class DragPanel : MonoBehaviour, IDragHandler,IPointerDownHandler
{
    RectTransform rectTransform;
    Canvas canvas;
    
    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();

        //��Ϸ����Ĭ�ϲ� setActive(true) �㼶����� ����DragPanel ������--����ᱨ��
        canvas = GameObject.Find("InventoryCanvas").GetComponent<Canvas>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor; //eventData.deltaָ������  ���� ����
        //Debug.Log("");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        rectTransform.SetSiblingIndex(1); // ��������--����Խ�� ͼ����ǰ * ��֤DragPanel���������
    }
}
