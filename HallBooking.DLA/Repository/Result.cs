using HallBooking.DLA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HallBooking.DLA.Repository
{
    //Класс для отримання результату. Мiнi версiя, щоб розумiти результат
    public class Result
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public static Result SuccessResult(string message = "Success")
        {
            return new Result { Message = message, Success = true };
        }

        public static Result UnsuccessResult(string message = "Unsuccses")
        {
            return new Result { Message = message, Success = false };
        }
    }
}
