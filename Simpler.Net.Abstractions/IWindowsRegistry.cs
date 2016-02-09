using System;
using Microsoft.Win32;

namespace Simpler.Net.Abstractions
{
	/// <summary>
	/// Abstraction interface for <see cref="Registry"/>.
	/// </summary>
	public interface IWindowsRegistry
	{
		/// <summary>
		/// See <see cref="Registry.ClassesRoot"/>.
		/// </summary>
		RegistryKey ClassesRoot { get; }
		/// <summary>
		/// See <see cref="Registry.CurrentConfig"/>.
		/// </summary>
		RegistryKey CurrentConfig { get; }
		/// <summary>
		/// See <see cref="Registry.CurrentUser"/>.
		/// </summary>
		RegistryKey CurrentUser { get; }
		/// <summary>
		/// See <see cref="Registry.DynData"/>.
		/// </summary>
		RegistryKey DynData { get; }
		/// <summary>
		/// See <see cref="Registry.PerformanceData"/>.
		/// </summary>
		RegistryKey PerformanceData { get; }
		/// <summary>
		/// See <see cref="Registry.Users"/>.
		/// </summary>
		RegistryKey Users { get; }

		/// <summary>
		/// See <see cref="Registry.GetValue"/>.
		/// </summary>
		Object GetValue(String keyName, String valueName, Object defaultValue);

		/// <summary>
		/// See <see cref="Registry.SetValue(string,string,object)"/>.
		/// </summary>
		void SetValue(String keyName, String valueName, Object value);

		/// <summary>
		/// See <see cref="Registry.SetValue(string,string,object,RegistryValueKind)"/>.
		/// </summary>
		void SetValue(String keyName, String valueName, Object value, RegistryValueKind valueKind);
	}
}