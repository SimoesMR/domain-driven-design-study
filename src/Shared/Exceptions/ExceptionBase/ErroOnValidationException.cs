namespace Exceptions.ExceptionBase
{
    public class ErroOnValidationException : ExceptionBase
    {
        public IList<string> ErroMensages { get; set; }

        public ErroOnValidationException(IList<string> erroMensages)
        {
            ErroMensages = erroMensages;
        }
    }
}
