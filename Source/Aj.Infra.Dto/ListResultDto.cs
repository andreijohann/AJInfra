namespace Aj.Infra.Dto
{
    public class ListResultDto<TDto>: ResultDto
    {

        public ListResultDto() : base() { }


        public ListResultDto(ErrorDto error) : base(error) { } 

        public ListResultDto(IEnumerable<ErrorDto> errors) : base(errors) { }

        public IEnumerable<TDto> List { get; set; }


    }
}
