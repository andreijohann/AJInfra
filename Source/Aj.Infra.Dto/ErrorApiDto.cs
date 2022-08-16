namespace Aj.Infra.Dto
{
    /// <summary>
    /// Class for transporting error information in REST APIs
    /// </summary>
    public class ErrorApiDto
    {
        public string Id { get; set; }
        public string Message { get; set; }
        public string Field { get; set; }
        public string Detail { get; set; }


    }
}
