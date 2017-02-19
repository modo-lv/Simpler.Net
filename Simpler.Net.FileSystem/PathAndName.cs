using System;

namespace Simpler.Net.FileSystem
{
	/// <summary>
	/// A simple class for holding a file or folder's name as well
	/// as it's containing folder (directory path).
	/// </summary>
	public class PathAndName
	{
		/// <summary>
		/// File or folder's path (without filename).
		/// </summary>
		public virtual String Path { get; set; }

		/// <summary>
		/// File or folder's name (including extension, if any).
		/// </summary>
		public virtual String Name { get; set; }


		/// <summary>
		/// Parameterless constructor.
		/// </summary>
		public PathAndName()
		{
		}

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="path"><see cref="Path"/></param>
		/// <param name="name"><see cref="Name"/></param>
		public PathAndName(String path, String name)
		{
			this.Path = path;
			this.Name = name;
		}


		/// <summary>
		/// See <see cref="Equals(Object)"/>.
		/// </summary>
		protected virtual Boolean Equals(PathAndName other)
			=> String.Equals(this.Path.Trim(), other?.Path.Trim()) && String.Equals(this.Name.Trim(), other?.Name.Trim());

		/// <summary>
		/// Check if the full path name represented by the current properties
		/// of one <see cref="PathAndName"/> are the same as that of another.
		/// </summary>
		/// <remarks>
		/// The comparison is case-sensitive and only trims witespace.
		/// "a/b" and "a//b" will NOT be considered equal.
		/// </remarks>
		/// <param name="other"><see cref="PathAndName"/> object to compare the this one to.</param>
		/// <returns><c>true</c> if the paths are the same, <c>false</c> otherwise.</returns>
		public override Boolean Equals(Object other)
		{
			if (Object.ReferenceEquals(null, other)) return false;
			if (Object.ReferenceEquals(this, other)) return true;
			if (other.GetType() != this.GetType()) return false;

			return this.Equals((PathAndName) other);
		}

		/// <inheritdoc />
		public override Int32 GetHashCode()
			=> (this.Path + "/" + this.Name).GetHashCode();

		/// <summary>
		/// Operator version of <see cref="Equals(PathAndName)"/>.
		/// </summary>
		public static Boolean operator ==(PathAndName one, PathAndName two)
		{
			return one.IfNotNull(o => o.Equals(two));
		}

		/// <summary>
		/// Operator version of !<see cref="Equals(PathAndName)"/>.
		/// </summary>
		public static Boolean operator !=(PathAndName one, PathAndName two)
		{
			return !(one == two);
		}
	}
}