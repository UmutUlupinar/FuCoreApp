namespace FuCoreApp.Api.DTOs
{
    //error'lar kullanıcıya bizim atayacağımız mesajlar ile yollansın diye dto kullanırız.
    //bu sayede c# - visual studio 'nun yolladığı hatalar Kullanıcıya bizim vereceğimiz şekilde görünür.
    public class ErrorDto
    {
        public ErrorDto()
        {
            Errors= new List<string>();
        }

        //yukarıdaki yapı ve alttaki satır aynı işlev--constructor
        //public ErrorDto() => new List<string>(); 
        public List<string> Errors { get; set; }

        public int Status { get; set; }


    }
}
