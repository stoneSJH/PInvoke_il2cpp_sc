using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;

using UnityEngine;

public class Interop
{
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate IntPtr UnaryFunc(IntPtr ob);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate IntPtr BinaryFunc(IntPtr ob, IntPtr arg);
	
	public static IntPtr GetThunk(MethodInfo method, string funcType)
	{
		Type dt;
		if (funcType != null)
		{
			dt = typeof(Interop).GetNestedType(funcType) as Type;
			UnityEngine.Debug.Log("[" + method.Module.Name + "]" +method.DeclaringType.FullName + "." + method.Name + ":" 
			                      +  "(Delegate Type)" +  dt.FullName);
		}
		else
		{
			return IntPtr.Zero;			
		}

		if (dt != null)
		{
			Delegate d = Delegate.CreateDelegate(dt, method);
      IntPtr fp = Marshal.GetFunctionPointerForDelegate(d);
			UnityEngine.Debug.Log("[" + method.Module.Name + "]" +method.DeclaringType.FullName + "." + method.Name + ":" 
			                      + "(Generated Delegate Function Pointer)" + fp.ToInt64());
			return fp;
		}
		return IntPtr.Zero;
	}
}
