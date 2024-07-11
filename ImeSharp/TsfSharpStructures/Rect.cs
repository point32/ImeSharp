using System.Runtime.InteropServices;

namespace TsfSharp
{
  [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
  public struct Rect
  {
    public int Left;
    public int Top;
    public int Right;
    public int Bottom;
  }
}
