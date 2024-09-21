using Microsoft.AspNetCore.Http;

namespace Data.ViewModels.DataUserVM
{
    public class Image
    {
        public IFormFile FormFile { get; set; } 
        public bool ImageP { get; set; } =false;
        public bool CoverP { get; set; }=false; 
    }
}
