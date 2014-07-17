using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Simpler.Net.FileSystem {
    /// <summary>
    /// A simple class for holding a file or folder's name as well
    /// as it's containing folder (directory path).
    /// </summary>
    public class PathAndName {
        public virtual String Path { get; set; }
        public virtual String Name { get; set; }

        public PathAndName() {}

        public PathAndName(string path, string name)
        {
            Path = path;
            Name = name;
        }

        public override bool Equals(object obj)
        {
            var other = obj as PathAndName;

            if (ReferenceEquals(other, null))
                return false;

            return ReferenceEquals(this, obj) || Equals(other);
        }
        protected bool Equals(PathAndName other)
        {
            return string.Equals(Path, other.Path) && string.Equals(Name, other.Name);
        }

        public override int GetHashCode()
        {
            return (Path + "/" + Name).GetHashCode();
        }

        public static Boolean operator ==(PathAndName one, PathAndName two)
        {
            return one != null && one.Equals(two);
        }

        public static bool operator !=(PathAndName one, PathAndName two)
        {
            return !(one == two);
        }
    }
}