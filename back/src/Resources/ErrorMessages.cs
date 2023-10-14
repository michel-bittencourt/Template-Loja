namespace Loja.API.Resources;

public static class ErrorMessages
{
    public static string DefaultError(Exception ex)
    {
        string defaultErrorMessage = $"Something went wrong, please contact the developers. \nError:{ex.Message}";
        return defaultErrorMessage;
    }
}
