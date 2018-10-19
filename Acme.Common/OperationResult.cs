using System;
using System.Collections.Generic;
using System.Text;

namespace Acme.Common
{
    public class OperationResult
    {
        // Default constructor
        public OperationResult()
        {

        }

        //Parameterized constructor
        public OperationResult(bool success, string message) : this()
        {
            this.Success = success;
            this.Message = message;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
