namespace GestionBiblioteca.DTO
{
    public class Response
    {
        public bool Success => !Errors.Any();
        public string Message { get; set; } 
        public List<string> Errors { get; set; } = new List<string>();
    }

    public class Response<T> : Response where T : class 
    {
        public IEnumerable<T> DataList { get; set; }
        public T SingleData { get; set; }   
    }
}
