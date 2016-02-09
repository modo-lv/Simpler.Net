using System;

namespace Simpler.Net.Abstractions.WindowsRegistry
{
	public class MockWindowsRegistry : WindowsRegistry
	{
		/// <summary>
		/// If set (not null), all calls to <see cref="WindowsRegistry.GetValue"/> will return this value,
		/// regardless of parameters.
		/// </summary>
		public virtual Object AlwaysReturn { get; set; }


		/// <summary>
		/// Constructor.
		/// </summary>
		public MockWindowsRegistry()
		{
		}

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="alwaysReturn">Value to return for all <see cref="WindowsRegistry.GetValue"/> calls.</param>
		public MockWindowsRegistry(Object alwaysReturn)
		{
			this.AlwaysReturn = alwaysReturn;
		}


		public override Object GetValue(String keyName, String valueName, Object defaultValue)
		{
			return this.AlwaysReturn ?? base.GetValue(keyName, valueName, defaultValue);
		}
	}
}
