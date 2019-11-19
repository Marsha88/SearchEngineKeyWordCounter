// Decompiled with JetBrains decompiler
// Type: SearchEngineKeyWordCounter.SharedLogic.InputStringNotInRightFormatException
// Assembly: SearchEngineKeyWordCounter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8E9D6ED4-F37D-45A7-8FCF-62098EDA6852
// Assembly location: C:\Users\tobst\source\repos\New folder\SearchEngineKeyWordCounter.dll

using System;

namespace SearchEngineKeyWordCounter.SharedLogic
{
  public class InputStringNotInRightFormatException : Exception
  {
    public InputStringNotInRightFormatException()
    {
    }

    public InputStringNotInRightFormatException(string message)
      : base(message)
    {
    }

    public InputStringNotInRightFormatException(string message, Exception inner)
      : base(message, inner)
    {
    }
  }
}
