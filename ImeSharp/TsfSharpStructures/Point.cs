using System.Runtime.InteropServices;

namespace TsfSharp;
[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
public struct Point
{
	public int X;

	public int Y;
}
