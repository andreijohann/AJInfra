namespace Aj.Infra.Dto
{
    public class ResultDto
    {

        public ResultDto()
        {
            Errors = new List<ErrorDto>();
        }

        public ResultDto(ErrorDto error)
        {
            Errors = new List<ErrorDto>(new[] { error });
        }

        public ResultDto(IEnumerable<ErrorDto> errors)
        {
            Errors = errors;
        }

        public IEnumerable<ErrorDto> Errors { get; set; }
        public bool Valid { get { return Errors != null && !Errors.Any(); } }



    }
}
