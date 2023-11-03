namespace WebApplicationCRUDTestControllerBased.Common;

public class GenericHttpResponse<T>
{
    public T? Data { get; set; }
    public string? Message { get; set; }
    public bool Status { get; set; }

}
