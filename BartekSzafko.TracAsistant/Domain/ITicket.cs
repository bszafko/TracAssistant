using System;
namespace BartekSzafko.TracAssistant.Domain
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITicket
    {
        string CC { get; set; }
        string Component { get; set; }
        DateTime Created { get; set; }
        string Description { get; set; }
        string Keywords { get; set; }
        string Milestone { get; set; }
        string Owner { get; set; }
        string Priority { get; set; }
        string Reporter { get; set; }
        string Resolution { get; set; }
        string Selection { get; set; }
        string Severity { get; set; }
        string Status { get; set; }
        string Summary { get; set; }
        string TicketType { get; set; }
        string Version { get; set; }
    }
}
