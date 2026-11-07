using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HelpDeskWebNew.Pages;

public class IndexModel : PageModel
{
    // Database connection
    private readonly HelpDeskContext _context;

    public IndexModel(HelpDeskContext context)
    {
        _context = context;
    }

    // Employee input fields
    [BindProperty]
    public string EmployeeName { get; set; } = "";

    [BindProperty]
    public string Description { get; set; } = "";

    public string Message { get; set; } = "";

    // Lists for all tickets and employee tickets
    public List<Ticket> Tickets { get; set; } = new List<Ticket>();

    public List<Ticket> MyTickets { get; set; } = new List<Ticket>();

    public string SearchEmployeeName { get; set; } = "";

    // Variables for ticket summary
    public int OpenTickets { get; set; }
    public int InProgressTickets { get; set; }
    public int ClosedTickets { get; set; }
    public int TotalTickets { get; set; }

    // Count tickets by status and calculate the total
    public void CalculateTickets()
    {
        OpenTickets = Tickets.Count(t => t.Status == "Open");
        InProgressTickets = Tickets.Count(t => t.Status == "In Progress");
        ClosedTickets = Tickets.Count(t => t.Status == "Closed");

        TotalTickets = OpenTickets + InProgressTickets + ClosedTickets;
    }

    // Load tickets and search by employee name
    public void OnGet(string? searchEmployeeName)
    {
        Tickets = _context.Tickets.ToList();
        CalculateTickets();

        SearchEmployeeName = searchEmployeeName ?? "";

        if (!string.IsNullOrWhiteSpace(SearchEmployeeName))
        {
            MyTickets = Tickets
                .Where(t => t.EmployeeName == SearchEmployeeName)
                .ToList();
        }
    }

    // Update the status of an existing ticket
    public IActionResult OnPostUpdateStatus(int ticketId, string status)
    {
        Ticket? ticket = _context.Tickets.Find(ticketId);

        if (ticket != null &&
            (status == "Open" || status == "In Progress" || status == "Closed"))
        {
            ticket.Status = status;
            _context.SaveChanges();
        }

        return RedirectToPage();
    }

    // Edit the employee name and problem description
    public IActionResult OnPostEditTicket(
        int ticketId, string employeeName, string description)
    {
        Ticket? ticket = _context.Tickets.Find(ticketId);

        if (ticket != null)
        {
            ticket.EmployeeName = employeeName;
            ticket.Description = description;
            _context.SaveChanges();
        }

        return RedirectToPage();
    }

    // Delete a ticket from the database
    public IActionResult OnPostDeleteTicket(int ticketId)
    {
        Ticket? ticket = _context.Tickets.Find(ticketId);

        if (ticket != null)
        {
            _context.Tickets.Remove(ticket);
            _context.SaveChanges();
        }

        return RedirectToPage();
    }

    // Create and save a new support ticket
    public void OnPost()
    {
        Ticket newTicket = new Ticket();

        newTicket.EmployeeName = EmployeeName;
        newTicket.Description = Description;
        newTicket.SubmissionDate = DateTime.Now;
        newTicket.Status = "Open";

        _context.Tickets.Add(newTicket);
        _context.SaveChanges();

        Message = "Ticket submitted successfully!";

        Tickets = _context.Tickets.ToList();
        CalculateTickets();
    }
}
