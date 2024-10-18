using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application
{
    public class BaseResponse<T> 
    {
        public int TotalCount   { get; set; }
        public T Data { get; set; }
        public bool hasError => errorList.Any(); //list also is a generic class 
        public  List<string> errorList { get; set; }

        //başarılı response için constructor
        public BaseResponse()
        {
            errorList = new List<string>();

        }
    

        //public List<T> Response(List<T> Data)
        //{
        //    var context = new AppDbContext();
        //    var responseContext = context.Set<T>().ToList(); 
        //    if (responseContext == null )
        //    {
        //        string message = "Error catched";

        //    }
        //    else()
        //    {

        //    }

        //}

    }
}
