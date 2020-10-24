using System;
using System.Collections.Generic;
using System.Text;

namespace Bodeguin.Application.Communication
{
    public class JsonResult<TData>
    {
        public bool Valid { get; set; }
        public string Message { get; set; }
        public TData Data { get; set; }
        public int ErrorCode { get; set; }
        public JsonResult() { }
        public JsonResult(bool valid = true, TData data = default, string message = null, int errorCode = 0)
        {
            Valid = valid;
            Data = data;
            Message = message;
            ErrorCode = errorCode;
        }
    }
}
