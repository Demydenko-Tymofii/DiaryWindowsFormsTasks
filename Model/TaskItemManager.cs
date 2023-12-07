using System.ComponentModel;
using System.Linq;

namespace WindowsFormsTasks.Model
{
    internal class TaskItemManager : BindingList<TaskItem>
    {
        public void Add(string Name) 
        {
            var Id = 1;

            if(Items.Count > 0)
                Id = Items.Max(x => x.Id) + 1;

            base.Add(new TaskItem() { Id = Id, Name = Name });
        }

        public void Edit(int id, string Name) 
        {
            if (Items.Any(x => x.Id == id))
            {
                var item = Items.First(x => x.Id == id);
                item.Name = Name;
            }
        }

        public void Delete(int id) 
        {
            if (Items.Any(x => x.Id == id))
            {
                var item = Items.First(x => x.Id == id);
                base.Remove(item);
            }
        }
    }
}
