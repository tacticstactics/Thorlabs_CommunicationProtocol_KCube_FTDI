using System;
using System.Runtime.InteropServices;

namespace KDC_WinForm_Net
{
	/// <summary> Utilities. </summary>
	public static class Utilities
	{
		/// <summary> Serialize message. </summary>
		/// <typeparam name="T"> Generic type parameter. </typeparam>
		/// <param name="msg"> The message. </param>
		/// <returns> . </returns>
		public static Byte[] SerializeMessage<T>(T msg) where T : struct
		{
			int objsize = Marshal.SizeOf(typeof(T));
			Byte[] ret = new Byte[objsize];
			IntPtr buff = Marshal.AllocHGlobal(objsize);
			Marshal.StructureToPtr(msg, buff, true);
			Marshal.Copy(buff, ret, 0, objsize);
			Marshal.FreeHGlobal(buff);
			return ret;
		}

		/// <summary> Deserialize message. </summary>
		/// <typeparam name="T"> Generic type parameter. </typeparam>
		/// <param name="data"> The data. </param>
		/// <returns> . </returns>
		public static T DeserializeMsg<T>(Byte[] data) where T : struct
		{
			int objsize = Marshal.SizeOf(typeof(T));
			IntPtr buff = Marshal.AllocHGlobal(objsize);
			Marshal.Copy(data, 0, buff, objsize);
			T retStruct = (T)Marshal.PtrToStructure(buff, typeof(T));
			Marshal.FreeHGlobal(buff);
			return retStruct;
		}
	}
}
