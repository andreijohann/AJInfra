namespace Aj.Infra.Dto
{
    public class QueryResultDto<TDto>: ResultDto
    {

        public QueryResultDto() : base() { }


        public QueryResultDto(ErrorDto error) : base(error) { } 

        public QueryResultDto(IEnumerable<ErrorDto> errors) : base(errors) { }

        public TDto Dto { get; set; }


    }
}
