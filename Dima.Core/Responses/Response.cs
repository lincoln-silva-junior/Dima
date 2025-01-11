﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Dima.Core.Responses
{
    public class Response<TData>
    {
        private const int DefaultCode = 200;

        private readonly int _code;

        [JsonConstructor]
        public Response()
            => _code = DefaultCode;        

        public Response(TData? data, 
                        int code = 200,
                        string? message = null)        
        {
           Data = data;
           Message = message;
           _code = code;            
        }

        public TData? Data { get; set; }

        public string? Message { get; set; }

        [JsonIgnore]
        public bool IsSuccess => _code is >= 200 && _code <= 299;
    }
}
