// Decompiled with JetBrains decompiler
// Type: sims3.LocaleManager
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using midp;
using System;
using System.Globalization;
using XLSLoader;

namespace sims3
{
  public class LocaleManager
  {
    private static readonly sbyte[] FILE_IDENTIFIER = new sbyte[13]
    {
      (sbyte) -85,
      (sbyte) 83,
      (sbyte) 116,
      (sbyte) 114,
      (sbyte) 105,
      (sbyte) 110,
      (sbyte) 103,
      (sbyte) 115,
      (sbyte) -69,
      (sbyte) 13,
      (sbyte) 10,
      (sbyte) 26,
      (sbyte) 10
    };
    private static LocaleManager s_instance;
    private static Vector m_supportedLocales;
    private string m_currentLocale;
    private static int m_currentLocaleIndex;
    private static string[] strings;

    public LocaleManager()
    {
      LocaleManager.m_supportedLocales = (Vector) null;
      this.m_currentLocale = (string) null;
      LocaleManager.m_currentLocaleIndex = -1;
      LocaleManager.strings = (string[]) null;
      string letterIsoLanguageName = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
      LocaleManager.m_supportedLocales = new Vector();
      LocaleManager.m_supportedLocales.addElement((object) "en");
      LocaleManager.m_supportedLocales.addElement((object) "fr");
      LocaleManager.m_supportedLocales.addElement((object) "it");
      LocaleManager.m_supportedLocales.addElement((object) "de");
      LocaleManager.m_supportedLocales.addElement((object) "es");
      this.setLocale(letterIsoLanguageName);
    }

    public static LocaleManager getInstance()
    {
      if (LocaleManager.s_instance == null)
        LocaleManager.s_instance = new LocaleManager();
      return LocaleManager.s_instance;
    }

    public void setStringIdBits(int shift)
    {
    }

    public string getSupportedLang(string langCode)
    {
      throw new NotImplementedException();
    }

    public string[] getSupportedLocales()
    {
      string[] strArray = new string[LocaleManager.m_supportedLocales.size()];
      for (int index = 0; index < strArray.Length; ++index)
        strArray[index] = (string) LocaleManager.m_supportedLocales.elementAt(index);
      return strArray;
    }

    public string getLocale()
    {
      return this.m_currentLocale;
    }

    public void setLocale(string locale)
    {
      int localeIndex = LocaleManager.getLocaleIndex(locale);
      if (localeIndex != -1)
      {
        LocaleManager.m_currentLocaleIndex = localeIndex;
        this.m_currentLocale = locale;
      }
      else
      {
        LocaleManager.m_currentLocaleIndex = 0;
        this.m_currentLocale = "en";
      }
    }

    private static int getLocaleIndex(string locale)
    {
      if (locale == null)
        return LocaleManager.m_currentLocaleIndex;
      int num = LocaleManager.m_supportedLocales.size();
      for (int index = 0; index < num; ++index)
      {
        if (LocaleManager.m_supportedLocales.elementAt(index).Equals((object) locale))
          return index;
      }
      return -1;
    }

    public string[] loadStrings(string filename)
    {
      return this.loadStrings(filename, (string) null);
    }

    public string[] loadStrings(string filename, string locale)
    {
            
      return JavaLib.contentManager.Load<Data>("MasterTextFile").Grid[LocaleManager.m_currentLocaleIndex];
    }

    private void extendPools(int count)
    {
    }

    public int getStringPoolCount()
    {
      throw new NotImplementedException();
    }

    public void setStringPool(int poolIndex, string[] pool)
    {
      this.setStringPool(poolIndex, pool, (string) null);
    }

    public void setStringPool(int poolIndex, string[] pool, string locale)
    {
    }

    public string[] getStringPool(int poolIndex)
    {
      return this.getStringPool(poolIndex, (string) null);
    }

    public string[] getStringPool(int poolIndex, string locale)
    {
      throw new NotImplementedException();
    }

    public string getString(int stringId)
    {
      return LocaleManager.getString(stringId, (string) null);
    }

    public static string getString(int stringId, string locale)
    {
      LocaleManager.getLocaleIndex(locale);
      if (LocaleManager.strings == null)
        LocaleManager.strings = JavaLib.contentManager.Load<Data>("MasterTextFile").Grid[LocaleManager.m_currentLocaleIndex];
      return LocaleManager.strings[stringId];
    }

    public string formatCurrency(double number)
    {
      throw new NotImplementedException();
    }

    public string formatNumber(double number, int decimals)
    {
      throw new NotImplementedException();
    }

    public string formatNumber(long number)
    {
      throw new NotImplementedException();
    }

    public string formatDate(Date date)
    {
      throw new NotImplementedException();
    }

    public InputStream getLocalizedResourceAsStream(string filename)
    {
      return this.getLocalizedResourceAsStream(filename, (string) null);
    }

    public InputStream getLocalizedResourceAsStream(string filename, string locale)
    {
      if (locale == null)
        this.getLocale();
      string filename1 = filename;
      return filename1 == null ? (InputStream) null : JavaLib.getResourceAsStream(filename1, false) ?? (InputStream) null;
    }
  }
}
