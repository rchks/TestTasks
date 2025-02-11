using System.ComponentModel.DataAnnotations;
using Task1.Abstractions;

namespace Task1.Models
{
    public class UserDataModel: Model
    {
        public int Code { get; set; }
        public string Value { get; set; }
    }

    public class UserDataParameter
    {
        public int Code { get; set; }
        public string Value { get; set; }
    }
}
