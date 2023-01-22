﻿using System.Reflection.Metadata.Ecma335;

namespace Mongo.Services.ProductAPI.Models.Dto
{
    public class ResponseDto
    {
        public bool IsSuccess { get; set; }

        public object Result { get; set; }

        public string DisplayMessage { get; set; } = string.Empty;

        public List<string> ErrorMessage { get; set; }
    }
}