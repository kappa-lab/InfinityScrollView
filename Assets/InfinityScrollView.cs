using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace KappaLab.UI
{
    public abstract class BaseItem<T> : MonoBehaviour
    {
        public abstract void SetData(T m);

        public virtual void SetIndex(int index)
        {
            name = "Index : " + index;
        }
    }

    public class InfinityScrollView : MonoBehaviour
    {
        public Text t1;

        [SerializeField]
        private ScrollRect scrollRect;
        [SerializeField]
        private int offset = 2;
        [SerializeField]
        private int col = 2;
        [SerializeField]
        private int row = 3;
        [SerializeField]
        private Vector2 spacing = Vector2.zero;

        private RectTransform content;
        private int itemBufferCount;
        private int dataCount;

        private float itemH;
        private float itemW;

        public void Setup<T>(List<T> data, BaseItem<T> prefab, int col, int row, int offset, Vector2 spacing)
        {
            this.col = col;
            this.row = row;
            this.offset = offset;
            this.spacing = spacing;
            Setup(data, prefab);
        }

        public void Setup<T>(List<T> data, BaseItem<T> prefab)
        {
            itemBufferCount = col * row;
            content = scrollRect.content;

            var items = new List<BaseItem<T>>();
            var cellSize = prefab.GetComponent<RectTransform>().sizeDelta;
            itemH = cellSize.y;
            itemW = cellSize.x;
            dataCount = data.Count;
            var l = Mathf.Min(itemBufferCount, data.Count);
            var totalCol = Mathf.CeilToInt(data.Count / (float)col);
            var contentH = totalCol * itemH + (totalCol - 1) * spacing.y;
            var contentW = col * itemW + (col - 1) * spacing.x;

            content.anchorMax = content.anchorMin = content.pivot = new Vector2(0, 1);
            content.localPosition = Vector3.zero;
            content.sizeDelta = new Vector2(contentW, contentH);

            for (var i = 0; i < l; i++)
            {
                var item = Instantiate(prefab, content, false) as BaseItem<T>;
                item.SetData(data[i]);
                item.SetIndex(i);
                var pos = new Vector3(itemW / 2 + itemW * (i % col), Mathf.Floor(i / col) * -itemH - itemH / 2, 0);
                pos.x += spacing.x * (i % col);
                pos.y += spacing.y * -Mathf.Floor(i / col);
                item.transform.localPosition = pos;
                items.Add(item);
            }
            scrollRect.onValueChanged.AddListener(_ => OnScroll(data, items));
        }

        private void OnScroll<T>(List<T> data, List<BaseItem<T>> items)
        {
            var y = content.localPosition.y;
            int head = (Mathf.FloorToInt(y / itemH) - offset) * col;
            t1.text = string.Format("c.y : {0}\nHEAD : {1}", content.localPosition.y, head);
            if (head < 0)
            {
                head = 0;
            }

            var length = Mathf.Min(data.Count, head + itemBufferCount);

            for (var i = head; i < length; i++)
            {

                var item = items[i % itemBufferCount];
                item.SetData(data[i]);
                var pos = new Vector3(itemW / 2 + itemW * (i % col), Mathf.Floor(i / col) * -itemH - itemH / 2, 0);
                pos.x += spacing.x * (i % col);
                pos.y += spacing.y * -Mathf.Floor(i / col);

                item.transform.localPosition = pos;
            }
        }

        public void RemoveAllItems()
        {
            scrollRect.onValueChanged.RemoveAllListeners();

            foreach (Transform i in content.transform)
            {
                Destroy(i.gameObject);
            }

            content.localPosition = new Vector3(content.localPosition.x, 0);
            content.sizeDelta = new Vector2(content.sizeDelta.x, 0);
        }

        public void JumpToY(float y)
        {
            content.localPosition = new Vector3(content.localPosition.x, y);
        }

        public void JumpToX(float x)
        {
            content.localPosition = new Vector3(x, content.localPosition.y);
        }

    }
}