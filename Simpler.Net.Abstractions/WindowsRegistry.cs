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
		public virtual RegistryKey ClassesRoot => Registry.ClassesRoot;

		public virtual RegistryKey CurrentConfig => Registry.CurrentConfig;

		public virtual RegistryKey CurrentUser => Registry.CurrentUser;

		[ObsoleteAttribute("The DynData registry key only works on Win9x, which is no longer supported by the CLR.  On NT-based operating systems, use the PerformanceData registry key instead.")]
		public virtual RegistryKey DynData => Registry.DynData;

		public virtual RegistryKey LocalMachine => Registry.LocalMachine;

		public virtual RegistryKey PerformanceData => Registry.PerformanceData;

		public virtual RegistryKey Users => Registry.Users;


		public virtual Object GetValue(String keyName, String valueName, Object defaultValue)
		{
			return Registry.GetValue(keyName, valueName, defaultValue);
		}


		public virtual void SetValue(String keyName, String valueName, Object value)
		{
			Registry.SetValue(keyName, valueName, value);
		}


		public virtual void SetValue(String keyName, String valueName, Object value, RegistryValueKind valueKind)
		{
			Registry.SetValue(keyName, valueName, value, valueKind);
		}
	}
}