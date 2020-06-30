// Decompiled with JetBrains decompiler
// Type: StringFunctions
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

internal static class StringFunctions
{
  private static string activestring;
  private static int activeposition;

  internal static string ChangeCharacter(string sourcestring, int charindex, char changechar)
  {
    return (charindex > 0 ? sourcestring.Substring(0, charindex) : "") + changechar.ToString() + (charindex < sourcestring.Length - 1 ? sourcestring.Substring(charindex + 1) : "");
  }

  internal static bool IsXDigit(char character)
  {
    return char.IsDigit(character) || "ABCDEFabcdef".IndexOf(character) > -1;
  }

  internal static string StrChr(string stringtosearch, char chartofind)
  {
    int startIndex = stringtosearch.IndexOf(chartofind);
    return startIndex > -1 ? stringtosearch.Substring(startIndex) : (string) null;
  }

  internal static string StrRChr(string stringtosearch, char chartofind)
  {
    int startIndex = stringtosearch.LastIndexOf(chartofind);
    return startIndex > -1 ? stringtosearch.Substring(startIndex) : (string) null;
  }

  internal static string StrStr(string stringtosearch, string stringtofind)
  {
    int startIndex = stringtosearch.IndexOf(stringtofind);
    return startIndex > -1 ? stringtosearch.Substring(startIndex) : (string) null;
  }

  internal static string StrTok(string stringtotokenize, string delimiters)
  {
    if (stringtotokenize != null)
    {
      StringFunctions.activestring = stringtotokenize;
      StringFunctions.activeposition = -1;
    }
    if (StringFunctions.activestring == null)
      return (string) null;
    if (StringFunctions.activeposition == StringFunctions.activestring.Length)
      return (string) null;
    ++StringFunctions.activeposition;
    while (StringFunctions.activeposition < StringFunctions.activestring.Length && delimiters.IndexOf(StringFunctions.activestring[StringFunctions.activeposition]) > -1)
      ++StringFunctions.activeposition;
    if (StringFunctions.activeposition == StringFunctions.activestring.Length)
      return (string) null;
    int activeposition = StringFunctions.activeposition;
    do
    {
      ++StringFunctions.activeposition;
    }
    while (StringFunctions.activeposition < StringFunctions.activestring.Length && delimiters.IndexOf(StringFunctions.activestring[StringFunctions.activeposition]) == -1);
    return StringFunctions.activestring.Substring(activeposition, StringFunctions.activeposition - activeposition);
  }
}
