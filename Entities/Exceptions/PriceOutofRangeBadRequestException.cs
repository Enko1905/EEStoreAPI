namespace Entities.Exceptions
{
    public class PriceOutofRangeBadRequestException : BadRequestException
    {
        public PriceOutofRangeBadRequestException()
            :base("Maximum Price should be less than 1000 and  greater 10")
        {

        }
    }
}
