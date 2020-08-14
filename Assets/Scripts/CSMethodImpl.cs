using System;

public class CSMethodImpl
{
	[AOT.MonoPInvokeCallbackAttribute(typeof(Interop.BinaryFunc))]
	public static IntPtr __instancecheck__(IntPtr tp, IntPtr args)
	{
		return DoInstanceCheck(tp, args, false);
	}
        
	[AOT.MonoPInvokeCallbackAttribute(typeof(Interop.BinaryFunc))]
	public static IntPtr __subclasscheck__(IntPtr tp, IntPtr args)
	{
		return DoInstanceCheck(tp, args, true);
	}
        
	private static IntPtr DoInstanceCheck(IntPtr tp, IntPtr args, bool checkType)
	{
		//impl
		return IntPtr.Zero;
	}	
}
