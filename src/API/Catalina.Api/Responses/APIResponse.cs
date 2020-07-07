using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalina.Api.Responses
{
    public class APIResponse<T> //Clase de Tipo Generica
    {
        public APIResponse(T data)
        {
            Data = data;

        }
        private T Data { get; set;} // Data es generico
    }
}
