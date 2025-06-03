namespace Ensumex.Utils
{
    public static class ValidationUtils
    {
        public static bool EsNumeroDecimal(string valor, out decimal resultado)
        {
            return decimal.TryParse(valor, out resultado);
        }
    }
}