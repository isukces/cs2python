using System.Collections.Generic;
using System.Linq;
using Cs2Py.Source;

namespace Cs2Py.Compilation
{
    public class PyModuleNamespaceManager
    {
        private static Item GetItemForNamespace(List<Item> list, PyNamespace name)
        {
            var item = list.Any() ? list.Last() : null;
            if (item == null || item.Name != name)
            {
                item = new Item(name);
                list.Add(item);
            }

            return item;
        }

        // Public Methods 

        public void Add(IEnumerable<IPyStatement> statements)
        {
            foreach (var statement in statements)
                Add(statement);
        }

        public void Add(IEmitable statement)
        {
            if (statement is IPyStatement && !PyCodeBlock.HasAny(statement as IPyStatement))
                return;
            if (statement is PyNamespaceStatement)
            {
                var tmp  = statement as PyNamespaceStatement;
                var item = GetItemForNamespace(Container, tmp.Name);
                item.Items.AddRange(tmp.Code.Statements);
            }
            else if (statement is PyClassDefinition)
            {
                var tmp = statement as PyClassDefinition;
                if (tmp.IsEmpty)
                    return;
                var item = GetItemForNamespace(Container, tmp.Name.Namespace);
                item.Items.Add(statement);
            }
            else
            {
                var item = GetItemForNamespace(Container, PyNamespace.Root);
                item.Items.Add(statement);
            }
        }

        /// <summary>
        ///     Własność jest tylko do odczytu.
        /// </summary>
        public bool OnlyOneRootStatement => Container.Count == 1 && Container[0].Name.IsRoot;

        /// <summary>
        /// </summary>
        public List<Item> Container { get; set; } = new List<Item>();


        public class Item
        {
            public Item(PyNamespace Name)
            {
                this.Name = Name;
                Items     = new List<IEmitable>();
                ;
            }

            public List<IEmitable> Items { get; private set; }

            public PyNamespace Name { get; private set; }
        }
    }
}