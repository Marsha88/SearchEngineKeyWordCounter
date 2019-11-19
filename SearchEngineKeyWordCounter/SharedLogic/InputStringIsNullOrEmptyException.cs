// Decompiled with JetBrains decompiler
// Type: SearchEngineKeyWordCounter.SharedLogic.InputStringIsNullOrEmptyException
// Assembly: SearchEngineKeyWordCounter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8E9D6ED4-F37D-45A7-8FCF-62098EDA6852
// Assembly location: C:\Users\tobst\source\repos\New folder\SearchEngineKeyWordCounter.dll

using System;

namespace SearchEngineKeyWordCounter.SharedLogic
{
  /// <summary>
  /// Exception for string is null or empty.
  /// </summary>
  public class InputStringIsNullOrEmptyException : Exception
  {
    public InputStringIsNullOrEmptyException()
    {
    }

    public InputStringIsNullOrEmptyException(string message)
      : base(message)
    {
    }

    public InputStringIsNullOrEmptyException(string message, Exception inner)
      : base(message, inner)
    {
    }
  }
}
