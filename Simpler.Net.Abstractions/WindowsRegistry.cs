using System;
using Microsoft.Win32;

namespace Simpler.Net.Abstractions
{
	/// <summary>
	/// Concrete implementation for <see cref="IWindowsRegistry"/>, forwarding calls to
	/// to static <see cref="Registry"/> fields and methods.
	/// </summary>
	public class WindowsRegistry : IWindowsRegistry
	{
		/// <summary>
		/// See <see cref="Registry.ClassesRoot"/>.
		/// </summary>
		public virtual RegistryKey ClassesRoot => Registry.ClassesRoot;

		/// <summary>
		/// See <see cref="Registry.CurrentConfig"/>.
		/// </summary>
		public virtual RegistryKey CurrentConfig => Registry.CurrentConfig;

		/// <summary>
		/// See <see cref="Registry.CurrentUser"/>.
		/// </summary>
		public virtual RegistryKey CurrentUser => Registry.CurrentUser;

		/// <summary>
		/// See <see cref="Registry.DynData"/>.
		/// </summary>
		[ObsoleteAttribute("The DynData registry key only works on Win9x, which is no longer supported by the CLR.  On NT-based operating systems, use the PerformanceData registry key instead.")]
		public virtual RegistryKey DynData => Registry.DynData;

		/// <summary>
		/// See <see cref="Registry.LocalMachine"/>.
		/// </summary>
		public virtual RegistryKey LocalMachine => Registry.LocalMachine;

		/// <summary>
		/// See <see cref="Registry.PerformanceData"/>.
		/// </summary>
		public virtual RegistryKey PerformanceData => Registry.PerformanceData;

		/// <summary>
		/// See <see cref="Registry.Users"/>.
		/// </summary>
		public virtual RegistryKey Users => Registry.Users;


		/// <summary>
		/// See <see cref="Registry.GetValue"/>.
		/// </summary>
		public virtual Object GetValue(String keyName, String valueName, Object defaultValue)
		{
			return Registry.GetValue(keyName, valueName, defaultValue);
		}


		/// <summary>
		/// See <see cref="Registry.SetValue(string,string,object)"/>.
		/// </summary>
		public virtual void SetValue(String keyName, String valueName, Object value)
		{
			Registry.SetValue(keyName, valueName, value);
		}


		/// <summary>
		/// See <see cref="Registry.SetValue(string,string,object,RegistryValueKind)"/>.
		/// </summary>
		public virtual void SetValue(String keyName, String valueName, Object value, RegistryValueKind valueKind)
		{
			Registry.SetValue(keyName, valueName, value, valueKind);
		}
	}
}