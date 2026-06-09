using CityApp.Identity;

namespace CityApp.Models;

public class Message
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public string? Context { get; set; }
    public DateTime Created { get; set; } = DateTime.Now;
    public DateTime? Seen { get; set; }
    public string? Attachment { get; set; }
    public int Status { get; set; }
    public string SenderId { get; set; } = null!;
    public string ReceiverId { get; set; } = null!;
    public Guid? SenderFederationId { get; set; }
    public Guid? ReceiverFederationId { get; set; }
    public virtual CityRole Sender { get; set; } = null!;
    public virtual CityRole Receiver { get; set; } = null!;
    public virtual LocalFederation? SenderFederation { get; set; }
    public virtual LocalFederation? ReceiverFederation { get; set; }
}
