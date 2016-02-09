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
		public RegistryKey ClassesRoot => Registry.ClassesRoot;

		public RegistryKey CurrentConfig => Registry.CurrentConfig;

		public RegistryKey CurrentUser => Registry.CurrentUser;

		[ObsoleteAttribute("The DynData registry key only works on Win9x, which is no longer supported by the CLR.  On NT-based operating systems, use the PerformanceData registry key instead.")]
		public RegistryKey DynData => Registry.DynData;

		public RegistryKey PerformanceData => Registry.PerformanceData;

		public RegistryKey Users => Registry.Users;


		public Object GetValue(String keyName, String valueName, Object defaultValue)
		{
			return Registry.GetValue(keyName, valueName, defaultValue);
		}


		public void SetValue(String keyName, String valueName, Object value)
		{
			Registry.SetValue(keyName, valueName, value);
		}


		public void SetValue(String keyName, String valueName, Object value, RegistryValueKind valueKind)
		{
			Registry.SetValue(keyName, valueName, value, valueKind);
		}
	}
}