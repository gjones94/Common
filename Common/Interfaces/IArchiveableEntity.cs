namespace Common.Interfaces
{
    public interface IArchiveableEntity
    {
        public bool IsArchived { get; set; }

        public DateTime? ArchivedDate { get; set; }

        public string? ArchivedBy { get; set; }
    }
}