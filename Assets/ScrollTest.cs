using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using System;
using DG.Tweening;
using System;

public class ScrollTest : MonoBehaviour
{
    public Text t1;
    public ScrollRect scrollRect;
    public Item itemPrefab;
    public RectTransform container;

    private List<string> data;

    List<Item> items = new List<Item>();
    public int numItem = 7;
    public int offset = 2;
    int itemH = 100;

    public void Init(List<string> data)
    {
        this.data = data;
        var i = 0;
        data.All(x =>
        {
            var item = Instantiate(itemPrefab, container, false) as Item;
            item.data.text = x;
            item.id.text = "ID:"+i;
            item.name = "item:" + i;
            items.Add(item);
            i++;
            if (i >= numItem)
            {
                return false;
            }
            return true;
        });

        container.DOSizeDelta(new Vector2(container.sizeDelta.x, data.Count * itemH), 0);

        scrollRect.onValueChanged.AddListener(onScroll);
    }

    void onScroll(Vector2 arg0)
    {
        container.GetComponent<GridLayoutGroup>().enabled = false;
        var y = container.localPosition.y;
        int head = Mathf.FloorToInt(y / itemH) - offset;
        t1.text = string.Format("c.y : {0}\nHEAD : {1}", container.localPosition.y, head);
        if (head < 0)
        {
            return;
        }


        var length = Mathf.Min(data.Count, head + numItem);

        for (var i = head; i < length; i++)
        {
            var item = items[i % numItem];
            item.data.text = data[i];
            item.transform.DOLocalMoveY(-i * itemH - itemH / 2, 0);
        }
    }
}
