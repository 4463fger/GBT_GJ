using UnityEngine.EventSystems;
using UnityEngine;
using JKFrame;
using UnityEngine.UI;
using TMPro;
using UnityEditor;
using Map;
public class SlotBase : MonoBehaviour, IPointerClickHandler ,IPointerEnterHandler,IPointerExitHandler,IBeginDragHandler,IDragHandler,IEndDragHandler
{
    [SerializeField] private TextMeshProUGUI CostText;
    [SerializeField] private Image towerImage;
    [SerializeField] private Image selectedImage;
    [SerializeField] private Image nullImage;
    [SerializeField] private TowerConfig towerConfig;
    private bool isDragging;
    private bool isInteractable=true;
    public void OnPointerClick(PointerEventData eventData)
    {
        if(isInteractable)
        {
            Instantiate(towerConfig.towerPreviewPrefab);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(isInteractable) 
        {
            selectedImage.gameObject.SetActive(true);
            
        }
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if(isInteractable) 
        {
            selectedImage.gameObject.SetActive(false);
        }
        
    }

    private GameObject previewTower;
    private RectTransform previewTowerRect;
    public void OnBeginDrag(PointerEventData eventData)
    {
        if(eventData.button!=PointerEventData.InputButton.Left)
        {
            return;
        }
        isDragging = true;
        previewTower=Instantiate(towerConfig.towerPreviewPrefab,UISystem.DragLayer);
        previewTowerRect=previewTower.GetComponent<RectTransform>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(!isDragging)
            return;
        UpdatePreviewPos(eventData);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if(!isDragging)
            return;
        // ��ȡUIԪ�ص���������
        Vector2 worldPos = GetPreviewTowerWorldPosition();

        // ʹ����������������߼��
        Tools.UnityTools.ScreenPointToRay2D(Camera.main, Input.mousePosition, (collider2D) =>
        {
            if (collider2D == null)
                return;
            Block block =collider2D.gameObject?.GetComponent<Block>();
            if (block != null && block.Type == BlockType.Placedable)
            {
                Instantiate(towerConfig.towerPrefab, block.transform.position, Quaternion.identity);
            }
        });
        Destroy(previewTower);
        previewTower = null;
    }
    public void Init(TowerConfig towerConfig)
    {
        if(towerConfig != null)
        {
            this.towerConfig = towerConfig;
            CostText.text = towerConfig.Coin.ToString();
            selectedImage.gameObject.SetActive(false);
            towerImage.sprite = towerConfig.towerSprite;
        }
        else if(towerConfig==null) 
        {
            nullImage.gameObject.SetActive(true);
            towerImage.gameObject.SetActive(false);
            selectedImage.gameObject.SetActive(false);
            CostText.gameObject.SetActive(false);
            isInteractable = false;
        }
        
    }
    /// <summary>
    /// ����Ԥ������λ��
    /// </summary>
    /// <param name="eventData"></param>
    private void UpdatePreviewPos(PointerEventData eventData)
    {
        if (previewTower == null)
            return;
        RectTransformUtility.ScreenPointToWorldPointInRectangle(GetComponentInParent<Canvas>().transform as RectTransform,
            eventData.position, null, out Vector3 worldPos);
        previewTowerRect.position = worldPos;
    }
    //private Block GetWorldPosition(Vector2 screenPos)
    //{
    //    Ray ray = Camera.main.ScreenPointToRay(screenPos);
    //    RaycastHit hit;

    //    if (Physics.Raycast(ray, out hit, 100,6))
    //    {
    //        print(hit.collider.gameObject.name);
    //        return hit.collider.gameObject.GetComponent<Block>();
    //    }
    //    return null;
    //}
    private Vector2 GetPreviewTowerWorldPosition()
    {
        // ��ȡUIԪ�ص����ĵ���Ļ����
        Vector2 screenCenter = RectTransformUtility.WorldToScreenPoint(
            null, // ���Canvas��Screen Space - Overlay������null
            previewTowerRect.position
        );

        // ת��Ϊ�������꣨����Z����ȣ�
        Vector3 screenPosWithZ = new Vector3(
            screenCenter.x,
            screenCenter.y,
            Camera.main.nearClipPlane // ��ʵ�������Z�����
        );
        return Camera.main.ScreenToWorldPoint(screenPosWithZ);
    }
    private Block GetWorldPosition(Vector2 worldPosition)
    {
        //  Ray ray=Camera.main.ScreenPointToRay(Input.mousePosition);
        //  RaycastHit hit;
        //  if (Physics.Raycast(ray, out hit, 100, 6))
        //  {
        //      Block block=hit.collider.gameObject.GetComponent<Block>();
        //      print(block.gameObject.transform.position);
        //      return block;
        //  }
        return null;
        // //
    }

    private Block GetWorldPositionTest()
    {
        return null;
    }

}
