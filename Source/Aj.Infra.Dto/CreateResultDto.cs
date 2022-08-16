namespace Aj.Infra.Dto
{
    public class CreateResultDto<TId> : ResultDto
    {
        public CreateResultDto() : base() { }

        public CreateResultDto(ErrorDto error) : base(error) { }
        public CreateResultDto(IEnumerable<ErrorDto> errors) : base(errors) { }
        public TId IdGenerated { get; set; }

    }
}
