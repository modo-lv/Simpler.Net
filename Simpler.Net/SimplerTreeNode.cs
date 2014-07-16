using System;
using System.Collections.Generic;

namespace Simpler.Net
{
    /// <summary>
    /// Represents a node in the a tree tree.
    /// </summary>
    public class SimplerTreeNode
    {
        /// <summary>
        /// A name for the node.
        /// </summary>
        public virtual String Name { get; set; }

        /// <summary>
        /// Parent node. Null for root nodes.
        /// </summary>
        public virtual SimplerTreeNode Parent { get; set; }

        /// <summary>
        /// Child nodes of this node.
        /// </summary>
        public virtual IList<SimplerTreeNode> Children { get; set; }

        
        public SimplerTreeNode()
        {
            Children = new List<SimplerTreeNode>();
        }

        public SimplerTreeNode(String name)
            : this()
        {
            Name = name;
        }


        /// <summary>
        /// Add a new child node to this node and return it.
        /// </summary>
        /// <param name="name">Name of the new node.</param>
        /// <returns></returns>
        public SimplerTreeNode AddNewChild(String name)
        {
            var node = new SimplerTreeNode(name);
            Children.Add(node);
            return node;
        }


        public override String ToString()
        {
            return Name;
        }
    }
}