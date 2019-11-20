using System;
using System.Collections.Generic;
using System.Text;

namespace SearchEngineKeyWordUnitTests.Test_Exceptions
{

        /// <summary>
        /// Exception for string is null or empty.
        /// </summary>
        public class TestException : Exception
        {
            public TestException()
            {
            }

            public TestException(string message)
              : base(message)
            {
            }

            public TestException(string message, Exception inner)
              : base(message, inner)
            {
            }
        }
    
}
