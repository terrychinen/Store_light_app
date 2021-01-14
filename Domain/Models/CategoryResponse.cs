using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Models
{
    public class CategoryResponse
    {
        private bool ok;
        private string message;
        private List<CategoryModel> categoryList;

        public bool Ok { get => ok; set => ok = value; }
        public string Message { get => message; set => message = value; }
        public List<CategoryModel> CategoryList { get => categoryList; set => categoryList = value; }
    }
}
