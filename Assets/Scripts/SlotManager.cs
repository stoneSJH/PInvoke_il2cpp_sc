using System;
using System.Runtime.InteropServices;

public class SlotManager
{
	internal static IntPtr WriteMethodDef(IntPtr mdef, IntPtr name, IntPtr func, int flags, IntPtr doc)
	{
		Marshal.WriteIntPtr(mdef, name);
		Marshal.WriteIntPtr(mdef, 1 * IntPtr.Size, func);
		Marshal.WriteInt32(mdef, 2 * IntPtr.Size, flags);
		Marshal.WriteIntPtr(mdef, 3 * IntPtr.Size, doc);
		return mdef + 4 * IntPtr.Size;
	}

	public static void InitializeSlots()
	{
		//Alloc space for target method definitions
		IntPtr mdef = Marshal.AllocHGlobal(2 * 4 * IntPtr.Size);
		//write method implementation to slot
		mdef = WriteMethodDef(
			mdef,
			Marshal.StringToHGlobalAnsi("__instancecheck__"),
			Interop.GetThunk(typeof(CSMethodImpl).GetMethod("__instancecheck__"), "BinaryFunc"),
			0x0001,
			IntPtr.Zero
		);
		
		mdef = WriteMethodDef(
			mdef,
			Marshal.StringToHGlobalAnsi("__subclasscheck__"),
			Interop.GetThunk(typeof(CSMethodImpl).GetMethod("__subclasscheck__"), "BinaryFunc"),
			0x0001,
			IntPtr.Zero
		);
	}
}
