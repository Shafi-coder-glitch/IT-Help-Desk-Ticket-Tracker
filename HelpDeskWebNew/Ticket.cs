
namespace HelpDeskWebNew;

public class Ticket
{
    public int TicketID { get; set; }

    public string EmployeeName { get; set; } = "";

    public string Description { get; set; } = "";

    public DateTime SubmissionDate { get; set; }

    public string Status { get; set; } = "";
}
