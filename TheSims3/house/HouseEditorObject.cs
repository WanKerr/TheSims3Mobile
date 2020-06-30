// Decompiled with JetBrains decompiler
// Type: house.HouseEditorObject
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using midp;

namespace house
{
  public class HouseEditorObject : GlobalConstants
  {
    public new void Dispose()
    {
      base.Dispose();
    }

    public static string readXMLAttribStr(string str, string attrib)
    {
      StringBuffer stringBuffer = new StringBuffer();
      stringBuffer.append(attrib);
      stringBuffer.append("=\"");
      string str1 = stringBuffer.toString();
      int startIndex = str.IndexOf(str1) + str1.Length;
      int length = str.IndexOf('"', startIndex);
      return str.Substring(startIndex, length);
    }

    public static int readXMLAttribInt(string str, string attrib)
    {
      return Integer.parseInt(HouseEditorObject.readXMLAttribStr(str, attrib));
    }

    public static int idLookup(string[] lookupArray, int lookupCount, string idStr)
    {
      for (int index = 0; index < lookupCount; ++index)
      {
        if (idStr.Equals(lookupArray[index]))
          return index;
      }
      return -1;
    }
  }
}
