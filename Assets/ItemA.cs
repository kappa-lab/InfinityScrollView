using UnityEngine;
using UnityEngine.UI;
using System.Collections;
namespace KappaLab.UI
{
    public class ItemA : BaseItem<ItemA.Model>
    {
        public Text index;
        public Text data;
        public Text pos;

        private void Update()
        {
            pos.text = transform.localPosition.y.ToString();
        }

        public override void SetData(Model m)
        {
            Model model = m as Model;
            data.text = string.Format("ID:{0}, {1}", model.id, model.body);
        }

        public override void SetIndex(int index)
        {
            base.SetIndex(index);
            this.index.text = string.Format("# {0}", index);
        }

        public class Model
        {
            public int id;
            public string body;

            public Model(int id, string body)
            {
                this.id = id;
                this.body = body;
            }
        }
    }
}