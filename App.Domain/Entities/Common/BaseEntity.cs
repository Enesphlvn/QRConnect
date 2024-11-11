namespace App.Domain.Entities.Common
{
    public class BaseEntity<T>
    {
        public T Id { get; set; } = default!;
        public bool IsStatus { get; set; } = true;
    }
}
