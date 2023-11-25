using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace AtherMesRestApi.MESModels
{
    public class FileUploadAPI
    {
        public int ImgID { get; set; }
        public string? Customers { get; set; }
        public IFormFile? files { get; set; }
        public string ImgName { get; set; }
    }
    public class common
    {
        public FileUploadAPI _fileAPI { get; set; }
        public Customer _Customer { get; set; }
        public List<Customer> LstCustomer { get; set; }
    }

    public class FileUploadAPI2
    {
        public IFormFile? files { get; set; }
        public string ImgName { get; set; }
    }
    public class common2
    {
        public FileUploadAPI2 _fileAPI { get; set; }
    }
}
