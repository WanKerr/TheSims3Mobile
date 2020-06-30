// Decompiled with JetBrains decompiler
// Type: sims3.AppResources
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace sims3
{
  [DebuggerNonUserCode]
  [CompilerGenerated]
  [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
  internal class AppResources
  {
    private static System.Resources.ResourceManager resourceMan;
    private static CultureInfo resourceCulture;

    internal AppResources()
    {
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static System.Resources.ResourceManager ResourceManager
    {
      get
      {
        if (object.ReferenceEquals((object) AppResources.resourceMan, (object) null))
          AppResources.resourceMan = new System.Resources.ResourceManager("sims3.AppResources", typeof (AppResources).Assembly);
        return AppResources.resourceMan;
      }
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static CultureInfo Culture
    {
      get
      {
        return AppResources.resourceCulture;
      }
      set
      {
        AppResources.resourceCulture = value;
      }
    }
  }
}
