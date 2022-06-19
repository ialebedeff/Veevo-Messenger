namespace Veevo.Kernel.Models.Entities
{
    public class MessageModel
    {
        public MessageModel() { }
        public MessageModel(bool sendByMe) => SendByMe = sendByMe;
        public int Id { get; set; }
        public DateTime? CreateDate { get; set; }
        public bool IsEdited { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsRead { get; set; }
        public string? Text { get; set; }
        public bool SendByMe { get; set; }
        public int FromId { get; set; }
        public int ToUserId { get; set; }
    }
}
