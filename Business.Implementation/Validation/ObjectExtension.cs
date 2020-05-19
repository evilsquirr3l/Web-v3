namespace Business.Implementation.Validation
{
    public static class ObjectExtension
    {
        public static void AssertIsNotNull(this object value)
        {
            if (value is null)
            {
                throw new BusinessException("Item is not found.");
            }
        }
    }
}