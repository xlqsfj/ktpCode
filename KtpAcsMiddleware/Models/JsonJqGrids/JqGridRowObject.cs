namespace KtpAcsMiddleware.Models.JsonJqGrids
{
    public class JqGridRowObject
    {
        public JqGridRowObject(string id, string[] cell)
        {
            Id = id;
            Cell = cell;
        }

        public string Id { get; }

        public string[] Cell { get; }
    }
}