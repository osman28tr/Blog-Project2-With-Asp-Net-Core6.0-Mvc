﻿using ProgrammersBlog.Shared.Utilities.Results.Abstract;
using ProgrammersBlog.Shared.Utilities.Results.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Shared.Utilities.Results.Concrete
{
    public class DataResult<T> : IDataResult<T>
    {
        public DataResult(ResultStatus resultStatus,T data)
        {
            ResultStatus = resultStatus;
            Data = data;
        }
        public DataResult(ResultStatus resultStatus, string message, T data)
        {
            Message = message;
            ResultStatus = resultStatus;
            Data = data;
        }
        public DataResult(ResultStatus resultStatus, string message, T data,Exception exception)
        {
            Exception = exception;
            Message = message;
            ResultStatus = resultStatus;
            Data = data;
        }
        public T Data { get; }

        public ResultStatus ResultStatus{get; }

        public string Message { get; }

        public Exception Exception { get; }
    }
}
