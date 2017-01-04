using UnityEngine;
using UnityEngine.UI;
using System.Collections;
namespace KappaLab.UI
{
    public class ItemB : BaseItem<ItemB.Model>
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
            data.text = string.Format("ID:{0}, Age:{1}", model.id, model.age);
        }

        public override void SetIndex(int index)
        {
            base.SetIndex(index);
            this.index.text = string.Format("@ {0}", index);
        }

        public class Model
        {
            public int id;
            public int age;

            public Model(int id, int age)
            {
                this.id = id;
                this.age = age;
            }
        }
    }
}