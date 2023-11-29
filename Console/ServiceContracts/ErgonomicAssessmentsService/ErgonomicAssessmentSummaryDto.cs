using JetBrains.Annotations;

namespace Console.ServiceContracts.ErgonomicAssessmentsService;

[PublicAPI]
public record ErgonomicAssessmentSummaryDto
{
    public Guid ErgonomicAssessmentId { get; init; }
    public Guid UserAccountId { get; init; }
}
