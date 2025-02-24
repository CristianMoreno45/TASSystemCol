using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UnalColombia.Common.Dtos;

namespace UnalColombia.Common.Extensions.Dto
{
    public static class ResponseExtensions
    {
        public static Response<T> AsResponseDTO<T>(this T resultDTO, HttpStatusCode code = HttpStatusCode.OK, string message = "OK")
        {
            Response<T> responseDTO = new();
            responseDTO.Data = resultDTO;
            responseDTO.Header = new HeaderResponse
            {
                ResponseCode = code,
                Message = message
            };
            return responseDTO;
        }
    }
}
